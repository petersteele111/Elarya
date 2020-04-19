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
        public int AttackPowerChange { get; set; }
        public int DefensePowerChange { get; set; }


        public Potion()
        {

        }

        public Potion(int id, string name, int value, int healthChange, int livesChange, int manaChange, int attackPowerChange, int defensePowerChange,
            string description) : base(id, name, value, description)
        {
            HealthChange = healthChange;
            LivesChange = livesChange;
            ManaChange = manaChange;
            AttackPowerChange = attackPowerChange;
            DefensePowerChange = defensePowerChange;
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
            else if (AttackPowerChange != 0)
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
