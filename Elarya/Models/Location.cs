using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private string _message;
        private ObservableCollection<GameItemQuantity> _gameItems;


		#endregion

		#region Properties

		/// <summary>
		/// Location ID
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
		/// Location Name
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
		/// Location Description
		/// </summary>
		public string Description
		{
			get => _description;
			set
			{
				_description = value;
			}
		}

		public string Messages 
		{ get => _messages;
			set 
			{
				_messages = value;
			}
		}

		/// <summary>
		/// Is Location Accessible?
		/// </summary>
		public bool Accessible
		{
			get => _accessible;
			set
			{
				_accessible = value;
			}
		}

        public int MageSkill
        {
            get => _MageSkill;
            set
            {
                _MageSkill = value;
            }
        }

        public int HealerSkill
        {
            get => _HealerSkill;
            set
            {
                _HealerSkill = value;
            }
        }

        public int ModifyLives
        {
            get => _modifyLives;
            set
            {
                _modifyLives = value;
            }
        }

        public int ModifyHealth
        {
            get => _modifyHealth;
            set
            {
                _modifyHealth = value;
            }
        }

        public ObservableCollection<GameItemQuantity> GameItems
        {
            get => _gameItems;
            set
            {
                _gameItems = value;
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
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

        public void AddGameItemQuantityToLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in location
            //
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

        public void RemoveGameItemQuantityFromLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //
            // locate selected item in location
            //
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _gameItems.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateLocationGameItems();
        }

        #endregion
    }
}
