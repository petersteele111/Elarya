using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Elarya.Models
{
    public class Location
    {

        #region Fields

        private int _id;
		private string _name;
		private string _description;
		private string _messages;
		private bool _accessible;
        private int _MageSkill;
        private int _HealerSkill;
        private int _modifyLives;
        private int _modifyHealth;
        private int _requiredExperience;
        private int _requiredItem;
        private int _experienceGain;
        private ObservableCollection<GameItemQuantity> _gameItems;
        private ObservableCollection<NPC> _npcs;


		#endregion

		#region Properties

		/// <summary>
		/// Gets and Sets Location ID
		/// </summary>
		public int ID
		{
			get => _id;
			set
			{
				_id = value;
			}
		}

		/// <summary>
		/// Gets and Sets Location Name
		/// </summary>
		public string Name
		{
			get => _name;
			set 
			{
				_name = value;
			}
		}

		/// <summary>
		/// Gets and Sets Location Description
		/// </summary>
		public string Description
		{
			get => _description;
			set
			{
				_description = value;
			}
		}

        /// <summary>
        /// Gets and Sets Messages for the location
        /// </summary>
		public string Messages 
		{ get => _messages;
			set 
			{
				_messages = value;
			}
		}

		/// <summary>
		/// Gets and Sets if the location is accessible
		/// </summary>
		public bool Accessible
		{
			get => _accessible;
			set
			{
				_accessible = value;
			}
		}

        /// <summary>
        /// Gets and Sets Mage Skill for the location
        /// </summary>
        public int MageSkill
        {
            get => _MageSkill;
            set
            {
                _MageSkill = value;
            }
        }

        /// <summary>
        /// Gets and Sets Healer Skill for the location
        /// </summary>
        public int HealerSkill
        {
            get => _HealerSkill;
            set
            {
                _HealerSkill = value;
            }
        }

        /// <summary>
        /// Gets and Sets life modifcation for location
        /// </summary>
        public int ModifyLives
        {
            get => _modifyLives;
            set
            {
                _modifyLives = value;
            }
        }

        /// <summary>
        /// Gets and Sets health modification for location
        /// </summary>
        public int ModifyHealth
        {
            get => _modifyHealth;
            set
            {
                _modifyHealth = value;
            }
        }

        /// <summary>
        /// Gets and Sets required item to unlock location
        /// </summary>
        public int RequiredItem
        {
            get => _requiredItem;
            set
            {
                _requiredItem = value;
            }
        }

        /// <summary>
        /// Gets and Sets Game Items for a location
        /// </summary>
        public ObservableCollection<GameItemQuantity> GameItems
        {
            get => _gameItems;
            set
            {
                _gameItems = value;
            }
        }

        public ObservableCollection<NPC> Npcs
        {
            get => _npcs;
            set
            {
                _npcs = value;
            }
        }

        /// <summary>
        /// Gets and Sets the required experience to access a location
        /// </summary>
        public int RequiredExperience
        {
            get => _requiredExperience;
            set
            {
                _requiredExperience = value;
            }
        }

        /// <summary>
        /// Gets and Sets the experience gained for travelling to a location
        /// </summary>
        public int ExperienceGain
        {
            get => _experienceGain;
            set
            {
                _experienceGain = value;
            }
        }

		#endregion

        #region Constructors

        public Location()
        {
			_gameItems = new ObservableCollection<GameItemQuantity>();
        }

        #endregion

        #region Methods

        // TODO: Fix this so that if the required experience is 0, it does not become accessible. Remove comment as well
        /// <summary>
        /// Checks if location is accessbile by experience points
        /// </summary>
        /// <param name="experience">player experience points</param>
        /// <returns>Returns true or false if player can access location</returns>
        public bool IsAccessibleByExperience(int experience)
        {
            if (_requiredExperience == 0)
            {
                return false;
            } 
            else if (experience >= _requiredExperience)
            {
                return true;
            }

            return false;
            //return experience >= _requiredExperience ? true : false;
        }

        /// <summary>
        /// Updates location Game Items
        /// </summary>
        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItemQuantity> updatedLocationGameItems = new ObservableCollection<GameItemQuantity>();

            foreach (GameItemQuantity gameItemQuantity in _gameItems)
            {
                updatedLocationGameItems.Add(gameItemQuantity);
            }

            GameItems.Clear();

            foreach (GameItemQuantity gameItemQuantity in updatedLocationGameItems)
            {
                GameItems.Add(gameItemQuantity);
            }
        }

        /// <summary>
        /// Adds Game Items to a location (dropped by player)
        /// </summary>
        /// <param name="selectedGameItemQuantity">Selected Item</param>
        public void AddGameItemQuantityToLocation(GameItemQuantity selectedGameItemQuantity)
        {
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _gameItems.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateLocationGameItems();
        }

        /// <summary>
        /// Removes Game Items from a location (Player Pickup)
        /// </summary>
        /// <param name="selectedGameItemQuantity">Selected Item</param>
        /// <param name="quantity">Quantity of Item</param>
        public void RemoveGameItemQuantityFromLocation(GameItemQuantity selectedGameItemQuantity, int quantity)
        {
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == quantity)
                {
                    _gameItems.Remove(gameItemQuantity);
                }
            }

            UpdateLocationGameItems();
        }

        #endregion

    }
}
