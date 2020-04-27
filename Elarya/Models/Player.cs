using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Elarya.Models
{
    public class Player : Character
    {

        #region Enums

        /// <summary>
        /// Job Title Enumerator
        /// </summary>
        public enum JobTitleName
        {
            Mage,
            Healer
        }

        #endregion

        #region Fields

        private int _health;
        private int _mana;
        private int _life;
        private int _mageSkill;
        private int _healerSkill;
        private int _experience;
        private int _wealth;

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets and Sets the JobTitle Enumerator
        /// </summary>
        public JobTitleName JobTitle { get; set; }

        /// <summary>
        /// Sets and Gets the Health of the Player
        /// </summary>
        public int Health
        {
            get => _health;
            set
            {
                _health = value;

                if (_health > 100)
                {
                    _health = 100;
                }
                else if (_health <= 0)
                {
                    _health = 100;
                    _life--;
                }
                OnPropertyChanged(nameof(Health));
            }
        }

        /// <summary>
        /// Sets and Gets the Mana of the Player
        /// </summary>
        public int Mana
        {
            get => _mana;
            set
            {
                _mana = value;

                if (_mana > 100)
                {
                    _mana = 100;
                }
                else if (_mana <= 0)
                {
                    _mana = 0;
                    _life--;
                }
                OnPropertyChanged(nameof(Mana));
            }
        }

        /// <summary>
        /// Sets and Gets the lives remaining for the Player
        /// </summary>
        public int Life
        {
            get => _life;
            set
            {
                _life = value;
                OnPropertyChanged(nameof(Life));
            }
        }

        /// <summary>
        /// Sets and Gets the Mage Skill for the Player
        /// </summary>
        public int MageSkill
        {
            get => _mageSkill;
            set
            {
                _mageSkill = value;
                OnPropertyChanged(nameof(MageSkill));
            }
        }

        /// <summary>
        /// Sets and Gets the Mage Skill for the Player
        /// </summary>
        public int HealerSkill
        {
            get => _healerSkill;
            set
            {
                _healerSkill = value;
                OnPropertyChanged(nameof(HealerSkill));
            }
        }

        /// <summary>
        /// Sets and Gets the Spell for the Player
        /// </summary>
        public ObservableCollection<GameItemQuantity> Spell { get; set; }

        /// <summary>
        /// Gets and Sets Player Experience
        /// </summary>
        public int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                OnPropertyChanged(nameof(Experience));
            }
        }

        /// <summary>
        /// Gets and Sets Player Wealth
        /// </summary>
        public int Wealth
        {
            get => _wealth;
            set
            {
                _wealth = value;
                OnPropertyChanged(nameof(Wealth));
            }
        }

        /// <summary>
        /// Gets and Sets a list of locations the player has visited
        /// </summary>
        public List<Location> LocationsVisited { get; set; }

        /// <summary>
        /// Lis of NPC's talked too
        /// </summary>
        public List<NPC> NpcsTalkedTo { get; set; }

        /// <summary>
        /// Lis of NPC's talked too
        /// </summary>
        public List<NPC> NpcsEngaged { get; set; }

        /// <summary>
        /// Gets and Sets a new inventory for the player
        /// </summary>
        public ObservableCollection<GameItemQuantity> Inventory { get; set; }

        /// <summary>
        /// Gets and Sets a new inventory of potions for the player
        /// </summary>
        public ObservableCollection<GameItemQuantity> Potions { get; set; }

        /// <summary>
        /// Gets and Sets a new inventory of Clothes for the player
        /// </summary>
        public ObservableCollection<GameItemQuantity> Clothes { get; set; }

        /// <summary>
        /// Gets and Sets a new inventory of food for the player
        /// </summary>
        public ObservableCollection<GameItemQuantity> Food { get; set; }

        /// <summary>
        /// Gets and Sets a new inventory of treasure for the player
        /// </summary>
        public ObservableCollection<GameItemQuantity> Treasure { get; set; }

        public ObservableCollection<Quest> Quests { get; set; }

        #endregion
        
        #region Constructor

        /// <summary>
        /// Public Constructor for the Player Class
        /// </summary>
        public Player()
        {
            LocationsVisited = new List<Location>();
            NpcsTalkedTo = new List<NPC>();
            NpcsEngaged = new List<NPC>();
            Potions = new ObservableCollection<GameItemQuantity>();
            Clothes = new ObservableCollection<GameItemQuantity>();
            Food = new ObservableCollection<GameItemQuantity>();
            Treasure = new ObservableCollection<GameItemQuantity>();
            Inventory = new ObservableCollection<GameItemQuantity>();
            Spell = new ObservableCollection<GameItemQuantity>();
            Quests = new ObservableCollection<Quest>();
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Calculates the players wealth
        /// </summary>
        public void CalcWealth()
        {
            Wealth = Inventory.Sum(i => i.GameItem.Value * i.Quantity);
        }

        /// <summary>
        /// Updates the Players Inventory
        /// </summary>
        public void UpdateInventory()
        {
            Potions.Clear();
            Clothes.Clear();
            Food.Clear();
            Treasure.Clear();
            Spell.Clear();

            foreach (var gameItemQuantity in Inventory)
            {
                switch (gameItemQuantity.GameItem)
                {
                    case Potion _:
                        Potions.Add(gameItemQuantity);
                        break;
                    case Clothes _:
                        Clothes.Add(gameItemQuantity);
                        break;
                    case Food _:
                        Food.Add(gameItemQuantity);
                        break;
                    case Treasure _:
                        Treasure.Add(gameItemQuantity);
                        break;
                    case Spell _:
                        Spell.Add(gameItemQuantity);
                        break;
                }
            }
        }

        /// <summary>
        /// Adds an item to the players inventory
        /// </summary>
        /// <param name="selectedGameItemQuantity">Selected Item</param>
        /// <param name="quantity">Quantity of Item</param>
        public void AddGameItemQuantityToInventory(GameItemQuantity selectedGameItemQuantity, int quantity)
        {
            var gameItemQuantity = Inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                var newGameItemQuantity = new GameItemQuantity
                {
                    GameItem = selectedGameItemQuantity.GameItem, Quantity = quantity
                };

                Inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity += quantity;
            }

            UpdateInventory();
        }

        /// <summary>
        /// Pays the Merchant for an Item
        /// </summary>
        /// <param name="quantity">Cost of Item</param>
        /// <returns>Returns true or false if the payment went through</returns>
        public bool PayMerchant(int quantity)
        {
            var gameItemQuantity = Inventory.FirstOrDefault(i => i.GameItem.Id == 131);
            if (gameItemQuantity != null)
            {
                if (gameItemQuantity.Quantity < quantity)
                {
                    return false;
                }
                else if (gameItemQuantity.Quantity == quantity)
                {
                    Inventory.Remove(gameItemQuantity);
                    UpdateInventory();
                    return true;
                }
                else
                {
                    gameItemQuantity.Quantity -= quantity;
                    UpdateInventory();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sells and Item to a merchant
        /// </summary>
        /// <param name="quantity">Price for Merchant to pay Player</param>
        public void SellToMerchant(int quantity)
        {
            var gameItemQuantity = Inventory.FirstOrDefault(i => i.GameItem.Id == 131);
            if (gameItemQuantity == null)
            {
                var newGameItemQuantity = new GameItemQuantity
                {
                    GameItem = gameItemQuantity.GameItem, Quantity = quantity
                };

                Inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity += quantity;
            }

            UpdateInventory();
        }

        /// <summary>
        /// Remove selected item from inventory
        /// </summary>
        /// <param name="selectedGameItemQuantity">selected item</param>
        public void RemoveGameItemQuantityFromInventory(GameItemQuantity selectedGameItemQuantity)
        {
            var gameItemQuantity = Inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    Inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateInventory();
        }

        /// <summary>
        /// Checks if Player has visited location or not
        /// </summary>
        /// <param name="location">location</param>
        /// <returns>Returns true or false if player has visited or not</returns>
        public bool HasVisited(Location location)
        {
            return LocationsVisited.Contains(location);
        }

        /// <summary>
        /// Tracks if the player has talked to an NPC
        /// </summary>
        /// <param name="npc">NPC player talked too</param>
        /// <returns>Returns if the player has talked to an NPC or not</returns>
        public bool HasTalkedTo(NPC npc)
        {
            return NpcsTalkedTo.Contains(npc);
        }

        /// <summary>
        /// Default Greeting for the Player
        /// </summary>
        /// <returns>Returns the Default Greeting</returns>
        public override string Greeting()
        {
            return $"Hello, my name is {_name}, and I am {_age} years old. I am setting off on my journey in hopes to become a {JobTitle}, and am excited to get started!";
        }

        /// <summary>
        /// Checks to see if the Player has a Quest. Useful for changing dialogue with NPC's
        /// </summary>
        /// <returns></returns>
        public override bool HasQuest()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the Quest Status
        /// </summary>
        public void UpdateQuestStatus()
        {
            foreach (var quest in Quests.Where(q=>q.Status == Quest.QuestStatus.Incomplete))
            {
                switch (quest)
                {
                    case QuestTravel travel:
                    {
                        if (travel.LocationsNotCompleted(LocationsVisited).Count == 0)
                        {
                            travel.Status = Quest.QuestStatus.Complete;
                            Experience += travel.ExperienceGain;
                        }

                        break;
                    }
                    case QuestGather gather:
                    {
                        if (gather.GameItemQuantitiesNotCompleted(Inventory.ToList()).Count == 0)
                        {
                            gather.Status = Quest.QuestStatus.Complete;
                            Experience += gather.ExperienceGain;
                        }

                        break;
                    }
                    case QuestEngage engage:
                    {
                        if (engage.NpcsNotEngaged(NpcsEngaged).Count == 0)
                        {
                            engage.Status = Quest.QuestStatus.Complete;
                            Experience += engage.ExperienceGain;
                        }

                        break;
                    }
                    default:
                        throw new Exception("Unknown Mission Child Class");
                }
            }
        }

        #endregion

    }
}
