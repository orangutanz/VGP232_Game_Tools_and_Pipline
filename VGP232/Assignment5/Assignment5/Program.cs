using System;

namespace Assignment5
{
    // Assignment 5A
    // NAME: Yuhan Ma
    // STUDENT NUMBER: 1930014
    // MARKS: 84/100 Great work, there's a misunderstanding with the inventory's items dictionary key value pair, where the value is an int, but it represents the quantity and item's amount represents a number for the item i.e. health potions that heals 10 amount of health. Also you should check if the inventory is full first before you add it to the items list.
    // Does it compile? Yes
    // Does it produce the correct results? No, the inventory had some wrong assumptions
    // Does all the unit tests pass? Yes
    // Was all the branches merged? Yes
    // Where's the repo? https://github.com/orangutanz/VGP232_A5_FA20

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
