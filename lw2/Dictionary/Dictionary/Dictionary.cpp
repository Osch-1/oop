#include "pch.h"

const int REQUIRED_ARGUMENTS_NUMBER = 2;

using namespace std;

struct Arguments
{
    string dictionaryFileName;
};

struct Dictionary
{
    map<string, set<string>> wordsMappings;
};

Arguments FormArguments(const string& inputFileName)
{
    Arguments arguments;

    arguments.dictionaryFileName = inputFileName;

    return arguments;
}

optional<Arguments> ParseInputArgs(int argc, char* argv[])
{
    if (argc != REQUIRED_ARGUMENTS_NUMBER)
    {
        return nullopt;
    }

    return FormArguments(argv[1]);
}

void AddWordMapping(Dictionary& dictionary, const string& word, set<string>& translates)
{
    auto keyValuePair = dictionary.wordsMappings.find(word);

    if (keyValuePair != dictionary.wordsMappings.end())
    {
        keyValuePair->second.merge(translates);
    }
    else
    {
        dictionary.wordsMappings.insert({ word, translates });
    }
}

Dictionary LoadDictionaryFromFile(ifstream& inputFile)
{
    Dictionary dictionary;

    while (!inputFile.eof())
    {
        string word;
        inputFile >> word;

        string buffer;
        getline(inputFile, buffer);

        set<string> translates(buffer.begin(), buffer.end());

        AddWordMapping(dictionary, word, translates);
    }

    return dictionary;
}

int main(int argc, char* argv[])
{
    auto args = ParseInputArgs(argc, argv);

    if (!args)
    {
        cout << "Incorrect number of arguments have been provided - " << argc << ". Required params number - " << REQUIRED_ARGUMENTS_NUMBER << endl;
        cout << "Make sure sure that your running command matches this pattern: dictionary.exe <dictionaryFileName>" << endl;

        return 1;
    }

    ifstream input;
    input.open(args->dictionaryFileName);
    if (!input.is_open())
    {
        cout << "Couldn't open " << argv[1] << " for reading." << endl;
        return 1;
    }


}