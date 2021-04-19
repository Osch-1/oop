#include "pch.h"
#include "VectorHandler/VectorHandler/ReadVectorFromStream.h"
#include "VectorHandler/VectorHandler/HandleVector.h"
#include "VectorHandler/VectorHandler/SortVector.h"

bool IsDoubleEquals(double first, double second)
{
    return fabs(first - second) < numeric_limits<double>::epsilon();
}

TEST_CASE("ReadVectorFromStream() returns empty vector if argument is an empty stream")
{
    //arrange
    istringstream emptyInputStream;
    size_t readedVectorSize;

    //act
    readedVectorSize = ReadVectorFromStream(emptyInputStream).size();

    //assert
    CHECK(readedVectorSize == 0);
}

TEST_CASE("ReadVectorFromStream() returns empty vector input is incorrect")
{
    //arrange
    stringstream streamWithIncorrectData;
    streamWithIncorrectData << "incorrect data";

    vector<double> readedVector;

    //act
    readedVector = ReadVectorFromStream(streamWithIncorrectData);

    //assert
    CHECK(readedVector.size() == 0);
}

TEST_CASE("ReadVectorFromStream() returns vector which contains all floating point numbers from input stream")
{
    //arrange
    stringstream stringStream;
    stringStream << "2.0 3.2 -212";

    vector<double> readedVector;

    //act
    readedVector = ReadVectorFromStream(stringStream);

    //assert
    CHECK(IsDoubleEquals(readedVector[0], 2.0));
    CHECK(IsDoubleEquals(readedVector[1], 3.2));
    CHECK(IsDoubleEquals(readedVector[2], -212.0));
}

TEST_CASE("SortVector() does nothing if empty vector has been provided")
{
    //arrange
    vector<double> emptyVector;

    //act
    SortVector(emptyVector);

    //assert
    CHECK(emptyVector.size() == 0);
}

TEST_CASE("SortVector() sorts vector in ascending order")
{
    //arrange
    vector<double> vector = { 10, 11, -2.0, 3.0 };

    //act
    SortVector(vector);

    //assert
    CHECK(IsDoubleEquals(vector[0], -2.0));
    CHECK(IsDoubleEquals(vector[1], 3.0));
    CHECK(IsDoubleEquals(vector[2], 10.0));
    CHECK(IsDoubleEquals(vector[3], 11.0));
}

TEST_CASE("HandleVector() does nothing if empty vector has been provided")
{
    //arrange
    vector<double> emptyVector;

    //act
    HandleVector(emptyVector);

    //assert
    CHECK(emptyVector.size() == 0);
}

TEST_CASE("HandleVector() multiplies every negative element on product of min and max elem")
{
    //arrange
    double min = -10.0;
    double max = 10.0;
    vector<double> vector = { -10.0, 2.0, 10.0, -2.0 };

    double productOfMinAndMax = min * max;

    double expectedFirstValue = (vector[0] * productOfMinAndMax);
    double expectedSecondValue = (vector[1]);
    double expectedThirdValue = (vector[2]);
    double expectedFourthValue = (vector[3] * productOfMinAndMax);

    //act
    HandleVector(vector);

    //assert
    CHECK(IsDoubleEquals(vector[0], expectedFirstValue));
    CHECK(IsDoubleEquals(vector[1], expectedSecondValue));
    CHECK(IsDoubleEquals(vector[2], expectedThirdValue));
    CHECK(IsDoubleEquals(vector[3], expectedFourthValue));
}