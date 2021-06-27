#include "pch.h"
#include "../MyArray/MyArray.h"

template <typename T> bool isConst(T& x)
{
    return false;
}

template <typename T> bool isConst(T const& x)
{
    return true;
}

TEST(MyArray, DefaultConstructor) {
    //arrange & act
    MyArray<string> arr;

    //assert
    ASSERT_EQ(0, arr.GetSize());
    ASSERT_EQ(0, arr.GetCapacity());
}

TEST(MyArray, AppendCorrectlyWorksOnEmptyArr) {
    //arrange
    MyArray<string> arr;

    //act
    arr.Append("val");

    //assert
    ASSERT_EQ(1, arr.GetSize());
    ASSERT_EQ(1, arr.GetCapacity());
}

TEST(MyArray, AppendCorrectlyWorksOnNonEmptyArray) {
    //arrange
    MyArray<string> arr;

    //act
    arr.Append("val1");
    arr.Append("val2");
    arr.Append("val3");
    arr.Append("val4");

    //assert
    ASSERT_EQ(4, arr.GetSize());
    ASSERT_EQ(4, arr.GetCapacity());
}

TEST(MyArray, ClearOperatorWorks) {
    //arrange
    MyArray<string> arr;
    arr.Append("val1");
    arr.Append("val2");
    arr.Append("val3");
    arr.Append("val4");

    //act
    arr.Clear();

    //assert
    ASSERT_EQ(0, arr.GetSize());
    ASSERT_EQ(4, arr.GetCapacity());
}

TEST(MyArray, ArrayAreAbleToBeModifiedAfterClear) {
    //arrange
    MyArray<string> arr;
    arr.Append("val1");
    arr.Append("val2");
    arr.Append("val3");
    arr.Append("val4");

    //act
    arr.Clear();
    arr.Append("val1");

    //assert
    ASSERT_EQ(1, arr.GetSize());
    ASSERT_EQ(4, arr.GetCapacity());
}

TEST(MyArray, IteratorCorrectlyWorks) {
    //arrange
    MyArray<int> arr;
    arr.Append(1);
    arr.Append(2);
    arr.Append(3);
    arr.Append(4);

    //act
    int res = 0;
    for (auto it = arr.begin(); it != arr.end(); ++it)
    {
        res += *it;
    }

    //assert
    ASSERT_EQ(4, arr.GetSize());
    ASSERT_EQ(4, arr.GetCapacity());
    ASSERT_EQ(10, res);
}

TEST(MyArray, ConstantIteratorCorrectlyWorks) {
    //arrange
    MyArray<int> arr;
    arr.Append(1);
    arr.Append(2);
    arr.Append(3);
    arr.Append(4);

    //act
    int res = 0;
    for (auto it = arr.cbegin(); it != arr.cend(); ++it)
    {
        res += *it;
    }

    //assert
    ASSERT_EQ(4, arr.GetSize());
    ASSERT_EQ(4, arr.GetCapacity());
    ASSERT_EQ(10, res);
}

TEST(MyArray, ReverseIteratorCorrectlyWorks) {
    //arrange
    MyArray<int> arr;
    arr.Append(1);
    arr.Append(2);
    arr.Append(3);
    arr.Append(4);

    //act
    int res = 0;
    for (auto it = arr.rbegin(); it != arr.rend(); ++it)
    {
        res += *it;
    }

    //assert
    ASSERT_EQ(4, arr.GetSize());
    ASSERT_EQ(4, arr.GetCapacity());
    ASSERT_EQ(10, res);
}

TEST(MyArray, ReverseConstantIteratorCorrectlyWorks) {
    //arrange
    MyArray<int> arr;
    arr.Append(1);
    arr.Append(2);
    arr.Append(3);
    arr.Append(4);

    //act
    int res = 0;
    for (auto it = arr.crbegin(); it != arr.crend(); ++it)
    {
        res += *it;
    }

    //assert
    ASSERT_EQ(4, arr.GetSize());
    ASSERT_EQ(4, arr.GetCapacity());
    ASSERT_EQ(10, res);
}

TEST(MyArray, CopyConstructorWorks) {
    //arrange
    MyArray<int> src;
    src.Append(1);
    src.Append(2);
    src.Append(3);
    src.Append(4);

    //act
    auto arr = MyArray<int>(src);

    //assert
    ASSERT_EQ(4, arr.GetSize());
    ASSERT_EQ(4, arr.GetCapacity());
}

TEST(MyArray, CopyAssignmentWorks) {
    //arrange
    MyArray<int> src;
    src.Append(1);
    src.Append(2);
    src.Append(3);
    src.Append(4);

    //act
    auto arr = src;

    //assert
    ASSERT_EQ(4, arr.GetSize());
    ASSERT_EQ(4, arr.GetCapacity());
}

