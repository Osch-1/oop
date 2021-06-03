#include <iostream>
#include <string>
#include "CMyString.h"

using namespace std;

int main()
{
    CMyString s = "Hello";
    CMyString a = CMyString(s);
    s.SubString(0, 0);
}
