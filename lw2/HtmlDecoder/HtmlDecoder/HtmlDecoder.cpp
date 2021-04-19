#include "pch.h"
#include "HtmlDecode.h"

int main()
{
    string buffer;

    while (getline(cin, buffer))
    {
        cout << HtmlDecode(buffer) << endl;
    }
}