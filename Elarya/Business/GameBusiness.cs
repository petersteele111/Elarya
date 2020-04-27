using Elarya.Data;
using Elarya.Models;
using Elarya.Presentation.ViewModels;
using Elarya.Presentation.Views;
using System.Collections.ObjectModel;

namespace Elarya.Business
{
    public class GameBusiness
    {

        #region Fields

        ElaryaGameViewModel _elaryaGameViewModel;
        Player _player = new Player();
        Map _gameMap;
        MapCoordinates _initilizeMapCoordinates;
        bool _newPlayer = true;
        PlayerSetupView _playerSetupView;

        #endregion

        #region Constructor

        /// <summary>
        /// Public Constructor for GameBusiness Class
        /// </summary>
        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateandShowView();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method to initialize Default Intro Text
        /// </summary>
        private void InitializeDataSet()
        {
            _gameMap = GameData.GameMap();
            _initilizeMapCoordinates = GameData.InitializeGameMapLocation();
        }

        /// <summary>
        /// Instantiates and Shows the Main Game View
        /// </summary>
        private void InstantiateandShowView()
        {
            _elaryaGameViewModel = new ElaryaGameViewModel(_player, _gameMap, _initilizeMapCoordinates);
            ElaryaGameView elaryaGameView = new ElaryaGameView(_elaryaGameViewModel);
            elaryaGameView.DataContext = _elaryaGameViewModel;
            elaryaGameView.Show();
            _playerSetupView.Close();
        }

        /// <summary>
        /// Method to create the new Player with default values
        /// </summary>
        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();

                _player.Health = 100;
                _player.Mana = 100;
                _player.Life = 3;
                if (_player.JobTitle == Player.JobTitleName.Mage)
                {
                    _player.MageSkill = 5;
                }
                else if (_player.JobTitle == Player.JobTitleName.Healer)
                {

                }
                {
                    _player.HealerSkill = 5;
                }

                if (_player.Race == Character.RaceType.Nungari)
                {
                    _player.MageSkill += 5;
                }
                else if (_player.Race == Character.RaceType.Diolecian)
                {
                    _player.MageSkill += 10;
                }
                else if (_player.Race == Character.RaceType.Draggaru)
                {
                    _player.HealerSkill += 5;
                }
                else
                {
                    _player.HealerSkill += 10;
                }

                if (_player.Gender == Character.GenderType.Male)
                {
                    _player.MageSkill += 5;
                }
                else if (_player.Gender == Character.GenderType.Female)
                {
                    _player.HealerSkill += 5;
                }
                else
                {
                    _player.MageSkill += 5;
                    _player.HealerSkill += 5;
                }
                _player.Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameData.GameItemById(131), 1000)
                };
                _player.Quests = new ObservableCollection<Quest>()
                {
                    GameData.QuestById(1),
                    GameData.QuestById(2),
                    GameData.QuestById(3)
                };
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }

        #endregion

    }
}
