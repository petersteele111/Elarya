using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    class Clothes
    {
        public enum ClothesType
        {
            Cloak,
            Robe,
            Hat,
            Staff,
            Pants,
            Shoes
        }

        public ClothesType Type { get; set; }

        public int HealthChange { get; set; }
        public int ManaChange { get; set; }
        public int AttackPowerChange { get; set; }
        public int DefensePowerChange { get; set; }
        public int MagicSkillChange { get; set; }

    }
}
