using MyDictionary;
using NUnit.Framework;

namespace MyDictionaryTests
{
    public class MyDictionaryTests
    {
        private string _existingFilePath = @"C:\Users\danik\source\repos\oop\MyDictionary\Dictionaries\dictionary.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MyDictionary_Constructor_ExistingFilePath_CreatesCorrectObject()
        {
            //Arrange
            WordDictionary dictionary;

            //Act
            dictionary = new WordDictionary( _existingFilePath );

            //Assert

        }
    }
}