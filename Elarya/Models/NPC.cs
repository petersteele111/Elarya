using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public abstract class NPC : Character
    {

        #region Fields

        private ObservableCollection<GameItemQuantity> _gameItems;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets and Sets the Mage Skil Point Gain
        /// </summary>
        public int MageSkillGain { get; set; }

        /// <summary>
        /// Gets and Sets the Healer Skill Gain
        /// </summary>
        public int HealerSkillGain { get; set; }

        /// <summary>
        /// Gets and Sets the NPC Inventory
        /// </summary>
        public ObservableCollection<GameItemQuantity> GameItems
        {
            get => _gameItems;
            set
            {
                _gameItems = value;
            }
        }

        /// <summary>
        /// Gets and Sets the Information Text String 
        /// </summary>
        public string Information
        {
            get => InformationText();
            set
            {

            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public Constructor
        /// </summary>
        public NPC()
        {
            _gameItems = new ObservableCollection<GameItemQuantity>();
        }

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <param name="id">ID of NPC</param>
        /// <param name="locationId">Location ID of NPC</param>
        /// <param name="name">Name of NPC</param>
        /// <param name="age">Age of NPC</param>
        /// <param name="race">Race of NPC</param>
        /// <param name="gender">Gender of NPC</param>
        /// <param name="description">Description of NPC</param>
        public NPC(int id, int locationId, string name, int age, RaceType race, GenderType gender, string description) : base(id, locationId, name, age, race, gender)
        {
            Id = id;
            LocationId = locationId;
            Age = age;
            Race = race;
            Gender = gender;
            Description = description;
            _gameItems = new ObservableCollection<GameItemQuantity>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Information String about NPC
        /// </summary>
        /// <returns></returns>
        protected abstract string InformationText();

        /// <summary>
        /// Override of NPC having a Quest
        /// </summary>
        /// <returns></returns>
        public override bool HasQuest()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove selected item from inventory
        /// </summary>
        /// <param name="selectedGameItemQuantity">selected item</param>
        public void RemoveGameItemQuantityFromInventory(GameItemQuantity selectedGameItemQuantity)
        {
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

            UpdateMerchantGameItems();
        }

        /// <summary>
        /// Updates location Game Items
        /// </summary>
        public void UpdateMerchantGameItems()
        {
            ObservableCollection<GameItemQuantity> updatedMerchantGameItems = new ObservableCollection<GameItemQuantity>();

            foreach (GameItemQuantity gameItemQuantity in _gameItems)
            {
                updatedMerchantGameItems.Add(gameItemQuantity);
            }

            GameItems.Clear();

            foreach (GameItemQuantity gameItemQuantity in updatedMerchantGameItems)
            {
                GameItems.Add(gameItemQuantity);
            }
        }

        #endregion

    }
}