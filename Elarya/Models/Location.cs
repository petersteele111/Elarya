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
        private int _requiredMageSkill;
        private int _requiredHealerSkill;
        private int _modifyLives;
        private int _modifyHealth;
        private ObservableCollection<GameItem> _gameItems;


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

        public int RequiredMageSkill
        {
            get => _requiredMageSkill;
            set
            {
                _requiredMageSkill = value;
            }
        }

        public int RequiredHealerSkill
        {
            get => _requiredHealerSkill;
            set
            {
                _requiredHealerSkill = value;
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

        public ObservableCollection<GameItem> GameItems
        {
            get => _gameItems;
            set
            {
                _gameItems = value;
            }
        }

		#endregion

        #region Constructors

        public Location()
        {
			_gameItems = new ObservableCollection<GameItem>();
        }

		#endregion

        #region Methods

        

        #endregion
	}
}
