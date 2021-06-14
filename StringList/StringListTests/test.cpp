#include "pch.h"
#include "../StringList/StringList.h"

TEST(StringList, DefaultConstructorCorrectlyCreatesObject) {
    //Arrange & act
    StringList stringList;

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 0);
}

//add values check
TEST(StringList, PushFrontCreatesFirstAndLastElemIfListIsEmpty) {
    //Arrange
    StringList stringList;

    //Act
    stringList.PushBack("data1");

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 1);
    ASSERT_EQ(*stringList.begin(), "data1");
}

//add values check
TEST(StringList, PushFrontAddsAnotherElementInNonEmptyList) {
    //Arrange
    StringList stringList;

    //Act
    stringList.PushBack("data1");
    stringList.PushBack("data2");

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 2);
    ASSERT_EQ(*stringList.begin(), "data1");
}

//add values check
TEST(StringList, ClearDeletesAllElementsAndSetsSizeTo0) {
    //Arrange
    StringList stringList;
    stringList.PushBack("data1");
    stringList.PushBack("data2");

    //Act
    stringList.Clear();

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 0);
}

TEST(StringList, AbleToPushBack) {
    //Arrange
    StringList stringList;

    //Act
    stringList.PushFront("data1");
    stringList.PushFront("data2");

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 2);
    ASSERT_EQ(*stringList.begin(), "data2");
}

TEST(StringList, AbleToInsertInEmpty) {
    //Arrange
    StringList stringList;

    //Act
    stringList.Insert(stringList.begin(), "data2");

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 1);
    ASSERT_EQ(*stringList.begin(), "data2");
}

TEST(StringList, AbleToInsertInNonEmpty) {
    //Arrange
    StringList stringList;
    stringList.PushFront("data1");

    //Act
    stringList.Insert(stringList.begin(), "data2");

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 2);
    ASSERT_EQ(*stringList.begin(), "data2");
}

TEST(StringList, AbleToInsertMultipleTimes) {
    //Arrange
    StringList stringList;

    //Act
    stringList.Insert(stringList.begin(), "data2");
    stringList.Insert(stringList.begin(), "data1");

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 2);
    ASSERT_EQ(*stringList.begin(), "data1");
}

TEST(StringList, AbleToInsertByRIterator) {
    //Arrange
    StringList stringList;

    //Act
    stringList.Insert(stringList.rbegin(), "data2");
    stringList.Insert(stringList.rbegin(), "data1");

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 2);
    ASSERT_EQ(*stringList.begin(), "data2");
}

TEST(StringList, AbleToIterateByIterator) {
    //Arrange
    StringList stringList;
    stringList.PushBack("Hello ");
    stringList.PushBack("world");
    stringList.PushBack("!");
    string res = "";

    //Act
    for (auto it = stringList.begin(); it != stringList.end(); ++it)
    {
        res += *it;
    }

    //Assert    
    ASSERT_EQ(res, "Hello world!");
}

TEST(StringList, CopyConstructor) {
    //Arrange
    StringList stringList;
    stringList.Insert(stringList.begin(), "data2");
    stringList.Insert(stringList.begin(), "data1");

    StringList* stringList2;

    //Act
    stringList2 = new StringList(stringList);

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 2);
    ASSERT_EQ(*stringList.begin(), "data1");
}