namespace MultiValueDictionaryLibrary
{
    public interface IValidateUserInput
    {
        bool ValidateArrayLength(string[] inputArray, int expectedLength);
    }
}