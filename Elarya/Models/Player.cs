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
        #region Fields

        protected JobTitleName _jobTitle;
        private int _health;
        private int _mana;
        private int _life;
        private int _mageSkill;
        private int _healerSkill;
        private string _spell;
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
            }
        }

        public int Wealth
        {
            get => _wealth;
            set
            {
                _wealth = value;
            }
        }

        public List<Location> LocationsVisited
        {
            get => _locationsVisited;
            set
            {
                _locationsVisited = value;
            }
        }

        public ObservableCollection<GameItemQuantity> Inventory
        {
            get => _inventory;
            set
            {
                _inventory = value;
            }
        }

        public ObservableCollection<GameItemQuantity> Potions
        {
            get => _potions;
            set
            {
                _potions = value;
            }
        }

        public ObservableCollection<GameItemQuantity> Clothes
        {
            get => _clothes;
            set
            {
                _clothes = value;
            }
        }

        public ObservableCollection<GameItemQuantity> Food
        {
            get => _food;
            set
            {
                _food = value;
            }
        }

        public ObservableCollection<GameItemQuantity> Treasure
        {
            get => _treasure;
            set
            {
                _treasure = value;
            }
        }
        #endregion

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

        #region Constructor

        /// <summary>
        /// Public Constructor for the Player Class
        /// </summary>
        public Player()
        {

        }

        /// <summary>
        /// Public constructor for the Player Class (Overload)
        /// </summary>
        /// <param name="id">Player ID</param>
        /// <param name="locationId">Location ID</param>
        /// <param name="name">Name of the Player</param>
        /// <param name="age">Age of of the Player Character</param>
        /// <param name="race">Race of the Player Character</param>
        /// <param name="gender">Gender of the Player Character</param>
        /// <param name="health">Health of the Player Character</param>
        /// <param name="mana">Mana of the Player Character</param>
        /// <param name="life">Life Remaining of the Player Character</param>
        /// <param name="mageSkill">Mage Skill Points of the Player Character</param>
        /// <param name="healerSkill">Healer Skill Points for the Player Character</param>
        /// <param name="spell">Spell for the Player Character</param>
        public Player(int id, int locationId, string name, int age, RaceType race, GenderType gender, int health, int mana,  int life, int mageSkill, int healerSkill, string spell) : base(id, locationId, name, age, race, gender)
        {
            _health = health;
            _mana = mana;
            _life = life;
            _mageSkill = mageSkill;
            _healerSkill = healerSkill;
            _spell = spell;
            _locationsVisited = new List<Location>();
            _potions = new ObservableCollection<GameItemQuantity>();
            _clothes = new ObservableCollection<GameItemQuantity>();
            _food = new ObservableCollection<GameItemQuantity>();
            _treasure = new ObservableCollection<GameItemQuantity>();
        }

        #endregion

        #region Methods

        public void CalcWealth()
        {
            Wealth = _inventory.Sum(i => i.GameItem.Value * i.Quantity);
        }

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

        public void AddGameItemQuantityToInventory(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in inventory
            //
            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _inventory.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateInventory();
        }

        /// <summary>
        /// remove selected item from inventory
        /// </summary>
        /// <param name="selectedGameItemQuantity">selected item</param>
        public void RemoveGameItemQuantityFromInventory(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in inventory
            //
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
