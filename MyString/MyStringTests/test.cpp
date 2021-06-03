#include "pch.h"
#include "../MyString/CMyString.cpp"
#include <iterator>

TEST(CMyStringTest, NoParamsConstructorTest)
{
    //arrange & act
    CMyString str = CMyString();

    //assert
    ASSERT_TRUE(str.GetLength() == 0);
}

TEST(CMyStringTest, CStrConstructorTest)
{
    //arrange
    size_t size = 3;
    char* source = "abc";

    //act
    CMyString str = CMyString(source);

    //assert
    ASSERT_TRUE(str.GetLength() == size);
    ASSERT_EQ(str, "abc"s);
}

TEST(CMyStringTest, CStrConstructorTestEmptySource)
{
    //arrange
    size_t size = 0;
    char* source = "";

    //act
    CMyString str = CMyString(source);

    //assert
    ASSERT_TRUE(str.GetLength() == 0);
    ASSERT_EQ(str, ""s);
}

TEST(CMyStringTest, CStrConstructorTestOneSymbolSource)
{
    //arrange
    size_t size = 1;
    char* source = "a";

    //act
    CMyString str = CMyString(source);

    //assert
    ASSERT_TRUE(str.GetLength() == 1);
    ASSERT_EQ(str, "a"s);
}

TEST(CMyStringTest, CStrWithLengthConstructorTestOneSymbolSource)
{
    //arrange
    size_t size = 1;
    const char* source = "a";

    //act
    CMyString str = CMyString(source, size);

    //assert
    ASSERT_TRUE(str.GetLength() == 1);
    ASSERT_EQ(str, "a"s);
}


TEST(CMyStringTest, CStrWithLengthConstructorTest)
{
    //arrange
    size_t size = 3;
    const char* source = "abc";

    //act
    CMyString str = CMyString(source, size);

    //assert
    ASSERT_TRUE(str.GetLength() == size);
    ASSERT_EQ(str, "abc"s);
}

TEST(CMyStringTest, CStrWithLengthConstructorTestEmptySource)
{
    //arrange
    size_t size = 0;
    const char* source = "";

    //act
    CMyString str = CMyString(source, size);

    //assert
    ASSERT_TRUE(str.GetLength() == 0);
    ASSERT_EQ(str, ""s);
}

TEST(CMyStringTest, CMyStringConstructorTestEmptySource)
{
    //arrange
    size_t size = 0;
    const char* source = "";
    CMyString sourceStr = CMyString(source, size);

    //act
    CMyString str = CMyString(sourceStr);

    //assert
    ASSERT_TRUE(str.GetLength() == 0);
    ASSERT_EQ(str, ""s);
}

TEST(CMyStringTest, CMyStringConstructorTest)
{
    //arrange
    size_t size = 3;
    const char* source = "abc";
    CMyString sourceStr = CMyString(source, size);

    //act
    CMyString str = CMyString(sourceStr);

    //assert
    ASSERT_TRUE(str.GetLength() == size);
    ASSERT_EQ(str, "abc"s);
}

TEST(CMyStringTest, CMyStringConstructorTestOneSymbolSizedSource)
{
    //arrange
    size_t size = 1;
    const char* source = "a";
    CMyString sourceStr = CMyString(source, size);

    //act
    CMyString str = CMyString(sourceStr);

    //assert
    ASSERT_TRUE(str.GetLength() == 1);
    ASSERT_EQ(str, "a"s);
}

TEST(CMyStringTest, StlStringConstructorNonEmptySource)
{
    //arrange
    string source = "source";

    //act
    CMyString str = CMyString(source);

    //assert
    ASSERT_TRUE(str.GetLength() == 6);
    ASSERT_EQ(str, "source"s);

}

TEST(CMyStringTest, StlStringConstructorEmptySource)
{
    //arrange
    string source = "";

    //act
    CMyString str = CMyString(source);

    //assert
    ASSERT_TRUE(str.GetLength() == 0);
    ASSERT_EQ(str, ""s);
}

