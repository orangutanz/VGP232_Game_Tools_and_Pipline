using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum WeaponType
{
    Sword,
    Polearm,
    Claymore,
    Catalyst,
    Bow,
    None
}

namespace Assignment2a
{
    public class Weapon
    {
        // Name,Type,Rarity,BaseAttack
        public string Name { get; set; }
        public WeaponType Type { get; set; }
        public string Image { get; set; }
        public int Rarity { get; set; }
        public int BaseAttack { get; set; }
        public string SecondaryStat { get; set; }
        public string Passive { get; set; }

        static public bool TryParse(string[] rawData, out Weapon weapon)
        {
            weapon = new Weapon();
            try
            {
                if (rawData.Length != 7)
                {
                    throw new Exception("Invalid amount of data.(not match with weapon class.)");
                }
                else
                {
                    //Name,Type,Image,Rarity,BaseAttack,SecondaryStat,Passive
                    int number;
                    weapon.Name = rawData[0];
                    switch (rawData[1])
                    {
                        case "Sword":
                            weapon.Type = WeaponType.Sword;
                            break;
                        case "Polearm":
                            weapon.Type = WeaponType.Polearm;
                            break;
                        case "Claymore":
                            weapon.Type = WeaponType.Claymore;
                            break;
                        case "Catalyst":
                            weapon.Type = WeaponType.Catalyst;
                            break;
                        case "Bow":
                            weapon.Type = WeaponType.Bow;
                            break;
                        default:
                            weapon.Type = WeaponType.None;
                            break;
                    }
                    weapon.Image = rawData[2];
                    if (!int.TryParse(rawData[3], out number))
                        throw new Exception("Invalid weapon Rarity datatype.");
                    weapon.Rarity = int.Parse(rawData[3]);
                    if (!int.TryParse(rawData[4], out number))
                        throw new Exception("Invalid weapon BaseAttack datatype.");
                    weapon.BaseAttack = int.Parse(rawData[4]);
                    weapon.SecondaryStat = rawData[5];
                    weapon.Passive = rawData[6];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }
            return true;
        }

        /// <summary>
        /// The Comparator function to check for name
        /// </summary>
        /// <param name="left">Left side Weapon</param>
        /// <param name="right">Right side Weapon</param>
        /// <returns> -1 (or any other negative value) for "less than", 0 for "equals", or 1 (or any other positive value) for "greater than"</returns>
        public static int CompareByName(Weapon left, Weapon right)
        {
            return left.Name.CompareTo(right.Name);
        }
        public static int CompareByType(Weapon left, Weapon right)
        {
            return left.Type.CompareTo(right.Type);
        }
        public static int CompareByRarity(Weapon left, Weapon right)
        {
            return left.Rarity.CompareTo(right.Rarity);
        }
        public static int CompareByBaseAttack(Weapon left, Weapon right)
        {
            return left.BaseAttack.CompareTo(right.BaseAttack);
        }

        /// <summary>
        /// The Weapon string with all the properties
        /// </summary>
        /// <returns>The Weapon formated string</returns>
        public override string ToString()
        {
            // Name,Type,Rarity,BaseAttack
            return Name + "," + Type + "," + Rarity + "," + BaseAttack + "," + Passive + "," + SecondaryStat + "," + Image;
        }

    }
}