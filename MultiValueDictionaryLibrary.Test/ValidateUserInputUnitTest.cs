using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MultiValueDictionaryLibrary.Test
{
    public class ValidateUserInputUnitTest
    {

        public ValidateUserInputUnitTest()
        {
        }

        private ValidateUserInput BuildMockInstance()
        {
            return new ValidateUserInput();
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(2, false)]
        public void ValidateArrayLength(int length, bool valid)
        {
            //arrange
            var testArray = new string[] { "ADD", "key", "value" };

            using (var stringWriter = new StringWriter())
            {

                Console.SetOut(stringWriter);

                var sut = BuildMockInstance();

                //act
                var result = sut.ValidateArrayLength(testArray, length);

                //assert
                if (!valid)
                {
                    result.Should().BeFalse();
                    stringWriter.ToString().Trim().Should().Be(") ERROR, Unexpected command phrase, please try again.");
                }
                else
                {
                    result.Should().BeTrue();
                }
            
            }
        }


    }
}
