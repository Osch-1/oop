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
    try
    {
        for (auto const& str : src)
        {
            PushFront(str);//exception?++
        }
    }
    catch (exception)
    {
        Clear();
        delete m_base;
        throw;
    }
}

StringList::StringList(StringList&& src) noexcept
    : StringList()
{
    swap(m_size, src.m_size);
    swap(m_base, src.m_base);
}

StringList::~StringList() noexcept
{
    //очищаем выделенную под значимые элементы память
    Clear();

    //удаляем суррогатную ноду
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

StringList::Iterator<false> StringList::Delete(Iterator<false> it) // Принимайте по значению
{
    //нельзя удалять основообразующую ноду
    if (it.m_node == m_base)
        return begin();

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
    //возвращать итератор на след/end
    auto buff = it.m_node->next;
    delete it.m_node;
    --m_size;

    return buff ? buff : end();
}

size_t StringList::GetSize() const noexcept
{
    return m_size;
}

bool StringList::IsEmpty() const noexcept
{
    return m_size == 0;
}

void StringList::Clear() noexcept
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

StringList::Iterator<false> StringList::begin() const noexcept
{
    return Iterator<false>(m_base->next);
}

StringList::Iterator<false> StringList::end() const noexcept
{
    return Iterator<false>(m_base->prev->next);
}

StringList::Iterator<true> StringList::cbegin() const noexcept
{
    return Iterator<true>(m_base->next);
}

StringList::Iterator<true> StringList::cend() const noexcept
{
    return Iterator<true>(m_base->prev->next);
}

reverse_iterator<StringList::Iterator<false>> StringList::rbegin() const noexcept
{
    return make_reverse_iterator(end());
}

reverse_iterator<StringList::Iterator<false>> StringList::rend() const noexcept
{
    return make_reverse_iterator(begin());
}

reverse_iterator<StringList::Iterator<true>> StringList::crbegin() const noexcept
{
    return make_reverse_iterator(cend());
}

reverse_iterator<StringList::Iterator<true>> StringList::crend() const noexcept
{
    return make_reverse_iterator(cbegin());
}

StringList& StringList::operator=(const StringList& src)
{
    if (this == &src)
        return *this;
    //?    

    return *this;
}

StringList& StringList::operator=(StringList&& other) noexcept
{
    swap(m_size, other.m_size);
    swap(m_base, other.m_base);

    return *this;
}