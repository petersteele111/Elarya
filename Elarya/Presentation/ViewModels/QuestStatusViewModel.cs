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
        private string _questInformation;
        private List<Quest> _quests;

        public List<Quest> Quests
        {
            get => _quests;
            set => _quests = value;
        }

        public string QuestInformation
        {
            get => _questInformation;
            set
            {
                _questInformation = value;
                OnPropertyChanged(nameof(QuestInformation));
            }
        }


    }
}
