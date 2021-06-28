#include <iostream>
#include <algorithm>
#include "MyArray.h"

int main()
{
    MyArray<int> arr;
    arr.Append(5);
    arr.Append(3);
    arr.Append(2);
    arr.Append(1);
    arr.Append(4);
    //std::sort(arr.begin(), arr.end());

    std::cout << "Hello World!\n";
}