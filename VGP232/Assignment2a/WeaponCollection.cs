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

        public bool Save(string filename)
        {
            throw new NotImplementedException();

        }
        
        public bool Load(string filename)
        {            
            using (StreamReader reader = new StreamReader(filename)) 
            {
                string header = reader.ReadLine();
                if (header.Length == 0)
                {
                    Console.WriteLine("Nothing to load in the file.");
                    return false;
                }
                while (reader.Peek() > 0)
                {
                    //Name,Type,Image,Rarity,BaseAttack,SecondaryStat,Passive
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    Weapon weapon = new Weapon();
                    if(Weapon.TryParse(values,out weapon))
                    {
                        this.Add(weapon);
                    }
                    else
                    {

                    }
                }
                return true;
            }
            // TODO: implement the streamreader that reads the file and appends each line to the list
            // note that the result that you get from using read is a string, and needs to be parsed 
            // to an int for certain fields i.e. HP, Attack, etc.
            // i.e. int.Parse() and if the results cannot be parsed it will throw an exception
            // or can use int.TryParse() 

            // streamreader https://msdn.microsoft.com/en-us/library/system.io.streamreader(v=vs.110).aspx
            // Use string split https://msdn.microsoft.com/en-us/library/system.string.split(v=vs.110).aspx
        }
    }
}
