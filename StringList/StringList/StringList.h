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
        Node()
        {
            data = "";
            next = nullptr;
            prev = nullptr;
        }

        Node(string const& data, Node* next = nullptr, Node* prev = nullptr)
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
        friend StringList;
        friend Iterator<true>;
    public:
        //штука, чтобы работало со стандартными std итераторами
        using iterator_category = bidirectional_iterator_tag;
        using difference_type = ptrdiff_t;
        using value_type = conditional_t<IsConst, string, string>;
        using pointer = value_type*;
        using reference = value_type&;

        Iterator() = default;
        Iterator(Iterator<false> const& it)
            :m_node(it.m_node)
        {
        }
        Iterator(Node* node)
            :m_node(node)
        {
        }

        pointer operator->()
        {
            return &m_node->data;
        }

        reference operator*()
        {
            return m_node->data;
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

        friend bool operator == (Iterator const& it1, Iterator const& it2)
        {
            return it1.m_node == it2.m_node;
        };

        friend bool operator != (Iterator const& it1, Iterator const& it2)
        {
            return it1.m_node != it2.m_node;
        };
    private:
        Node* m_node = nullptr;
    };

    StringList();
    StringList(StringList const& src);
    StringList(StringList&& src) noexcept;
    ~StringList() noexcept;

    void PushBack(string const& data);
    void PushFront(string const& data);

    void Insert(Iterator<false> const& it, string const& data);
    void Insert(reverse_iterator<Iterator<false>> const& it, string const& data);

    void Delete(Iterator<false>& it);
    void Delete(reverse_iterator<Iterator<false>>& it);

    size_t GetSize() const;
    bool IsEmpty() const;

    void Clear();

    Iterator<false> begin() const;
    Iterator<false> end() const;

    Iterator<true> cbegin() const;
    Iterator<true> cend() const;

    reverse_iterator<Iterator<false>> rbegin() const;
    reverse_iterator<Iterator<false>> rend() const;

    reverse_iterator<Iterator<true>> crbegin() const;
    reverse_iterator<Iterator<true>> crend() const;
private:
    size_t m_size = 0;

    //так не получится реализовать итератор, точнее так сложнее
    /*Node* m_first = nullptr;
    Node* m_last = nullptr;*/
    Node* m_base;
};