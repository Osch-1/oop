#include "StringList.h"

StringList::StringList()
    :m_size(0)
{
    m_base = new Node("", nullptr, nullptr);

    m_base->next = m_base;
    m_base->prev = m_base;
}

StringList::StringList(StringList const& src)
    : StringList()
{
    for (auto const& str : src)
    {
        PushFront(str);//exception
    }
}

StringList::StringList(StringList&& src) noexcept
    :StringList()
{
    swap(m_size, src.m_size);
    swap(m_base, src.m_base);
    //swap(m_first, src.m_first);
    //swap(m_last, src.m_last);
}

StringList::~StringList() noexcept
{
    Clear();
    delete m_base;
}

void StringList::PushBack(string const& data)
{
    Node* newNode = new Node(data, m_base, m_base->prev);

    if (m_base->prev)
    {
        m_base->prev->next = newNode;
    }
    else
    {
        m_base->next = newNode;
    }

    m_base->prev = newNode;

    ++m_size;
}

//Можно выделить private push с параметром type, в нем осуществить првоерку + вставку по параметру, будет меньше кода, но менее понятно
void StringList::PushFront(string const& data)
{
    Node* newNode = new Node(data, m_base->next);

    if (m_base->next)
    {
        m_base->next->prev = newNode;
    }
    else
    {
        m_base->prev = newNode;
    }

    m_base->next = newNode;

    ++m_size;
}

void StringList::Insert(Iterator<false> const& it, string const& data)
{
    if (!it.m_node)
    {
        PushBack(data);
        return;
    }

    Node* node = new Node(data, it.m_node, it.m_node->prev);
    if (it.m_node->prev)
    {
        it.m_node->prev->next = node;
    }
    else
    {
        m_base->next = node;
    }

    it.m_node->prev = node;
    ++m_size;
}

void StringList::Insert(reverse_iterator<Iterator<false>> const& it, string const& data)
{
    Insert(it.base(), data);
}

void StringList::Delete(Iterator<false>& it)
{
    if (it.m_node == m_base)
        return;

    //если это первая нода
    if (m_base->next == it.m_node)
        m_base->next = it.m_node->next;

    //если это последняя нода
    if (m_base->prev == it.m_node)
        m_base->prev = it.m_node->prev;

    //если есть что-то слева
    if (it.m_node->prev)
        it.m_node->prev->next = it.m_node->next;

    //если есть что-то справа
    if (it.m_node->next)
        it.m_node->next->prev = it.m_node->prev;

    //итератор после удаления должен быть равен next
    auto buff = it.m_node->next;
    delete it.m_node;
    it = buff;

    --m_size;
}

void StringList::Delete(reverse_iterator<Iterator<false>>& it)
{
    if (it.base().m_node == m_base)
        return;

    //сохраняем итератор, чтобы после удаления получить уже следующий элемент
    auto deletable = --it.base();
    Delete(deletable);

    it.base() = deletable;
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
    auto curr = m_base->next;
    while (curr != m_base)
    {
        auto next = curr->next;
        delete curr;
        curr = next;
    }

    m_base->next = m_base;
    m_base->prev = m_base;

    m_size = 0;
}

StringList::Iterator<false> StringList::begin() const
{
    return Iterator<false>(m_base->next);
}

StringList::Iterator<false> StringList::end() const
{
    return Iterator<false>(m_base->prev->next);
}

StringList::Iterator<true> StringList::cbegin() const
{
    return Iterator<true>(m_base->next);
}

StringList::Iterator<true> StringList::cend() const
{
    return Iterator<true>(m_base->prev->next);
}

reverse_iterator<StringList::Iterator<false>> StringList::rbegin() const
{
    return make_reverse_iterator(end());
}

reverse_iterator<StringList::Iterator<false>> StringList::rend() const
{
    return make_reverse_iterator(begin());
}

reverse_iterator<StringList::Iterator<true>> StringList::crbegin() const
{
    return make_reverse_iterator(cend());
}

reverse_iterator<StringList::Iterator<true>> StringList::crend() const
{
    return make_reverse_iterator(cbegin());
}