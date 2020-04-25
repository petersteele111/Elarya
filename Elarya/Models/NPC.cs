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
        public string Description { get; set; }
        private ObservableCollection<GameItemQuantity> _gameItems;

        public ObservableCollection<GameItemQuantity> GameItems 
        {
            get => _gameItems;
            set
            {
                _gameItems = value;
            } }

        public string Information
        {
            get => InformationText();
            set
            {

            }
        }

        public NPC()
        {
            _gameItems = new ObservableCollection<GameItemQuantity>();
        }

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

        protected abstract string InformationText();

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
    }
}