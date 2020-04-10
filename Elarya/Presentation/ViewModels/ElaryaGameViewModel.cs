using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elarya.Models;

namespace Elarya.Presentation.ViewModels
{
    public class ElaryaGameViewModel : ObservableObject
    {
        #region Fields

        private Player _player;
        private List<string> _messages;
        private Map _gamemap;
        private Location _location, _currentLocation, _northLocation, _eastLocation, _saouthLocation, _westLocation;

        #endregion

        #region Properties

        public Player Player
        {
            get => _player;
            set
            {
                _player = value;
            }
        }

        public Map GameMap
        {
            get => _gamemap;
            set
            {
                _gamemap = value;
            }
        }

        public Location CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
            }
        }

        public Location NorthLocation
        {
            get => _northLocation;
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(hasNorthLocation));
            }
        }

        public Location EastLocation
        {
            get => _northLocation;
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(hasEastLocation));
            }
        }

        public Location SouthLocation
        {
            get => _northLocation;
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(hasSouthLocation));
            }
        }

        public Location WestLocation
        {
            get => _northLocation;
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(hasWestLocation));
            }
        }

        public bool hasNorthLocation { get { return NorthLocation != null; } }
        public bool hasEastLocation { get { return EastLocation != null; } }
        public bool hasSouthLocation { get { return SouthLocation != null; } }
        public bool hasWestLocation { get { return WestLocation != null; } }


        #endregion

        #region Constructor

        public ElaryaGameViewModel()
        {

        }

        public ElaryaGameViewModel(Player player, List<string> initialMessages)
        {
            _player = player;
            _messages = initialMessages;
        }

        #endregion

        #region Methods

        public string MessageDisplay
        {
            get => string.Join("\n\n", _messages);
        }


        #endregion
    }
}
