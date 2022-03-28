using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MultiValueDictionaryLibrary;
using FluentAssertions;
using Moq;

namespace MultiValueDictionaryLibrary.Test
{
    public class HandleUserInputUnitTest
    {
     
        [Fact]
        public void UserInputToArray()
        {
            //arrange
            string test = "ADD foo bar";

            //act
            var result = HandleUserInput.UserInputToArray(test);

            //assert
            Assert.Equal(3, result.Count());//Count().Should().Be(3);
        }
    }
}
