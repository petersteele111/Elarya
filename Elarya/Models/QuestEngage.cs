using System.Collections.Generic;
using System.Linq;

namespace Elarya.Models
{
    public class QuestEngage : Quest
    {

        #region Properties

        /// <summary>
        /// Gets and Sets the Required Npcs for Quest
        /// </summary>
        public List<Npc> RequiredNpcs { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a list of NPC's that have not been engaged yet
        /// </summary>
        /// <param name="npcsEngaged">Engaged NPC's</param>
        /// <returns>Returns NPC's to complete</returns>
        public List<Npc> NpcsNotEngaged(List<Npc> npcsEngaged)
        {
            return RequiredNpcs.Where(requiredNpc => npcsEngaged.All(x => x.Id != requiredNpc.Id)).ToList();
        }

        #endregion

    }
}
