namespace Elarya.Models
{
    public class GameItem
    {

        #region Properties

        /// <summary>
        /// Gets and sets item id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets item name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets item value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets and sets item description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets and sets item use message
        /// </summary>
        public string UseMessage { get; set; }

        /// <summary>
        /// Gets overridden information string for items
        /// </summary>
        public string Information => InformationString();

        #endregion

        #region Constructor

        public GameItem(int id, string name, int value, string description, string useMessage = ".")
        {
            Id = id;
            Name = name;
            Value = value;
            Description = description;
            UseMessage = useMessage;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Allows for override of information string
        /// </summary>
        /// <returns>Returns information on item</returns>
        public virtual string InformationString()
        {
            return $"{Name}: {Description}/nValue: {Value}";
        }

        #endregion

    }
}
