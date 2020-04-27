using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Navigation;
using Elarya.Models;

namespace Elarya.Data
{
    public static class GameData
    {

        #region Player Data

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
                Experience = 0,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(131), 1000)
                },
                Quests = new ObservableCollection<Quest>()
                {
                    QuestById(1),
                    QuestById(2),
                    QuestById(3)
                }
            };
        }

        #endregion

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
        /// Gets the Item by Item ID
        /// </summary>
        /// <param name="id">Selected Item ID</param>
        /// <returns>Returns the Item</returns>
        public static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Gets the NPC by ID
        /// </summary>
        /// <param name="id">Selected NPC ID</param>
        /// <returns>Returns the NPC</returns>
        public static Npc GetNpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Gets a Quest by Id
        /// </summary>
        /// <param name="id">Id of Quest</param>
        /// <returns>Returns the selected Quest</returns>
        public static Quest QuestById(int id)
        {
            return Quests().FirstOrDefault(q => q.Id == id);
        }

        /// <summary>
        /// Gets a location by id
        /// </summary>
        /// <param name="id">ID of Location</param>
        /// <returns>Returns the Location</returns>
        public static Location LocationById(int id)
        {
            List<Location> locations =new List<Location>();

            foreach (Location location in GameMap().Locations)
            {
                if (location != null)
                {
                    locations.Add(location);
                }
            }

            return locations.FirstOrDefault(x => x.Id == id);
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
                Id = 1,

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
                Id = 2,

                Name = "Market Square (Nocti)",

                Description = "The market is in full swing! Breakfast is over, and people are hustling and bustling about. " +
                "You hear the blacksmith tanging away on metal, the horses in the stables neighing, and the smell of bread " +
                "wafts over you, inundating your senses.",

                Messages = "To your left is the Merchant Shop. A great place to sell treasures for Nocti Quarks. " +
                "To your right is the Stables, filled with glorious horses of all breeds. ",

                Accessible = true,

                ExperienceGain = 10,

                Npcs = new ObservableCollection<Npc>()
                {
                    GetNpcById(1005),
                    GetNpcById(1010)
                }
            };

            gameMap.Locations[3, 5] = new Location()
            {
                Id = 3,

                Name = "Merchant (Nocti)",

                Description = "The Merchant shop looks pristine and kept up. A faint scent of Junl'ai berries fill the air " +
                "In the corner sits a case with the most magnificient gems in the land! " +
                "On the wall behind the merchant sit scrolls from times gone by.",

                Messages = "On your quest, you may discover treasures throughout the land! " +
                "Find these treasures and bring them back to the Merchant to trade for Nocti Quarks! ",

                Accessible = true,

                ExperienceGain = 10,

                Npcs = new ObservableCollection<Npc>()
                {
                    GetNpcById(1001)
                }
            };

            gameMap.Locations[3, 7] = new Location()
            {
                Id = 4,

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
                Id = 5,

                Name = "Front Gate (Nocti)",

                Description = "The iron wrought gate looms over the town of Nocti, the only entrance and exit from the city!",

                Messages = "You must have at least 100 experience to leave the city!",

                Accessible = true,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(131), 50)
                },

                Npcs = new ObservableCollection<Npc>()
                {
                    GetNpcById(1011)
                }
            };

            gameMap.Locations[2, 5] = new Location()
            {
                Id = 6,

                Name = "Food Shop (Nocti)",

                Description = "The aroma of food fills the air. Breads, meats, berries, oh my! The chef stands in the corner stirring " +
                "a large pot of porridge. He's a rather portly man who clearly has a great taste in food. ",

                Messages = "If you plan on traveling a fair distance from Nocti, you might want to invest in some rations to take with you. " +
                           "I'm sure the chef would be more than happy to help you out if you asked nicely!",

                Accessible = false,

                RequiredExperience = 10,

                ExperienceGain = 10,

                Npcs = new ObservableCollection<Npc>()
                {
                    GetNpcById(1003)
                }
            };

            gameMap.Locations[2, 6] = new Location()
            {
                Id = 7,

                Name = "Tailor (Nocti)",

                Description = "The tailor shop is overflowing with leather and cloth goods. Robes with magical affinities " +
                "and satchels for holding copious amount of items. Wading through the rows upon rows of items, the store owner finally comes into view. " +
                "She is a the Great Mage Tulmerian!",

                Messages = "With a Great Mage making these fine clothing items, surely something here can be of use on your journey! " +
                "Items of this quality though are not cheap. Make sure to budget wisely.",

                Accessible = false,

                RequiredExperience = 20,

                ExperienceGain = 10,

                Npcs = new ObservableCollection<Npc>()
                {
                    GetNpcById(1002)
                }
            };

            gameMap.Locations[2, 7] = new Location()
            {
                Id = 8,

                Name = "Potions Shop (Nocti)",

                Description = "The Potions Shop is now open!",

                Messages = "Potions of all kind exist here. Everything from gaining life, mana, and even skill points as a Healer or Mage!",

                Accessible = false,

                RequiredExperience = 30,

                ExperienceGain = 10,

                Npcs = new ObservableCollection<Npc>()
                {
                    GetNpcById(1004)
                }
            };

            gameMap.Locations[5, 7] = new Location()
            {
                Id = 9,

                Name = "Southern Road 1",

                Description = "The road is long and dusty. The sun bearing down overhead, you feel a slight breeze moving in " +
                "from the North.",

                Accessible = false,

                RequiredExperience = 100,

                ExperienceGain = 5
            };

            gameMap.Locations[5, 6] = new Location()
            {
                Id = 20,

                Name = "Ferlion Fields",

                Description = "The fields of Ferlion! Filled with copious amounts of flowers that are so beautiful to look at!" ,

                Messages = "Too bad they are deadly! You died! Lucky your Amulet given to you by your mother brought you back! Lucky for you, there appears to be a valuable item here you need, at the cost of your life though",

                Accessible = false,

                ModifyLives = -1,

                RequiredExperience = 150,

                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(142), 1)
                }
            };

                gameMap.Locations[6, 7] = new Location()
            {
                Id = 10,

                Name = "Southern Road 2",

                Description = "The road is long, but the breeze grows stronger. The smell of salt lingers in the air, you must be nearing Sra'lik Sea!",

                Accessible = true,

                ExperienceGain = 5
            };

            gameMap.Locations[6, 6] = new Location()
            {
                Id = 19,

                Name = "Magic Swamp",

                Description = "The Swamp teems with Magic! Fairies and sprites abound. You can feel the magic flow into you!",

                Messages = "You stand in a swamp of great magic! You gain +10 Mage Skill and +10 Healer Skill!",

                Accessible = false,

                RequiredExperience = 180,

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
                Id = 11,

                Name = "Sra'Lik Sea",

                Description = "At last the sea is in full view! The breeze cutting through the hot mid summer sun like a cool autumn night. " +
                "To the east is a fishing shop and to the west is a man sitting on a dock.",

                Messages = "After Such a long journey a fresh fish sounds amazing right now! Too bad the fishing shop seems to be closed right now. " +
                "Maybe that old woman on the path up ahead might know when they open?",

                Accessible = true,

                ExperienceGain = 20,

                Npcs = new ObservableCollection<Npc>()
                {
                    GetNpcById(1009)
                }
            };

            gameMap.Locations[7, 8] = new Location()
            {
                Id = 12,

                Name = "Fishing Shop",

                Description = "The fishing shop seems old and run down. A haggard old fisherman stands behind the counter. He doesn't look well. ",

                Messages = "This old man may be in some serious need of a healer and stat! " ,

                Accessible = false,

                HealerSkill = 15,

                RequiredItem = 139,

                ExperienceGain = 20,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(102), 2),
                    new GameItemQuantity(GameItemById(131), 25)
                },

                Npcs = new ObservableCollection<Npc>()
                {
                    GetNpcById(1007)
                }
            };

            gameMap.Locations[7, 6] = new Location()
            {
                Id = 13,

                Name = "Tornul (Fishing Master)",

                Description = "You see an old man, sitting on the dock, feet hanging off in the Water. This must be Tornul " +
                "the Fishing Master everyone talks about.",

                Messages = "Tornul is one of the greatest fishermen of all time! He uses his advanced knowledge of magic to call the fish to his lures. " +
                "Maybe he can teach you a thing or two about his magic?",

                Accessible = false,

                MageSkill = 15,

                RequiredItem = 138,

                ExperienceGain = 20,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(131), 2),
                    new GameItemQuantity(GameItemById(134), 2)
                },

                Npcs = new ObservableCollection<Npc>()
                {
                    GetNpcById(1006)
                }
            };

            gameMap.Locations[5, 8] = new Location()
            {
                Id = 14,

                Name = "Eastern Road 1",

                Description = "Yet another long road leading to the east. The path is covered in grass, and looks to be less traveled than the southern road!",

                Accessible = true,

                ExperienceGain = 10
            };

            gameMap.Locations[5, 9] = new Location()
            {
                Id = 15,

                Name = "Eastern Road 2",

                Description = "The road seems to be inclining as you near the end. The path becomes much more difficult to traverse! No wonder no one came up here.",

                Accessible = true,

                ExperienceGain = 25,

                Npcs = new ObservableCollection<Npc>()
                {
                    GetNpcById(1012)
                }
            };

            gameMap.Locations[5, 10] = new Location()
            {
                Id = 16,

                Name = "Juit Bluffs",

                Description = "As the road levels off at the top, a wide bluff extends out for as far as the eye can see. This must be Juit Bluffs!",

                Messages = "Locals have talked about great magic and dragons residing here at Juit Bluffs! " +
                "Perhaps you can learn some of this Mage magic or even find a rare Healing Spell. Too bad that hike has left you starving though. 25 health lost",

                Accessible = true,

                ModifyHealth = -25,

                ExperienceGain = 20,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(101), 1)
                }
            };

            gameMap.Locations[5, 11] = new Location()
            {
                Id = 17,

                Name = "Dragon Clutch",

                Description = "Approaching the edge, a dragon clutch can be seen down the bluffs. That is a far way down though . . . At the bottom appears to be a scroll, closely guarded by the dragons",

                Messages = "You are determined to find out what is on that scroll! Only problem is, their clutch is a solid 300 feet down the bluff " +
                "Good thing you found the Scroll of Descent right! Get to descending.",

                Accessible = false,

                HealerSkill = 150,

                RequiredItem = 137,

                ExperienceGain = 20,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(101), 2),
                    new GameItemQuantity(GameItemById(141), 1),
                    new GameItemQuantity(GameItemById(133), 2)
                }
            };

            gameMap.Locations[6, 10] = new Location()
            {
                Id = 18,

                Name = "Campfire",

                Description = "A large bonfire roars with such ferocity. On the other side sits an old mage contemplating god knows what.",

                Messages = "The mage surely can teach you some magic. Do you have what it takes to learn from a master? ",
                
                Accessible = false,

                RequiredItem = 142,

                ExperienceGain = 20,

                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(122), 4)
                },

                Npcs = new ObservableCollection<Npc>()
                {
                    GetNpcById(1008)
                }
            };

            return gameMap;
        }

        #endregion

        #region Game Items

        /// <summary>
        /// Creates the Standard Game Items
        /// </summary>
        /// <returns>Returns a list of the Game Items</returns>
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Potion(101, "Lesser Health Potion", 50, 25, 0, 0, 0, 0, 10, "Lesser Health Potion restores 25 HP", "You restored 25 HP"),
                new Potion(102, "Greater Health Potion", 150, 75, 0, 0, 0, 0, 10, "Greater Health Potion restores 75 HP", "You restored 75 HP"),
                new Potion(103, "Lesser Mage Potion", 100, 0, 0, 0, 10, 0, 10, "Lesser Mage Potion grants 10 Mage Skill Points", "You gained 10 Mage Skill Points"),
                new Potion(104, "Greater Mage Potion", 250, 0, 0, 0, 25, 0, 10, "Greater Mage Potion grants 25 Mage Skill Points", "You gained 25 Mage Skill Points"),
                new Potion(105, "Lesser Healer Potion", 100, 0, 0, 0, 0, 10, 10, "Lesser Healer Potion grants 10 Healer Skill Points", "You gained 10 Healer Skill Points"),
                new Potion(106, "Greater Healer Potion", 250, 0, 0, 0, 0, 25, 10, "Greater Healer Potion grants 25 Healer Skill Points", "You gained 25 Healer Skill Points"),
                new Potion(107, "Mana Potion", 50, 0, 0, 25, 0, 0, 10, "Mana Potions restore 25 Mana", "You restored 25 Mana"),
                new Potion(108, "Life Potion", 500, 100, 1, 100, 0, 0, 10, "Life Potions grant 1 life, Full Health, and Full Mana", "You gained 1 life, Full Health, and Full Mana"),
                

                new Potion(109, "Free Mage Potion", 0, 0, 0, 0, 25, 0, 25, "Increase your Mage Skill points", "You gained 25 Mage Skill Points"),
                new Potion(110, "Free Healer Potion", 0, 0, 0, 0, 0, 25, 0, "Grants 25 Healer Skill", "You gained 25 Healer Skill Points!"),


                new Clothes( 111, "Hat of Quin'lai", 50, Clothes.ClothesType.Hat, 0, 0, 10, 0, 20, "This hat pulses with the power of many mages!", "You have gained 10 Mage Skill and 20 Experience!"),
                new Clothes(112, "Robe of Quin'lai", 150, Clothes.ClothesType.Robe, 0, 0, 25, 0, 20, "This robe has decades of mages secrets woven into it's fibers", "You have gained 25 Mage Skill and 20 Experience"),
                new Clothes(113, "Cloak of Quin'lai", 150, Clothes.ClothesType.Cloak, 0, 0, 25, 0, 20,"This cloak glows with the power of the Quin'lai mages", "You have gained 25 Mage Skill and 20 Experience"),
                new Clothes(114, "Hat of Aqua'l", 50, Clothes.ClothesType.Hat, 0, 0, 0, 10, 20, "The hat glows with the golden light of Aqua'l", "You have gained 10 Healer Skill and 20 Experience"),
                new Clothes(115, "Robe of Aqua'l", 150, Clothes.ClothesType.Robe, 0, 0, 0, 25, 20, "This robe seems to be imbued with healing powers", "You have gained 25 Healer Skill and 20 Experience"),
                new Clothes(116, "Cloak of Aqua'l", 150, Clothes.ClothesType.Cloak, 0, 0, 0, 25, 20, "This cloak casts a warm healing light", "You have gained 25 Healer Skill and 20 Experience"),

                new Food(121, "Marlio Berries", 5, Food.FoodType.Berries, 10, 0, 10, "These delicious berries can be used to restore health", "Restored 10HP"),
                new Food(122, "Wizard Berries", 25, Food.FoodType.Berries, 75, 0, 10, "These bright white berries are known for restoring large amounts of health", "Restored 75HP"),
                new Food(123, "Quil'ash Stout", 10, Food.FoodType.Drink, 25, 25, 10, "These stout is briming with medicinal herbs and roots. Great for Health and Mana", "Restored 25HP and 25 Mana"),
                new Food(124, "Nocti Tea", 300, Food.FoodType.Drink, 50, 50, 10, "Nocti tea is renowned for its healing and regeneration properties", "Restored 50HP and 50 Mana"),
                new Food(125, "Starl'ai Boar", 40, Food.FoodType.Meat, 40, 0, 10, "Some of the finest meat around!", "Restored 40 HP"),
                new Food(126, "Yerlund Venison", 60, Food.FoodType.Meat, 60, 0, 10, "Venision from the finest magical forest", "Restored 60HP"),
                new Food(127, "Nocti Bakers Special", 25, Food.FoodType.Bread, 30, 30, 10, "Nocti's cheapest bread. Restores health and mana", "Restored 30 HP and 30 Mana"),
                new Food(128, "Mystic bread", 600, Food.FoodType.Bread, 100, 100, 10, "Magical bread that fully restores a user", "Restored 100HP and 100 Mana"),

                new Treasure(131, "Nocti Quarks", 1, Treasure.TreasureType.Coin, "Nocti Quarks are the official currency in Nocti"),
                new Treasure(132, "Gem of Odal", 100, Treasure.TreasureType.Gem, "A rather sizeable gem, might be worth something"),
                new Treasure(133, "Qui'lash Star", 500, Treasure.TreasureType.Gem, "The rarest gem of Qui'lash! Worth a sizeable sum"),
                new Treasure(134, "Black Diamond", 250, Treasure.TreasureType.Gem, "Special gem found only in Nocti. Worth an average amount"),

                new Spell(137, "Spell of Descent", 100, Spell.SpellType.Mage, 50, 10, 0, "Great for descending bluffs . . .", "You opened up access to the Dragon Clutch!"),
                new Spell(138, "Spell of Thanks", 0, Spell.SpellType.Mage, 25, 10, 0 , " Removes Mist often blocking Fisherman, like Tornul!"),
                new Spell(139, "Spell of Revival", 250, Spell.SpellType.Healing, 75, 0, 10, "If someone needs healing, use this spell", "You have healed the Fishing Shop owner! Go Speak with him!"),
                new Spell(140, "Great Mage Spell", 0, Spell.SpellType.Mage, 95, 10, 0, "Grants a massive amount of Mage Skill.", "You have gained 200 Mage Skill Points"),
                new Spell(141, "Great Healer Spell", 0, Spell.SpellType.Healing, 95, 0, 10, "Grants a massive amount of Healer Skill.", "You have gained 200 Healer Skill Points"),
                new Spell(142, "Spell of Disallusion", 250, Spell.SpellType.Mage, 50, 10, 0, "Removes illusions opening up areas otherwise closed!", "You opened access to the CampFire!")
            };
        }

        #endregion

        #region NPC's

        /// <summary>
        /// Creates the List of NPCs
        /// </summary>
        /// <returns>Returns the List of NPCs</returns>
        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new Merchant()
                {
                    Id = 1001,
                    Name = "Qenli",
                    Age = 32,
                    Race = Character.RaceType.Diolecian,
                    Gender = Character.GenderType.Female,
                    Description = "A quaint little woman with sharp eyes, and a sharper wit!",
                    LocationId = 3,
                    Messages = new List<string>()
                    {
                        "Welcome to the Merchant Shop!",
                        "Do you have any treasure to show me?",
                        "What brings you into my shop today?",
                        "If you come across treasure on your travels, I can make you richer!"
                    },
                    GameItems = new ObservableCollection<GameItemQuantity>()
                    {
                        new GameItemQuantity(GameItemById(139), 1)
                    }
                },
                new Merchant()
                {
                    Id = 1002,
                    Name = "Shi'ler",
                    Age = 18,
                    Race = Character.RaceType.Draggaru,
                    Gender = Character.GenderType.Male,
                    Description = "A man with a powerful presence. Decked out head to toe in the finest clothing, looking dapper!",
                    LocationId = 7,
                    Messages = new List<string>()
                    {
                        "Welcome to the Tailor Shop!",
                        "We have the finest clothing around!",
                        "What brings you into my shop today?"
                    },

                    GameItems = new ObservableCollection<GameItemQuantity>()
                    {
                        new GameItemQuantity(GameItemById(111), 1),
                        new GameItemQuantity(GameItemById(112), 1),
                        new GameItemQuantity(GameItemById(113), 1),
                        new GameItemQuantity(GameItemById(114), 1),
                        new GameItemQuantity(GameItemById(115), 1),
                        new GameItemQuantity(GameItemById(116), 1)
                    }
                },
                new Merchant()
                {
                    Id = 1003,
                    Name = "Horec",
                    Age = 32,
                    Race = Character.RaceType.Plenskolt,
                    Gender = Character.GenderType.Female,
                    Description = "A rather portly woman who is covered in flour and smells of fresh baked bread! ",
                    LocationId = 6,
                    Messages = new List<string>()
                    {
                        "Welcome to the Food Shop!",
                        "We have the finest food in Nocti. What would you like today?",
                        "What brings you into my shop today?"
                    },
                    GameItems = new ObservableCollection<GameItemQuantity>()
                    {
                        new GameItemQuantity(GameItemById(121), 10),
                        new GameItemQuantity(GameItemById(122), 10),
                        new GameItemQuantity(GameItemById(123), 10),
                        new GameItemQuantity(GameItemById(124), 10),
                        new GameItemQuantity(GameItemById(125), 10),
                        new GameItemQuantity(GameItemById(126), 10),
                        new GameItemQuantity(GameItemById(127), 10),
                        new GameItemQuantity(GameItemById(128), 10),

                    }
                },
                new Merchant()
                {
                    Id = 1004,
                    Name = "Jurolion",
                    Age = 65,
                    Race = Character.RaceType.Nungari,
                    Gender = Character.GenderType.Male,
                    Description = "A tall man with a large black hood. He towers over the cauldron he tends too. ",
                    LocationId = 8,
                    Messages = new List<string>()
                    {
                        "Welcome to the Potions Shop!",
                        "Are you in need of Potions today? We have several to choose from!",
                        "What brings you into my shop today?"
                    },
                    GameItems = new ObservableCollection<GameItemQuantity>()
                    {
                        new GameItemQuantity(GameItemById(101), 10),
                        new GameItemQuantity(GameItemById(102), 10),
                        new GameItemQuantity(GameItemById(103), 10),
                        new GameItemQuantity(GameItemById(104), 10),
                        new GameItemQuantity(GameItemById(105), 10),
                        new GameItemQuantity(GameItemById(106), 10),
                        new GameItemQuantity(GameItemById(107), 10),
                        new GameItemQuantity(GameItemById(108), 10)
                    }
                },
                new Citizen()
                {
                    Id = 1005,
                    Name = "Tru'pli",
                    Age = 43,
                    Description = "A citizen from Diolece! 4 arms, 3 legs, and 6 eyes! Rare around these parts",
                    Race = Character.RaceType.Diolecian,
                    Gender = Character.GenderType.Nonbinary,
                    Messages = new List<string>()
                    {
                        "Oh how exciting! You are going on your coming of age adventure today!",
                        "You know, I hear there is a wonderful magic swamp around here.",
                        "If your going on your adventure, make sure to stock up on some potions and food!",
                        "Have you seen where they sell Wizard berries? Oh nvm, I couldn't afford them anyways."
                    }
                },
                new Citizen()
                {
                    Id = 1006,
                    Name = "Tornul",
                    Age = 150,
                    Gender = Character.GenderType.Male,
                    Race = Character.RaceType.Plenskolt,
                    Description = "Tornul is an old wizard, who has mastered the art of fish magic!",
                    MageSkillGain = 25,
                    Messages = new List<string>()
                    {
                        "Welcome traveler! I heard what you did for my friend over in the Fish shop! Here take this Mage Skill Potion if you are interested and some Mage Skill Points too!"
                    },
                    GameItems = new ObservableCollection<GameItemQuantity>()
                    {
                        new GameItemQuantity(GameItemById(109), 1)
                    }

                },
                new Citizen()
                {
                    Id = 1007,
                    Name = "Hrcs'et",
                    Age = 95,
                    Gender = Character.GenderType.Male,
                    Race = Character.RaceType.Draggaru,
                    Description = "A frail old Draggaru who is not looking so well",
                    GameItems = new ObservableCollection<GameItemQuantity>()
                    {
                        new GameItemQuantity(GameItemById(110), 1),
                        new GameItemQuantity(GameItemById(138), 1)
                    },
                    HealerSkillGain = 25,
                    Messages = new List<string>()
                    {
                        "Thank you so much for healing me!",
                        "Wow I feel so much better, thank you!",
                        "Did you remember to grab that free Scroll of Thanks yet?"
                    }
                },
                new Citizen()
                {
                    Id = 1008,
                    Name = "Geryres",
                    Age = 78,
                    Gender = Character.GenderType.Male,
                    Race = Character.RaceType.Nungari,
                    Description = "An old and wise mage, capable of great magic!",
                    Messages = new List<string>()
                    {
                        "Welcome, if you have made it this far, you must possess great magic!",
                        "If its magic skill you seek, I have a potion for that! Please take it",
                        "You will be a great mage some day! I can feel it in my bones."
                    },

                    GameItems = new ObservableCollection<GameItemQuantity>()
                    {
                        new GameItemQuantity(GameItemById(140), 1)
                    }
                },
                new Citizen()
                {
                    Id = 1009,
                    Name = "Relia",
                    Age = 65,
                    Gender = Character.GenderType.Female,
                    Race = Character.RaceType.Nungari,
                    Description = "She may look old, but this woman in spritely and alive!",
                    Messages = new List<string>()
                    {
                        "Hello Traveler!",
                        "I hope your journey has been treating you well so far?",
                        "I hear the fish shop owner is not doing so well, if you have the Spell of Revival, I am sure it would perk him right up!",
                        "Remember, if you are stuck and feel like there is no where else to go, try gaining some experience with potions or clothes. New areas may open up once you break past a certain experience threshold."
                    }
                },
                new Guard()
                {
                    Id = 1010,
                    Name = "Captain Hrelion",
                    Age = 32,
                    Gender = Character.GenderType.Male,
                    Race = Character.RaceType.Nungari,
                    Description = "The Captian is decked out in full Military Garb. A sword in one hand and a shield in the other",
                    Messages = new List<string>()
                    {
                        "Good luck on your journey, now move along!",
                        "This is no time to loiter, your future here depends on this adventure!",
                        "Make sure you have what you need to leave the city. We won't let under prepared travelers out until you are ready"
                    }
                },
                new Guard()
                {
                    Id = 1011,
                    Name = "Seargant Lia'e",
                    Age = 21,
                    Gender = Character.GenderType.Female,
                    Race = Character.RaceType.Nungari,
                    Description = "A young Nungari woman who just completed her quest to find her calling. She guards the gate into Nocti with pride and youthfulness",
                    Messages = new List<string>()
                    {
                        "You cannot leave the city without the basic provisions!",
                        "Best of luck on your journey",
                        "If you don't have at least 100 experience, I cannot let you leave"
                    }
                },
                new Citizen()
                {
                    Id = 1012,
                    Name = "Hozw'ier",
                    Age = 28,
                    Gender = Character.GenderType.Male,
                    Race = Character.RaceType.Plenskolt,
                    Description = "A fit traveler, happily hiking the ascent on the Eastern Road",
                    Messages = new List<string>()
                    {
                        "I hear there are dragons up ahead at the bluffs! You might want a rope if you plan to access it . . . ",
                        "Greetings Traveler! I hope you are doing well on your journey up to the bluffs!",
                        "They say a great mage makes his home at the bluffs, but you can't see it because he has it hidden with an allusion!"
                    }
                }
            };
        }

        #endregion

        #region Quests

        /// <summary>
        /// Creates a list of quests
        /// </summary>
        /// <returns>Returns the list of quests</returns>
        public static List<Quest> Quests()
        {
            return new List<Quest>()
            {
                new QuestEngage()
                {
                    Id = 1,

                    Name = "Speak to NPC's",

                    Description =
                        "Talk to all NPC's in the Game. Some are locked behind items and will require those Quests to be complete to open NPC's Up",

                    Status = Quest.QuestStatus.Incomplete,

                    RequiredNpcs = new List<Npc>()
                    {
                        GetNpcById(1001),
                        GetNpcById(1002),
                        GetNpcById(1003),
                        GetNpcById(1004),
                        GetNpcById(1005),
                        GetNpcById(1006),
                        GetNpcById(1007),
                        GetNpcById(1008),
                        GetNpcById(1009),
                        GetNpcById(1010),
                        GetNpcById(1011),
                        GetNpcById(1012)
                    },

                    ExperienceGain = 100
                },

                new QuestTravel()
                {
                    Id = 2,

                    Name = "Exploration",

                    Description =
                        "Travel to all area's in the game. Some areas are experienced locked or require a certain item to unlock them",

                    Status = Quest.QuestStatus.Incomplete,

                    RequiredLocations = new List<Location>()
                    {
                        LocationById(2),
                        LocationById(3),
                        LocationById(4),
                        LocationById(5),
                        LocationById(6),
                        LocationById(7),
                        LocationById(8),
                        LocationById(9),
                        LocationById(10),
                        LocationById(11),
                        LocationById(12),
                        LocationById(13),
                        LocationById(14),
                        LocationById(15),
                        LocationById(16),
                        LocationById(17),
                        LocationById(18),
                        LocationById(19),
                        LocationById(20)
                    },

                    ExperienceGain = 250
                },

                new QuestGather()
                {
                    Id = 3,

                    Name = "Treasure Hunter",

                    Description = "Find all the treasures in the land!",

                    Status = Quest.QuestStatus.Incomplete,

                    RequiredGameItemQuantities = new List<GameItemQuantity>()
                    {
                        new GameItemQuantity(GameItemById(132), 1),
                        new GameItemQuantity(GameItemById(133), 1),
                        new GameItemQuantity(GameItemById(134), 1)
                    }
                }
            };
        }

        #endregion

    }
}
