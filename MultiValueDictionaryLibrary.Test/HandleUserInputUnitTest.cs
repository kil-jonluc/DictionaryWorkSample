using FluentAssertions;
using System;
using System.Linq;
using Xunit;
using MultiValueDictionaryLibrary;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace MultiValueDictionaryLibrary.Test
{
    public class HandleUserInputUnitTest
    {
        private readonly Mock<IDictionaryCommands> _mockDictionaryCommands;
        private readonly Mock<IValidateUserInput> _mockValidateUserInput;

        public HandleUserInputUnitTest()
        {
            _mockDictionaryCommands = new Mock<IDictionaryCommands>();
            _mockValidateUserInput = new Mock<IValidateUserInput>();
        }

        private HandleUserInput BuildMockInstance()
        {
            return new HandleUserInput(_mockDictionaryCommands.Object, _mockValidateUserInput.Object);
        }
        [Fact]
        public void UserInputToArray()
        {
            //arrange
            string test = "ADD foo bar";
            var sut = BuildMockInstance();

            //act
            var result = sut.UserInputToArray(test);

            //assert
            result.Count().Should().Be(3);
        }


        [Theory]
        [InlineData("ADD")]
        [InlineData("KEYS")]
        public void DetermineDictionaryCommand(string command)
        {
            //arrange
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>()
            {
                { "testKey1", new List<string>{"testValue1" }},
                { "testKey2", new List<string>{"testValue2" }}
            };
            var testArray = new string[] { command, "Foo", "Bar" };
            var sut = BuildMockInstance();

            var addTest = false;
            var keysTest = false;
            if (command == "ADD")
            {
                _mockDictionaryCommands.Setup(x => x.Add(It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<string>(), It.IsAny<string>())).Callback(() => addTest = true);
            }
            if (command == "KEYS")
            {
                _mockDictionaryCommands.Setup(x => x.Keys(It.IsAny<Dictionary<string, List<string>>>())).Callback(() => keysTest = true);
            }

            //act
            sut.DetermineDictionaryCommand(dictionary, testArray);

            //assert
            if (command == "ADD")
            {
                addTest.Should().BeTrue();
            }
            if (command == "KEYS")
            {
                keysTest.Should().BeTrue();
            }

        }
    }
}
