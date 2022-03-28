namespace MultiValueDictionaryLibrary.Services
{
    /// <summary>
    /// Service for Writing text to the console
    /// Notes: honestly I wrote it initially because two of my unit tests were not passing because the string writer output 
    /// was getting text from a different test in the assert. But it would be good way to interchange where output was written to
    /// if application wanted to write to say a text file instead of the console it would be easy to do this way. 
    /// </summary>
    public interface IWritingService
    {
        void Write(string text);
        void WriteLine(string text);
    }
}