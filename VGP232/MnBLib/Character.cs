using System;
using System.Collections.Generic;
using System.Text;

namespace MnBLib
{
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
            name = "name";

            strength = 5;
            agility = 5;
            intelligence = 5;
            charisma = 5;

            trade = 0;
            leadership = 0;
            prisoner_management = 0;
            persuasion = 0;
            engineer = 0;
            first_aid = 0;
            surgery = 0;
            wound_treatment = 0;
            inventory_management = 0;
            spotting = 0;
            path_finding = 0;
            tactics = 0;
            tracking = 0;
            trainer = 0;
            looting = 0;
            horse_archery = 0;
            riding = 3;
            athletics = 3;
            shield = 0;
            weapon_master = 1;
            power_draw = 0;
            power_throw = 2;
            power_strike = 2;
            ironflesh = 2;

            one_handed_weapons = 90;
            two_handed_weapons = 60;
            polearms = 60;
            archery = 60;
            crossbows = 60;
            throwing = 60;
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