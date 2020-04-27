using System.Collections.Generic;
using Elarya.Models;

namespace Elarya.Presentation.ViewModels
{
    public class QuestStatusViewModel : ObservableObject
    {

        #region Fields

        private string _questInformation;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets the List of Quests
        /// </summary>
        public List<Quest> Quests { get; set; }

        /// <summary>
        /// Gets and Sets the Quest Information
        /// </summary>
        public string QuestInformation
        {
            get => _questInformation;
            set
            {
                _questInformation = value;
                OnPropertyChanged(nameof(QuestInformation));
            }
        }

        #endregion

    }
}
