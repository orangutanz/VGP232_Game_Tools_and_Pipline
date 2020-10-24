using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;

namespace Assignment2a
{
    public class WeaponCollection : List<Weapon>, IPeristence
    {
        public int GetHighestBaseAttack()
        {
            int result = 0;
            foreach (var i in this)
            {
                if(i.BaseAttack > result)
                {
                    result = i.BaseAttack;
                }
            }
            return result;
        }
        public int GetLowestBaseAttack()
        {
            int result = 999999999;
            if (this.Count == 0)
                return 0;
            foreach (var i in this)
            {
                if (i.BaseAttack < result)
                {
                    result = i.BaseAttack;
                }
            }
            return result;
        }
        public List<Weapon> GetAllWeaponsOfType(WeaponType type)
        {
            List<Weapon> result = new List<Weapon>();
            foreach (var i in this)
            {
                if (i.Type == type)
                {
                    result.Add(i);
                }
            }
            return result;
        }
        public List<Weapon> GetAllWeaponsOfRarity(int stars)
        {
            List<Weapon> result = new List<Weapon>();
            foreach (var i in this)
            {
                if (i.Rarity == stars)
                {
                    result.Add(i);
                }
            }
            return result;
        }
        public void SortBy(string columnName)
        {
            switch(columnName)
            {
                case "Name":                    
                    this.Sort(Weapon.CompareByName);
                    Console.WriteLine("Sorting by Name.");
                    break;
                case "Type":
                    this.Sort(Weapon.CompareByType);
                    Console.WriteLine("Sorting by Type.");
                    break;
                case "Rarity":
                    this.Sort(Weapon.CompareByRarity);
                    Console.WriteLine("Sorting by Rarity.");
                    break;
                case "BaseAttack":
                    this.Sort(Weapon.CompareByBaseAttack);
                    Console.WriteLine("Sorting by BaseAttack.");
                    break;
                default:                    
                    Console.WriteLine("Invalid sorting. Did not sort.");
                    break;
            }
        }

        public bool Save(string outputFile)
        {
            FileStream fs;
            fs = File.Open(outputFile, FileMode.Create);
            Console.WriteLine("Output is saved to a new file.");

            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine("Name,Type,Image,Rarity,BaseAttack,SecondaryStat,Passive");
                foreach (var weapon in this)
                {
                    writer.WriteLine(weapon);
                }
                Console.WriteLine("Output file has been saved.");
            }
            return true;

        }
        public bool SaveAppend(string outputFile)
        {
            if(!File.Exists(outputFile))
            {
                Console.WriteLine("Output file not found."); 
                return false;
            }

            FileStream fs;
            fs = File.Open(outputFile, FileMode.Append);
            Console.WriteLine("Output is append to existing file.");

            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine("Name,Type,Image,Rarity,BaseAttack,SecondaryStat,Passive");                                
                foreach (var weapon in this)
                {
                    writer.WriteLine(weapon);
                }
                Console.WriteLine("Output file has been saved.");
            }
            return true;
        }
        
        public bool Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine(filename + " not found.");
                return false;
            }
            using (StreamReader reader = new StreamReader(filename)) 
            {
                string header = reader.ReadLine();
                if (header.Length == 0)
                {
                    Console.WriteLine("Nothing to load in the file.");
                    return false;
                }
                int row = 1;
                while (reader.Peek() > 0)
                {
                    //Name,Type,Image,Rarity,BaseAttack,SecondaryStat,Passive
                    string line = reader.ReadLine();
                    Weapon weapon = null;
                    try
                    {
                        if (!Weapon.TryParse(line, out weapon))
                        {
                            //know wich weapon is failed to load.
                            throw new Exception("Fail to load a weapon at row_" + row);
                        }
                        else
                        {
                            this.Add(weapon);
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("{0} Exception caught.", e);
                        return false;
                    }
                    
                    ++row;
                }
                return true;
            }
        }

    }
}
