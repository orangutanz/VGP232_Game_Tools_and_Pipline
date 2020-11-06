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

namespace WeaponLib
{
    public class Weapon
    {
        //Name,Type,Image,Rarity,BaseAttack,SecondaryStat,Passive
        public string Name { get; set; }
        public WeaponType Type { get; set; }
        public string Image { get; set; }
        public int Rarity { get; set; }
        public int BaseAttack { get; set; }
        public string SecondaryStat { get; set; }
        public string Passive { get; set; }

        static public bool TryParse(string rawData, out Weapon weapon)
        {
            weapon = null;
            try
            {
                string[] values = rawData.Split(',');
                if (values.Length != 7)
                {
                    throw new Exception("Invalid amount of data.(not match with weapon class.)");
                }
                else
                {
                    weapon = new Weapon();
                    //Name,Type,Image,Rarity,BaseAttack,SecondaryStat,Passive
                    int number;
                    weapon.Name = values[0];
                    // LC2: should be using enum.Parse so it'll throw exception when this cannot parse because the test for invalid data failed.
                    Enum.Parse(typeof(WeaponType), values[1]);
                    switch (values[1])
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
                    weapon.Image = values[2];
                    if (!int.TryParse(values[3], out number))
                        throw new Exception("Invalid weapon Rarity datatype.");
                    weapon.Rarity = int.Parse(values[3]);
                    if (!int.TryParse(values[4], out number))
                        throw new Exception("Invalid weapon BaseAttack datatype.");
                    weapon.BaseAttack = int.Parse(values[4]);
                    weapon.SecondaryStat = values[5];
                    weapon.Passive = values[6];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                weapon = null;
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
        public static int CompareBySecondaryStat(Weapon left, Weapon right)
        {
            return left.SecondaryStat.CompareTo(right.SecondaryStat);
        }
        public static int CompareByPassive(Weapon left, Weapon right)
        {
            return left.Passive.CompareTo(right.Passive);
        }

        /// <summary>
        /// The Weapon string with all the properties
        /// </summary>
        /// <returns>The Weapon formated string</returns>
        public override string ToString()
        {
            // i.e. "Name,Type,Image,Rarity,BaseAttack,SecondaryStat,Passive"
            return Name + "," + Type + "," + Image + "," + Rarity + "," + BaseAttack + "," + Passive + "," + SecondaryStat;
        }

    }
}