TEST(CMyStringTest, StlStringConstructorOneSymbolSizedSource)
{
    //arrange
    string source = "a";

    //act
    CMyString str = CMyString(source);

    //assert
    ASSERT_TRUE(str.GetLength() == 1);
    ASSERT_EQ(str, "a"s);
}

TEST(CMyStringTest, ClearWithNonEmptyStr)
{
    //arrange
    CMyString str = CMyString("abc");

    //act
    str.Clear();

    //assert
    ASSERT_TRUE(str.GetLength() == 0);
}

TEST(CMyStringTest, ClearWithEmptyStr)
{
    //arrange
    CMyString str = CMyString("");

    //act
    str.Clear();

    //assert
    ASSERT_TRUE(str.GetLength() == 0);
}

TEST(CMyStringTest, SubStringWithCorrectParams)
{
    //arrange
    CMyString str = CMyString("Some string with value");

    //act
    auto res = str.SubString(0, 4);

    //assert
    ASSERT_TRUE(res.GetLength() == 4);
    ASSERT_EQ(res, "Some"s);
}

TEST(CMyStringTest, SubStringWithIncorrectStartIndex)
{
    //arrange
    CMyString str = CMyString("Some string with value");
    exception ex;

    //act
    try
    {
        auto res = str.SubString(22, 4);
    }
    catch (exception e)
    {
        ex = e;
    }

    //assert
    ASSERT_TRUE(ex.what() == "Start index is out of range"s);
}

TEST(CMyStringTest, SubStringWithIncorrectSubstringLength)
{
    //arrange
    CMyString str = CMyString("Some string with value");
    exception ex;

    //act
    try
    {
        auto res = str.SubString(0, 40);
    }
    catch (exception e)
    {
        ex = e;
    }

    //assert
    ASSERT_TRUE(ex.what() == "Size of substring you trying to get is greater than source string"s);
}

TEST(CMyStringTest, SubStringWithNoSecondValue)
{
    //arrange
    CMyString str = CMyString("Some string with value");

    //act
    auto res = str.SubString(0, 22);

    //assert    
    ASSERT_TRUE(res.GetLength() == 22);
    ASSERT_TRUE(res == "Some string with value");
}

TEST(CMyStringTest, SubStringWithNoSecondValueWithIncorrectStartIndex)
{
    //arrange
    CMyString str = CMyString("Some string with value");
    exception ex;

    //act
    try
    {
        auto res = str.SubString(22, 1);
    }
    catch (exception e)
    {
        ex = e;
    }

    //assert
    ASSERT_TRUE(ex.what() == "Start index is out of range"s);
}

TEST(CMyStringTest, AssignmentOperatorCorrectlyCopiesData)
{
    //arrange
    CMyString src = "some string";

    //act    
    CMyString str = src;

    //assert
    ASSERT_EQ(str.GetLength(), 11);
    ASSERT_EQ(str, "some string");
}

TEST(CMyStringTest, AssignmentOperatorAssignToItself)
{
    //arrange
    CMyString src = "some string";

    //act    
    src = src;

    //assert
    ASSERT_EQ(src.GetLength(), 11);
    ASSERT_EQ(src, "some string");
}

TEST(CMyStringTest, AssignmentOperatorDoesntChangeSrcString)
{
    //arrange
    CMyString src = "some string";

    //act    
    CMyString str = src;
    str = "a";

    //assert
    ASSERT_EQ(str.GetLength(), 1);
    ASSERT_EQ(str, "a");
    ASSERT_EQ(src, "some string");
}

TEST(CMyStringTest, IndexAccessToAConstantValueReturnsConstantValue)
{
    //arrange
    const CMyString src = "some string";

    //act    
    const char value = src[0];

    //assert    
    ASSERT_EQ(value, 's');
    ASSERT_TRUE(is_const<const char>::value);
}

TEST(CMyString, ConcatenationReturnsSumOfTwoString)
{
    //arrange
    CMyString str1 = "Hello ";
    CMyString str2 = "world";

    //act
    CMyString res = str1 + str2;

    //assert
    ASSERT_TRUE(res.GetLength() == 11);
    ASSERT_EQ(res, "Hello world");
}

