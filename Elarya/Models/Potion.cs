namespace Elarya.Models
{
    public class Potion : GameItem
    {

        #region Properties

        /// <summary>
        /// Gets and Sets Health Change for potion
        /// </summary>
        public int HealthChange { get; set; }

        /// <summary>
        /// Gets and Sets Life Change for potion
        /// </summary>
        public int LivesChange { get; set; }

        /// <summary>
        /// Gets and Sets Mana Change for potion
        /// </summary>
        public int ManaChange { get; set; }

        /// <summary>
        /// Gets and Sets Mage Skill Change for potion
        /// </summary>
        public int MageSkillChange { get; set; }

        /// <summary>
        /// Gets and Sets Healer Skill Change for potion
        /// </summary>
        public int HealerSkillChange { get; set; }

        /// <summary>
        /// Gets and Sets Experience Gain for potion
        /// </summary>
        public int ExperienceGain { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Public Constructor for Potion Model
        /// </summary>
        /// <param name="id">ID of Potion</param>
        /// <param name="name">Name of Potion</param>
        /// <param name="value">Value of Potion</param>
        /// <param name="healthChange">Health Change effect of Potion</param>
        /// <param name="livesChange">Life Change effect of Potion</param>
        /// <param name="manaChange">Mana Change effect of Potion</param>
        /// <param name="mageSkillChange">Mage Skill effect of Potion</param>
        /// <param name="healerSkillChange">Healer Skill effect of Potion</param>
        /// <param name="experienceGain">Experienced Gained from Potion</param>
        /// <param name="description">Description of Potion</param>
        /// <param name="useMessage">Message displayed on use</param>
        public Potion(int id, string name, int value, int healthChange, int livesChange, int manaChange, int mageSkillChange, int healerSkillChange, int experienceGain,
            string description, string useMessage) : base(id, name, value, description, useMessage)
        {
            HealthChange = healthChange;
            LivesChange = livesChange;
            ManaChange = manaChange;
            MageSkillChange = mageSkillChange;
            HealerSkillChange = healerSkillChange;
            ExperienceGain = experienceGain;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates item information
        /// </summary>
        /// <returns>Returns overriden item information string</returns>
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
            else if (MageSkillChange != 0)
            {
                return $"{Name}: {Description}/nMage Skill Change: {MageSkillChange}";
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

        #endregion

    }
}
