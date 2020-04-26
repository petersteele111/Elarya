using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Unnassigned,
            Incomplete,
            Complete
        }

        #endregion

        #region Fields

        private int _id;
        private string _name;
        private string _description;
        private QuestStatus _status;
        private string _statusDetail;
        private int _experienceGain;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets the Quest Id
        /// </summary>
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Gets and Sets the Quest Name
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// Gets and Sets the Quest Description
        /// </summary>
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        /// <summary>
        /// Gets and Sets the Quest Status
        /// </summary>
        public QuestStatus Status
        {
            get => _status;
            set => _status = value;
        }

        /// <summary>
        /// Gets and Sets the Quest Status Detail
        /// </summary>
        public string StatusDetail
        {
            get => _statusDetail;
            set => _statusDetail = value;
        }

        /// <summary>
        /// Gets and Sets the Quest Experience Gain
        /// </summary>
        public int ExperienceGain
        {
            get => _experienceGain;
            set => _experienceGain = value;
        }

        #endregion


        #region Constructor

        public Quest()
        {

        }

        public Quest(int id, string name, QuestStatus status)
        {
            _id = id;
            _name = name;
            _status = status;
        }

        #endregion


        #region Methods



        #endregion
    }
}
