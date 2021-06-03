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

    //тегированный конструктор
    //вспомогатлеьная структура BUffer, копирование, деструктор, просто memcpy
    CMyString(size_t length, char* src) noexcept
    {
        m_chars = src;
        m_size = length;
    }
public:
    CMyString();

    CMyString(const char*);

    CMyString(char*, size_t);

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

    //объявить внешними для того, чтобы был вызов конструкторов
    friend bool operator!=(const CMyString& a, const CMyString& b);

    friend bool operator>(const CMyString& a, const CMyString& b);

    friend bool operator<(const CMyString& a, const CMyString& b);

    friend bool operator>=(const CMyString& a, const CMyString& b);

    friend bool operator<=(const CMyString& a, const CMyString& b);

    friend ostream& operator<<(ostream& os, const CMyString& str);

    friend istream& operator>>(istream& os, CMyString& str);
};
