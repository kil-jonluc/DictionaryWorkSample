using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryLibrary
{
    public class ValidateUserInput : IValidateUserInput
    {
        //validate that index one is a valid command
        //validate that the length of the input is correct based on the command that is entered run the validation methods prior to running the command methods
        public ValidateUserInput()
        {
        }

        public bool ValidateArrayLength(string[] inputArray, int expectedLength)
        {
            var valid = true;
            if (inputArray.Length != expectedLength)
            {
                valid = false;
                //error message
                Console.WriteLine(") ERROR, Unexpected command phrase, please try again.");
            }
            return valid;
        }
    }
}
