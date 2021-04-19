#include "pch.h"
#include "HtmlDecode.h"
#include <unordered_map>

string HtmlDecode(const string& html)
{
    string result = html;
    unordered_map<string, string> htmlEntitiyToEncodedValue;

    htmlEntitiyToEncodedValue =
    { { "&quot;", "\"" },
    { "&apos;", "'" },
    { "&amp;", "&" },
    { "&gt;", ">" },
    { "&lt;", "<" } };

    for (auto& it : htmlEntitiyToEncodedValue)
    {
        regex encodedHtmlEntitiesExpression(it.first);

        result = regex_replace(result, encodedHtmlEntitiesExpression, it.second);
    }

    return result;
}