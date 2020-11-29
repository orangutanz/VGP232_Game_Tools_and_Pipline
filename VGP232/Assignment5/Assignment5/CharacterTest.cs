using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class CharacterTest
    {
        Character myCharacter = new Character("Soilder", RaceCategory.Human, 100);

        [SetUp]
        public void SetUp()
        {
            myCharacter.Health = myCharacter.MaxHealth;
            myCharacter.IsAlive = true;
        }
        [TearDown]
        public void CleanUp()
        {

        }

        [Test]
        public void TakeDamageAndLive()
        {
            Assert.IsTrue(myCharacter.IsAlive);
            myCharacter.TakeDamage(10);
            Assert.IsTrue(myCharacter.IsAlive);
        }

        [Test]
        public void TakeDamageAndDie()
        {
            Assert.IsTrue(myCharacter.IsAlive);
            myCharacter.TakeDamage(300);
            Assert.IsFalse(myCharacter.IsAlive);

        }

        [Test]
        public void RestoreHealth()
        {
            Assert.IsTrue(myCharacter.IsAlive);
            myCharacter.TakeDamage(30);
            Assert.IsTrue(myCharacter.IsAlive);

            int healAmount = 10;
            int hp = myCharacter.Health;
            myCharacter.RestoreHealth(healAmount);
            Assert.IsTrue(myCharacter.Health == (hp + healAmount));
        }

        [Test]
        public void RestoreHealthAndRevive()
        {
            Assert.IsTrue(myCharacter.IsAlive);
            myCharacter.TakeDamage(200);
            Assert.IsFalse(myCharacter.IsAlive);

            myCharacter.IsAlive = true;
            myCharacter.RestoreHealth(999);
            Assert.IsTrue(myCharacter.Health == myCharacter.MaxHealth);

        }
    }
}
