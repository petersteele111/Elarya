using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public class GameItem
    {

        #region Fields

        private int _id;
        private string _name;
        private int _value;
        private string _description;
        private string _useMessage;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets item id
        /// </summary>
        public int Id 
        { 
            get => _id;
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Gets and sets item name
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
        /// Gets and sets item value
        /// </summary>
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// Gets and sets item description
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
        /// Gets and sets item use message
        /// </summary>
        public string UseMessage
        {
            get => _useMessage;
            set
            {
                _useMessage = value;
            }
        }

        /// <summary>
        /// Gets overridden information string for items
        /// </summary>
        public string Information
        {
            get => InformationString();
        }

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
