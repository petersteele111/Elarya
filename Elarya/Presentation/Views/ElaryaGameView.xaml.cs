﻿using Elarya.Presentation.ViewModels;
using System.Windows;

namespace Elarya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ElaryaGameView : Window
    {
        ElaryaGameViewModel _elaryaGameViewModel;

        /// <summary>
        /// Initializes the game view model
        /// </summary>
        /// <param name="elaryaGameViewModel">name of gameviewmodel</param>
        public ElaryaGameView(ElaryaGameViewModel elaryaGameViewModel)
        {
            _elaryaGameViewModel = elaryaGameViewModel;
            InitializeComponent();
        }

        /// <summary>
        /// Button to Move Player North
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NorthButton_Click(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.MoveNorth();
        }

        /// <summary>
        /// Button to Move Player East
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EastButton_Click(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.MoveEast();
        }

        /// <summary>
        /// Button to Move Player South
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SouthButton_Click(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.MoveSouth();
        }

        /// <summary>
        /// Button to Move Player West
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WestButton_Click(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.MoveWest();
        }

        private void PickUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationItemsDataGrid.SelectedItem != null)
            {
                _elaryaGameViewModel.AddItemToInventory();
            }
        }

        private void PutDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerInfoTabControl.SelectedItem != null)
            {
                _elaryaGameViewModel.RemoveItemFromInventory();
            }

        }

        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerInfoTabControl.SelectedItem != null)
            {
                _elaryaGameViewModel.OnUseGameItem();
            }
        }

        private void TalkToNpcButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _elaryaGameViewModel.OnPlayerTalkTo();
            }
        }

        private void BuyItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _elaryaGameViewModel.BuyItem();
            }
        }


        private void SellItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _elaryaGameViewModel.SellItem();
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.QuitApplication();
        }

        private void RestartMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.ResetPlayer();
        }

        private void HelpMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.Help();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.QuestWindow();
        }
    }
}
