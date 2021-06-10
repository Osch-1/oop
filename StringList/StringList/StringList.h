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
    struct Node
    {
        Node(string const& data, Node* next, Node* prev)
            :data(data),
            next(next),
            prev(prev)
        {
        }

        string data;
        Node* next;
        Node* prev;
    };

    template<bool IsConst>
    class Iterator
    {
        friend Iterator<true>;
        friend StringList;
        using iterator_category = bidirectional_iterator_tag;//можно превратить в reverse iterator
        using difference_type = ptrdiff_t;
        using value_type = conditional_t<IsConst, string, string>;
        using pointer = value_type*;
        using reference = value_type&;
    public:
        Iterator() = default;
        Iterator(Iterator<false> const& it)
            :m_node(it.m_node)
        {
        }

        reference operator*() const
        {
            return m_node->data;
        }

        pointer operator->()
        {
            return &m_node->data;
        }

        Iterator& operator++()
        {
            m_node = m_node->next;
            return *this;
        }

        Iterator& operator--()
        {
            m_node = m_node->prev;
            return *this;
        }

        friend bool operator== (const Iterator& it1, const Iterator& it2)
        {
            return it1.m_node == it2.m_node;
        };

        friend bool operator != (const Iterator& it1, const Iterator& it2)
        {
            return it1.m_node != it2.m_node;
        };
    protected:
        Node* m_node = nullptr;
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

    /*Iterator<false> begin();
    Iterator<false> end();

    Iterator<true> cbegin();
    Iterator<true> cend();

    reverse_iterator<Iterator<false>> rbegin();
    reverse_iterator<Iterator<false>> rend();

    reverse_iterator<Iterator<true>> crbegin();
    reverse_iterator<Iterator<true>> crend();*/
private:
    size_t m_size = 0;
    Node* m_first = nullptr;
    Node* m_last = nullptr;
};