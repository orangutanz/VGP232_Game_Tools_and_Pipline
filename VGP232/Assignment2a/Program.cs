using System;
using System.Collections.Generic;
using System.IO;

// TODO: Fill in your name and student number.
// Assignment 1
// NAME: Yuhan Ma
// STUDENT NUMBER: 1930014

// MARKS: 99/100 Excellent work! When storing the sortColumnName, it does not need the validation as it's also done in the switch case statement before sort is called, but the default case should be when it doesn't trigger sort. Remember for the next assignment int.Parse will throw an exception, so you want to wrap it in a try-catch.

// Does it compile? Yes
// Does it produce the correct results? Yes

namespace Assignment2a
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Commands for testing
            //args = new string[]{ "-i", "data.csv", "-o", "output.csv", "-c", "-s", "BaseAttack" };//for assignment1
            //args = new string[]{ "-i", "data.csv", "-o", "output.csv" };//for testing

            // Variables and flags

            // The path to the input file to load.
            string inputFile = string.Empty;

            // The path of the output file to save.
            string outputFile = string.Empty;

            // The flag to determine if we overwrite the output file or append to it.
            bool appendToFile = false;

            // The flag to determine if we need to display the number of entries
            bool displayCount = false;

            // The flag to determine if we need to sort the results via name.
            bool sortEnabled = false;

            // The column name to be used to determine which sort comparison function to use.
            string sortColumnName = string.Empty;

            // The results to be output to a file or to the console
            List<Weapon> results = new List<Weapon>();

            for (int i = 0; i < args.Length; i++)
            {
                // h or --help for help to output the instructions on how to use it
                if (args[i] == "-h" || args[i] == "--help")
                {
                    Console.WriteLine("-i <path> or --input <path> : loads the input file path specified (required)");
                    Console.WriteLine("-o <path> or --output <path> : saves result in the output file path specified (optional)");
                    Console.WriteLine("-c or --count : displays the number of entries in the input file (optional)");
                    Console.WriteLine("-a or --append : enables append mode when writing to an existing output file (optional)");
                    Console.WriteLine("-s or --sort <column name> : outputs the results sorted by column name");

                    break;
                }
                else if (args[i] == "-i" || args[i] == "--input")
                {
                    // Check to make sure there's a second argument for the file name.
                    if (args.Length > i + 1)
                    {
                        // stores the file name in the next argument to inputFile
                        ++i;
                        inputFile = args[i];

                        if (string.IsNullOrEmpty(inputFile))
                        {
                            Console.WriteLine("Error. No input file specified.");
                        }
                        else if (!File.Exists(inputFile))
                        {
                            Console.WriteLine("Error. File does not exist.");
                        }
                        else
                        {
                            // This function returns a List<Weapon> once the data is parsed.
                            results = Parse(inputFile);
                        }
                    }
                }
                else if (args[i] == "-s" || args[i] == "--sort")
                {
                    sortEnabled = true;
                    ++i;

                    // LC: could remove the check because you do it again in line 127
                    if (args[i] == "Name" || args[i] == "Type" || args[i] == "Rarity" || args[i] == "BaseAttack")
                    {
                        sortColumnName = args[i];
                    }
                }
                else if (args[i] == "-c" || args[i] == "--count")
                {
                    displayCount = true;
                }
                else if (args[i] == "-a" || args[i] == "--append")
                {
                    appendToFile = true;
                }
                else if (args[i] == "-o" || args[i] == "--output")
                {
                    // validation to make sure we do have an argument after the flag
                    if (args.Length > i + 1)
                    {
                        // increment the index.
                        ++i;
                        string filePath = args[i];
                        if (string.IsNullOrEmpty(filePath))
                        {
                            Console.WriteLine("Error. File not specified.");
                        }
                        else
                        {
                            outputFile = filePath;
                            // TODO: set the output file to the outputFile
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The argument Arg[{0}] = [{1}] is invalid", i, args[i]);
                }
            }

            if (sortEnabled)
            {
                // TODO: add implementation to determine the column name to trigger a different sort. (Hint: column names are the 4 properties of the weapon class)
                switch (sortColumnName)
                {
                    case "Name":
                        results.Sort(Weapon.CompareByName);
                        Console.WriteLine("Sorting by Name.");
                        break;
                    case "Type":
                        results.Sort(Weapon.CompareByType);
                        Console.WriteLine("Sorting by Type.");
                        break;
                    case "Rarity":
                        results.Sort(Weapon.CompareByRarity);
                        Console.WriteLine("Sorting by Rarity.");
                        break;
                    case "BaseAttack":
                        results.Sort(Weapon.CompareByBaseAttack);
                        Console.WriteLine("Sorting by BaseAttack.");
                        break;
                    // LC: the default case can be the invalid choice where it prints invalid column name and not sort.
                    default:
                        results.Sort(Weapon.CompareByName);
                        Console.WriteLine("Sorting by Name.");
                        break;
                }
                // print: Sorting by <column name> e.g. BaseAttack

                // Sorts the list based off of the Weapon name.
            }

            if (displayCount)
            {
                Console.WriteLine("There are {0} entries", results.Count);
            }

            if (results.Count > 0)
            {
                if (!string.IsNullOrEmpty(outputFile))
                {
                    FileStream fs;

                    // Check if the append flag is set, and if so, then open the file in append mode; otherwise, create the file to write.
                    if (appendToFile && File.Exists((outputFile)))
                    {
                        Console.WriteLine("Output append to existing file.");
                        fs = File.Open(outputFile, FileMode.Append);
                    }
                    else
                    {
                        Console.WriteLine("Output to created new file.");
                        fs = File.Open(outputFile, FileMode.Create);
                    }

                    // opens a stream writer with the file handle to write to the output file.
                    using (StreamWriter writer = new StreamWriter(fs))
                    {

                        // Hint: use writer.WriteLine
                        // TODO: write the header of the output "Name,Type,Rarity,BaseAttack"
                        writer.WriteLine("Name,Type,Rarity,BaseAttack");

                        // LC: naming: use weapon instead of i and you don't need to call ToString() explicitly as it'll automatically invoke the ToString()
                        foreach (var i in results)
                        {
                            writer.WriteLine(i.ToString());
                        }

                        // TODO: print out the file has been saved.
                        Console.WriteLine("Output file has been saved.");
                    }
                }
                else
                {
                    // prints out each entry in the weapon list results.
                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.WriteLine(results[i]);
                    }
                }
            }

            Console.WriteLine("Done!");
        }

        /// <summary>
        /// Reads the file and line by line parses the data into a List of Weapons
        /// </summary>
        /// <param name="fileName">The path to the file</param>
        /// <returns>The list of Weapons</returns>
        public static List<Weapon> Parse(string fileName)
        {
            // TODO: implement the streamreader that reads the file and appends each line to the list
            // note that the result that you get from using read is a string, and needs to be parsed 
            // to an int for certain fields i.e. HP, Attack, etc.
            // i.e. int.Parse() and if the results cannot be parsed it will throw an exception
            // or can use int.TryParse() 

            // streamreader https://msdn.microsoft.com/en-us/library/system.io.streamreader(v=vs.110).aspx
            // Use string split https://msdn.microsoft.com/en-us/library/system.string.split(v=vs.110).aspx

            List<Weapon> output = new List<Weapon>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                // Skip the first line because header does not need to be parsed.
                // Name,Type,Rarity,BaseAttack

                string header = reader.ReadLine();

                // The rest of the lines looks like the following:
                // Skyward Blade,Sword,5,46
                while (reader.Peek() > 0)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    Weapon weapon = new Weapon();
                    if (values.Length == 4)
                    {
                        weapon.Name = values[0];
                        weapon.Type = values[1];
                        weapon.Rarity = int.Parse(values[2]);
                        weapon.BaseAttack = int.Parse(values[3]);
                    }
                    output.Add(weapon);
                }
            }

            return output;
        }
    }
}
