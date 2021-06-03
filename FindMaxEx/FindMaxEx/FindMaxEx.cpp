﻿#include "FindMaxEx.h"

template<typename T, typename Less>
inline bool FindMax(vector<T> const& arr, T& maxValue, Less const& less)
{
    if (arr.empty())
    {
        return false;
    }

    maxValue = arr[0];
    for (int i = 1; i < arr.size(); ++i)
    {
        if (less(maxValue, arr[i]))
            maxValue = arr[i];
    }

    return true;
}
