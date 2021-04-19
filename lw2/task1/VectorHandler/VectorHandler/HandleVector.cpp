#include "pch.h"
#include "HandleVector.h"

void HandleVector(vector<double>& vector)
{
    if (vector.size() == 0)
    {
        return;
    }

    auto mm = minmax_element(vector.begin(), vector.end());

    double productOfMinAndMaxValues = *mm.first * *mm.second;

    transform(vector.begin(), vector.end(), vector.begin(),
        [productOfMinAndMaxValues](double n) -> double {
            if (n < 0)
            {
                return n * productOfMinAndMaxValues;
            }

            return n;
        });
}