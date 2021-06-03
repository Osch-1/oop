#include <iostream>
#include <vector>

using namespace std;

template <typename T, typename Less>
bool FindMax(vector<T> const& arr, T& maxValue, Less const& less);