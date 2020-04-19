using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    class Food : GameItem
    {
        public enum FoodType
        {
            Meat,
            Bread,
            Berries,
            Drink
        }

        public FoodType Type { get; set; }

        public int HealthChange { get; set; }
        public int ManaChange { get; set; }


        public Food(int id, string name, int value, int healthChange, int livesChange, string description)
            : base(id, name, value, description)
        {
            HealthChange = healthChange;
            ManaChange = livesChange;
        }

        public override string InformationString()
        {
            if (HealthChange != 0)
            {
                return $"{Name}: {Description}\nHealth: {HealthChange}";
            }
            else if (ManaChange != 0)
            {
                return $"{Name}: {Description}\nLives: {ManaChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }
    }
}
