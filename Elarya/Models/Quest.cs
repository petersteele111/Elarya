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
