#include <stdlib.h>
#include <stdio.h>
#include <iterator>
#include <memory>
#include <new>
#include <algorithm>
#include <stdexcept>

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
        using iterator_category = std::random_access_iterator_tag; // Random access iterator ++
        using difference_type = std::ptrdiff_t;// typedef __int64 ptrdiff_t;
        using value_type = std::conditional_t<IsConst, const T, T>;
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

        inline pointer operator->() const
        {
            return item;
        }

        inline reference& operator*() const
        {
            return *item;
        }

        inline reference operator[](difference_type offset) const
        {
            return item[offset];
        }

        inline Iterator& operator+=(difference_type offset)
        {
            item += offset;
            return *this;
        }

        inline Iterator& operator-=(difference_type offset)
        {
            item -= offset;
            return *this;
        }

        inline Iterator& operator++()
        {
            item++;
            return *this;
        }

        inline Iterator& operator--()
        {
            item--;
            return *this;
        }

        inline Iterator operator++(int)
        {
            Iterator tmp(*this);
            ++item;
            return tmp;
        }

        inline Iterator operator--(int)
        {
            Iterator tmp(*this);
            ++item;
            return tmp;
        }

        inline difference_type operator-(Iterator const& rhs) const
        {
            return item - rhs.item;
        }

        inline Iterator operator+(difference_type rhs) const
        {
            return Iterator(item + rhs);
        }

        inline Iterator operator-(difference_type rhs) const
        {
            return Iterator(item - rhs);
        }

        inline Iterator operator=(Iterator const& src)
        {
            if (this == &src)
                return *this;

            item = src.item;

            return *this;
        }

        inline bool operator==(const Iterator& rhs) const
        {
            return item == rhs.item;
        }

        inline bool operator!=(const Iterator& rhs) const
        {
            return item != rhs.item;
        }

        inline bool operator>(const Iterator& rhs) const
        {
            return item > rhs.item;
        }

        inline bool operator<(const Iterator& rhs) const
        {
            return item < rhs.item;
        }

        inline bool operator>=(const Iterator& rhs) const
        {
            return item >= rhs.item;
        }

        inline bool operator<=(const Iterator& rhs) const
        {
            return item <= rhs.item;
        }

        inline friend Iterator operator-(difference_type lhs, const Iterator& rhs)
        {
            return Iterator(lhs - rhs.item);
        }

        inline friend Iterator operator+(difference_type lhs, const Iterator& rhs)
        {
            return Iterator(lhs + rhs.item);
        }
    private:
        T* item = nullptr;
    };

    MyArray() = default;

    MyArray(MyArray const& src)
    {
        size_t size = src.GetSize();
        m_first = Allocate(size);
        try
        {
            CopyItems(src.m_first, src.m_last, m_first, m_last);
            m_endOfCapacity = m_first + src.GetCapacity();
        }
        catch (...)
        {
            DeleteItems(m_first, m_last);
            throw;
        }
    }

    MyArray(MyArray&& src)
        :MyArray() // Не надо выделять память ++
    {
        m_first = src.m_first;
        m_last = src.m_last;
        m_endOfCapacity = src.m_endOfCapacity;

        src.m_first = nullptr;
        src.m_last = nullptr;
        src.m_endOfCapacity = nullptr;
    }

    ~MyArray()
    {
        DeleteItems(m_first, m_last);
    }

    size_t GetSize() const
    {
        return m_last - m_first;
    }

    size_t GetCapacity() const
    {
        return m_endOfCapacity - m_first;
    }

    void Append(T const& value)
    {
        if (m_last == m_endOfCapacity)
        {
            size_t newSize = std::max(size_t(1), GetCapacity() * 2);
            T* newBegin = Allocate(newSize);
            T* newEnd = newBegin;

            try
            {
                CopyItems(m_first, m_last, newBegin, newEnd);

                new(newEnd) T(value);
                ++newEnd;
            }
            catch (...)
            {
                DeleteItems(newBegin, newBegin);
                throw;
            }
            DeleteItems(m_first, m_last);

            m_first = newBegin;
            m_last = newEnd;
            m_endOfCapacity = newBegin + newSize;
        }
        else
        {
            new(m_last) T(value);
            ++m_last;
        }
    }

    void Resize(size_t newSize)
    {
        size_t size = GetSize();
        if (newSize == size)
            return;

        size_t capacity = GetCapacity();
        if (newSize < capacity && newSize > size)
        {
            size_t diff = newSize - size;
            auto endCpy = m_last;
            try
            {
                CreateNItemsUsingDefaultCtor(m_last, diff); // Если выбросится исключение, надо созданные элементы удалить ++
            }
            catch (...)
            {
                DeleteItems(endCpy, m_last);
            }
        }
        else if (newSize < size)
        {
            size_t itemsToDelete = size - newSize;
            while (GetSize() != newSize)
            {
                --m_last;
                m_last->~T();
            }
        }
        else
        {
            size_t diff = newSize - size;
            T* newBegin = Allocate(newSize);
            T* newEnd = newBegin;

            try
            {
                CopyItems(m_first, m_last, newBegin, newEnd);
                CreateNItemsUsingDefaultCtor(newEnd, diff); // Если выбросится исключение, никто не узнает, что там что-то было создано ++
            }
            catch (...)
            {
                DeleteItems(newBegin, newEnd); // Удаляете 0 элементов?
                throw;
            }
            DeleteItems(m_first, m_last);

            m_first = newBegin;
            m_last = newEnd;
            m_endOfCapacity = newBegin + newSize;
        }
    }

    void Clear()
    {
        DestroyItems(m_first, m_last);
    }

    Iterator<false> begin() const noexcept
    {
        return Iterator<false>(m_first);
    }

    Iterator<false> end() const noexcept
    {
        return Iterator<false>(m_last);
    }

    Iterator<true> cbegin() const noexcept
    {
        return Iterator<true>(m_first);
    }

    Iterator<true> cend() const noexcept
    {
        return Iterator<true>(m_last);
    }

    std::reverse_iterator<MyArray::Iterator<false>> rbegin() const noexcept
    {
        return std::make_reverse_iterator(end());
    }

    std::reverse_iterator<MyArray::Iterator<false>> rend() const noexcept
    {
        return std::make_reverse_iterator(begin());
    }

    std::reverse_iterator<MyArray::Iterator<true>> crbegin() const noexcept
    {
        return std::make_reverse_iterator(cend());
    }

    std::reverse_iterator<MyArray::Iterator<true>> crend() const noexcept
    {
        return std::make_reverse_iterator(cbegin());
    }

    MyArray& operator=(MyArray const& src) noexcept
    {
        if (this == &src)
            return *this;

        MyArray temp(src);
        swap(m_first, src.m_first);
        swap(m_last, temp.m_last);
        swap(m_endOfCapacity, temp.m_endOfCapacity);
        delete temp;

        return *this;
    }

    MyArray& operator=(MyArray&& src) noexcept
    {
        m_first = src.m_first;
        m_last = src.m_last;
        m_endOfCapacity = src.m_endOfCapacity;

        src.m_first = nullptr;
        src.m_last = nullptr;
        src.m_endOfCapacity = nullptr;

        return *this;
    }

    T& operator[](size_t index)
    {
        size_t size = GetSize();
        if (index > size + 1)
            throw std::out_of_range("");

        return *(begin() + index);
    }

    const T& operator[](size_t index) const
    {
        size_t size = GetSize();
        if (index > size + 1)
            throw std::out_of_range("");

        return *(cbegin() + index);
    }
