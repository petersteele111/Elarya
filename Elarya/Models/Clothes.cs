using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    class Clothes : GameItem
    {
        public enum ClothesType
        {
            Cloak,
            Robe,
            Hat
        }

        public ClothesType Type { get; set; }

        public int HealthChange { get; set; }
        public int ManaChange { get; set; }
        public int MageSkillChange { get; set; }
        public int HealerSkillChange { get; set; }
        public int ExperienceGain { get; set; }

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

    }
}
