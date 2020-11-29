﻿using System;

namespace Assignment5
{
    // Assignment 5A
    // NAME: Yuhan Ma
    // STUDENT NUMBER: 1930014

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            // TODO: Create an inventory
            Inventory myInventory = new Inventory(10);
            Console.WriteLine("Inventory created.");

            // TODO: Add 2 items to the inventory
            Item potion = new Item("Healing_Potion", 3, ItemGroup.Consumable);
            Item weapon = new Item("Sword", 1, ItemGroup.Equipment);
            myInventory.AddItem(potion);
            myInventory.AddItem(weapon);
            Console.WriteLine("Items added.");

            // Verify the number of items in the inventory.
            Console.WriteLine("\nList of items.");
            myInventory.ListAllItems();
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            Character hero = new Character("Bob", RaceCategory.Human, 100);

            Console.WriteLine("{0} has entered the forest", hero.Name );

            string monster = "goblin";
            int damage = 10;

            Console.WriteLine("A {0} appeared and attacks {1}", monster, hero.Name);

            Console.WriteLine("{0} takes {1} damage", hero.Name, damage);

            hero.TakeDamage(damage);
            Console.WriteLine(hero);

            Console.WriteLine("{0} flees from the enemy", hero.Name);

            string item = "small health potion";
            int restoreAmount = 10;

            Console.WriteLine("{0} find a {1} and drinks it", hero.Name, item);

            Console.WriteLine("{0} restores {1} health", hero.Name, restoreAmount);

            hero.RestoreHealth(restoreAmount);

            Console.WriteLine(hero);

            if (hero.IsAlive)
            {
                Console.WriteLine("Congratulations! {0} survived.", hero.Name);
            }
            else
            {
                Console.WriteLine("{0} has died.", hero.Name);
            }
        }
    }
}
