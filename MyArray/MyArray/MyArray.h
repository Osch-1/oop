#include <stdlib.h>
#include <stdio.h>
#include <iterator>
#include <memory>
#include <new>
#include <algorithm>
#include <stdexcept>

using namespace std;

template<typename T>
class MyArray
{
public:
    template<bool IsConst>
    class Iterator
    {
        friend class Iterator<true>;
        friend MyArray;
    public:
        using iterator_category = bidirectional_iterator_tag;
        using difference_type = ptrdiff_t;
        using value_type = conditional_t<IsConst, const T, T>;
        using pointer = value_type*;
        using reference = value_type&;

        Iterator() = default;
        Iterator(T* item)
            :item(item)
        {
        }
        Iterator(Iterator<false> const& src)
            :item(src.item)
        {
        }

        pointer operator->()
        {
            return &item;
        }

        reference& operator*() const
        {
            return *item;
        }

        Iterator& operator+=(difference_type offset)
        {
            item += offset;
            return *this;
        }

        Iterator& operator++()
        {
            item++;
            return *this;
        }

        Iterator& operator--()
        {
            item--;
            return *this;
        }


        Iterator operator+(difference_type offset) const
        {
            Iterator curr(item);
            return curr += offset;
        }

        friend bool operator == (Iterator const& it1, Iterator const& it2)
        {
            return it1.item == it2.item;
        };

        friend bool operator != (Iterator const& it1, Iterator const& it2)
        {
            return it1.item != it2.item;
        };
    private:
        T* item = nullptr;
    };

    MyArray() = default;

    MyArray(MyArray const& src)
    {
        auto size = src.GetSize();
        first = Allocate(size);
        try
        {
            CopyItems(src.first, src.last, first, last);
            endOfMem = last;//т.к. мы копируем от first по last, а не по endOfMem src            
        }
        catch (exception)
        {
            DeleteItems(first, last);
            throw;
        }
    }

    MyArray(MyArray&& src)
        :MyArray()
    {
        auto srcSize = src.GetSize();
        last = UninitializedMoveNIfNoexcept(src.first, srcSize, first);
        endOfMem = last;
    }

    ~MyArray()
    {
        DeleteItems(first, last);
    }

    size_t GetSize() const
    {
        return last - first;
    }

    size_t GetCapacity() const
    {
        return endOfMem - first;
    }

    void Append(T const& value)
    {
        if (last == endOfMem)
        {
            size_t newSize = max(size_t(1), GetCapacity() * 2);
            T* newBegin = Allocate(newSize);
            T* newEnd = newBegin;

            try
            {
                CopyItems(first, last, newBegin, newEnd);

                new(newEnd) T(value);
                ++newEnd;
            }
            catch (exception)
            {
                DeleteItems(newBegin, newBegin);
                throw;
            }
            DeleteItems(first, last);

            first = newBegin;
            last = newEnd;
            endOfMem = newBegin + newSize;
        }
        else
        {
            //high exception safety
            new(last) T(value);
            ++last;
        }
    }

    void Resize(size_t newSize)
    {
        if (newSize < 0)
        {
            throw invalid_argument("");
        }
        auto size = GetSize();
        if (newSize == size)
            return;

        if (newSize < size)
        {
            T* rightBorder = &*(begin() + newSize);
            size_t itemsToDelete = GetSize() - newSize;
            while (GetSize() != newSize)
            {
                --last;
                last->~T();
            }
            endOfMem = last;
        }
        else
        {
            int diff = newSize - GetSize();
            T* newBegin = Allocate(newSize);
            T* newEnd = newBegin;

            try
            {
                CopyItems(first, last, newBegin, newEnd);
            }
            catch (exception)
            {
                DeleteItems(newBegin, newBegin);
                throw;
            }
            DeleteItems(first, last);

            auto cpyEnd = newEnd;
            for (int i = 0; i < diff; ++i)
            {
                new(cpyEnd) T();
                ++cpyEnd;
            }

            first = newBegin;
            last = newEnd;
            endOfMem = newBegin + newSize;
        }
    }

    void Clear()
    {
        DestroyItems(first, last);
        first->~T();
        first = last = endOfMem = nullptr;
    }

    Iterator<false> begin() const noexcept
    {
        return Iterator<false>(first);
    }

    Iterator<false> end() const noexcept
    {
        return Iterator<false>(last);
    }

    Iterator<true> cbegin() const noexcept
    {
        return Iterator<true>(first);
    }

    Iterator<true> cend() const noexcept
    {
        return Iterator<true>(last);
    }

    reverse_iterator<MyArray::Iterator<false>> rbegin() const noexcept
    {
        return make_reverse_iterator(end());
    }

    reverse_iterator<MyArray::Iterator<false>> rend() const noexcept
    {
        return make_reverse_iterator(begin());
    }

    reverse_iterator<MyArray::Iterator<true>> crbegin() const noexcept
    {
        return make_reverse_iterator(cend());
    }

    reverse_iterator<MyArray::Iterator<true>> crend() const noexcept
    {
        return make_reverse_iterator(cbegin());
    }

    MyArray& operator=(MyArray const& other) noexcept
    {
        if (this == &other)
            return *this;

        MyArray* temp = new MyArray(other);
        swap(first, other->first);
        swap(last, temp->last);
        swap(endOfMem, temp->endOfMem);
        delete temp;

        return *this;
    }

    MyArray& operator=(MyArray&& other) noexcept
    {
        auto srcSize = other.GetSize();
        last = UninitializedMoveNIfNoexcept(other.first, srcSize, first);
        endOfMem = last;

        return *this;
    }

    T& operator[](size_t index)
    {
        auto capacity = GetCapacity();
        if (index > capacity + 1)
            throw out_of_range("");

        return *(begin() + index);
    }

    const T& operator[](size_t index) const
    {
        auto capacity = GetCapacity();
        if (index > capacity + 1)
            throw out_of_range("");

        return *(cbegin() + index);
    }
private:
    T* first = nullptr;
    T* last = nullptr;
    T* endOfMem = nullptr;//right boundary of allocated memory

    static T* Allocate(size_t elemsCount)
    {
        size_t requiredSize = sizeof(T) * elemsCount;
        T* start = static_cast<T*>(malloc(requiredSize));//exception?

        if (!start)
        {
            throw bad_alloc();
        }

        return start;
    }

    static void CopyItems(const T* srcBegin, T* srcEnd, T* const dstBegin, T*& dstEnd)
    {
        for (dstEnd = dstBegin; srcBegin != srcEnd; ++srcBegin, ++dstEnd)
        {
            new (dstEnd) T(*srcBegin);
        }
    }

    static T* UninitializedMoveNIfNoexcept(T* from, size_t n, T* to) {
        if constexpr (is_nothrow_move_constructible_v<T> || !is_copy_constructible_v<T>) {
            return uninitialized_move_n(from, n, to).second;
        }
        else {
            return uninitialized_copy_n(from, n, to);
        }
    }

    static void DeleteItems(T* begin, T* end)
    {
        DestroyItems(begin, end);
        free(begin);
    }

    static void DestroyItems(T* begin, T* end)
    {
        while (begin != end)//взял с лекции
        {
            --end;
            end->~T();
        }
    }

    static void DeleteNItems(T* end, size_t n)
    {
        size_t count = 0;
        while (count != n)//взял с лекции
        {
            --end;
            end->~T();
            ++count;
        }

        free(end);
    }
};