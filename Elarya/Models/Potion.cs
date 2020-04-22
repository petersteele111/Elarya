using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public class Potion : GameItem
    {
        public int HealthChange { get; set; }
        public int LivesChange { get; set; }
        public int ManaChange { get; set; }
        public int MageSkillChange { get; set; }
        public int HealerSkillChange { get; set; }
        public int ExperienceGain { get; set; }

        /// <summary>
        /// Public Constructor for Potion Model
        /// </summary>
        /// <param name="id">ID of Potion</param>
        /// <param name="name">Name of Potion</param>
        /// <param name="value">Value of Potion</param>
        /// <param name="healthChange">Health Change effect of Potion</param>
        /// <param name="livesChange">Life Change effect of Potion</param>
        /// <param name="manaChange">Mana Change effect of Potion</param>
        /// <param name="mageSkillChange">Mage Skill effect of Potion</param>
        /// <param name="healerSkillChange">Healer Skill effect of Potion</param>
        /// <param name="description">Description of Potion</param>
        /// <param name="useMessage">Message displayed on use</param>
        public Potion(int id, string name, int value, int healthChange, int livesChange, int manaChange, int mageSkillChange, int healerSkillChange, int experienceGain,
            string description, string useMessage) : base(id, name, value, description, useMessage)
        {
            HealthChange = healthChange;
            LivesChange = livesChange;
            ManaChange = manaChange;
            MageSkillChange = mageSkillChange;
            HealerSkillChange = healerSkillChange;
            ExperienceGain = experienceGain;

        }

        public override string InformationString()
        {
            if (HealthChange != 0)
            {
                return $"{Name}: {Description}/nHealth: {HealthChange}";
            }
            else if (LivesChange != 0)
            {
                return $"{Name}: {Description}/nLives: {LivesChange}";
            } 
            else if (ManaChange != 0)
            {
                return $"{Name}: {Description}/nMana: {ManaChange}";
            }
            else if (MageSkillChange != 0)
            {
                return $"{Name}: {Description}/nMage Skill Change: {MageSkillChange}";
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
    }
}
