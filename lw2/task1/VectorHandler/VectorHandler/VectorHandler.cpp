#include "pch.h"
#include "ReadVectorFromStream.h"
#include "HandleVector.h"
#include "PrintVector.h"
#include "SortVector.h"

int main()
{
    vector<double> vector = ReadVectorFromStream(cin);
    HandleVector(vector);
    SortVector(vector);
    PrintVector(vector, cout);
}