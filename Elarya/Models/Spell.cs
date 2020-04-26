using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    class Spell : GameItem
    {

        #region Enums

        /// <summary>
        /// Defines the Types of Treasure
        /// </summary>
        public enum SpellType
        {
            Healing,
            Mage
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets treasure type
        /// </summary>
        public SpellType Type { get; set; }

        /// <summary>
        /// Mana cost to cast the spell
        /// </summary>
        public int ManaCost { get; set; }

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
        public Spell(int id, string name, int value, SpellType type, int manaCost, string description, string useMessage = "")
            : base(id, name, value, description, useMessage)
        {
            Type = type;
            ManaCost = manaCost;
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
