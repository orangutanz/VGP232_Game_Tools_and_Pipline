using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment2b
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
            // LC2: you forgot to add this so majority of your test can succeed, but this only fixes 2 tests.
            testCollection.Load(inputPath);
        }

        [TearDown]
        public void CleanUp()
        {
            // We remove the output file after we are done.
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
            if (File.Exists("weapons.json"))
            {
                File.Delete("weapons.json");
            }
            if (File.Exists("weapons.xml"))
            {
                File.Delete("weapons.xml");
            }
            if (File.Exists("weapons.csv"))
            {
                File.Delete("weapons.csv");
            }
            if (File.Exists("empty.json"))
            {
                File.Delete("empty.json");
            }
            if (File.Exists("empty.xml"))
            {
                File.Delete("empty.xml");
            }
            if (File.Exists("empty.csv"))
            {
                File.Delete("empty.csv");
            }
        }

        // WeaponCollection Unit Tests
        [Test]
        public void WeaponCollection_GetHighestBaseAttack_HighestValue()
        {
            // Expected Value: 48

            // TODO: call WeaponCollection.GetHighestBaseAttack() and confirm that it matches the expected value using asserts.

            // LC2: I would recommend using a variable in for the actual results i.e. int testCollection.GetHighestBaseAttack() so you can debug it.
            // LC2: missed the testCollection.Load(inputFile) before you compare the results.

            SetUp();
            int result = testCollection.GetHighestBaseAttack();
            Assert.IsTrue(result == 48);
            CleanUp();
        }

        [Test]
        public void WeaponCollection_GetLowestBaseAttack_LowestValue()
        {
            // Expected Value: 23
            // TODO: call WeaponCollection.GetLowestBaseAttack() and confirm that it matches the expected value using asserts.

            SetUp();
            int result = testCollection.GetLowestBaseAttack();
            Assert.IsTrue(result == 23);
            CleanUp();
        }

        [TestCase(WeaponType.Sword, 21)]
        public void WeaponCollection_GetAllWeaponsOfType_ListOfWeapons(WeaponType type, int expectedValue)
        {
            // TODO: call WeaponCollection.GetAllWeaponsOfType(type) and confirm that the weapons list returns Count matches the expected value using asserts.

            SetUp();
            int result = testCollection.GetAllWeaponsOfType(type).Count();
            Assert.IsTrue(result == expectedValue);
            CleanUp();
        }

        [TestCase(5, 10)]
        public void WeaponCollection_GetAllWeaponsOfRarity_ListOfWeapons(int stars, int expectedValue)
        {
            SetUp();
            // TODO: call WeaponCollection.GetAllWeaponsOfRarity(stars) and confirm that the weapons list returns Count matches the expected value using asserts.
            Assert.IsTrue(testCollection.GetAllWeaponsOfRarity(stars).Count() == expectedValue);
            CleanUp();
        }

        [Test]
        public void WeaponCollection_LoadThatExistAndValid_True()
        {
            // TODO: load returns true, expect WeaponCollection with count of 95 .

            // LC2: you're suppose to be using inputPath because there's usually a path issue.
            Assert.IsTrue(testCollection.Load(inputPath));
            Assert.IsTrue(testCollection.Count() == 95);
        }

        [Test]
        public void WeaponCollection_LoadThatDoesNotExist_FalseAndEmpty()
        {
            // TODO: load returns false, expect an empty WeaponCollection

            // LC2: you're suppose to be using inputPath because there's usually a path issue.
            testCollection.Clear();
            Assert.IsFalse(testCollection.Load("FalseFileName"));
            Assert.IsTrue(testCollection.Count() == 0);
        }

        [Test]
        public void WeaponCollection_SaveWithValuesCanLoad_TrueAndNotEmpty()
        {
            // TODO: save returns true, load returns true, and WeaponCollection is not empty.

            SetUp();
            // LC2: you're suppose to be using inputPath because there's usually a path issue.
            Assert.IsTrue(testCollection.Load(inputPath));
            Assert.IsTrue(testCollection.Count > 0);

            // LC2: you're suppose to be using outputPath because there's usually a path issue.
            Assert.IsTrue(testCollection.Save(outputPath));
            CleanUp();

        }

        [Test]
        public void WeaponCollection_SaveEmpty_TrueAndEmpty()
        {
            //After saving an empty WeaponCollection, load the file and expect WeaponCollection to be empty.
            testCollection.Clear();

            // LC2: you're suppose to be using outputPath because there's usually a path issue.
            Assert.IsTrue(testCollection.Save(outputPath));
            Assert.IsTrue(testCollection.Load(outputPath));
            Assert.IsTrue(testCollection.Count == 0);
            CleanUp();
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

            // LC2: apparently Equals is deprecated and should be using AreEqual instead
            // Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Image, actual.Image);
            Assert.AreEqual(expected.Rarity, actual.Rarity);
            Assert.AreEqual(expected.BaseAttack, actual.BaseAttack);
            Assert.AreEqual(expected.SecondaryStat, actual.SecondaryStat);
            Assert.AreEqual(expected.Passive, actual.Passive);
            // TODO: check for the rest of the properties, Image,Rarity,SecondaryStat,Passive
        }

        [Test]
        public void Weapon_TryParseInvalidLine_FalseNull()
        {
            // TODO: use "1,Bulbasaur,A,B,C,65,65", Weapon.TryParse returns false, and Weapon is null.
            string notWeapon = "1,Bulbasaur,A,B,C,65,65";
            Weapon result = null;

            // LC2: this ends up returning true because you didn't use an enum.Parse

            Assert.IsFalse(Weapon.TryParse(notWeapon, out result));
            Assert.IsTrue(result == null);
        }


        //Assignment2b

        [Test]
        public void WeaponCollection_Load_Save_Load_ValidJson()
        {
            // LC3: this doesn't need to be explicitly called the [SetUp] attribute in Setup() will make it called at the end of every test.
            SetUp();
            // LC3: since the weapons.json, weapons.xml are always being used and this is called many times, why don't you use a new variable put it in the Setup()
            outputPath = CombineToAppPath("weapons.json");
            Assert.IsTrue(testCollection.Save(outputPath));
            inputPath = CombineToAppPath("weapons.json");
            Assert.IsTrue(testCollection.Load(inputPath));
            Assert.IsTrue(testCollection.Count() == 95);
            // LC3: this doesn't need to be explicitly called the [TearDown] attribute in CleanUp() will make it called at the end of every test.
            CleanUp();
        }

        [Test]
        public void WeaponCollection_Load_SaveAsJSON_Load_ValidJson()
        {
            SetUp();
            outputPath = CombineToAppPath("weapons.json");
            Assert.IsTrue(testCollection.SaveAsJSON(outputPath));
            inputPath = CombineToAppPath("weapons.json");
            Assert.IsTrue(testCollection.Load(inputPath));
            Assert.IsTrue(testCollection.Count() == 95);
            CleanUp();
        }

        [Test]
        public void WeaponCollection_Load_SaveAsJSON_LoadJSON_ValidJson()
        {
            SetUp();
            outputPath = CombineToAppPath("weapons.json");
            Assert.IsTrue(testCollection.SaveAsJSON(outputPath));
            inputPath = CombineToAppPath("weapons.json");
            Assert.IsTrue(testCollection.LoadJSON(inputPath));
            Assert.IsTrue(testCollection.Count() == 95);
            CleanUp();
        }

        [Test]
        public void WeaponCollection_Load_Save_LoadJSON_ValidJson()
        {
            SetUp();
            outputPath = CombineToAppPath("weapons.json");
            Assert.IsTrue(testCollection.Save(outputPath));
            inputPath = CombineToAppPath("weapons.json");
            Assert.IsTrue(testCollection.LoadJSON(inputPath));
            Assert.IsTrue(testCollection.Count() == 95);
            CleanUp();
        }

        [Test]
        public void WeaponCollection_Load_Save_Load_ValidCsv()
        {
            SetUp();
            outputPath = CombineToAppPath("weapons.csv");
            Assert.IsTrue(testCollection.Save(outputPath));
            inputPath = CombineToAppPath("weapons.csv");
            Assert.IsTrue(testCollection.Load(inputPath));
            CleanUp();
        }

        [Test]
        public void WeaponCollection_Load_SaveAsCSV_LoadCSV_ValidCsv()
        {
            SetUp();
            outputPath = CombineToAppPath("weapons.csv");
            Assert.IsTrue(testCollection.SaveAsCSV(outputPath));
            inputPath = CombineToAppPath("weapons.csv");
            Assert.IsTrue(testCollection.LoadCSV(inputPath));
            CleanUp();
        }

        [Test]
        public void WeaponCollection_Load_Save_Load_ValidXml()
        {
            SetUp();
            outputPath = CombineToAppPath("weapons.xml");
            Assert.IsTrue(testCollection.Save(outputPath));
            inputPath = CombineToAppPath("weapons.xml");
            Assert.IsTrue(testCollection.Load(inputPath));
            CleanUp();
        }

        [Test]
        public void WeaponCollection_Load_SaveAsXML_LoadXML_ValidXml()
        {
            SetUp();
            outputPath = CombineToAppPath("weapons.xml");
            Assert.IsTrue(testCollection.SaveAsXML(outputPath));
            inputPath = CombineToAppPath("weapons.xml");
            Assert.IsTrue(testCollection.LoadXML(inputPath));
            CleanUp();

        }

        [Test]
        public void WeaponCollection_SaveEmpty_Load_ValidJson()
        {
            WeaponCollection empty = new WeaponCollection();
            outputPath = CombineToAppPath("empty.json");
            Assert.IsTrue(empty.SaveAsJSON(outputPath));
            inputPath = CombineToAppPath("empty.json");
            Assert.IsTrue(testCollection.Load(inputPath));
            Assert.IsTrue(testCollection.Count == 0);
            CleanUp();
        }

        [Test]
        public void WeaponCollection_SaveEmpty_Load_ValidCsv()
        {
            WeaponCollection empty = new WeaponCollection();
            outputPath = CombineToAppPath("empty.csv");
            Assert.IsTrue(empty.SaveAsJSON(outputPath));
            inputPath = CombineToAppPath("empty.csv");
            Assert.IsTrue(testCollection.Load(inputPath));
            Assert.IsTrue(testCollection.Count == 0);
            CleanUp();
        }

        [Test]
        public void WeaponCollection_SaveEmpty_Load_ValidXml()
        {
            WeaponCollection empty = new WeaponCollection();
            outputPath = CombineToAppPath("empty.xml");
            Assert.IsTrue(empty.SaveAsJSON(outputPath));
            inputPath = CombineToAppPath("empty.xml");
            Assert.IsTrue(testCollection.Load(inputPath));
            Assert.IsTrue(testCollection.Count == 0);
            CleanUp();
        }

        [Test]
        public void WeaponCollection_Load_SaveJSON_LoadXML_InvalidXml()
        {
            SetUp();
            outputPath = CombineToAppPath("weapons.json");
            Assert.IsTrue(testCollection.SaveAsJSON(outputPath));
            inputPath = CombineToAppPath("weapons.json");
            Assert.IsFalse(testCollection.LoadXML(inputPath));
            Assert.IsTrue(testCollection.Count == 0);
            CleanUp();
        }

        [Test]
        public void WeaponCollection_Load_SaveXML_LoadJSON_InvalidJson()
        {
            SetUp();
            outputPath = CombineToAppPath("weapons.xml");
            Assert.IsTrue(testCollection.SaveAsXML(outputPath));
            inputPath = CombineToAppPath("weapons.xml");
            Assert.IsFalse(testCollection.LoadJSON(inputPath));
            Assert.IsTrue(testCollection.Count == 0);
            CleanUp();
        }

        [Test]
        public void WeaponCollection_ValidCsv_LoadXML_InvalidXml()
        {
            inputPath = CombineToAppPath("data2.csv");
            Assert.IsFalse(testCollection.LoadXML(inputPath));
            Assert.IsTrue(testCollection.Count == 0);
            CleanUp();
        }


        [Test]
        public void WeaponCollection_ValidCsv_LoadJSON_InvalidJson()
        {
            inputPath = CombineToAppPath("data2.csv");
            Assert.IsFalse(testCollection.LoadJSON(inputPath));
            Assert.IsTrue(testCollection.Count == 0);

            CleanUp();
        }


    }
}
