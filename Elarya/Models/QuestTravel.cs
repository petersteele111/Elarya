using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Elarya.Models
{
    public class QuestTravel : Quest
    {

        #region Fields

        private int _id;
        private string _name;
        private string _description;
        private Quest.QuestStatus _status;
        private string _statusDetail;
        private InputGesture _experienceGain;
        private List<Location> _requiredLocations;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets required locations for Quest
        /// </summary>
        public List<Location> RequiredLocations
        {
            get => _requiredLocations;
            set
            {
                _requiredLocations = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public Constructor
        /// </summary>
        public QuestTravel()
        {

        }

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <param name="id">Id of QuestTravel</param>
        /// <param name="name">Name of QuestTravel</param>
        /// <param name="status">Status of QuestTravel</param>
        /// <param name="requiredLocations">Required Locations to Visit</param>
        public QuestTravel(int id, string name, QuestStatus status, List<Location> requiredLocations) : base(id, name, status)
        {
            _id = id;
            _name = name;
            _status = status;
            _requiredLocations = requiredLocations;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines locations not yet visited
        /// </summary>
        /// <param name="locationsTraveled">Locations Traveled</param>
        /// <returns>Returns locations that still need to be visited</returns>
        public List<Location> LocationsNotCompleted(List<Location> locationsTraveled)
        {
            List<Location> locationsToComplete = new List<Location>();

            foreach (var requiredLocation in _requiredLocations)
            {
                if (Equals(locationsTraveled.All(x => x.ID != requiredLocation.ID)))
                {
                    locationsToComplete.Add(requiredLocation);
                }
            }

            return locationsToComplete;
        }

        #endregion
    }
}
