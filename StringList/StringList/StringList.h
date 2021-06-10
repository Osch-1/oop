#pragma once

#include <string>
#include <memory>
#include <iostream>
#include <stdexcept>
#include <string>
#include <memory>
#include <cassert>
#include <iterator>

using namespace std;

class StringList
{
public:
    template<bool IsConst>
    class Iterator
    {
        friend StringList;
        using iterator_category = bidirectional_iterator_tag;//можно превратить в reverse iterator
        using difference_type = ptrdiff_t;
        using value_type = conditional_t<IsConst, string, string>;
        using pointer = value_type*;
        using reference = value_type&;
    private:
        Node* m_node = nullptr;
    public:
        Iterator() = default;
        Iterator(Iterator<false> const& it)
            :m_node(it.m_node)
        {
        }

        reference operator*() const
        {
            return m_node.get()->data;
        }
        pointer operator->()
        {
            return &m_node.get()->data;
        }
        Iterator& operator++()
        {
            m_node = m_node.get()->next;
            return *this;
        }
        Iterator& operator--()
        {
            m_node = m_node.get()->prev;
            return *this;
        }
        friend bool operator== (const Iterator& a, const Iterator& b)
        {
            return a.m_node == b.m_node;
        };
        friend bool operator != (const Iterator& a, const Iterator& b)
        {
            return a.m_node != b.m_node;
        };
    };
    struct Node
    {
        Node(string const& data, unique_ptr<Node> next, Node* prev)
            :data(data),
            next(move(next)),
            prev(prev)
        {
        }

        string data;
        unique_ptr<Node> next;
        Node* prev;
    };

    StringList() = default;
    StringList(StringList& src);
    ~StringList() noexcept;

    void Push(string const& data);
    void PushBack(string const& data);

    void Insert(Iterator<false> const& it, string const& data);
    void Insert(reverse_iterator<Iterator<false>> const& it, string const& data);

    size_t GetSize() const;
    bool IsEmpty() const;

    void Clear();

    Iterator<false> begin();
    Iterator<false> end();

    Iterator<true> cbegin();
    Iterator<true> cend();

    reverse_iterator<Iterator<false>> rbegin();
    reverse_iterator<Iterator<false>> rend();

    reverse_iterator<Iterator<true>> crbegin();
    reverse_iterator<Iterator<true>> crend();
private:
    size_t m_size = 0;
    unique_ptr<Node> m_first;
    Node* m_last = nullptr;
};

//class const_iterator
//{
//    friend StringList;
//private:
//    Node* m_node = nullptr;
//public:
//    const_iterator() = default;
//    const_iterator(Node* node);
//
//    const_iterator& operator++();
//    string& operator*();
//};
//
//class reverse_iterator
//{
//    friend StringList;
//private:
//    Node* m_node = nullptr;
//public:
//    reverse_iterator() = default;
//    reverse_iterator(Node* node);
//
//    reverse_iterator& operator++();
//    string& operator*();
//};
//
//class const_reverse_iterator
//{
//    friend StringList;
//private:
//    Node* m_node = nullptr;
//public:
//    const_reverse_iterator() = default;
//    const_reverse_iterator(Node* node);
//
//    const_iterator& operator++();
//    string& operator*();
//};