TEST(CMyString, ConcatenationWithEmptyStringReturnsCorrectValue)
{
    //arrange
    CMyString str1 = "Non empty string";
    CMyString str2 = "";

    //act
    CMyString res = str1 + str2;

    //assert
    ASSERT_TRUE(res.GetLength() == 16);
    ASSERT_EQ(res, "Non empty string");
}

TEST(CMyString, ConcatenationOfTwoEmptyStringReturnsEmptyString)
{
    //arrange
    CMyString str1 = "";
    CMyString str2 = "";

    //act
    CMyString res = str1 + str2;

    //assert
    ASSERT_TRUE(res.GetLength() == 0);
    ASSERT_EQ(res, "");
}

TEST(CMyString, ConcatenationMultipleNumberOfStringsReturnsCorrectvalue)
{
    //arrange
    CMyString str1 = "Hello";
    CMyString str2 = " my";
    CMyString str3 = " dear friend!";

    //act
    CMyString res = str1 + str2 + str3;

    //assert
    ASSERT_TRUE(res.GetLength() == 21);
    ASSERT_EQ(res, "Hello my dear friend!");
}

TEST(CMyString, ConcatenationWithCStringReturnsCorrectValue)
{
    //arrange
    CMyString str1 = "Hello";
    CMyString str2 = " my";

    //act
    CMyString res = str1 + str2 + " dear friend!";

    //assert
    ASSERT_TRUE(res.GetLength() == 21);
    ASSERT_EQ(res, "Hello my dear friend!");
}

TEST(CMyString, AdditionalAssignmentReturnsCorrectValue)
{
    //arrange
    CMyString str1 = "Hello";
    CMyString str2 = " my";
    CMyString str3 = " dear friend!";

    //act
    str1 += str2;
    str1 += str3;

    //assert
    ASSERT_TRUE(str1.GetLength() == 21);
    ASSERT_EQ(str1, "Hello my dear friend!");
}

TEST(CMyString, AdditionalAssignmentWithEmptyStringReturnsCorrectValue)
{
    //arrange
    CMyString str1 = "Hello";
    CMyString str2 = "";
    CMyString str3 = " my dear friend!";

    //act
    str1 += str2;
    str1 += str3;

    //assert
    ASSERT_TRUE(str1.GetLength() == 21);
    ASSERT_EQ(str1, "Hello my dear friend!");
}

TEST(CMyString, AdditionalAssignmentOfEmptyStringsReturnsCorrectValue)
{
    //arrange
    CMyString str1 = "";
    CMyString str2 = "";
    CMyString str3 = "";

    //act
    str1 += str2;
    str1 += str3;

    //assert
    ASSERT_TRUE(str1.GetLength() == 0);
    ASSERT_EQ(str1, "");
}

TEST(CMyString, AdditionalAssignmentWithItselfReturnsCorrectValue)
{
    //arrange
    CMyString str1 = "hello ";

    //act
    str1 += str1;

    //assert
    ASSERT_TRUE(str1.GetLength() == 12);
    ASSERT_EQ(str1, "hello hello ");
}

TEST(CMyString, NonEqualityOperatorReturnsTrueIfStringsAreNotEqual)
{
    //arrange
    CMyString str1 = "b";
    CMyString str2 = "a";

    //act
    bool res = str1 != str2;

    //assert
    ASSERT_TRUE(res);
}

TEST(CMyString, NonEqualityOperatorReturnsFalseIfStringsAreEqual)
{
    //arrange
    CMyString str1 = "some string";
    CMyString str2 = "some string";

    //act
    bool res = str1 != str2;

    //assert
    ASSERT_FALSE(res);
}

TEST(CMyString, NonEqualityOperatorReturnsFalseIfStringsAreIdentity)
{
    //arrange
    CMyString str1 = "some string";
    CMyString str2 = str1;

    //act
    bool res = str1 != str2;

    //assert
    ASSERT_FALSE(res);
}

