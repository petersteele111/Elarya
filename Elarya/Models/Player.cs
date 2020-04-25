using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected JobTitleName _jobTitle;
        private int _health;
        private int _mana;
        private int _life;
        private int _mageSkill;
        private int _healerSkill;
        private string _spell;
        private int _experience;
        private List<Location> _locationsVisited;
        private int _wealth;
        private ObservableCollection<GameItemQuantity> _inventory;
        private ObservableCollection<GameItemQuantity> _potions;
        private ObservableCollection<GameItemQuantity> _clothes;
        private ObservableCollection<GameItemQuantity> _food;
        private ObservableCollection<GameItemQuantity> _treasure;

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets and Sets the JobTitle Enumerator
        /// </summary>
        public JobTitleName JobTitle
        {
            get => _jobTitle;
            set
            {
                _jobTitle = value;
            }
        }

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
        public string  Spell
        {
            get => _spell;
            set
            {
                _spell = value;
                OnPropertyChanged(nameof(Spell));
            }
        }

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
        public List<Location> LocationsVisited
        {
            get => _locationsVisited;
            set
            {
                _locationsVisited = value;
            }
        }

        /// <summary>
        /// Gets and Sets a new inventory for the player
        /// </summary>
        public ObservableCollection<GameItemQuantity> Inventory
        {
            get => _inventory;
            set
            {
                _inventory = value;
            }
        }

        /// <summary>
        /// Gets and Sets a new inventory of potions for the player
        /// </summary>
        public ObservableCollection<GameItemQuantity> Potions
        {
            get => _potions;
            set
            {
                _potions = value;
            }
        }

        /// <summary>
        /// Gets and Sets a new inventory of Clothes for the player
        /// </summary>
        public ObservableCollection<GameItemQuantity> Clothes
        {
            get => _clothes;
            set
            {
                _clothes = value;
            }
        }

        /// <summary>
        /// Gets and Sets a new inventory of food for the player
        /// </summary>
        public ObservableCollection<GameItemQuantity> Food
        {
            get => _food;
            set
            {
                _food = value;
            }
        }

        /// <summary>
        /// Gets and Sets a new inventory of treasure for the player
        /// </summary>
        public ObservableCollection<GameItemQuantity> Treasure
        {
            get => _treasure;
            set
            {
                _treasure = value;
            }
        }

        #endregion
        
        #region Constructor

        /// <summary>
        /// Public Constructor for the Player Class
        /// </summary>
        public Player()
        {
            _locationsVisited = new List<Location>();
            _potions = new ObservableCollection<GameItemQuantity>();
            _clothes = new ObservableCollection<GameItemQuantity>();
            _food = new ObservableCollection<GameItemQuantity>();
            _treasure = new ObservableCollection<GameItemQuantity>();
            _inventory = new ObservableCollection<GameItemQuantity>();
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// Calculates the players wealth
        /// </summary>
        public void CalcWealth()
        {
            Wealth = _inventory.Sum(i => i.GameItem.Value * i.Quantity);
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

            foreach (var gameItemQuantity in _inventory)
            {
                if (gameItemQuantity.GameItem is Potion)
                {
                    Potions.Add(gameItemQuantity);
                }

                if (gameItemQuantity.GameItem is Clothes)
                {
                    Clothes.Add(gameItemQuantity);
                }

                if (gameItemQuantity.GameItem is Food)
                {
                    Food.Add(gameItemQuantity);
                }

                if (gameItemQuantity.GameItem is Treasure)
                {
                    Treasure.Add(gameItemQuantity);
                }
            }
        }

        /// <summary>
        /// Add's an item to the players inventory
        /// </summary>
        /// <param name="selectedGameItemQuantity">Selected Item</param>
        /// <param name="quantity">Quantity of Item</param>
        public void AddGameItemQuantityToInventory(GameItemQuantity selectedGameItemQuantity, int quantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = quantity;

                _inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity += quantity;
            }

            UpdateInventory();
        }

        public bool PayMerchant(int quantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == 131);
            if (gameItemQuantity != null)
            {
                if (gameItemQuantity.Quantity < quantity)
                {
                    return false;
                }
                else if (gameItemQuantity.Quantity == quantity)
                {
                    _inventory.Remove(gameItemQuantity);
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

        public void SellToMerchant(int quantity)
        {
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == 131);
            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = gameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = quantity;

                _inventory.Add(newGameItemQuantity);
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
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateInventory();
        }

        /// <summary>
        /// Checks if Player has visted location or not
        /// </summary>
        /// <param name="location">location</param>
        /// <returns>Returns true or false if player has visted or not</returns>
        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        /// <summary>
        /// Default Greeting for the Player
        /// </summary>
        /// <returns>Returns the Default Greeting</returns>
        public override string Greeting()
        {
            return $"Hello, my name is {_name}, and I am {_age} years old. I am setting off on my journey in hopes to become a {_jobTitle}, and am excited to get started!";
        }

        /// <summary>
        /// Checks to see if the Player has a Quest. Useful for changing dialogue with NPC's
        /// </summary>
        /// <returns></returns>
        public override bool HasQuest()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
