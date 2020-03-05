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
            setupWindow();
        }

        private void setupWindow()
        {
            List<string> races = Enum.GetNames(typeof(Player.RaceType)).ToList();
            List<string> gender = Enum.GetNames(typeof(Player.GenderType)).ToList();
            List<string> jobTitle = Enum.GetNames(typeof(Player.JobTitleName)).ToList();

            RaceTypeComboBox.ItemsSource = races;
            GenderTypeComboBox.ItemsSource = gender;
            JobTitleTypeComboBox.ItemsSource = jobTitle;

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
