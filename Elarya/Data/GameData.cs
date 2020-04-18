using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elarya.Models;

namespace Elarya.Data
{
    public static class GameData
    {
        /// <summary>
        /// Method to create the Player Data
        /// </summary>
        /// <returns>Returns a default player</returns>
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                LocationId = 1,
                Name = "Arya\'e",
                Age = 20,
                Race = Character.RaceType.Nungari,
                Gender = Character.GenderType.Female,
                JobTitle = Player.JobTitleName.DragonRider,
                Health = 100,
                Mana = 100,
                AttackPower = 10,
                DefensePower = 5,
                HealthRegenRate = 5,
                ManaRegenRate = 5,
                Life = 3,
                WarriorSkill = 0,
                DragonRiderSkill = 0,
                HunterSkill = 0,
                MageSkill = 0,
                Spell = null,
                InventoryItem = null
            };
        }


        public static MapCoordinates InitializeGameMapLocation()
        {
            return new MapCoordinates() { Row = 4, Column = 6 };
        }

        public static Map GameMap()
        {
            int rows = 15;
            int columns = 15;

            Map gameMap = new Map(rows, columns);

            gameMap.Locations[4, 6] = new Location()
            {
                ID = 1,

                Name = "Home (Nocti)",

                Description = "You arose in your home in the capital City of Nocti. The air is damp, the room is dark. " +
                "You start to hear the hustle and bustle outside. The city is awakening and you slowly stir from bed." + 
                "You make your way to the kitchen, whisper Fiero'n and watch as the fire springs from your fingertips to the hearth." +
                "You listen to the crackle of the fire as you prepare breakfast. Today is an important day, and you soak up your home for the forseeable future.",

                Messages = "You are soon to become of age in the realm of Qui'Lash. You must venture forth on an epic journey to discover what talents and skills you have to benefit society." +
                "Will you be a fearsome Dragon Rider? Or maybe a noble Warrior. A competent Hunter, or even a powerful Mage!" +
                "You only have 3 months to discover your true talents, or you risk being exiled from Nocti and banished to the Northern Tundra." +
                "Good luck on your quest, and remember, every choice you make, every quest you complete, will determine you role in society! ",
                
                Accessible = true

            };

            gameMap.Locations[3, 6] = new Location()
            {
                ID = 2,

                Name = "Market Square (Nocti)",

                Description = "The market is in full swing! Breakfast is over, and people are hustling and bustling about. " +
                "You hear the blacksmith tanging away on metal, the horses in the stables neighing, and the smell of bread " +
                "wafts over you, inundating your senses.",

                Messages = "To your left is the Blacksmiths Forge. A great place to acquire weapons and armor (If you have the coin) " +
                "To your right is the Stables, filled with glorious horses of all breeds. You will need a saddle if you wish " +
                "to have a horse for your journey. ",

                Accessible = true
            };

            gameMap.Locations[3, 5] = new Location()
            {
                ID = 3,

                Name = "BlackSmith (Nocti)",

                Description = "The Blacksmith is pounding away at his forge. As you enter the shop, he looks up at you " +
                "and welcomes you to the shop! The smell of coal and fire fills your nostrils, as sparks fly " +
                "across the shop. You see lots of Heavy Armor and Weapons hanging on the wall behind the counter",

                Messages = "On your quest, you may encounter dangerous beasts or have need for armor if attacked while traveling. " +
                "You have limited coin however, and there are many other shops to visit before leaving on your epic quest!" +
                "Choose wisely, or you may regret your decisions later.",

                Accessible = true
            };

            gameMap.Locations[3, 7] = new Location()
            {
                ID = 4,

                Name = "Stables (Nocti)",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
                "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[4, 7] = new Location()
            {
                ID = 5,

                Name = "Front Gate (Nocti)",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[2, 5] = new Location()
            {
                ID = 6,

                Name = "Food Shop (Nocti)",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[2, 6] = new Location()
            {
                ID = 7,

                Name = "Tailor (Nocti)",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[2, 7] = new Location()
            {
                ID = 8,

                Name = "Saddle Shop (Nocti)",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[5, 7] = new Location()
            {
                ID = 9,

                Name = "Southern Road",

                Description = "The road is long and dusty. The sun bearing down overhead, you feel a slight breeze moving in " +
                "from the North.",

                Accessible = true
            };

            gameMap.Locations[6, 7] = new Location()
            {
                ID = 10,

                Name = "Southern Road",

                Description = "The road is long, but the breeze grows stronger. The smell of salt lingers in the air, you must be nearing Sra'lik Sea!",

                Accessible = true
            };

            gameMap.Locations[7, 7] = new Location()
            {
                ID = 11,

                Name = "Sra'Lik Sea",

                Description = "At last the sea is in full view! The breeze cutting through the hot mid summer sun like a cool autumn night. " +
                "To the east is a fishing shop and to the west is a man sitting on a dock.",
                Messages = "After such a long journey, the thought of a fresh fish sounds tantilizing to your taste buds. " +
                "Alas, you do not have a fishing pole however. Maybe that fishing shop to the east you've heard about can help?",

                Accessible = true
            };

            gameMap.Locations[7, 8] = new Location()
            {
                ID = 12,

                Name = "Fishing Shop",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[7, 6] = new Location()
            {
                ID = 13,

                Name = "Tornul (Fishing Master)",

                Description = "You see an old man, sitting on the dock, feet hanging off in the Water. This must be Tornul " +
                "the Fishing Master everyone talks about.",

                Messages = "So you want a fish but haven't fished in years. Maybe Tornul can teach you (for a price of course)!" +
                "",

                Accessible = true
            };

            gameMap.Locations[5, 8] = new Location()
            {
                ID = 14,

                Name = "Eastern Road",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[5, 9] = new Location()
            {
                ID = 15,

                Name = "Eastern Road",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[5, 10] = new Location()
            {
                ID = 16,

                Name = "Juit Bluffs",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[5, 11] = new Location()
            {
                ID = 17,

                Name = "Dragon Clutch",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[6, 10] = new Location()
            {
                ID = 18,

                Name = "Campfire",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[4, 10] = new Location()
            {
                ID = 19,

                Name = "Northern Road",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[3, 10] = new Location()
            {
                ID = 20,

                Name = "Northern Road",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[2, 10] = new Location()
            {
                ID = 21,

                Name = "Yerfurd Forest",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[1, 10] = new Location()
            {
                ID = 22,

                Name = "Yerfurd Forest",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[0, 10] = new Location()
            {
                ID = 23,

                Name = "Yerfurd Forest",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[2, 11] = new Location()
            {
                ID = 24,

                Name = "Mages Hut",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[2, 9] = new Location()
            {
                ID = 25,

                Name = "Rebel Encampment",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[0, 9] = new Location()
            {
                ID = 26,

                Name = "Hunting Grounds",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[5, 6] = new Location()
            {
                ID = 27,

                Name = "Western Road",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[5, 5] = new Location()
            {
                ID = 28,

                Name = "Western Road",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[5, 4] = new Location()
            {
                ID = 29,

                Name = "Pledg'ui Caverns",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[4, 4] = new Location()
            {
                ID = 30,

                Name = "Dragon Mother",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[4, 3] = new Location()
            {
                ID = 31,

                Name = "Whispering Caverns",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[6, 4] = new Location()
            {
                ID = 32,

                Name = "Rebel Camp",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            gameMap.Locations[6, 5] = new Location()
            {
                ID = 33,

                Name = "Rebel Leader",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are where you can purchase a horse. Make sure you have a saddle though! " +
    "I hear the Saddle shop is now open and you can purchase one from them.",

                Accessible = true
            };

            return gameMap;
        }
    }
}
