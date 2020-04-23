using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
                Experience = 0,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(131), 500)
                }
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

        public static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Creates the data for the Game Map
        /// </summary>
        /// <returns>Returns the populated Game Map</returns>
        public static Map GameMap()
        {
            int rows = 8;
            int columns = 12;

            Map gameMap = new Map(rows, columns);

            gameMap.StandardGameItems = StandardGameItems();

            gameMap.Locations[4, 6] = new Location()
            {
                ID = 1,

                Name = "Home (Nocti)",

                Description = "You arose in your home in the capital City of Nocti. The air is damp, the room is dark. " +
                "You start to hear the hustle and bustle outside. The city is awakening and you slowly stir from bed. " +
                "You make your way to the kitchen, whisper Fiero'n and watch as the fire springs from your fingertips to the hearth. " +
                "You listen to the crackle of the fire as you prepare breakfast. Today is an important day, and you soak up your home for the foreseeable future.",

                Messages = "You are soon to become of age in the realm of Qui'Lash. You must venture forth on an epic journey to discover what talents and skills you have to benefit society. " +
                "Will you follow in your Mom's footstep as a formidable healer or in your Father's light as a powerful Mage? " +
                "You only have 3 months to discover your true talents, or you risk being exiled from Nocti and banished to the Northern Tundra.",

                Accessible = true,
                
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(101), 2),
                    new GameItemQuantity(GameItemById(121), 1),
                    new GameItemQuantity(GameItemById(123), 1)
                }

            };

            gameMap.Locations[3, 6] = new Location()
            {
                ID = 2,

                Name = "Market Square (Nocti)",

                Description = "The market is in full swing! Breakfast is over, and people are hustling and bustling about. " +
                "You hear the blacksmith tanging away on metal, the horses in the stables neighing, and the smell of bread " +
                "wafts over you, inundating your senses.",

                Messages = "To your left is the Merchant Shop. A great place to sell treasures for Nocti Quarks. " +
                "To your right is the Stables, filled with glorious horses of all breeds. ",

                Accessible = true,

                ExperienceGain = 10,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(101), 5)
                }
            };

            gameMap.Locations[3, 5] = new Location()
            {
                ID = 3,

                Name = "Merchant (Nocti)",

                Description = "The Merchant shop looks pristine and kept up. A faint scent of Junl'ai berries fill the air " +
                "In the corner sits a case with the most magnificient gems in the land! " +
                "On the wall behind the merchant sit scrolls from times gone by.",

                Messages = "On your quest, you may discover treasures throughout the land! " +
                "Find these treasures and bring them back to the Merchant to trade for Nocti Quarks! ",

                Accessible = true,

                ExperienceGain = 10,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(101), 2)
                }
            };

            gameMap.Locations[3, 7] = new Location()
            {
                ID = 4,

                Name = "Stables (Nocti)",

                Description = "The Stables are roaring as you enter. Horses neighing and stomping their feet.",

                Messages = "The Stables are quite lively this morning aren't they?",

                Accessible = false,

                RequiredExperience = 40,

                ExperienceGain = 10,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(132), 1)
                }
            };

            gameMap.Locations[4, 7] = new Location()
            {
                ID = 5,

                Name = "Front Gate (Nocti)",

                Description = "The iron wrought gate looms over the town of Nocti, the only entrance and exit from the city!",

                Messages = "You must have at least 100 experience to leave the city!",

                Accessible = true,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(131), 2)
                }
            };

            gameMap.Locations[2, 5] = new Location()
            {
                ID = 6,

                Name = "Food Shop (Nocti)",

                Description = "The aroma of food fills the air. Breads, meats, berries, oh my! The chef stands in the corner stirring " +
                "a large pot of porridge. He's a rather portly man who clearly has a great taste in food. ",

                Messages = "If you plan on traveling a fair distance from Nocti, you might want to invest in some rations to take with you. " +
                           "I'm sure the chef would be more than happy to help you out if you asked nicely!",

                Accessible = false,

                RequiredExperience = 10,

                ExperienceGain = 10,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(131), 10)
                }
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

                Accessible = false,

                RequiredExperience = 20,

                ExperienceGain = 10,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(131), 1)
                }
            };

            gameMap.Locations[2, 7] = new Location()
            {
                ID = 8,

                Name = "Potions Shop (Nocti)",

                Description = "The Potions Shop is now open!",

                Messages = "Potions of all kind exist here. Everything from gaining life, mana, and even skill points as a Healer or Mage!",

                Accessible = false,

                RequiredExperience = 30,

                ExperienceGain = 10,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(131), 5)
                }
            };

            gameMap.Locations[5, 7] = new Location()
            {
                ID = 9,

                Name = "Southern Road",

                Description = "The road is long and dusty. The sun bearing down overhead, you feel a slight breeze moving in " +
                "from the North.",

                Accessible = false,

                RequiredExperience = 100,

                ExperienceGain = 5
            };

            gameMap.Locations[5, 6] = new Location()
            {
                ID = 20,

                Name = "Ferlion Fields",

                Description = "The fields of Ferlion! Filled with copious amounts of flowers that are so beautiful to look at!" ,

                Messages = "Too bad they are deadly! You died! Lucky your Amulet given to you by your mother brought you back! Now Be Gone!",

                Accessible = false,

                RequiredExperience = 110,

                ModifyHealth = -75,

                ModifyLives = -1
            };

                gameMap.Locations[6, 7] = new Location()
            {
                ID = 10,

                Name = "Southern Road",

                Description = "The road is long, but the breeze grows stronger. The smell of salt lingers in the air, you must be nearing Sra'lik Sea!",

                Accessible = false,

                RequiredExperience = 100,

                ExperienceGain = 5
            };

            gameMap.Locations[6, 6] = new Location()
            {
                ID = 19,

                Name = "Magic Swamp",

                Description = "The Swamp teems with Magic! Fairies and sprites abound. You can feel the magic flow into you!",

                Messages = "You stand in a swamp of great magic! You gain +10 Mage Skill and +10 Healer Skill!",

                Accessible = false,

                RequiredExperience = 110,

                MageSkill = 10,

                HealerSkill = 10,

                ExperienceGain = 20,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(103), 1),
                    new GameItemQuantity(GameItemById(105), 1),
                    new GameItemQuantity(GameItemById(131), 50),
                    new GameItemQuantity(GameItemById(137), 1)
                }
            };

            gameMap.Locations[7, 7] = new Location()
            {
                ID = 11,

                Name = "Sra'Lik Sea",

                Description = "At last the sea is in full view! The breeze cutting through the hot mid summer sun like a cool autumn night. " +
                "To the east is a fishing shop and to the west is a man sitting on a dock.",

                Messages = "After Such a long journey a fresh fish sounds amazing right now! Too bad the fishing shop seems to be closed right now. " +
                "Maybe that old woman on the path up ahead might know when they open?",

                Accessible = true
            };

            gameMap.Locations[7, 8] = new Location()
            {
                ID = 12,

                Name = "Fishing Shop",

                Description = "The fishing shop seems old and run down. A haggard old fisherman stands behind the counter. He doesn't look well. ",

                Messages = "This old man may be in some serious need of a healer and stat! " ,

                Accessible = false,

                HealerSkill = 15,

                RequiredItem = 102,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(102), 2),
                    new GameItemQuantity(GameItemById(131), 25)
                }
            };

            gameMap.Locations[7, 6] = new Location()
            {
                ID = 13,

                Name = "Tornul (Fishing Master)",

                Description = "You see an old man, sitting on the dock, feet hanging off in the Water. This must be Tornul " +
                "the Fishing Master everyone talks about.",

                Messages = "Tornul is one of the greatest fishermen of all time! He uses his advanced knowledge of magic to call the fish to his lures. " +
                "Maybe he can teach you a thing or two about his magic?",

                Accessible = false,

                MageSkill = 15,

                RequiredExperience = 135,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(131), 2)
                }
            };

            gameMap.Locations[5, 8] = new Location()
            {
                ID = 14,

                Name = "Eastern Road",

                Description = "Yet another long road leading to the east. The path is covered in grass, and looks to be less traveled than the southern road!",

                Accessible = false,

                RequiredExperience = 120,
                
                ExperienceGain = 10
            };

            gameMap.Locations[5, 9] = new Location()
            {
                ID = 15,

                Name = "Eastern Road",

                Description = "The road seems to be inclining as you near the end. The path becomes much more difficult to traverse! No wonder no one came up here.",

                Accessible = false,

                RequiredExperience = 125,

                ExperienceGain = 25
            };

            gameMap.Locations[5, 10] = new Location()
            {
                ID = 16,

                Name = "Juit Bluffs",

                Description = "As the road levels off at the top, a wide bluff extends out for as far as the eye can see. This must be Juit Bluffs!",

                Messages = "Locals have talked about great magic and dragons residing here at Juit Bluffs! " +
                "Perhaps you can learn some of this magic or even gather some dragon scale! Too bad that hike has left you starving though. 25 health lost",

                Accessible = false,

                ModifyHealth = -25,

                RequiredExperience = 130,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(101), 1),
                    new GameItemQuantity(GameItemById(137), 10)
                }
            };

            gameMap.Locations[5, 11] = new Location()
            {
                ID = 17,

                Name = "Dragon Clutch",

                Description = "Approaching the edge, a dragon clutch can be seen down the bluffs. That is a far way down though . . .",

                Messages = "You are determined to gather loose dragon scales! Only problem is, their clutch is a solid 300 feet down the bluff " +
                "Good thing you found the Scroll of Descent right?!?",

                Accessible = false,

                HealerSkill = 25,

                RequiredItem = 137,

                RequiredExperience = 110,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(101), 2)
                }
            };

            gameMap.Locations[6, 10] = new Location()
            {
                ID = 18,

                Name = "Campfire",

                Description = "A large bonfire roars with such ferocity. On the other side sits an old mage contemplating god knows what.",

                Messages = "The mage surely can teach you some magic. Do you have what it takes to learn from a master? " +
                "I'm sure some of those mage affinity potions would come in great help in this instance!",

                Accessible = false,

                MageSkill = 25,

                RequiredExperience = 150,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(122), 4)
                }
            };

            return gameMap;
        }

        #endregion

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Potion(101, "Lesser Health Potion", 10, 25, 0, 0, 0, 0, 10, "Lesser Health Potion restores 25 HP", "You restored 25 HP"),
                new Potion(102, "Greater Health Potion", 25, 75, 0, 0, 0, 0, 10, "Greater Health Potion restores 75 HP", "You restored 75 HP"),
                new Potion(103, "Lesser Mage Potion", 100, 0, 0, 0, 10, 0, 10, "Lesser Mage Potion grants 10 Mage Skill Points", "You gained 10 Mage Skill Points"),
                new Potion(104, "Greater Mage Potion", 250, 0, 0, 0, 25, 0, 10, "Greater Mage Potion grants 25 Mage Skill Points", "You gained 25 Mage Skill Points"),
                new Potion(105, "Lesser Healer Potion", 100, 0, 0, 0, 0, 10, 10, "Lesser Healer Potion grants 10 Healer Skill Points", "You gained 10 Healer Skill Points"),
                new Potion(106, "Greater Healer Potion", 250, 0, 0, 0, 0, 25, 10, "Greater Healer Potion grants 25 Healer Skill Points", "You gained 25 Healer Skill Points"),
                new Potion(107, "Mana Potion", 10, 0, 0, 25, 0, 0, 10, "Mana Potions restore 25 Mana", "You restored 25 Mana"),
                new Potion(108, "Life Potion", 500, 100, 1, 100, 0, 0, 10, "Life Potions grant 1 life, Full Health, and Full Mana", "You gained 1 life, Full Health, and Full Mana"),

                new Clothes( 111, "Hat of Quin'lai", 50, Clothes.ClothesType.Hat, 0, 0, 10, 0, 10, "This hat pulses with the power of many mages!"),
                new Clothes(112, "Robe of Quin'lai", 150, Clothes.ClothesType.Robe, 0, 0, 25, 0, 10, "This robe has decades of mages secrets woven into it's fibers"),
                new Clothes(113, "Cloak of Quin'lai", 150, Clothes.ClothesType.Cloak, 0, 0, 25, 0, 10,"This clock glows with the power of the Quin'lai mages"),
                new Clothes(114, "Hat of Aqua'l", 50, Clothes.ClothesType.Hat, 0, 0, 0, 10, 10, "The hat glows with the golden light of Aqua'l"),
                new Clothes(115, "Robe of Aqua'l", 150, Clothes.ClothesType.Robe, 0, 0, 0, 25, 10, "This robe seems to be imbued with healing powers"),
                new Clothes(116, "Cloak of Aqua'l", 150, Clothes.ClothesType.Cloak, 0, 0, 0, 25, 10, "This cloak casts a warm healing light"),

                new Food(121, "Marlio Berries", 5, Food.FoodType.Berries, 10, 0, 10, "These delicious berries can be used to restore health", "Restored 10HP"),
                new Food(122, "Wizard Berries", 25, Food.FoodType.Berries, 75, 0, 10, "These bright white berries are known for restoring large amounts of health", "Restored 75HP"),
                new Food(123, "Quil'ash Stout", 10, Food.FoodType.Drink, 25, 25, 10, "These stout is briming with medicinal herbs and roots. Great for Health and Mana", "Restored 25HP and 25 Mana"),
                new Food(124, "Nocti Tea", 300, Food.FoodType.Drink, 50, 50, 10, "Ncoti tea is renowned for its healing and regeneration properties", "Restored 50HP and 50 Mana"),
                new Food(125, "Starl'ai Boar", 40, Food.FoodType.Meat, 40, 0, 10, "Some of the finest meat around!", "Restored 40 HP"),
                new Food(126, "Yerlund Venison", 60, Food.FoodType.Meat, 60, 0, 10, "Venision from the finest magical forest", "Restored 60HP"),
                new Food(127, "Nocti Bakers Special", 25, Food.FoodType.Bread, 30, 30, 10, "Nocti's cheapest bread. Restores health and mana", "Restored 30 HP and 30 Mana"),
                new Food(128, "Mystic bread", 600, Food.FoodType.Bread, 100, 100, 10, "Magical bread that fully restores a user", "Restored 100HP and 100 Mana"),

                new Treasure(131, "Nocti Quarks", 1, Treasure.TreasureType.Coin, "Nocti Quarks are the official currency in Nocti"),
                new Treasure(132, "Gem of Odal", 100, Treasure.TreasureType.Gem, "A rather sizeable gem, might be worth something"),
                new Treasure(133, "Qui'lash Star", 500, Treasure.TreasureType.Gem, "The rarest gem of Qui'lash! Worth a sizeable sum"),
                new Treasure(134, "Black Diamond", 250, Treasure.TreasureType.Gem, "Special gem found only in Nocti. Worth an average amount"),
                new Treasure(135, "Scoll of Mages", 50, Treasure.TreasureType.Scroll, "Scroll of Mages may be tradeable for some mage potions"),
                new Treasure(136, "Scroll of Healing", 50, Treasure.TreasureType.Scroll, "Scroll of Healing may be tradeable for some healer potions"),
                new Treasure(137, "Scroll of Descent", 100, Treasure.TreasureType.Scroll, "Scroll of Nocti calls forth a magical rope", "You opened up access to the Dragon Clutch!")
            };
        }
    }
}
