namespace Elarya.Models
{
    internal class Food : GameItem
    {

        #region Enums

        /// <summary>
        /// Defines the type of food items
        /// </summary>
        public enum FoodType
        {
            Meat,
            Bread,
            Berries,
            Drink
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets Food Type
        /// </summary>
        public FoodType Type { get; set; }

        /// <summary>
        /// Gets and Sets Health Change modification
        /// </summary>
        public int HealthChange { get; set; }

        /// <summary>
        /// Gets and Sets Mana Change modification
        /// </summary>
        public int ManaChange { get; set; }

        /// <summary>
        /// Gets and Sets experience gain modification
        /// </summary>
        public int ExperienceGain { get; set; }

        #endregion

        #region Constructors
        
        /// <summary>
        /// Public Constructor to create food item
        /// </summary>
        /// <param name="id">id of food item</param>
        /// <param name="name">name of food item</param>
        /// <param name="value">value of food item</param>
        /// <param name="type">type of food item</param>
        /// <param name="healthChange">health change from food item</param>
        /// <param name="manaChange">mana change from food item</param>
        /// <param name="experienceGain">experience gained from food item</param>
        /// <param name="description">description of food item</param>
        /// <param name="useMessage">on use message of food item</param>
        public Food(int id, string name, int value, FoodType type, int healthChange, int manaChange, int experienceGain, string description, string useMessage)
           : base(id, name, value, description, useMessage)
        {
            Type = type;
            HealthChange = healthChange;
            ManaChange = manaChange;
            ExperienceGain = experienceGain;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Displays messages for food items
        /// </summary>
        /// <returns>Returns override of message for food item</returns>
        public override string InformationString()
        {
            if (HealthChange != 0)
            {
                return $"{Name}: {Description}\nHealth: {HealthChange}";
            }
            else if (ManaChange != 0)
            {
                return $"{Name}: {Description}\nLives: {ManaChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }

        #endregion

    }
}
