#include <stdlib.h>
#include <stdio.h>
#include <iterator>
#include <memory>
#include <new>
#include <algorithm>

using namespace std;

template<typename T>
class MyArray
{
public:
    template<bool IsConst>
    class Iterator
    {
        friend class Iterator<true>;
    public:
        using iterator_category = bidirectional_iterator_tag;
        using difference_type = ptrdiff_t;
        using value_type = conditional_t<IsConst, T, T>;
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
            return &T;
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

        Iterator operator+(difference_type offset) const
        {
            Iterator cpy(item);
            return cpy += offset;
        }

        friend Iterator operator+(difference_type offset, const Iterator& it)
        {
            return it + offset;
        }
    private:
        T* item = nullptr;
    };

    MyArray() = default;

    MyArray(MyArray const& src)
    {
        auto size = src.GetSize();
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
            T* newBegin = MAllocate(newSize);
            T* newEnd = newBegin;

            try
            {
                CopyItems(first, last, newBegin, newEnd);

                new(newEnd) T(value);
                ++newEnd;
            }
            catch (exception)
            {
                Clear(newBegin, newBegin);//newBegin == newEnd
                throw;
            }
            Clear(first, last);

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
private:
    T* first = nullptr;
    T* last = nullptr;
    T* endOfMem = nullptr;//right boundary of allocated memory

    static T* MAllocate(size_t elemsCount)
    {
        size_t requiredSize = sizeof(T) * elemsCount;
        T* start = static_cast<T*>(malloc(requiredSize));//exception?

        if (!start)
        {
            //throw ? 
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

    static void Clear(T* begin, T* end)
    {
        while (end != begin)//взял с лекции
        {
            --end;
            end->~T();
        }

        free(begin);
    }
};