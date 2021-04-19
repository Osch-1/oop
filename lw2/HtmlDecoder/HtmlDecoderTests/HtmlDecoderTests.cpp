#include "pch.h"
#include "HtmlDecoder/HtmlDecoder/HtmlDecode.h"
#include "catch2/catch.hpp"

TEST_CASE("HtmlDecode() returns empty string if empty string provided")
{
    //arrange
    string emptyString;

    //act
    string result = HtmlDecode(emptyString);

    //assert
    CHECK(result == "");
}

TEST_CASE("HtmlDecode() correctly decode all encoded html entities in string")
{
    //arrange
    string encodedHtmlLine = "&& &&lt;; &lt;input type=&quot;text&quot; id=&quot;lname&quot; name=&quot;lname&quot;&gt; \\\\&apos;cool string&apos;";

    //act
    string result = HtmlDecode(encodedHtmlLine);

    //assert
    CHECK(result == "&& &<; <input type=\"text\" id=\"lname\" name=\"lname\"> \\\\'cool string'");
}