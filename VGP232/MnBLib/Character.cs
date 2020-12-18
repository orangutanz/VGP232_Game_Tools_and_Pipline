using System;
using System.Collections.Generic;
using System.Text;

namespace MnBLib
{
    // LC: if this class was implemented properly in a way that you can data bind, then you will need to implement the INotifyPropertyChanged and use full properties no auto properties.
    public class Character
    {
        public string name { get; set; }

        public int strength { get; set; }
        public int agility { get; set; }
        public int intelligence { get; set; }
        public int charisma { get; set; }


        public int trade { get; set; }
        public int leadership { get; set; }
        public int prisoner_management { get; set; }
        public int persuasion { get; set; }
        public int engineer { get; set; }
        public int first_aid { get; set; }
        public int surgery { get; set; }
        public int wound_treatment { get; set; }
        public int inventory_management { get; set; }
        public int spotting { get; set; }
        public int path_finding { get; set; }
        public int tactics { get; set; }
        public int tracking { get; set; }
        public int trainer { get; set; }
        public int looting { get; set; }
        public int horse_archery { get; set; }
        public int riding { get; set; }
        public int athletics { get; set; }
        public int shield { get; set; }
        public int weapon_master { get; set; }
        public int power_draw { get; set; }
        public int power_throw { get; set; }
        public int power_strike { get; set; }
        public int ironflesh { get; set; }

        public int one_handed_weapons { get; set; }
        public int two_handed_weapons { get; set; }
        public int polearms { get; set; }
        public int archery { get; set; }
        public int crossbows { get; set; }
        public int throwing { get; set; }
        public int firearms { get; set; }

        public Character()
        {
            Random rnd = new Random();
            name = "name";
            
            strength = rnd.Next(1, 12);
            agility = rnd.Next(1, 12);
            intelligence = rnd.Next(1, 12);
            charisma = rnd.Next(1, 12);

            trade = rnd.Next(0, 10);
            leadership = rnd.Next(0, 10);
            prisoner_management = rnd.Next(0, 10);
            persuasion = rnd.Next(0, 10);
            engineer = rnd.Next(0, 10);
            first_aid = rnd.Next(0, 10);
            surgery = rnd.Next(0, 10);
            wound_treatment = rnd.Next(0, 10);
            inventory_management = rnd.Next(0, 10);
            spotting = rnd.Next(0, 10);
            path_finding = rnd.Next(0, 10);
            tactics = rnd.Next(0, 10);
            tracking = rnd.Next(0, 10);
            trainer = rnd.Next(0, 10);
            looting = rnd.Next(0, 10);
            horse_archery = rnd.Next(0, 10);
            riding = rnd.Next(0, 10);
            athletics = rnd.Next(0, 10);
            shield = rnd.Next(0, 10);
            weapon_master = rnd.Next(0, 10);
            power_draw = rnd.Next(0, 10);
            power_throw = rnd.Next(0, 10);
            power_strike = rnd.Next(0, 10);
            ironflesh = rnd.Next(0, 10);

            one_handed_weapons = rnd.Next(10, 100);
            two_handed_weapons = rnd.Next(10, 100);
            polearms = rnd.Next(10, 100);
            archery = rnd.Next(10, 100);
            crossbows = rnd.Next(10, 100);
            throwing = rnd.Next(10, 100);
        }
        public Character(Character c)
        {

            name = c.name;

            strength = c.strength;
            agility = c.agility;
            intelligence = c.intelligence;
            charisma = c.charisma;

            trade = c.trade;
            leadership = c.leadership;
            prisoner_management = c.prisoner_management;
            persuasion = c.persuasion;
            engineer = c.engineer;
            first_aid = c.first_aid;
            surgery = c.surgery;
            wound_treatment = c.wound_treatment;
            inventory_management = c.inventory_management;
            spotting = c.spotting;
            path_finding = c.path_finding;
            tactics = c.tactics;
            tracking = c.tracking;
            trainer = c.trainer;
            looting = c.looting;
            horse_archery = c.horse_archery;
            riding = c.riding;
            athletics = c.athletics;
            shield = c.shield;
            weapon_master = c.weapon_master;
            power_draw = c.power_draw;
            power_throw = c.power_throw;
            power_strike = c.power_strike;
            ironflesh = c.ironflesh;

            one_handed_weapons = c.one_handed_weapons;
            two_handed_weapons = c.two_handed_weapons;
            polearms = c.polearms;
            archery = c.archery;
            crossbows = c.crossbows;
            throwing = c.throwing;
        }

    }
}
//the program will only pick up some of the stats in the original file and save them

//Original M&B character export file
/*
 charfile_version = 1
 name = AwA
 xp = 202
 money = 45
 
 attribute_points = 60
 skill_points = 60
 weapon_points = 60
 
 strength = 10
 agility = 12
 intelligence = 6
 charisma = 6
 
 trade = 0
 leadership = 2
 prisoner_management = 0
 reserved_skill_1 = 0
 reserved_skill_2 = 0
 reserved_skill_3 = 0
 reserved_skill_4 = 0
 persuasion = 0
 engineer = 0
 first_aid = 0
 surgery = 0
 wound_treatment = 0
 inventory_management = 2
 spotting = 1
 path-finding = 2
 tactics = 0
 tracking = 0
 trainer = 0
 reserved_skill_5 = 0
 reserved_skill_6 = 0
 reserved_skill_7 = 0
 reserved_skill_8 = 0
 looting = 4
 horse_archery = 0
 riding = 3
 athletics = 3
 shield = 0
 weapon_master = 1
 reserved_skill_9 = 0
 reserved_skill_10 = 0
 reserved_skill_11 = 0
 reserved_skill_12 = 0
 reserved_skill_13 = 0
 power_draw = 0
 power_throw = 1
 power_strike = 1
 ironflesh = 0
 reserved_skill_14 = 0
 reserved_skill_15 = 0
 reserved_skill_16 = 0
 reserved_skill_17 = 0
 reserved_skill_18 = 0
 
 one_handed_weapons = 94
 two_handed_weapons = 64
 polearms = 64
 archery = 31
 crossbows = 31
 throwing = 61
 firearms = 0
 
 face_key_1 = 1b80804c8
 face_key_2 = 6770a4cad492034a
 
 */