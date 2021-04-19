#include "pch.h"
#include "SortVector.h"

void SortVector(vector<double>& vector)
{
    if (vector.size() == 0)
    {
        return;
    }

    sort(vector.begin(), vector.end());
}
