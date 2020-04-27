using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public class QuestEngage : Quest
    {

        #region Fields

        private int _id;
        private string _name;
        private string _description;
        private QuestStatus _status;
        private string _statusDetail;
        private int _experienceGain;
        private List<NPC> _requiredNpcs;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets the Required Npcs for Quest
        /// </summary>
        public List<NPC> RequiredNpcs
        {
            get => _requiredNpcs;
            set => _requiredNpcs = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public Constructor
        /// </summary>
        public QuestEngage()
        {

        }

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <param name="id">Id of QuestEngagement</param>
        /// <param name="name">Name of QuestEngagement</param>
        /// <param name="status">Status of QuestEngagement</param>
        /// <param name="requiredNpcs">Required NPC's to Engage</param>
        public QuestEngage(int id, string name, QuestStatus status, List<NPC> requiredNpcs) : base(id, name, status)
        {
            _id = id;
            _name = name;
            _status = status;
            _requiredNpcs = requiredNpcs;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a list of NPC's that have not been engaged yet
        /// </summary>
        /// <param name="NpcsEngaged">Engaged NPC's</param>
        /// <returns>Returns NPC's to complete</returns>
        public List<NPC> NpcsNotEngaged(List<NPC> NpcsEngaged)
        {
            List<NPC> npcsToComplete = new List<NPC>();

            foreach (var requiredNpc in _requiredNpcs)
            {
                if (!NpcsEngaged.Any(x => x.Id == requiredNpc.Id))
                {
                    npcsToComplete.Add(requiredNpc);
                }
            }

            return npcsToComplete;
        }

        #endregion

    }
}
