﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Map _gameMap;
        private Location _currentLocation, _northLocation, _eastLocation, _southLocation, _westLocation;
        private TimeSpan _gameTime;
        private DateTime _gameStartTime;
        private string _gameTimeDisplay;
        private string _currentMessage;

        private GameItemQuantity _currentGameItem;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets the player
        /// </summary>
        public Player Player
        {
            get => _player;
            set { _player = value; }
        }

        /// <summary>
        /// Gets and sets the gamemap
        /// </summary>
        public Map GameMap
        {
            get => _gameMap;
            set { _gameMap = value; }
        }


        public string CurrentMessage
        {
            get => _currentMessage;
            set
            {
                _currentMessage = value;
                OnPropertyChanged(nameof(CurrentMessage));
            }
        }

        /// <summary>
        /// Gets and sets the current location
        /// </summary>
        public Location CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;
                _currentMessage = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentMessage));
            }
        }

        public string MessageDisplay
        {
            get => _currentLocation.Messages;
        }

        /// <summary>
        /// Gets and sets the north location (relative)
        /// </summary>
        public Location NorthLocation
        {
            get => _northLocation;
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }

        /// <summary>
        /// Gets and sets the east location (relative)
        /// </summary>
        public Location EastLocation
        {
            get => _eastLocation;
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }

        /// <summary>
        /// Gets and sets the south location (relative)
        /// </summary>
        public Location SouthLocation
        {
            get => _southLocation;
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }

        /// <summary>
        /// Gets and sets the west location (relative)
        /// </summary>
        public Location WestLocation
        {
            get => _westLocation;
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }

        /// <summary>
        /// Checks if a north location exists
        /// </summary>
        public bool HasNorthLocation
        {
            get { return NorthLocation != null; }
        }

        /// <summary>
        /// Checks if an east location exists
        /// </summary>
        public bool HasEastLocation
        {
            get { return EastLocation != null; }
        }

        /// <summary>
        /// Checks if a south location exists
        /// </summary>
        public bool HasSouthLocation
        {
            get { return SouthLocation != null; }
        }

        /// <summary>
        /// Checks if a west location exists
        /// </summary>
        public bool HasWestLocation
        {
            get { return WestLocation != null; }
        }

        /// <summary>
        /// Gets and sets the GameTime Display ticker
        /// </summary>
        public string GameTimeDisplay
        {
            get { return _gameTimeDisplay; }
            set
            {
                _gameTimeDisplay = value;
                OnPropertyChanged(nameof(GameTimeDisplay));
            }
        }

        public GameItemQuantity CurrentGameItem
        {
            get => _currentGameItem;
            set { _currentGameItem = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for the game
        /// </summary>
        /// <param name="player"></param>
        /// <param name="gameMap"></param>
        /// <param name="mapCoordinates"></param>
        public ElaryaGameViewModel(Player player, Map gameMap, MapCoordinates mapCoordinates)
        {
            _player = player;
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoords = mapCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
            _currentMessage = _currentLocation.Description;
            InitializeView();
            GameTimer();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the timer and locations available
        /// </summary>
        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            UpdateAvailableTravelPoints();
            _player.UpdateInventory();
            _player.CalcWealth();
        }

        #region Move Methods

        /// <summary>
        /// Updates the available travel points for a given area on the map
        /// </summary>
        private void UpdateAvailableTravelPoints()
        {

            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            if (_gameMap.NorthLocation() != null)
            {
                Location nextNorthLocation = _gameMap.NorthLocation();
                if (nextNorthLocation.Accessible == true || PlayerCanAccessLocation(nextNorthLocation))
                {
                    NorthLocation = nextNorthLocation;
                }
            }

            if (_gameMap.EastLocation() != null)
            {
                Location nextEastLocation = _gameMap.EastLocation();
                if (nextEastLocation.Accessible == true || PlayerCanAccessLocation(nextEastLocation))
                {
                    EastLocation = nextEastLocation;
                }
            }

            if (_gameMap.SouthLocation() != null)
            {
                Location nextSouthLocation = _gameMap.SouthLocation();
                if (nextSouthLocation.Accessible == true || PlayerCanAccessLocation(nextSouthLocation))
                {
                    SouthLocation = nextSouthLocation;
                }
            }

            if (_gameMap.WestLocation() != null)
            {
                Location nextWestLocation = _gameMap.WestLocation();
                if (nextWestLocation.Accessible == true || PlayerCanAccessLocation(nextWestLocation))
                {
                    WestLocation = nextWestLocation;
                }
            }
        }

        /// <summary>
        /// If a north location exists, the player can move north
        /// </summary>
        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.CanMoveNorth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                PlayerMove();
            }
        }

        /// <summary>
        /// If an east location exists, the player can move east
        /// </summary>
        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.CanMoveEast();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                PlayerMove();
            }
        }

        /// <summary>
        /// If a south location exists, the player can move south
        /// </summary>
        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.CanMoveSouth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                PlayerMove();
            }
        }

        /// <summary>
        /// If a west location exists, the player can move west
        /// </summary>
        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.CanMoveWest();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                PlayerMove();
            }
        }

        private bool PlayerCanAccessLocation(Location nextLocation)
        {
            if (nextLocation.IsAccessibleByExperience(_player.Experience))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PlayerMove()
        {
            //
            // Update Player Stats in location
            //
            if (!_player.HasVisited(_currentLocation))
            {
                _player.LocationsVisited.Add(_currentLocation);
                _player.Health += _currentLocation.ModifyHealth;
                _player.Life += _currentLocation.ModifyLives;
                _player.MageSkill += _currentLocation.MageSkill;
                _player.HealerSkill += _currentLocation.HealerSkill;
                _player.Experience += _currentLocation.ExperienceGain;
                OnPropertyChanged(nameof(MessageDisplay));
            }
        }

        #endregion

        #region Game Timer
        /// <summary>
        /// Initializes the Game Timer
        /// </summary>
        public void GameTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += OnGameTimerTick;
            timer.Start();
        }

        /// <summary>
        /// Initializes the Game Timer Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGameTimerTick(object sender, EventArgs e)
        {
            _gameTime = DateTime.Now - _gameStartTime;
            GameTimeDisplay = _gameTime.ToString(@"hh\:mm\:ss");
        }

        #endregion

        #region Inventory Methods

        /// <summary>
        /// add a new item to the players inventory
        /// </summary>
        /// <param name="selectedItem"></param>
        public void AddItemToInventory()
        {
            //
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            //
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                GameItemQuantity selectedGameItemQuantity = _currentGameItem;

                _currentLocation.RemoveGameItemQuantityFromLocation(selectedGameItemQuantity, selectedGameItemQuantity.Quantity);
                _player.AddGameItemQuantityToInventory(selectedGameItemQuantity, selectedGameItemQuantity.Quantity);

                OnPlayerPickUp(selectedGameItemQuantity);
            }
        }

        /// <summary>
        /// remove item from the players inventory
        /// </summary>
        /// <param name="selectedItem"></param>
        public void RemoveItemFromInventory()
        {
            //
            // confirm a game item selected and is in inventory
            // subtract from inventory and add to location
            //
            if (_currentGameItem != null)
            {
                //
                // cast selected game item 
                //
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentLocation.AddGameItemQuantityToLocation(selectedGameItemQuantity);
                _player.RemoveGameItemQuantityFromInventory(selectedGameItemQuantity);

                OnPlayerPutDown(selectedGameItemQuantity);
            }
        }

        /// <summary>
        /// process events when a player picks up a new game item
        /// </summary>
        /// <param name="gameItemQuantity">new game item</param>
        private void OnPlayerPickUp(GameItemQuantity gameItemQuantity)
        {
            _player.Wealth += gameItemQuantity.GameItem.Value;
        }

        /// <summary>
        /// process events when a player puts down a new game item
        /// </summary>
        /// <param name="gameItemQuantity">new game item</param>
        private void OnPlayerPutDown(GameItemQuantity gameItemQuantity)
        {
            _player.Wealth -= gameItemQuantity.GameItem.Value;
        }

        /// <summary>
        /// process using an item in the player's inventory
        /// </summary>
        public void OnUseGameItem()
        {
           try
            {
                switch (_currentGameItem.GameItem)
                {
                    case Potion potion:
                        ProcessPotionUse(potion);
                        break;
                    case Treasure treasure:
                        ProcessTreasure(treasure);
                        break;
                    case Food food:
                        ProcessFood(food);
                        break;
                    default:
                        break;
                }
            } 
            catch (NullReferenceException)
            {
                CurrentMessage = "Sorry, there is no use for that!";
            }
        }

        /// <summary>
        /// process the effects of using the potion
        /// </summary>
        /// <param name="potion">potion</param>
        private void ProcessPotionUse(Potion potion)
        {
            CurrentMessage = potion.UseMessage;

            _player.Health += potion.HealthChange;
            _player.Life += potion.LivesChange;
            _player.MageSkill += potion.MageSkillChange;
            _player.HealerSkill += potion.HealerSkillChange;
            _player.Experience += potion.ExperienceGain;
            _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
        }

        private void ProcessTreasure(Treasure treasure)
        {
            if (treasure.Type == Treasure.TreasureType.Coin)
            {
                CurrentMessage = "You threw a coin to your Witcher!";
                _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
            }
            else
            {
                string message = _gameMap.OpenLocationsByItem(treasure.Id);
                CurrentMessage = message;
                _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
            }
        }

        private void ProcessFood(Food food)
        {
            CurrentMessage = food.UseMessage;
            _player.Health += food.HealthChange;
            _player.Mana += food.ManaChange;
            _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
        }

        #endregion

        #endregion

        ///// <summary>
        ///// process player dies with option to reset and play again
        ///// </summary>
        ///// <param name="message">message regarding player death</param>
        //private void OnPlayerDies(string message)
        //{
        //    string messagetext = message +
        //                         "\n\nWould you like to play again?";

        //    string titleText = "Death";
        //    MessageBoxButton button = MessageBoxButton.YesNo;
        //    MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

        //    switch (result)
        //    {
        //        case MessageBoxResult.Yes:
        //            ResetPlayer();
        //            break;
        //        case MessageBoxResult.No:
        //            QuiteApplication();
        //            break;
        //    }
        //}

        /// <summary>
        /// player chooses to exit game
        /// </summary>
        public void QuitApplication()
        {
            Environment.Exit(0);
        }

    }
}
