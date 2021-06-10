#include "StringList.h"

StringList::StringList(StringList& src)
    :StringList()
{
    /*for (auto const& str : src)//используем итератор
    {
        PushBack(str);
    }*/
}

StringList::~StringList() noexcept
{
    Clear();
}

void StringList::PushFront(string const& data)
{
    Node* newNode = new Node(data, nullptr, nullptr);
    if (IsEmpty())//список пустой, т.к. при наличии 1..* нод m_last != null
    {
        m_first = newNode;
        m_last = newNode;

        //можно этого не делать, т.к. не используется и несет лишние проблемы        
        //m_first->next = m_last;
        //m_last->prev = m_first;
    }
    else if (GetSize() == 1)
    {
        m_last = newNode;

        m_first->next = m_last;
        m_last->prev = m_first;
    }
    else
    {
        m_last->next = newNode;
        newNode->prev = m_last;
    }

    ++m_size;
}

//Можно выделить private push с параметром type, в нем осуществить првоерку + вставку по параметру, будет меньше кода, но менее понятно
void StringList::PushBack(string const& data)
{
    Node* newNode = new Node(data, nullptr, nullptr);
    if (IsEmpty())//список пустой, т.к. при наличии 1..* нод m_last != null
    {
        m_first = newNode;
        m_last = newNode;

        //можно этого не делать, т.к. не используется и несет лишние проблемы        
        //m_first->next = m_last;
        //m_last->prev = m_first;
    }
    else if (GetSize() == 1)
    {
        m_first = newNode;

        m_first->next = m_last;
        m_last->prev = m_first;
    }
    else
    {
        m_first->prev = newNode;
        newNode->next = m_first;
    }

    ++m_size;
}

void StringList::Insert(Iterator<false> const& it, string const& data)
{
}

void StringList::Insert(reverse_iterator<Iterator<false>> const& it, string const& data)
{
}

size_t StringList::GetSize() const
{
    return m_size;
}

bool StringList::IsEmpty() const
{
    return m_size == 0;
}

void StringList::Clear()
{
    auto curr = m_first;
    while (curr != nullptr)
    {
        auto next = curr->next;
        delete curr;
        curr = next;
    }

    m_first = nullptr;
    m_last = nullptr;

    m_size = 0;
}

//StringList::Iterator<false> StringList::begin()
//{
//
//}
//
//StringList::Iterator<false> StringList::end()
//{
//    return Iterator<false>();
//}
//
//StringList::Iterator<true> StringList::cbegin()
//{
//    return Iterator<true>();
//}
//
//StringList::Iterator<true> StringList::cend()
//{
//    return Iterator<true>();
//}
//
//reverse_iterator<StringList::Iterator<false>> StringList::rbegin()
//{
//    return reverse_iterator<Iterator<false>>();
//}
//
//reverse_iterator<StringList::Iterator<false>> StringList::rend()
//{
//    return reverse_iterator<Iterator<false>>();
//}
//
//reverse_iterator<StringList::Iterator<true>> StringList::crbegin()
//{
//    return reverse_iterator<Iterator<true>>();
//}
//
//reverse_iterator<StringList::Iterator<true>> StringList::crend()
//{
//    return reverse_iterator<Iterator<true>>();
//}
