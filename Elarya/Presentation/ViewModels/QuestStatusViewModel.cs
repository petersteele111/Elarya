using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elarya.Models;

namespace Elarya.Presentation.ViewModels
{
    public class QuestStatusViewModel : ObservableObject
    {
        #region Fields

        private string _questInformation;
        private List<Quest> _quests;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets the List of Quests
        /// </summary>
        public List<Quest> Quests
        {
            get => _quests;
            set => _quests = value;
        }

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
