using System.Collections.ObjectModel;
using System.Linq;

namespace Elarya.Models
{
    public class Location
    {

        #region Fields

        #endregion

		#region Properties

		/// <summary>
		/// Gets and Sets Location ID
		/// </summary>
		public int Id { get; set; }

        /// <summary>
		/// Gets and Sets Location Name
		/// </summary>
		public string Name { get; set; }

        /// <summary>
		/// Gets and Sets Location Description
		/// </summary>
		public string Description { get; set; }

        /// <summary>
        /// Gets and Sets Messages for the location
        /// </summary>
		public string Messages { get; set; }

        /// <summary>
		/// Gets and Sets if the location is accessible
		/// </summary>
		public bool Accessible { get; set; }

        /// <summary>
        /// Gets and Sets Mage Skill for the location
        /// </summary>
        public int MageSkill { get; set; }

        /// <summary>
        /// Gets and Sets Healer Skill for the location
        /// </summary>
        public int HealerSkill { get; set; }

        /// <summary>
        /// Gets and Sets life modification for location
        /// </summary>
        public int ModifyLives { get; set; }

        /// <summary>
        /// Gets and Sets health modification for location
        /// </summary>
        public int ModifyHealth { get; set; }

        /// <summary>
        /// Gets and Sets required item to unlock location
        /// </summary>
        public int RequiredItem { get; set; }

        /// <summary>
        /// Gets and Sets Game Items for a location
        /// </summary>
        public ObservableCollection<GameItemQuantity> GameItems { get; set; }

        public ObservableCollection<NPC> Npcs { get; set; }

        /// <summary>
        /// Gets and Sets the required experience to access a location
        /// </summary>
        public int RequiredExperience { get; set; }

        /// <summary>
        /// Gets and Sets the experience gained for traveling to a location
        /// </summary>
        public int ExperienceGain { get; set; }

        #endregion

        #region Constructors

        public Location()
        {
			GameItems = new ObservableCollection<GameItemQuantity>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if location is accessible by experience points
        /// </summary>
        /// <param name="experience">player experience points</param>
        /// <returns>Returns true or false if player can access location</returns>
        public bool IsAccessibleByExperience(int experience)
        {
            if (RequiredExperience == 0)
            {
                return false;
            } 
            else if (experience >= RequiredExperience)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates location Game Items
        /// </summary>
        public void UpdateLocationGameItems()
        {
            var updatedLocationGameItems = new ObservableCollection<GameItemQuantity>();

            foreach (var gameItemQuantity in GameItems)
            {
                updatedLocationGameItems.Add(gameItemQuantity);
            }

            GameItems.Clear();

            foreach (var gameItemQuantity in updatedLocationGameItems)
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
            var gameItemQuantity = GameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity == null)
            {
                var newGameItemQuantity = new GameItemQuantity
                {
                    GameItem = selectedGameItemQuantity.GameItem, Quantity = 1
                };

                GameItems.Add(newGameItemQuantity);
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
            var gameItemQuantity = GameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == quantity)
                {
                    GameItems.Remove(gameItemQuantity);
                }
            }

            UpdateLocationGameItems();
        }

        #endregion

    }
}