private:
    T* m_first = nullptr;
    T* m_last = nullptr;
    T* m_endOfCapacity = nullptr;

    struct NItemsConstructorParams
    {
        size_t itemsCount;
    };

    static T* Allocate(size_t elemsCount)
    {
        size_t requiredSize = sizeof(T) * elemsCount;
        T* start = static_cast<T*>(malloc(requiredSize));

        if (!start)
        {
            throw std::bad_alloc();
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
        if constexpr (std::is_nothrow_move_constructible_v<T> || !std::is_copy_constructible_v<T>) {
            return std::uninitialized_move_n(from, n, to).second;
        }
        else {
            return std::uninitialized_copy_n(from, n, to);
        }
    }

    static void CreateNItemsUsingDefaultCtor(T*& from, size_t n)
    {
        for (size_t i = 0; i < n; ++i)
        {
            new(from) T();
            ++from;
        }
    }

    static void DeleteItems(T*& begin, T*& end)
    {
        DestroyItems(begin, end);
        free(begin);
    }

    static void DestroyItems(T*& begin, T*& end)
    {
        while (begin != end)
        {
            --end;
            end->~T();
        }
    }

    static void DeleteNItems(T*& end, size_t n)
    {
        size_t count = 0;
        while (count != n)
        {
            --end;
            end->~T();
            ++count;
        }

        free(end);
    }
};