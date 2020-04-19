using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    class Treasure : GameItem
    {
        public enum TreasureType
        {
            Coin,
            Gem,
            Scroll
        }

        public TreasureType Type { get; set; }

        public Treasure(int id, string name, int value, TreasureType type, string description)
            : base(id, name, value, description)
        {
            Type = type;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}\nValue: {Value}";
        }
    }
}
