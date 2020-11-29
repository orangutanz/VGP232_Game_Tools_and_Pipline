﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class Inventory
    {
        // The dictionary items consist of the item and the quantity
        private Dictionary<Item, int> items = new Dictionary<Item, int>();

        public int AvailableSlots 
        { 
            get
            {
                return availableSlots;
            } 
        }

        public int MaxSlots
        {
            get
            {
                return MaxSlots;
            }
        }


        // The available slots to add item, once it's 0, you cannot add any more items.
        private int availableSlots;

        // The max available slots which is set only in the constructor.
        private int maxSlots;
        public Inventory(int slots)
        {
            maxSlots = slots;
            availableSlots = maxSlots;
        }

        /// <summary>
        /// Removes all the items, and restore the original number of slots.
        /// </summary>
        public void Reset()
        {
            items.Clear();
            availableSlots = maxSlots;
        }

        /// <summary>
        /// Removes the item from the items dictionary if the count is 1 otherwise decrease the quantity.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <param name="found">The item if found</param>
        /// <returns>True if you find the item, and false if it does not exist.</returns>
        public bool TakeItem(string name, out Item found)
        {
            foreach (var i in items)
            {
                if (string.Equals(i.Key.Name, name))
                {
                    //take 1 out
                    found = i.Key;
                    // LC: amount is not the same as quantity.
                    found.Amount = 1;

                    i.Key.Amount--;
                    if (i.Value > 1)
                    {
                        //reduce the amount
                        items[i.Key]--;

                        // LC: you also need to increment the available slots here too.
                    }
                    else
                    {
                        //remove if 0
                        items.Remove(i.Key);
                        availableSlots++;
                    }
                    return true;
                }
            }
            found = null;
            return false;
        }

        /// <summary>
        /// Checks if there is space for a unique item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddItem(Item item)
        {
            // Add it in the items dictionary and increment it the number if it already exist
            // Reduce the slot once it's been added.
            // returns false if the inventory is full

            // LC: you should check for availablity first if there's space

            foreach (var i in items)
            {
                //increase the amount
                if (string.Equals(i.Key.Name, item.Name))
                {
                    items[i.Key]++;
                    // LC: no the amount is not the same as the quanity, so you don't need this.
                    i.Key.Amount++;
                    // LC: decrement slot here.
                    return true;
                }
            }

            // LC: this should go before you increment insert to the items dictionary. 
            //add new to the slot
            if (availableSlots > 0)
            {
                // LC: this line and the one after are doing the same thing
                // LC: the amount is not the same as the quanity, you're suppose to increment it by 1 if it already exist
                items.Add(item, item.Amount);
                items[item] = item.Amount;
                availableSlots--;
                return true;
            }
            else
            {
                //inventory is full
                return false;
            }

        }

        /// <summary>
        /// Iterates through the dictionary and create a list of all the items.
        /// </summary>
        /// <returns></returns>
        public List<Item> ListAllItems()
        {
            // use a foreach loop to iterate through the key value pairs and duplicate the item base on the quantity.
            List<Item> result = new List<Item>();
            foreach(var item in items)
            {
                // LC: you should iterate through the item.Value to determine how many item.Key to add to the list.
                result.Add(item.Key);
                Console.WriteLine(item.Key.ToString());

                for (int i = 0;i< items[item.Key] ;++i)
                {
                    // LC: missing the step to add the duplicates to the list.

                }
            }
            return result;

        }
    }
}
