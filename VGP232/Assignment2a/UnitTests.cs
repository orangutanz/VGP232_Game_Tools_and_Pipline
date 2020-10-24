﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment2a
{
    [TestFixture]
    public class UnitTests
    {
        private WeaponCollection testCollection = new WeaponCollection();
        private string inputPath;
        private string outputPath;

        const string INPUT_FILE = "data2.csv";
        const string OUTPUT_FILE = "output.csv";

        // A helper function to get the directory of where the actual path is.
        private string CombineToAppPath(string filename)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
        }

        [SetUp]
        public void SetUp()
        {
            inputPath = CombineToAppPath(INPUT_FILE);
            outputPath = CombineToAppPath(OUTPUT_FILE);
        }

        [TearDown]
        public void CleanUp()
        {
            // We remove the output file after we are done.
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
        }

        // WeaponCollection Unit Tests
        [Test]
        public void WeaponCollection_GetHighestBaseAttack_HighestValue()
        {
            // Expected Value: 48

            // TODO: call WeaponCollection.GetHighestBaseAttack() and confirm that it matches the expected value using asserts.

            Assert.IsTrue(testCollection.GetHighestBaseAttack() == 48);
        }

        [Test]
        public void WeaponCollection_GetLowestBaseAttack_LowestValue()
        {
            // Expected Value: 23
            // TODO: call WeaponCollection.GetLowestBaseAttack() and confirm that it matches the expected value using asserts.

            Assert.IsTrue(testCollection.GetLowestBaseAttack() == 23);
        }

        [TestCase(WeaponType.Sword, 21)]
        public void WeaponCollection_GetAllWeaponsOfType_ListOfWeapons(WeaponType type, int expectedValue)
        {
            // TODO: call WeaponCollection.GetAllWeaponsOfType(type) and confirm that the weapons list returns Count matches the expected value using asserts.
            Assert.IsTrue(testCollection.GetAllWeaponsOfType(type).Count() == expectedValue);
        }

        [TestCase(5, 10)]
        public void WeaponCollection_GetAllWeaponsOfRarity_ListOfWeapons(int stars, int expectedValue)
        {
            // TODO: call WeaponCollection.GetAllWeaponsOfRarity(stars) and confirm that the weapons list returns Count matches the expected value using asserts.
            Assert.IsTrue(testCollection.GetAllWeaponsOfRarity(stars).Count() == expectedValue);
        }

        [Test]
        public void WeaponCollection_LoadThatExistAndValid_True()
        {
            // TODO: load returns true, expect WeaponCollection with count of 95 .
            Assert.IsTrue(testCollection.Load(INPUT_FILE));
            Assert.IsTrue(testCollection.Count() == 95);
        }

        [Test]
        public void WeaponCollection_LoadThatDoesNotExist_FalseAndEmpty()
        {
            // TODO: load returns false, expect an empty WeaponCollection
            Assert.IsFalse(testCollection.Load(INPUT_FILE));
            Assert.IsTrue(testCollection.Count() == 0);
        }

        [Test]
        public void WeaponCollection_SaveWithValuesCanLoad_TrueAndNotEmpty()
        {
            // TODO: save returns true, load returns true, and WeaponCollection is not empty.
            Assert.IsTrue(testCollection.Load(INPUT_FILE));
            Assert.IsTrue(testCollection.Count > 0);
            Assert.IsTrue(testCollection.Save(OUTPUT_FILE));

        }

        [Test]
        public void WeaponCollection_SaveEmpty_TrueAndEmpty()
        {
            //After saving an empty WeaponCollection, load the file and expect WeaponCollection to be empty.
            testCollection.Clear();
            Assert.IsTrue(testCollection.Save(OUTPUT_FILE));
            Assert.IsTrue(testCollection.Load(OUTPUT_FILE));
            Assert.IsTrue(testCollection.Count == 0);
        }

        // Weapon Unit Tests
        [Test]
        public void Weapon_TryParseValidLine_TruePropertiesSet()
        {
            // TODO: create a Weapon with the stats above set properly
            Weapon expected = null;
            //Name,Type,Image,Rarity,BaseAttack,SecondaryStat,Passive
            expected = new Weapon()
            {
                Name = "Skyward Blade",
                Type = WeaponType.Sword,
                Image = "https://vignette.wikia.nocookie.net/gensin-impact/images/0/03/Weapon_Skyward_Blade.png",
                Rarity = 5,
                BaseAttack = 46,
                SecondaryStat = "Energy Recharge",
                Passive = "Sky-Piercing Fang"
            };

            string line = "Skyward Blade,Sword,https://vignette.wikia.nocookie.net/gensin-impact/images/0/03/Weapon_Skyward_Blade.png,5,46,Energy Recharge,Sky-Piercing Fang";
            Weapon actual = null;

            //Name,Type,Image,Rarity,BaseAttack,SecondaryStat,Passive
            Assert.IsTrue(Weapon.TryParse(line, out actual));
            Assert.Equals(expected.Name, actual.Name);
            Assert.Equals(expected.Type, actual.Type);
            Assert.Equals(expected.Image, actual.Image);
            Assert.Equals(expected.Rarity, actual.Rarity);
            Assert.Equals(expected.BaseAttack, actual.BaseAttack);
            Assert.Equals(expected.SecondaryStat, actual.SecondaryStat);
            Assert.Equals(expected.Passive, actual.Passive);
            // TODO: check for the rest of the properties, Image,Rarity,SecondaryStat,Passive
        }

        [Test]
        public void Weapon_TryParseInvalidLine_FalseNull()
        {
            // TODO: use "1,Bulbasaur,A,B,C,65,65", Weapon.TryParse returns false, and Weapon is null.
            string notWeapon = "1,Bulbasaur,A,B,C,65,65";
            Weapon result = null;
            Assert.IsFalse(Weapon.TryParse(notWeapon, out result));
            Assert.IsTrue(result == null);
        }
    }
}
