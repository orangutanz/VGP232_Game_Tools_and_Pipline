using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

// TODO: Fill in your name and student number.
// Assignment 2a
// NAME: Yuhan Ma
// STUDENT NUMBER: 1930014

// MARKS: 78/100 Good work! The WeaponCollection.Load needs to clear before it populates the elements. The Weapon.ToString the image property is not in the correct column.  The SortBy function should be invoked in Program.cs. The majority of the tests aren't running because it's not using the inputPath/outputPath and it's not calling Load in the setup function and the TryParse test should be using AreEqual instead of Equals. Please look for the // LC2 comments to find out how to fix them before you start on Assignment 2B.
// Does it compile? Yes
// Does it produce the correct results? Yes
// Does all the tests pass? No. 2/10 tests passed

namespace Assignment2b
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Commands for testing
            //args = new string[]{ "-i", "data2.csv", "-o", "output.csv", "-c", "-s", "BaseAttack" };//for assignment1
            //args = new string[]{ "-i", "data2.csv", "-o", "output.csv" };//for testing

            // LC2: you don't invoke the unit tests from main, you run them from the test explorer.


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
                // LC2: should be invoking the results.SortBy(sortColumnName);

                switch (sortColumnName)
                {
                    case "Name":
                        results.SortBy(sortColumnName);
                        Console.WriteLine("Sorting by Name.");
                        break;
                    case "Type":
                        results.SortBy(sortColumnName);
                        Console.WriteLine("Sorting by Type.");
                        break;
                    case "Rarity":
                        results.SortBy(sortColumnName);
                        Console.WriteLine("Sorting by Rarity.");
                        break;
                    case "BaseAttack":
                        results.SortBy(sortColumnName);
                        Console.WriteLine("Sorting by BaseAttack.");
                        break;
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
                // LC2: nice that you added check to append, but we will ditch append in this assignment2a and and 2b
                if (!string.IsNullOrEmpty(outputFile) && appendToFile)
                {
                    results.SaveAppend(outputFile);
                }
                else if (!string.IsNullOrEmpty(outputFile))
                {
                    results.Save(outputFile);
                }
                else
                {
                    // prints out each entry in the weapon list results.
                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.WriteLine(results[i]);
                    }
                    Console.WriteLine("Not saved to file.");
                }
            }

            Console.WriteLine("Done!");
        }

    }
}
