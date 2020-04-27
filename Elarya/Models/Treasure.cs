namespace Elarya.Models
{
    internal class Treasure : GameItem
    {

        #region Enums

        /// <summary>
        /// Defines the Types of Treasure
        /// </summary>
        public enum TreasureType
        {
            Coin,
            Gem
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets treasure type
        /// </summary>
        public TreasureType Type { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Public Constructor for Treasure items
        /// </summary>
        /// <param name="id">id of treasure item</param>
        /// <param name="name">name of treasure item</param>
        /// <param name="value">value of treasure item</param>
        /// <param name="type">type of treasure item</param>
        /// <param name="description">description of treasure item</param>
        /// <param name="useMessage">on use message of treasure item</param>
        public Treasure(int id, string name, int value, TreasureType type, string description, string useMessage = "")
    : base(id, name, value, description, useMessage)
        {
            Type = type;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the treasure item information
        /// </summary>
        /// <returns>Returns overridden string with treasure item information</returns>
        public override string InformationString()
        {
            return $"{Name}: {Description}\nValue: {Value}";
        }

        #endregion

    }
}
