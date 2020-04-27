using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace Elarya.Models
{
    public abstract class Npc : Character
    {

        #region Fields

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets and Sets the Mage Skill Point Gain
        /// </summary>
        public int MageSkillGain { get; set; }

        /// <summary>
        /// Gets and Sets the Healer Skill Gain
        /// </summary>
        public int HealerSkillGain { get; set; }

        /// <summary>
        /// Gets and Sets the NPC Inventory
        /// </summary>
        public ObservableCollection<GameItemQuantity> GameItems { get; set; }

        /// <summary>
        /// Gets and Sets the Information Text String 
        /// </summary>
        public string Information => InformationText();

        #endregion

        #region Constructor

        /// <summary>
        /// Public Constructor
        /// </summary>
        protected Npc()
        {
            GameItems = new ObservableCollection<GameItemQuantity>();
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
        protected Npc(int id, int locationId, string name, int age, RaceType race, GenderType gender, string description) : base(id, locationId, name, age, race, gender)
        {
            Id = id;
            LocationId = locationId;
            Age = age;
            Race = race;
            Gender = gender;
            Description = description;
            GameItems = new ObservableCollection<GameItemQuantity>();
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
            var gameItemQuantity = GameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    GameItems.Remove(gameItemQuantity);
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
            var updatedMerchantGameItems = new ObservableCollection<GameItemQuantity>();

            foreach (var gameItemQuantity in GameItems)
            {
                updatedMerchantGameItems.Add(gameItemQuantity);
            }

            GameItems.Clear();

            foreach (var gameItemQuantity in updatedMerchantGameItems)
            {
                GameItems.Add(gameItemQuantity);
            }
        }

        #endregion

    }
}