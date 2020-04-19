using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    class Weapon : GameItem
    {
        public enum WeaponType
        {
            Mace,
            Sword,
            Bow,
            Dagger
        }

        public WeaponType Type { get; set; }

        public int AttackPowerChange { get; set; }
        public int DefensePowerChange { get; set; }

        public Weapon(int id, string name, int value, WeaponType type, string description, int attackPowerChange, int defensePowerChange) : base(id, name, value, description)
        {
            Type = type;
            AttackPowerChange = attackPowerChange;
            DefensePowerChange = defensePowerChange;
        }

        public override string InformationString()
        {
            if (AttackPowerChange != 0)
            {
                return $"{Name}: {Description}/nAttack Power: {AttackPowerChange}";
            }
            else if (DefensePowerChange != 0)
            {
                return $"{Name}: {Description}/nDefense Power: {DefensePowerChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }

    }
}
