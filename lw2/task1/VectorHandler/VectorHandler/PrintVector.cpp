#include "pch.h"
#include "PrintVector.h"

void PrintVector(const vector<double>& vector, ostream& ostream)
{
    copy(vector.begin(), vector.end(), ostream_iterator<double>(ostream, " "));

    ostream << endl;
}
