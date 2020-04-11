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
        /// <summary>
        /// Method to create the Player Data
        /// </summary>
        /// <returns>Returns a default player</returns>
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

        /// <summary>
        /// Method to create the defaul greeting and messages upon game start
        /// </summary>
        /// <returns>Returns the default game greeting and information</returns>
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

        public static MapCoordinates InitializeGameMapLocation()
        {
            return new MapCoordinates() { Row = 0, Column = 0 };
        }

        public static Map GameMap()
        {
            int rows = 3;
            int columns = 4;

            Map gameMap = new Map(rows, columns);

            gameMap.Locations[0, 0] = new Location()
            {
                ID = 1,
                Name = "Norlon Corporate Headquarters",
                Description = "The Norlon Corporation Headquarters is located in just outside of Detroit " +
               "Michigan.Norlon, founded in 1985 as a bio-tech company, is now a 36 billion dollar company with " +
               "huge holdings in defense and space research and development.",
                Messages = "\tYou have been hired by the Norlon Corporation to participate in its latest endeavor, the " +
               "Aion Project. Your mission is to  test the limits of the new Aion Engine and report back to the Norlon " +
               "Corporation. You will begin by choosing a new location and using Aion Engine to travel to that point in the " +
               "Galaxy.\n\tThe Aion Engine, design by Dr. Tormeld, is limited to four slipstreams, denoted by the cardinal points on a compass, from any given locations.",
                Accessible = true
            };
            gameMap.Locations[0, 1] = new Location()
            {
                ID = 2,
                Name = "Aion Base Lab",
                Description = "The Norlon Corporation research facility located in the city of Heraklion on " +
                "the north coast of Crete and the top secret research lab for the Aion Project.\nThe lab is a large, " + "" +
                "well lit room, and staffed by a small number of scientists, all wearing light blue uniforms with the hydra-like Norlan Corporation logo.",
                Accessible = true
            };

            //
            // row 2
            //
            gameMap.Locations[1, 1] = new Location()
            {
                ID = 3,
                Name = "Felandrian Plains",
                Description = "The Felandrian Plains are a common destination for tourist. Located just north of the " +
                "equatorial line on the planet of Corlon, they provide excellent habitat for a rich ecosystem of flora and fauna.",
                Accessible = true
            };
            gameMap.Locations[1, 2] = new Location()
            {
                ID = 4,
                Name = "Epitoria's Reading Room",
                Description = "Queen Epitoria, the Torian Monarh of the 5th Dynasty, was know for her passion for " +
                "galactic history. The room has a tall vaulted ceiling, open in the middle  with four floors of wrapping " +
                "balconies filled with scrolls, texts, and infocrystals. As you enter the room a red fog desends from the ceiling " +
                "and you begin feeling your life energy slip away slowly until you are dead.",
                Accessible = true
            };

            //
            // row 3
            //
            gameMap.Locations[2, 0] = new Location()
            {
                ID = 5,
                Name = "Xantoria Market",
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an open market managed " +
                "by the Xantorian Commerce Coop. It is a place where many races from various systems trade goods." +
                "You purchase a blue potion in a thin, clear flask, drink it and receive 50 points of health.",
                Accessible = true
            };
            gameMap.Locations[2, 1] = new Location()
            {
                ID = 6,
                Name = "The Tamfasia Galactic Academy",
                Description = "The Tamfasia Galactic Academy was founded in the early 4th galactic metachron. " +
                "You are currently in the library, standing next to the protoplasmic encabulator that stores all " +
                "recorded information of the galactic history.",
                Accessible = true
            };

            return gameMap;
        }
    }
}
