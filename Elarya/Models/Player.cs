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
        private int _attackPower;
        private int _defensePower;
        private int _healthRegenRate;
        private int _manaRegenRate;
        private int _life;
        private int _warriorSkill;
        private int _dragonRiderSkill;
        private int _hunterSkill;
        private int _mageSkill;
        private string _spell;
        private string _inventoryItem;

        #endregion

        #region Properties

        public JobTitleName JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }


        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Mana
        {
            get { return _mana; }
            set { _mana = value; }
        }

        public int AttackPower
        {
            get { return _attackPower; }
            set { _attackPower = value; }
        }

        public int DefensePower
        {
            get { return _defensePower; }
            set { _defensePower = value; }
        }

        public int HealthRegenRate
        {
            get { return _healthRegenRate; }
            set { _healthRegenRate = value; }
        }

        public int ManaRegenRate
        {
            get { return _manaRegenRate; }
            set { _manaRegenRate = value; }
        }

        public int Life
        {
            get { return _life; }
            set { _life = value; }
        }

        public int WarriorSkill
        {
            get { return _warriorSkill; }
            set { _warriorSkill = value; }
        }

        public int DragonRiderSkill
        {
            get { return _dragonRiderSkill; }
            set { _dragonRiderSkill = value; }
        }

        public int HunterSkill
        {
            get { return _hunterSkill; }
            set { _hunterSkill = value; }
        }

        public int MageSkill
        {
            get { return _mageSkill; }
            set { _mageSkill = value; }
        }

        public string  Spell
        {
            get { return _spell; }
            set { _spell = value; }
        }

        public string  InventoryItem
        {
            get { return _inventoryItem; }
            set { _inventoryItem = value; }
        }

        #endregion

        #region Enums

        public enum JobTitleName
        {
            Warrior,
            DragonRider,
            Hunter,
            Mage
        }

        #endregion

        #region Constructor

        public Player()
        {

        }

        public Player(int id, int locationId, string name, int age, RaceType race, GenderType gender, int health, int mana, int attackPower, int defensePower, int healthRegenRate, int manaRegenRate, int life, int warriorSkill, int dragonRiderSkill, int hunterSkill, int mageSkill, string spell, string inventoryItem) : base(id, locationId, name, age, race, gender)
        {
            _health = health;
            _mana = mana;
            _attackPower = attackPower;
            _defensePower = defensePower;
            _healthRegenRate = healthRegenRate;
            _manaRegenRate = manaRegenRate;
            _life = life;
            _warriorSkill = warriorSkill;
            _dragonRiderSkill = dragonRiderSkill;
            _hunterSkill = hunterSkill;
            _mageSkill = mageSkill;
            _spell = spell;
            _inventoryItem = inventoryItem;
        }

        #endregion

        #region Methods

        public override string Greeting()
        {
            return $"Hello, my name is {_name}, and I am {_age} years old. I am setting off on my journey in hopes to become a {_jobTitle}, and am excited to get started!";
        }

        public override bool HasQuest()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
