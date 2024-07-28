using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionarySwitchStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a new dictionary to store key-value pairs
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            bool exit = false;

            //Menu loop
            while (!exit)
            {
                //Display menu options
                Console.WriteLine("Choose an option:");     
                Console.WriteLine("a. Populate the Dictionary");
                Console.WriteLine("b. Display Dictionary Contents");
                Console.WriteLine("c. Remove a Key");
                Console.WriteLine("d. Add a New Key and Value");
                Console.WriteLine("e. Add a Value to an Existing Key");
                Console.WriteLine("f. Sort the Keys");
                Console.WriteLine("g. Exit");
                
                //Reads user input
                string choice = Console.ReadLine();

                //Switch statement to perform action based on user input
                switch (choice)
                {
                    case "a":
                        PopulateDictionary(dictionary);
                        break;
                    case "b":
                        DisplayDictionaryContents(dictionary);
                        break;
                    case "c":
                        RemoveKey(dictionary);
                        break;
                    case "d":
                        AddNewKeyValue(dictionary);
                        break;
                    case "e":
                        AddValueToExistingKey(dictionary);
                        break;
                    case "f":
                        SortKeys(dictionary);
                        break;
                    case "g":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        //Method to populate the dictionary with a new key and list of values
        static void PopulateDictionary(Dictionary<string, List<string>> dict)
        {
            Console.WriteLine("Enter key:");
            string key = Console.ReadLine();

            Console.WriteLine("Enter value (comma-separated if multiple):");
            string[] values = Console.ReadLine().Split(',');

            // Add the key and values to the dictionary if the key doesn't already exist
            if (!dict.ContainsKey(key))
            {
                dict[key] = new List<string>(values);
            }
            else
            {
                Console.WriteLine("Key already exists.");
            }
        }

        //Method to display contents of the dictionary
        static void DisplayDictionaryContents(Dictionary<string, List<string>> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"Key: {item.Key}, Values: {string.Join(", ", item.Value)}");
            }
        }

        //Method to remove a key from the dictionary
        static void RemoveKey(Dictionary<string, List<string>> dict)
        {
            Console.WriteLine("Enter key to remove:");
            string key = Console.ReadLine();

            //Checks if the key exists, then removes it if it does
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
                Console.WriteLine("Key removed.");
            }
            else
            {
                Console.WriteLine("Key not found.");
            }
        }

        // Method to add a new key and a single value to the dictionary
        static void AddNewKeyValue(Dictionary<string, List<string>> dict)
        {
            Console.WriteLine("Enter new key:");
            string key = Console.ReadLine();

            Console.WriteLine("Enter value:");
            string value = Console.ReadLine();

            //Checks if the key already exists, then adds it if it doesn't
            if (!dict.ContainsKey(key))
            {
                dict[key] = new List<string> { value };
            }
            else
            {
                Console.WriteLine("Key already exists.");
            }
        }

        // Method to add a value to an existing key in the dictionary
        static void AddValueToExistingKey(Dictionary<string, List<string>> dict)
        {
            Console.WriteLine("Enter key to add value to:");
            string key = Console.ReadLine();
            
            //Checks if the key exists, then adds a value to it if it does
            if (dict.ContainsKey(key))
            {
                Console.WriteLine("Enter value to add:");
                string value = Console.ReadLine();
                dict[key].Add(value);
            }
            else
            {
                Console.WriteLine("Key not found.");
            }
        }

        // Method to sort the keys in the dictionary
        static void SortKeys(Dictionary<string, List<string>> dict)
        {
            // Sort the dictionary by keys and create a new sorted dictionary
            var sortedDict = dict.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            dict.Clear();
            foreach (var kvp in sortedDict)
            {
                dict[kvp.Key] = kvp.Value;
            }

            Console.WriteLine("Keys sorted.");
        }
    }
}