TEST(MyArray, IndexSubscriptWorks) {
    //arrange & act
    MyArray<int> arr;
    arr.Append(1);
    arr.Append(2);
    arr.Append(3);
    arr.Append(4);

    //assert
    ASSERT_EQ(4, arr.GetSize());
    ASSERT_EQ(4, arr.GetCapacity());
    ASSERT_EQ(arr[0], 1);
    ASSERT_EQ(arr[1], 2);
    ASSERT_EQ(arr[2], 3);
    ASSERT_EQ(arr[3], 4);
}

TEST(MyArray, CIndexSubscriptWorks) {
    //arrange
    MyArray<int> src;
    src.Append(1);
    src.Append(2);
    src.Append(3);
    src.Append(4);

    //act
    const MyArray<int> arr = MyArray<int>(src);

    //assert
    ASSERT_EQ(4, arr.GetSize());
    ASSERT_EQ(4, arr.GetCapacity());
    ASSERT_EQ(arr[0], 1);
    ASSERT_EQ(arr[1], 2);
    ASSERT_EQ(arr[2], 3);
    ASSERT_EQ(arr[3], 4);
}

TEST(MyArray, ResizeCorrectlyWorks) {
    //arrange
    MyArray<int> arr;
    arr.Append(1);
    arr.Append(2);
    arr.Append(3);
    arr.Append(4);

    //act
    arr.Resize(12);

    //assert
    ASSERT_EQ(4, arr.GetSize());
    ASSERT_EQ(12, arr.GetCapacity());
    ASSERT_EQ(arr[0], 1);
    ASSERT_EQ(arr[1], 2);
    ASSERT_EQ(arr[2], 3);
    ASSERT_EQ(arr[3], 4);
    ASSERT_EQ(arr[4], 0);
    ASSERT_EQ(arr[5], 0);
    ASSERT_EQ(arr[6], 0);
    ASSERT_EQ(arr[7], 0);
    ASSERT_EQ(arr[8], 0);
    ASSERT_EQ(arr[9], 0);
    ASSERT_EQ(arr[10], 0);
    ASSERT_EQ(arr[11], 0);
}

TEST(MyArray, CheckResizeToLower) {
    //arrange
    MyArray<int> arr;
    arr.Append(1);
    arr.Append(2);
    arr.Append(3);
    arr.Append(4);

    //act
    arr.Resize(2);

    //assert
    ASSERT_EQ(2, arr.GetSize());
    ASSERT_EQ(2, arr.GetCapacity());
    ASSERT_EQ(arr[0], 1);
    ASSERT_EQ(arr[1], 2);
}

TEST(MyArray, ResizeCorrectlyWorksForString) {
    //arrange
    MyArray<string> arr;
    arr.Append("1");
    arr.Append("2");
    arr.Append("3");
    arr.Append("4");

    //act
    arr.Resize(12);

    //assert
    ASSERT_EQ(4, arr.GetSize());
    ASSERT_EQ(12, arr.GetCapacity());
    ASSERT_EQ(arr[0], "1");
    ASSERT_EQ(arr[1], "2");
    ASSERT_EQ(arr[2], "3");
    ASSERT_EQ(arr[3], "4");
    ASSERT_EQ(arr[4], "");
    ASSERT_EQ(arr[5], "");
    ASSERT_EQ(arr[6], "");
    ASSERT_EQ(arr[7], "");
    ASSERT_EQ(arr[8], "");
    ASSERT_EQ(arr[9], "");
    ASSERT_EQ(arr[10], "");
    ASSERT_EQ(arr[11], "");
}

TEST(MyArray, ResizeCorrectlyWorksIfNewSizeIsInRangeOfCurrCapacity) {
    //arrange
    MyArray<string> arr;
    arr.Append("1");
    arr.Append("2");
    arr.Append("3");
    arr.Append("4");
    arr.Append("5");

    //act
    arr.Resize(7);

    //assert
    ASSERT_EQ(5, arr.GetSize());
    ASSERT_EQ(8, arr.GetCapacity());
    ASSERT_EQ(arr[0], "1");
    ASSERT_EQ(arr[1], "2");
    ASSERT_EQ(arr[2], "3");
    ASSERT_EQ(arr[3], "4");
    ASSERT_EQ(arr[4], "5");
    ASSERT_EQ(arr[5], "");
    ASSERT_EQ(arr[6], "");
}

TEST(MyArray, MoveConstructorWorksCorrectly) {
    //arrange
    MyArray<string> src;
    src.Append("1");
    src.Append("2");
    src.Append("3");
    src.Append("4");
    src.Append("5");

    //act
    MyArray<string> arr(move(src));
    arr.Append("6");

    //assert
    ASSERT_EQ(6, arr.GetSize());
    ASSERT_EQ(8, arr.GetCapacity());
    ASSERT_EQ(arr[0], "1");
    ASSERT_EQ(arr[1], "2");
    ASSERT_EQ(arr[2], "3");
    ASSERT_EQ(arr[3], "4");
    ASSERT_EQ(arr[4], "5");
    ASSERT_EQ(arr[5], "6");
}