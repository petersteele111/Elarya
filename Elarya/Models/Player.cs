using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public class Player : Character
    {
        #region Fields

        protected JobTitleName _jobTitle;
        private int _health;
        private int _mana;
        private int _life;
        private int _mageSkill;
        private int _healerSkill;
        private string _spell;
        private string _inventoryItem;

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets and Sets the JobTitle Enumerator
        /// </summary>
        public JobTitleName JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }

        /// <summary>
        /// Sets and Gets the Health of the Player
        /// </summary>
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        /// <summary>
        /// Sets and Gets the Mana of the Player
        /// </summary>
        public int Mana
        {
            get { return _mana; }
            set { _mana = value; }
        }

        /// <summary>
        /// Sets and Gets the lives remaining for the Player
        /// </summary>
        public int Life
        {
            get { return _life; }
            set { _life = value; }
        }

        /// <summary>
        /// Sets and Gets the Mage Skill for the Player
        /// </summary>
        public int MageSkill
        {
            get { return _mageSkill; }
            set { _mageSkill = value; }
        }

        /// <summary>
        /// Sets and Gets the Mage Skill for the Player
        /// </summary>
        public int HealerSkill
        {
            get { return _healerSkill; }
            set { _healerSkill = value; }
        }

        /// <summary>
        /// Sets and Gets the Spell for the Player
        /// </summary>
        public string  Spell
        {
            get { return _spell; }
            set { _spell = value; }
        }

        /// <summary>
        /// Sets and Gets the Inventory Item for the Player
        /// </summary>
        public string  InventoryItem
        {
            get { return _inventoryItem; }
            set { _inventoryItem = value; }
        }

        #endregion

        #region Enums

        /// <summary>
        /// Job Title Enumerator
        /// </summary>
        public enum JobTitleName
        {
            Mage,
            Healer
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public Constructor for the Player Class
        /// </summary>
        public Player()
        {

        }

        /// <summary>
        /// Public constructor for the Player Class (Overload)
        /// </summary>
        /// <param name="id">Player ID</param>
        /// <param name="locationId">Location ID</param>
        /// <param name="name">Name of the Player</param>
        /// <param name="age">Age of of the Player Character</param>
        /// <param name="race">Race of the Player Character</param>
        /// <param name="gender">Gender of the Player Character</param>
        /// <param name="health">Health of the Player Character</param>
        /// <param name="mana">Mana of the Player Character</param>
        /// <param name="life">Life Remaining of the Player Character</param>
        /// <param name="mageSkill">Mage Skill Points of the Player Character</param>
        /// <param name="healerSkill">Healer Skill Points for the Player Character</param>
        /// <param name="spell">Spell for the Player Character</param>
        /// <param name="inventoryItem">Inventory Item of the Player Character</param>
        public Player(int id, int locationId, string name, int age, RaceType race, GenderType gender, int health, int mana,  int life, int mageSkill, int healerSkill, string spell, string inventoryItem) : base(id, locationId, name, age, race, gender)
        {
            _health = health;
            _mana = mana;
            _life = life;
            _mageSkill = mageSkill;
            _healerSkill = healerSkill;
            _spell = spell;
            _inventoryItem = inventoryItem;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Default Greeting for the Player
        /// </summary>
        /// <returns>Returns the Default Greeting</returns>
        public override string Greeting()
        {
            return $"Hello, my name is {_name}, and I am {_age} years old. I am setting off on my journey in hopes to become a {_jobTitle}, and am excited to get started!";
        }

        /// <summary>
        /// Checks to see if the Player has a Quest. Useful for changing dialogue with NPC's
        /// </summary>
        /// <returns></returns>
        public override bool HasQuest()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
