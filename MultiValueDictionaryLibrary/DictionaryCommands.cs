using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionaryLibrary
{
    public class DictionaryCommands : IDictionaryCommands
    {
        public DictionaryCommands()
        {
        }

        public void Add(Dictionary<string, List<string>> demoDictionary, string key, string value)
        {
            // add command logic
            // -- if the key already exists 
            if (demoDictionary.ContainsKey(key))
            {
                List<string> valueList;
                demoDictionary.TryGetValue(key, out valueList);
                valueList.Add(value);
            }
            // -- if the key is new
            else
            {
                demoDictionary.Add(key, new List<string>() { value });

            }

            // Add command console print response 
            Console.WriteLine(") Added");
        }
        public void Keys(Dictionary<string, List<string>> demoDictionary)
        {
            int count = 1;
            if (demoDictionary.Keys.Count == 0)
            {
                Console.WriteLine(") empty set");
            }
            else
            {
                // Keys command console print response
                foreach (var key in demoDictionary)
                {
                    Console.WriteLine($"{count}) {key.Key}");
                    count++;
                }
            }
        }

        public void Members(Dictionary<string, List<string>> demoDictionary, string key)
        {
            int count = 1;
            if (DictionaryHasKey(demoDictionary, key))
            {
                // Keys command console print response
                List<string> valueList;
                demoDictionary.TryGetValue(key, out valueList);
                foreach (var value in valueList)
                {
                    Console.WriteLine($"{count}) {value}");
                    count++;
                }
            }
        }

        public void Remove(Dictionary<string, List<string>> demoDictionary, string key, string value)
        {
            if (DictionaryHasKey(demoDictionary, key))
            {
                List<string> valueList;
                demoDictionary.TryGetValue(key, out valueList);

                if (valueList.Any(x => x == value))
                {
                    valueList.RemoveAll(x => x == value);
                    Console.WriteLine(") Removed");
                }
                else
                {
                    Console.WriteLine(") ERROR, member does not exist.");
                }

                if (valueList.Count == 0)
                {
                    demoDictionary.Remove(key);
                }
                // Add command console print response 
            }

        }

        public void RemoveAll(Dictionary<string, List<string>> demoDictionary, string key)
        {
            if (DictionaryHasKey(demoDictionary, key))
            {
                demoDictionary.Remove(key);
                Console.WriteLine(") Removed");
            }
        }
        public void Clear(Dictionary<string, List<string>> demoDictionary)
        {
            demoDictionary.Clear();
            Console.WriteLine(") Cleared");

        }

        public void KeyExists(Dictionary<string, List<string>> demoDictionary, string key)
        {
            Console.WriteLine($") {(demoDictionary.ContainsKey(key) ? "true" : "false")}");
        }

        public void MemberExists(Dictionary<string, List<string>> demoDictionary, string key, string value)
        {
            var result = "true";
            if (demoDictionary.ContainsKey(key))
            {
                List<string> valueList;
                demoDictionary.TryGetValue(key, out valueList);
                if (!valueList.Any(x => x == value))
                {
                    result = "false";
                }
            }
            else
            {
                result = "false";
            }
            Console.WriteLine($") {result}");

        }

        public void AllMembers(Dictionary<string, List<string>> demoDictionary)
        {
            int count = 1;
            if (demoDictionary.Any(x => x.Value.Any()))
            {
                foreach (var key in demoDictionary)
                {
                    foreach (var value in key.Value)
                    {
                        Console.WriteLine($"{count}) {value}");
                        count++;
                    }
                }
            }
            else
            {
                Console.WriteLine(") empty set");
            }
        }

        public void Items(Dictionary<string, List<string>> demoDictionary)
        {
            int count = 1;
            if (demoDictionary.Any(x => x.Value.Any()))
            {
                foreach (var key in demoDictionary)
                {
                    foreach (var value in key.Value)
                    {
                        Console.WriteLine($"{count}) {key.Key}: {value}");
                        count++;
                    }
                }
            }
            else
            {
                Console.WriteLine(") empty set");
            }
        }




        private bool DictionaryHasKey(Dictionary<string, List<string>> demoDictionary, string key)
        {
            var exists = true;
            if (!demoDictionary.ContainsKey(key))
            {
                Console.WriteLine(") ERROR, key does not exist.");
                exists = false;
            }
            return exists;
        }
    }
}
