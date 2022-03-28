using System.Collections.Generic;

namespace MultiValueDictionaryLibrary
{
    public interface IHandleUserInput
    {
        /// <summary>
        /// Handles the user input from the console
        /// </summary>
        /// <param name="DemoDictionary"></param>
        /// <param name="input"></param>
        void Handle(Dictionary<string, List<string>> DemoDictionary, string input);
    }
}