using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elarya.Models;

namespace Elarya.Data
{
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                LocationId = 0,
                Name = "Arya\'e",
                Age = 20,
                Race = Character.RaceType.Nungari,
                Gender = Character.GenderType.Female,
                JobTitle = Player.JobTitleName.DragonRider,
                Health = 100,
                Mana = 100,
                AttackPower = 10,
                DefensePower = 5,
                HealthRegenRate = 5,
                ManaRegenRate = 5,
                Life = 3,
                WarriorSkill = 0,
                DragonRiderSkill = 0,
                HunterSkill = 0,
                MageSkill = 0,
                Spell = null,
                InventoryItem = null
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "You are soon to become of age in the realm of Qui'Lash. You must venture forth on an epic journey to discover what talents and skills you have to beneift society.",
                "Will you be a fearsome Dragon Rider? Or maybe a noble Warrior. A competent Hunter, or even a powerful Mage!",
                "You only have 3 months to discover your true talents, or you risk being exiled from Nocti and banished to the Northern Tundra.",
                "Good luck on your quest, and remember, every choice you make, every quest you complete, will determine you role in society! "
            };
        }
    }
}
