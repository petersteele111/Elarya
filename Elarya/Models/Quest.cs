namespace Elarya.Models
{
    public class Quest
    {

        #region Enums

        /// <summary>
        /// Quest Status Enum
        /// </summary>
        public enum QuestStatus
        {
            Incomplete,
            Complete
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets the Quest Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets and Sets the Quest Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and Sets the Quest Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets and Sets the Quest Status
        /// </summary>
        public QuestStatus Status { get; set; }

        /// <summary>
        /// Gets and Sets the Quest Status Detail
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Gets and Sets the Quest Experience Gain
        /// </summary>
        public int ExperienceGain { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Public Constructor
        /// </summary>
        public Quest()
        {

        }

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <param name="id">id of Quest</param>
        /// <param name="name">Name of Quest</param>
        /// <param name="status">Status of Quest</param>
        public Quest(int id, string name, QuestStatus status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        #endregion

    }
}
