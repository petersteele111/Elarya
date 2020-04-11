using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Elarya.Models;

namespace Elarya.Presentation.ViewModels
{
    public class ElaryaGameViewModel : ObservableObject
    {
        #region Fields

        private Player _player;
        private List<string> _messages;
        private Map _gameMap;
        private Location _currentLocation, _northLocation, _eastLocation, _southLocation, _westLocation;
        private TimeSpan _gameTime;
        private DateTime _gameStartTime;
        private string _gameTimeDisplay;

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
            get => _gameMap;
            set
            {
                _gameMap = value;
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
            get => _eastLocation;
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(hasEastLocation));
            }
        }

        public Location SouthLocation
        {
            get => _southLocation;
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(hasSouthLocation));
            }
        }

        public Location WestLocation
        {
            get => _westLocation;
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(hasWestLocation));
            }
        }

        public bool hasNorthLocation { get { return NorthLocation != null; } }
        public bool hasEastLocation { get { return EastLocation != null; } }
        public bool hasSouthLocation { get { return SouthLocation != null; } }
        public bool hasWestLocation { get { return WestLocation != null; } }

        public string GameTimeDisplay
        {
            get { return _gameTimeDisplay; }
            set
            {
                _gameTimeDisplay = value;
                OnPropertyChanged(nameof(GameTimeDisplay));
            }
        }

        #endregion

        #region Constructor

        public ElaryaGameViewModel()
        {

        }

        public ElaryaGameViewModel(Player player, List<string> initialMessages, Map gameMap, MapCoordinates mapCoordinates)
        {
            _player = player;
            _messages = initialMessages;
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoords = mapCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
            InitializeView();
            GameTimer();
        }

        #endregion

        #region Methods

        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            UpdateAvailableTravelPoints();
        }

        private void UpdateAvailableTravelPoints()
        {

            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            if (_gameMap.NorthLocation() != null)
            {
                Location nextNorthLocation = _gameMap.NorthLocation();
                if (nextNorthLocation.Accessible == true)
                {
                    NorthLocation = nextNorthLocation;
                }
            }

            if (_gameMap.EastLocation() != null)
            {
                Location nextEastLocation = _gameMap.EastLocation();
                if (nextEastLocation.Accessible == true)
                {
                    EastLocation = nextEastLocation;
                }
            }

            if (_gameMap.SouthLocation() != null)
            {
                Location nextSouthLocation = _gameMap.SouthLocation();
                if (nextSouthLocation.Accessible == true)
                {
                    SouthLocation = nextSouthLocation;
                }
            }

            if (_gameMap.WestLocation() != null)
            {
                Location nextWestLocation = _gameMap.WestLocation();
                if (nextWestLocation.Accessible == true)
                {
                    WestLocation = nextWestLocation;
                }
            }
        }

        public string MessageDisplay
        {
            get => string.Join("\n\n", _messages);
        }

        public void MoveNorth()
        {
            if (hasNorthLocation)
            {
                _gameMap.canMoveNorth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
            }
        }

        public void MoveEast()
        {
            if (hasEastLocation)
            {
                _gameMap.canMoveEast();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
            }
        }

        public void MoveSouth()
        {
            if (hasSouthLocation)
            {
                _gameMap.canMoveSouth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
            }
        }

        public void MoveWest()
        {
            if (hasWestLocation)
            {
                _gameMap.canMoveWest();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
            }
        }

        public void GameTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += OnGameTimerTick;
            timer.Start();
        }

        void OnGameTimerTick(object sender, EventArgs e)
        {
            _gameTime = DateTime.Now - _gameStartTime;
            GameTimeDisplay = _gameTime.ToString(@"hh\:mm\:ss");
        }

        #endregion
    }
}
