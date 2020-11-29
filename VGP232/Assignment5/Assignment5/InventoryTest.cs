using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class InventoryTest
    {
        Inventory myInventory = new Inventory(10);
        Item item_1 = new Item("Sword", 1, ItemGroup.Equipment);
        Item item_2 = new Item("Potion", 3, ItemGroup.Consumable);

        [SetUp]
        public void SetUp()
        {
            myInventory.Reset();
            myInventory.AddItem(item_1);
            myInventory.AddItem(item_2);
        }
        [TearDown]
        public void CleanUp()
        {
            myInventory.Reset();
        }


        [Test]
        public void RemoveItemFound()
        {
            int oldSlots = myInventory.AvailableSlots;
            myInventory.TakeItem(item_1.Name,out Item found);
            Assert.AreEqual(item_1.Name, found.Name);
            Assert.IsTrue((oldSlots+1) == myInventory.AvailableSlots);
        }

        [Test]
        public void RemoveItemNotFound()
        {
            int oldSlots = myInventory.AvailableSlots;
            myInventory.TakeItem("Noodles", out Item found);
            Assert.IsTrue(found == null);
            Assert.AreEqual(oldSlots, myInventory.AvailableSlots);
        }

        [Test]
        public void AddItem()
        {
            int oldSlots = myInventory.AvailableSlots;
            Item newItem = new Item("Bandage", 5, ItemGroup.Consumable);
            myInventory.AddItem(newItem);
            Assert.IsTrue((oldSlots - 1) == myInventory.AvailableSlots);

            List<Item> myItemList = myInventory.ListAllItems();
            bool itemExists = false;
            foreach(var i in myItemList)
            {
                if (i.Name == newItem.Name)
                    itemExists = true;
            }
            Assert.IsTrue(itemExists);            
        }

        [Test]
        public void Reset()
        {
            myInventory.Reset();
            Assert.IsTrue(myInventory.AvailableSlots == 10);
        }
    }
}
