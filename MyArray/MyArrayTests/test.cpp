#include "pch.h"
#include "../MyArray/MyArray.h"

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