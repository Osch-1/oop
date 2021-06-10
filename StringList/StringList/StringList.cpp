#include "StringList.h"

StringList::StringList(StringList& src)
    :StringList()
{
    for (auto const& str : src)//используем итератор
    {
        PushBack(str);
    }
}

StringList::~StringList() noexcept
{
    Clear();
}

void StringList::Push(string const& data)
{
}

void StringList::PushBack(string const& data)
{
}

void StringList::Insert(Iterator<false> const& it, string const& data)
{
}

void StringList::Insert(reverse_iterator<Iterator<false>> const& it, string const& data)
{
}

size_t StringList::GetSize() const
{
    return size_t();
}

bool StringList::IsEmpty() const
{
    return m_size == 0;
}

void StringList::Clear()
{

}

StringList::Iterator<false> StringList::begin()
{

}

StringList::Iterator<false> StringList::end()
{
    return Iterator<false>();
}

StringList::Iterator<true> StringList::cbegin()
{
    return Iterator<true>();
}

StringList::Iterator<true> StringList::cend()
{
    return Iterator<true>();
}

reverse_iterator<StringList::Iterator<false>> StringList::rbegin()
{
    return reverse_iterator<Iterator<false>>();
}

reverse_iterator<StringList::Iterator<false>> StringList::rend()
{
    return reverse_iterator<Iterator<false>>();
}

reverse_iterator<StringList::Iterator<true>> StringList::crbegin()
{
    return reverse_iterator<Iterator<true>>();
}

reverse_iterator<StringList::Iterator<true>> StringList::crend()
{
    return reverse_iterator<Iterator<true>>();
}
