using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

        public void BackgroundMusic()
        {
            SoundPlayer playerCreate = new SoundPlayer(System.AppDomain.CurrentDomain.BaseDirectory + @"\Presentation\Resources\Assets\Sounds\PlayerCreateScreen.wav");
            playerCreate.Load();
            playerCreate.PlayLooping();
        }
        

        #region Fields

        private Player _player;

        #endregion

        #region Properties

        /// <summary>
        /// Public Constructor for PlayerSetup
        /// </summary>
        /// <param name="player"></param>
        public PlayerSetupView(Player player)
        {
            _player = player;
            InitializeComponent();
            SetupWindow();
        }

        #endregion

        /// <summary>
        /// Method to setup the Window for Player Character Creation
        /// </summary>
        private void SetupWindow()
        {
            List<string> races = Enum.GetNames(typeof(Player.RaceType)).ToList();
            List<string> gender = Enum.GetNames(typeof(Player.GenderType)).ToList();
            List<string> jobTitle = Enum.GetNames(typeof(Player.JobTitleName)).ToList();

            RaceTypeComboBox.ItemsSource = races;
            GenderTypeComboBox.ItemsSource = gender;
            JobTitleTypeComboBox.ItemsSource = jobTitle;

            ErrorMessageTextBlock.Visibility = Visibility.Hidden;
            ErrorMessageTextBlockAge.Visibility = Visibility.Hidden;
            BackgroundMusic();

        }

        /// <summary>
        /// Method to Validate Player Character Name has been entered
        /// </summary>
        /// <param name="errorMessage">Error message if Player Character name has not been input</param>
        /// <returns>Returns True or False if the name is not blank and contains no digits or not</returns>
        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";
            if (PlayerName.Text == "")
            {
                errorMessage += "Player Name is required!";
            }
            else if (!PlayerName.Text.All(chr => char.IsLetter(chr)))
            {
                errorMessage += "No numbers! Letters only!";
            } 
            else
            {
                _player.Name = PlayerName.Text;
            }

            return errorMessage == "" ? true : false;
        }

        /// <summary>
        /// Method to Validate Player Character Age has been entered
        /// </summary>
        /// <param name="errorMessageAge">Error message if Player Character age has not been input</param>
        /// <returns>Returns True or False if the Age is properly input and formatted or not</returns>
        private bool IsValidInt(out string errorMessageAge)
        {
            errorMessageAge = "";
            if (Age.Text == "")
            {
                errorMessageAge += "You must enter an Age!";
            }
            else if (!int.TryParse(Age.Text, out int age))
            {
                errorMessageAge += "You must enter a valid number only!";
            }
            else
            {
                _player.Age = age;
            }

            return errorMessageAge == "" ? true : false;
        }



        /// <summary>
        /// Method to process Ok button click for Player Character creation view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput(out var errorMessage))
            {
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }
            else
            {
                ErrorMessageTextBlock.Visibility = Visibility.Hidden;
            }

            if (!IsValidInt(out var errorMessageAge))
            {
                ErrorMessageTextBlockAge.Visibility = Visibility.Visible;
                ErrorMessageTextBlockAge.Text = errorMessageAge;
            }
            else
            {
                ErrorMessageTextBlockAge.Visibility = Visibility.Hidden;
            }

            if (errorMessage == "" && errorMessageAge == "")
            {
                Enum.TryParse(JobTitleTypeComboBox.SelectionBoxItem.ToString(), out Player.JobTitleName jobTitle);
                Enum.TryParse(RaceTypeComboBox.SelectionBoxItem.ToString(), out Character.RaceType race);
                Enum.TryParse(GenderTypeComboBox.SelectionBoxItem.ToString(), out Character.GenderType gender);

                _player.JobTitle = jobTitle;
                _player.Race = race;
                _player.Gender = gender;
                _player.LocationId = 0;

                Visibility = Visibility.Hidden;
            }
        }
    }
}
