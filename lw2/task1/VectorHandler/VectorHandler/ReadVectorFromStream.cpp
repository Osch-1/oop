#include "pch.h"
#include "ReadVectorFromStream.h"

vector<double> ReadVectorFromStream(istream& inputStream)
{
    vector<double> numbers(istream_iterator<double>(inputStream), {});

    return numbers;
}