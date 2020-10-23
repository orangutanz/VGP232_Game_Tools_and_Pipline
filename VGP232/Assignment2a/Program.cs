using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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
            args = new string[]{ "-i", "data2.csv", "-o", "output.csv", "-c", "-s", "BaseAttack" };//for assignment1
            //args = new string[]{ "-i", "data2.csv", "-o", "output.csv" };//for testing

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
            WeaponCollection results = new WeaponCollection();      

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
                            results.Load(inputFile);
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
                        Console.WriteLine("Invalid sort name. Not sorted.");
                        break;
                }
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

                        writer.WriteLine("Name,Type,Image,Rarity,BaseAttack,SecondaryStat,Passive");

                        // LC: naming: use weapon instead of i and you don't need to call ToString() explicitly as it'll automatically invoke the ToString()
                        foreach (var weapon in results)
                        {
                            writer.WriteLine(weapon);
                        }

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

    }
}
