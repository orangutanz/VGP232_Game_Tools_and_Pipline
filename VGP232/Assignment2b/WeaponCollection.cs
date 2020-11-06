using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text.Json;

namespace Assignment2b
{
    public class WeaponCollection : List<Weapon>, IPeristence, IXmlSerializable, IJsonSerializable, ICsvSerializable
    {
        public int GetHighestBaseAttack()
        {
            int result = 0;
            foreach (var i in this)
            {
                if (i.BaseAttack > result)
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
                    i.Type.CompareTo(type);
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
            switch (columnName.ToLower())
            {
                case "name":
                    this.Sort(Weapon.CompareByName);
                    Console.WriteLine("Sorting by Name.");
                    break;
                case "type":
                    this.Sort(Weapon.CompareByType);
                    Console.WriteLine("Sorting by Type.");
                    break;
                case "rarity":
                    this.Sort(Weapon.CompareByRarity);
                    Console.WriteLine("Sorting by Rarity.");
                    break;
                case "baseattack":
                    this.Sort(Weapon.CompareByBaseAttack);
                    Console.WriteLine("Sorting by BaseAttack.");
                    break;
                case "secondarystat":
                    this.Sort(Weapon.CompareBySecondaryStat);
                    Console.WriteLine("Sorting by SecondaryStat.");
                    break;
                case "passive":
                    this.Sort(Weapon.CompareByPassive);
                    Console.WriteLine("Sorting by Passive.");
                    break;
                default:
                    Console.WriteLine("Invalid sorting. Did not sort.");
                    break;
            }
        }

        public bool Save(string outputFile)
        {
            if (Path.GetExtension(outputFile) == ".xml")
            {
                return SaveAsXML(outputFile);
            }
            else if (Path.GetExtension(outputFile) == ".csv")
            {
                return SaveAsCSV(outputFile);
            }
            else if (Path.GetExtension(outputFile) == ".json")
            {
                return SaveAsJSON(outputFile);
            }
            else
            {
                return false;
            }
        }


        public bool Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine(filename + " not found.");
                return false;
            }

            if (Path.GetExtension(filename) == ".xml")
            {
                LoadXML(filename);
                return true;
            }
            else if (Path.GetExtension(filename) == ".json")
            {
                LoadJSON(filename);
                return true;
            }
            else if (Path.GetExtension(filename) == ".csv")
            {
                LoadCSV(filename);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoadXML(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(WeaponCollection));
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    this.Clear();
                    this.AddRange((WeaponCollection)xml.Deserialize(reader));
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool SaveAsXML(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(WeaponCollection));
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    xml.Serialize(writer, this);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool LoadJSON(string path)
        {
            try
            {
                this.Clear();
                using (StreamReader reader = new StreamReader(path))
                {
                    this.AddRange((WeaponCollection)JsonSerializer.Deserialize<WeaponCollection>(reader.ReadToEnd()));
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool SaveAsJSON(string path)
        {
            try
            {
                
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(JsonSerializer.Serialize<WeaponCollection>(this));
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool LoadCSV(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string header = reader.ReadLine();
                this.Clear();
                if (header.Length == 0)
                {
                    Console.WriteLine("Nothing to load in the file.");
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
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} Exception caught.", e);
                        return false;
                    }

                    ++row;
                }
            }
            return true;
        }

        public bool SaveAsCSV(string path)
        {
            FileStream fs;
            fs = File.Open(path, FileMode.Create);
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
    }
}
