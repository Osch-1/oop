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
    stringList.PushFront("data");

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 1);
}

//add values check
TEST(StringList, PushFrontAddsAnotherElementInNonEmptyList) {
    //Arrange
    StringList stringList;

    //Act
    stringList.PushFront("data");
    stringList.PushFront("data");

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 2);
}

//add values check
TEST(StringList, ClearDeletesAllElementsAndSetsSizeTo0) {
    //Arrange
    StringList stringList;
    stringList.PushFront("data");
    stringList.PushFront("data");

    //Act
    stringList.Clear();

    //Assert
    ASSERT_TRUE(stringList.GetSize() == 0);
}