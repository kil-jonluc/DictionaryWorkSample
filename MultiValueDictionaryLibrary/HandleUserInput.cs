using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MultiValueDictionaryLibrary
{
    public class HandleUserInput : IHandleUserInput
    {
        private readonly IDictionaryCommands _dictionaryCommands;
        private readonly IValidateUserInput _validateUserInput;
        public HandleUserInput(IDictionaryCommands dictionaryCommands,
            IValidateUserInput validateUserInput)
        {
            _dictionaryCommands = dictionaryCommands;
            _validateUserInput = validateUserInput;
        }

        public void Handle(Dictionary<string, List<string>> demoDictionary, string input)
        {
            string[] inputArray = UserInputToArray(input);
            DetermineDictionaryCommand(demoDictionary, inputArray);
        }


        /// <summary>
        ///Converting User input to string array
        /// </summary>
        public string[] UserInputToArray(string input)
        {
            return input.Split(" ");
        }

        public void DetermineDictionaryCommand(Dictionary<string, List<string>> demoDictionary, string[] inputArray)
        {
            var command = inputArray[0];
            switch (command.ToUpper())
            {
                case "ADD":
                    if (!_validateUserInput.ValidateArrayLength(inputArray, 3))
                    {
                        break;
                    }
                    _dictionaryCommands.Add(demoDictionary, inputArray[1], inputArray[2]);
                    break;
                case "KEYS":
                    _dictionaryCommands.Keys(demoDictionary);
                    break;
                case "MEMBERS":
                    if (!_validateUserInput.ValidateArrayLength(inputArray, 2))
                    {
                        break;
                    }
                    _dictionaryCommands.Members(demoDictionary, inputArray[1]);
                    break;
                case "REMOVE":
                    if (!_validateUserInput.ValidateArrayLength(inputArray, 3))
                    {
                        break;
                    }
                    _dictionaryCommands.Remove(demoDictionary, inputArray[1], inputArray[2]);
                    break;
                case "REMOVEALL":
                    if (!_validateUserInput.ValidateArrayLength(inputArray, 2))
                    {
                        break;
                    }
                    _dictionaryCommands.RemoveAll(demoDictionary, inputArray[1]);
                    break;
                case "CLEAR":
                    _dictionaryCommands.Clear(demoDictionary);
                    break;
                case "KEYEXISTS":
                    if (!_validateUserInput.ValidateArrayLength(inputArray, 2))
                    {
                        break;
                    }
                    _dictionaryCommands.KeyExists(demoDictionary, inputArray[1]);
                    break;
                case "MEMBEREXISTS":
                    if (!_validateUserInput.ValidateArrayLength(inputArray, 3))
                    {
                        break;
                    }
                    _dictionaryCommands.MemberExists(demoDictionary, inputArray[1], inputArray[2]);
                    break;
                case "ALLMEMBERS":
                    _dictionaryCommands.AllMembers(demoDictionary);
                    break;
                case "ITEMS":
                    _dictionaryCommands.Items(demoDictionary);
                    break;
                default:
                    Console.WriteLine(") Invalid Command");
                    break;
            }
        }
    }
}
