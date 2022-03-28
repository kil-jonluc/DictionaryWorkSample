using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryLibrary
{
    public interface IDictionaryCommands
    {
        /// <summary>
        /// Adds a key value pair to a dictionary
        /// </summary>
        /// <param name="demoDictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Add(Dictionary<string, List<string>> demoDictionary, string key, string value);

        /// <summary>
        /// Writes all the keys of a dictionary to the console
        /// </summary>
        /// <param name="demoDictionary"></param>
        void Keys(Dictionary<string, List<string>> demoDictionary);

        /// <summary>
        /// Returns the collection of strings for the given key
        /// </summary>
        /// <param name="demoDictionary"></param>
        /// <param name="key"></param>
        void Members(Dictionary<string, List<string>> demoDictionary, string key);

        /// <summary>
        /// Removes a member from a key. If the last member is removed from the key, the key is removed from the dictionary
        /// </summary>
        /// <param name="demoDictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Remove(Dictionary<string, List<string>> demoDictionary, string key, string value);

        /// <summary>
        /// Removes all members for a key and removes the key from the dictionary
        /// </summary>
        /// <param name="demoDictionary"></param>
        /// <param name="key"></param>
        void RemoveAll(Dictionary<string, List<string>> demoDictionary, string key);

        /// <summary>
        /// Removes all keys and all members from the dictionary
        /// </summary>
        /// <param name="demoDictionary"></param>
        void Clear(Dictionary<string, List<string>> demoDictionary);

        /// <summary>
        /// Returns whether a key exists or not
        /// </summary>
        /// <param name="demoDictionary"></param>
        /// <param name="Key"></param>
        void KeyExists(Dictionary<string, List<string>> demoDictionary, string Key);
        /// <summary>
        /// Returns whether a member exists within a ke
        /// </summary>
        /// <param name="demoDictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void MemberExists(Dictionary<string, List<string>> demoDictionary, string key, string value);
        //void AllMembers(Dictionary<string, List<string>> demoDictionary);
        //void Items(Dictionary<string, List<string>> demoDictionary);
    }
}
