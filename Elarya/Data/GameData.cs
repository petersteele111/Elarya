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
                JobTitle = Player.JobTitleName.Mage,
                Health = 100,
                Mana = 100,
                Life = 3,
                MageSkill = 5,
                HealerSkill = 0,
                Spell = null,
                InventoryItem = null
            };
        }

        #region GameMap

        /// <summary>
        /// Initializes the Game Map
        /// </summary>
        /// <returns>Returns the Game Map with specified Rows and Columns</returns>
        public static MapCoordinates InitializeGameMapLocation()
        {
            return new MapCoordinates() { Row = 4, Column = 6 };
        }

        /// <summary>
        /// Creates the data for the Game Map
        /// </summary>
        /// <returns>Returns the populated Game Map</returns>
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
                "Will you follow in your Mom's footstep as a formidable healer or in your Father's light as a powerful Mage?" +
                "You only have 3 months to discover your true talents, or you risk being exiled from Nocti and banished to the Northern Tundra.",

                Accessible = true

            };

            gameMap.Locations[3, 6] = new Location()
            {
                ID = 2,

                Name = "Market Square (Nocti)",

                Description = "The market is in full swing! Breakfast is over, and people are hustling and bustling about. " +
                "You hear the blacksmith tanging away on metal, the horses in the stables neighing, and the smell of bread " +
                "wafts over you, inundating your senses.",

                Messages = "To your left is the Herbalist Shop. A great place to herbs for healing and potions (If you have the coin) " +
                "To your right is the Stables, filled with glorious horses of all breeds. ",

                Accessible = true
            };

            gameMap.Locations[3, 5] = new Location()
            {
                ID = 3,

                Name = "Herbalist (Nocti)",

                Description = "The Herbalist is pounding away in her mortar. As you enter the shop, she looks up at you " +
                "and welcomes you to the shop! The smell of dried herbs fills your nostrils " +
                "You glance around the shop. You see lots of different herbs for healing.",

                Messages = "On your quest, you may have need of some herbs. " +
                "You have limited coin however, and there are many other shops to visit before leaving on your epic quest!" +
                "Choose wisely, or you may regret your decisions later.",

                Accessible = true
            };

            gameMap.Locations[3, 7] = new Location()
            {
                ID = 4,

                Name = "Stables (Nocti)",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are quite lively this morning aren't they?",

                Accessible = true
            };

            gameMap.Locations[4, 7] = new Location()
            {
                ID = 5,

                Name = "Front Gate (Nocti)",

                Description = "The iron wrought gate looms over the town of Nocti, the only entrance and exit from the city!",

                Accessible = true
            };

            gameMap.Locations[2, 5] = new Location()
            {
                ID = 6,

                Name = "Food Shop (Nocti)",

                Description = "The aroma of food fills the air. Breads, meats, berries, oh my! The chef stands in the corner stirring " +
                "a large pot of porridge. He's a rather portly man who clearly has a great taste in food. ",

                Messages = "If you plan on traveling a fair distance from Nocti, you might want to invest in some rations to take with you. " +
                           "I'm sure the chef would be more than happy to help you out if you asked nicely!",

                Accessible = true
            };

            gameMap.Locations[2, 6] = new Location()
            {
                ID = 7,

                Name = "Tailor (Nocti)",

                Description = "The tailor shop is overflowing with leather and cloth goods. Robes with magical affinities " +
                "and satchels for holding copious amount of items. Wading through the rows upon rows of items, the store owner finally comes into view. " +
                "She is a the Great Mage Tulmerian!",

                Messages = "With a Great Mage making these fine clothing items, surely something here can be of use on your journey! " +
                "Items of this quality though are not cheap. Make sure to budget wisely.",

                Accessible = true
            };

            gameMap.Locations[2, 7] = new Location()
            {
                ID = 8,

                Name = "Potions Shop (Nocti)",

                Description = "The Potions Shop is now open!",

                Messages = "Potions of all kind exist here. Everything from gaining life, mana, and even skill points as a Healer or Mage!",

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

            gameMap.Locations[5, 6] = new Location()
            {
                ID = 20,

                Name = "Ferlion Fields",

                Description = "The fields of Ferlion! Filled with copious amounts of flowers that are so beautiful to look at!" ,

                Messages = "Too bad they are deadly! You died!",

                Accessible = true,

                ModifyHealth = 100,

                ModifyLives = 1
            };

                gameMap.Locations[6, 7] = new Location()
            {
                ID = 10,

                Name = "Southern Road",

                Description = "The road is long, but the breeze grows stronger. The smell of salt lingers in the air, you must be nearing Sra'lik Sea!",

                Accessible = true
            };

            gameMap.Locations[6, 6] = new Location()
            {
                ID = 19,

                Name = "Magic Swamp",

                Description = "The Swamp teems with Magic! Fairies and sprites abound. You can feel the magic flow into you!",

                Messages = "You stand in a swamp of great magic! You gain +10 Mage Skill and +10 Healer Skill!",

                Accessible = true,

                RequiredMageSkill = 10,

                RequiredHealerSkill = 10
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

                Description = "The fishing shop seems old and run down. A haggered old fisherman stands behind the counter. He doesn't look well. ",

                Messages = "This old man may be in some serious need of a healer and stat! " ,

                Accessible = true,

                RequiredHealerSkill = 5
            };

            gameMap.Locations[7, 6] = new Location()
            {
                ID = 13,

                Name = "Tornul (Fishing Master)",

                Description = "You see an old man, sitting on the dock, feet hanging off in the Water. This must be Tornul " +
                "the Fishing Master everyone talks about.",

                Messages = "Tornul is one of the greatest fishermen of all time! He uses his advanced knowledge of magic to call th fish to his lures. " +
                "Maybe he can teach you a thing or two about his magic?",

                Accessible = true,

                RequiredMageSkill = 5
            };

            gameMap.Locations[5, 8] = new Location()
            {
                ID = 14,

                Name = "Eastern Road",

                Description = "Yet another long road leading to the east. The path is covered in grass, and looks to be less traveled than the southern road!",

                Accessible = true
            };

            gameMap.Locations[5, 9] = new Location()
            {
                ID = 15,

                Name = "Eastern Road",

                Description = "The road seems to be inclining as you near the end. The path becomes much more difficult to traverse! No wonder no one came up here.",

                Accessible = true
            };

            gameMap.Locations[5, 10] = new Location()
            {
                ID = 16,

                Name = "Juit Bluffs",

                Description = "As the road levels off at the top, a wide bluff extends out for as far as the eye can see. This must be Juit Bluffs!",

                Messages = "Locals have talked about great magic and dragons residing here at Juit Bluffs! " +
                "Perhaps you can learn some of this magic or even gather some dragon scale! Too bad that hike has left you starving though. 25 health lost",

                Accessible = true,

                ModifyHealth = 25
            };

            gameMap.Locations[5, 11] = new Location()
            {
                ID = 17,

                Name = "Dragon Clutch",

                Description = "Approaching the edge, a dragon clutch can be seen down the bluffs. That is a far way down though . . .",

                Messages = "You are determined to gather loose dragon scales! Only problem is, their clutch is a solid 300 feet down the bluff " +
                "Good thing you bought some rope back in Nocti, right?!?",

                Accessible = true,

                RequiredHealerSkill = 25
            };

            gameMap.Locations[6, 10] = new Location()
            {
                ID = 18,

                Name = "Campfire",

                Description = "A large bonfire roars with such ferocity. On the other side sits an old mage contemplating god knows what.",

                Messages = "The mage surely can teach you some magic. Do you have what it takes to learn from a master? " +
                "I'm sure some of those mage affinity potions would come in great help in this instance!",

                Accessible = true,

                RequiredMageSkill = 25
            };

            return gameMap;
        }

        #endregion
    }
}
