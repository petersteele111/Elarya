using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    class Clothes : GameItem
    {
       
        #region Enums
        
        /// <summary>
        /// Enum for type of clothes
        /// </summary>
        public enum ClothesType
        {
            Cloak,
            Robe,
            Hat
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets the Clothes type
        /// </summary>
        public ClothesType Type { get; set; }

        /// <summary>
        /// Gets and Sets the Health modification
        /// </summary>
        public int HealthChange { get; set; }

        /// <summary>
        /// Gets and Sets the Mana modification
        /// </summary>
        public int ManaChange { get; set; }

        /// <summary>
        /// Gets and Sets the Mage Skill modification
        /// </summary>
        public int MageSkillChange { get; set; }

        /// <summary>
        /// Gets and Sets the Healer Skill modification
        /// </summary>
        public int HealerSkillChange { get; set; }

        /// <summary>
        /// Gets and Sets the Experience Gained from item
        /// </summary>
        public int ExperienceGain { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Public Constructor for Clothes Items
        /// </summary>
        /// <param name="id">id for clothes item</param>
        /// <param name="name">name of clothes item</param>
        /// <param name="value">value of clothes item</param>
        /// <param name="type">type of clothes item</param>
        /// <param name="healthChange">health change for clothes item</param>
        /// <param name="manaChange">mana change for clothes item</param>
        /// <param name="mageSkillChange">mage skill change for clothes item</param>
        /// <param name="healerSkillChange">healer skill change for clothes item</param>
        /// <param name="experienceGain">experience gain for clothes item</param>
        /// <param name="description">description of clothes item</param>
        public Clothes(int id, string name, int value, ClothesType type, int healthChange, int manaChange, int mageSkillChange,
          int healerSkillChange, int experienceGain, string description) : base(id, name, value, description)
        {
            Type = type;
            HealthChange = healthChange;
            ManaChange = manaChange;
            MageSkillChange = mageSkillChange;
            HealerSkillChange = healerSkillChange;
            ExperienceGain = experienceGain;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Displays clothes item information
        /// </summary>
        /// <returns>Returns override for item information</returns>
        public override string InformationString()
        {
            if (HealthChange != 0)
            {
                return $"{Name}: {Description}/nHealth: {HealthChange}";
            }
            else if (ManaChange != 0)
            {
                return $"{Name}: {Description}/nMana: {ManaChange}";
            }
            else if (MageSkillChange != 0)
            {
                return $"{Name}: {Description}/nMage SKill Change: {MageSkillChange}";
            }
            else if (HealerSkillChange != 0)
            {
                return $"{Name}: {Description}/nHealer Skill Change: {HealerSkillChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }

        #endregion

    }
}
