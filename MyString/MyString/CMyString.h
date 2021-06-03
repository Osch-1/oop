#include <iostream>
#include <string>
#include <cstdint>
#include <cstdint>

using namespace std;

class CMyString
{
private:
    char* m_chars = nullptr;
    size_t m_size = 0;

    CMyString(char* src, size_t length) noexcept
    {
        m_chars = src;
        m_size = length;
    }

    int Compare(const CMyString& str) const
    {
        if (this == &str)
            return 0;

        int minLength = min(m_size, str.m_size);
        for (size_t i = 0; i < minLength; ++i)
        {
            if (m_chars[i] < str[i])
                return -1;
            if (m_chars[i] > str[i])
                return 1;
        }

        if (m_size == str.m_size)
            return 0;
        if (m_size > str.m_size)
            return 1;
        return -1;
    }
public:
    CMyString();

    CMyString(const char*);

    CMyString(const char*, size_t);

    CMyString(CMyString const&);

    CMyString(CMyString&&) noexcept;

    CMyString(string const&);

    ~CMyString() noexcept;

    size_t GetLength() const;

    const char* GetStringData() const;

    CMyString SubString(size_t, size_t length) const;

    void Clear();

    CMyString& operator=(const CMyString& src);

    CMyString& operator=(CMyString&& other) noexcept;

    char& operator[](int);

    const char& operator[](int) const;

    CMyString operator+(const CMyString& a) const;

    friend bool operator==(const CMyString& a, const CMyString& b);

    CMyString& operator+=(const CMyString& a);

    bool operator!=(const CMyString& a) const;

    bool operator>(const CMyString& a) const;

    bool operator<(const CMyString& a) const;

    bool operator>=(const CMyString& a) const;

    bool operator<=(const CMyString& a) const;

    friend ostream& operator<<(ostream& os, const CMyString& str);

    friend istream& operator>>(istream& os, CMyString& str);
};
