using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Elarya.Models;

namespace Elarya.Presentation.Views
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;

        public PlayerSetupView(Player player)
        {
            _player = player;
            InitializeComponent();
            SetupWindow();
        }

        private void SetupWindow()
        {
            List<string> races = Enum.GetNames(typeof(Player.RaceType)).ToList();
            List<string> gender = Enum.GetNames(typeof(Player.GenderType)).ToList();
            List<string> jobTitle = Enum.GetNames(typeof(Player.JobTitleName)).ToList();

            RaceTypeComboBox.ItemsSource = races;
            GenderTypeComboBox.ItemsSource = gender;
            JobTitleTypeComboBox.ItemsSource = jobTitle;

            ErrorMessageTextBlock.Visibility = Visibility.Hidden;

        }

        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";
            if (Name.Text == "")
            {
                errorMessage += "Player Name is required!";
            }
            else
            {
                _player.Name = Name.Text;
            }
            return errorMessage == "" ? true : false;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;
            if (IsValidInput(out errorMessage))
            {
                Enum.TryParse(JobTitleTypeComboBox.SelectionBoxItem.ToString(), out Player.JobTitleName jobTitle);
                Enum.TryParse(RaceTypeComboBox.SelectionBoxItem.ToString(), out Character.RaceType race);
                Enum.TryParse(GenderTypeComboBox.SelectionBoxItem.ToString(), out Character.GenderType gender);

                _player.JobTitle = jobTitle;
                _player.Race = race;
                _player.Gender = gender;

                Visibility = Visibility.Hidden;
            }
            else
            {
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }
        }
    }
}
