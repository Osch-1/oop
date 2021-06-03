#include "CMyString.h"

CMyString::CMyString()
    :m_chars(new char[1])
{
    m_chars[0] = '\0';
}

CMyString::CMyString(const char* pString)
{
    size_t length = strlen(pString);
    m_chars = new char[length + 1];
    m_size = length;

    //size_t
    for (size_t i = 0; i < length; ++i)
    {
        m_chars[i] = pString[i];
    }

    m_chars[length] = '\0';
}

CMyString::CMyString(const char* pString, size_t length)
    :m_chars(new char[length + 1])
{
    m_size = length;

    for (size_t i = 0; i < length; ++i)
    {
        m_chars[i] = pString[i];
    }

    m_chars[length] = '\0';
}

CMyString::CMyString(CMyString const& other)
    :m_chars(new char[other.m_size + 1])
{
    memcpy(m_chars, other.GetStringData(), other.m_size + 1);
    m_size = other.m_size;
}

CMyString::CMyString(CMyString&& other) noexcept
{
    delete[] m_chars;
    m_size = other.m_size;

    m_chars = other.m_chars;
    other.m_chars = nullptr;
}

CMyString::CMyString(string const& stlString)
{
    size_t destSize = stlString.size() + 1;
    m_chars = new char[stlString.size() + 1];
    m_size = stlString.size();

    memcpy(m_chars, stlString.data(), destSize);
}

CMyString::~CMyString() noexcept
{
    delete[] m_chars;
}

size_t CMyString::GetLength() const
{
    return m_size;
}

const char* CMyString::GetStringData() const
{
    return m_chars ? m_chars : "";
}

CMyString CMyString::SubString(size_t start, size_t length) const
{
    if (start >= m_size) // слишком строгая проверка. При m_size==0 будет некорректное поведение++
        throw out_of_range("Start index is out of range");

    // Игнорируется параметр start, а также проблемы с символами с кодом 0++
    if (start + length > m_size)
        throw invalid_argument("Size of substring you trying to get is greater than source string");

    //?
    const char* str = m_chars;
    return CMyString(&str[start], length);
}

void CMyString::Clear()
{
    m_chars[0] = '\0';
    m_size = 0;
}

CMyString& CMyString::operator=(CMyString&& other) noexcept
{
    delete[] m_chars;
    m_size = 0;

    m_chars = other.m_chars;
    m_size = other.m_size;

    other.m_chars = nullptr;
    other.m_size = 0;

    return *this;
}

CMyString& CMyString::operator=(const CMyString& src) // должен возвращать CMyString&++
{
    if (this == &src)
        return *this;

    char* buff = new char[src.m_size + 1];
    memcpy(buff, src.m_chars, src.m_size + 1);

    delete[] m_chars;
    m_chars = buff; // Утечка памяти (массив по адресу прежнего значения m_chars)++
    m_size = src.m_size;

    return *this;
}

char& CMyString::operator[](int i)
{
    if (i >= m_size) // А если i == m_size?++
        throw out_of_range("Index is out of range"); //++ Непортабельно (в std::exception нет конструктора из const char*), следует выбрасывать другой тип исключения++

    return m_chars[i];
}

const char& CMyString::operator[](int i) const
{
    if (i >= m_size) // А если i == m_size?++
        throw out_of_range("Index is out of range");

    return m_chars[i];
}

CMyString CMyString::operator+(const CMyString& str) const
{
    int newSize = m_size + str.m_size;
    //утечка памяти++
    char* buff = new char[newSize + 1];

    memcpy(buff, m_chars, m_size + 1);
    memcpy(buff + m_size, str.m_chars, str.m_size + 1);

    //exception 
    CMyString newStr(buff, newSize);

    return newStr;
}

CMyString& CMyString::operator+=(const CMyString& str)//возвращает &левый элемент++
{
    int newSize = m_size + str.m_size;

    char* buff = new char[newSize + 1];
    memcpy(buff, m_chars, m_size);
    memcpy(buff + m_size, str.m_chars, str.m_size + 1);//нет нулевого символа++
    delete[] m_chars;

    m_chars = buff;
    m_size = newSize;

    return *this;
}

bool CMyString::operator!=(const CMyString& a) const
{
    return !(*this == a);
}

// ошибка abracadabra > zebra
bool CMyString::operator>(const CMyString& str) const
{
    // А можно ли за один проход по строке?
    if (this == &str)
        return false;

    return Compare(str) > 0;
}

// Ошибка zebra < and
bool CMyString::operator<(const CMyString& str) const
{
    if (this == &str)
        return false;

    return Compare(str) < 0;
}

//O(2N)/O(2)= h2o++
bool CMyString::operator>=(const CMyString& str) const
{
    return Compare(str) >= 0;
}

//O(2N)++
bool CMyString::operator<=(const CMyString& str) const
{
    return Compare(str) <= 0;
}

bool operator ==(const CMyString& a, const CMyString& b)
{
    if (&a == &b)
        return true;

    if (a.GetLength() != b.GetLength())
        return false;

    for (size_t i = 0; i < a.GetLength(); ++i)
    {
        if (a[i] != b[i])
            return false;
    }

    return true;
}

ostream& operator<<(ostream& os, const CMyString& str)
{
    for (size_t i = 0; i < str.m_size; ++i)
        os << str[i];
    return os;
}

istream& operator>>(istream& is, CMyString& str)
{
    string buff;

    is >> buff;
    str = CMyString(buff);

    return is;
}