TEST(CMyString, GreaterReturnsFalseIfTryingToCompareIdentities)
{
    //arrange
    CMyString str1 = "some string";
    CMyString str2 = str1;

    //act
    bool res = str1 > str2;

    //assert
    ASSERT_FALSE(res);
}

TEST(CMyString, GreaterReturnsFalseIfValueLess)
{
    //arrange
    CMyString str1 = "a";
    CMyString str2 = "b";

    //act
    bool res = str1 > str2;

    //assert
    ASSERT_FALSE(res);
}

TEST(CMyString, GreaterReturnsFalseIfValueEqual)
{
    //arrange
    CMyString str1 = "a";
    CMyString str2 = "a";

    //act
    bool res = str1 > str2;

    //assert
    ASSERT_FALSE(res);
}

TEST(CMyString, GreaterReturnsTrueIfValueGreater)
{
    //arrange
    CMyString str1 = "zebra";
    CMyString str2 = "and";

    //act
    bool res = str1 > str2;

    //assert
    ASSERT_TRUE(res);
}

TEST(CMyString, GreaterReturnsTrueIfValueGreaterInLexic)
{
    //arrange
    CMyString str1 = "abc";
    CMyString str2 = "ab";

    //act
    bool res = str1 > str2;

    //assert
    ASSERT_TRUE(res);
}

TEST(CMyString, LessReturnsFalseIfTryingToCompareIdentities)
{
    //arrange
    CMyString str1 = "some string";
    CMyString str2 = str1;

    //act
    bool res = str1 < str2;

    //assert
    ASSERT_FALSE(res);
}

TEST(CMyString, LessReturnsFalseIfValueGreater)
{
    //arrange
    CMyString str1 = "b";
    CMyString str2 = "a";

    //act
    bool res = str1 < str2;

    //assert
    ASSERT_FALSE(res);
}

TEST(CMyString, LessReturnsFalseIfValueEqual)
{
    //arrange
    CMyString str1 = "a";
    CMyString str2 = "a";

    //act
    bool res = str1 < str2;

    //assert
    ASSERT_FALSE(res);
}

TEST(CMyString, LessReturnsTrueIfValueLess)
{
    //arrange
    CMyString str1 = "b";
    CMyString str2 = "a";

    //act
    bool res = str2 < str1;

    //assert
    ASSERT_TRUE(res);
}

TEST(CMyString, LessReturnsTrueIfValueLessInLexic)
{
    //arrange
    CMyString str1 = "abracadabra";
    CMyString str2 = "zebra";

    //act
    bool res = str1 < str2;

    //assert
    ASSERT_TRUE(res);
}

TEST(CMyString, GreaterReturnsFalseIfValueLessInLexical)
{
    //arrange
    CMyString str1 = "abracadabra";
    CMyString str2 = "zebra";

    //act
    bool res = str1 > str2;

    //assert
    ASSERT_FALSE(res);
}

TEST(CMyString, LessReturnsFalseIfValueGreaterInLexical)
{
    //arrange
    CMyString str1 = "zebra";
    CMyString str2 = "and";

    //act
    bool res = str1 < str2;

    //assert
    ASSERT_FALSE(res);
}

TEST(CMyString, LessReturnsTrueIfValueLessInLexicButEqualsBySize)
{
    //arrange
    CMyString str1 = "zebaa";
    CMyString str2 = "zebra";

    //act
    bool res = str1 < str2;

    //assert
    ASSERT_TRUE(res);
}

TEST(CMyString, LessReturnsFalseIfValueLessInLexicButEqualsBySize)
{
    //arrange
    CMyString str1 = "zebsa";
    CMyString str2 = "zebra";

    //act
    bool res = str1 < str2;

    //assert
    ASSERT_FALSE(res);
}

TEST(CMyString, SubStringReturnsCorrectValueIfStringContainsZeroChars)
{
    //arrange
    CMyString str = "abc\0abc"s;

    //act
    auto res = str.SubString(0, 5);

    //assert
    ASSERT_EQ(res, "abc\0a"s);
}