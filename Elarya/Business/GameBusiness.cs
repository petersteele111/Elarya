using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elarya.Presentation.ViewModels;
using Elarya.Models;
using Elarya.Data;
using Elarya.Presentation.Views;

namespace Elarya.Business
{
    public class GameBusiness
    {
        ElaryaGameViewModel _elaryaGameViewModel;
        Player _player = new Player();
        List<string> _messages;
        bool _newPlayer = true;
        PlayerSetupView _playerSetupView;

        /// <summary>
        /// Public Constructor for GameBusiness Class
        /// </summary>
        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateandShowView();
        }

        /// <summary>
        /// Method to initialize Default Intro Text
        /// </summary>
        private void InitializeDataSet()
        {
            _messages = GameData.InitialMessages();
        }

        /// <summary>
        /// Instantiates and Shows the Main Game View
        /// </summary>
        private void InstantiateandShowView()
        {
            _elaryaGameViewModel = new ElaryaGameViewModel(_player, _messages);
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

                _player.Age = 20;
                _player.Health = 100;
                _player.Mana = 100;
                _player.AttackPower = 10;
                _player.DefensePower = 5;
                _player.Life = 3;
                _player.HealthRegenRate = 5;
                _player.ManaRegenRate = 5;
                _player.WarriorSkill = 0;
                _player.DragonRiderSkill = 0;
                _player.HunterSkill = 0;
                _player.MageSkill = 0;
                _player.Spell = null;
                _player.InventoryItem = null;
            } 
            else
            {
                _player = GameData.PlayerData();
            }
        }

    }
}
