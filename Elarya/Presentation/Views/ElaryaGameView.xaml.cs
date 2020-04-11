using Elarya.Presentation.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Elarya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ElaryaGameView : Window
    {
        ElaryaGameViewModel _elaryaGameViewModel;

        public ElaryaGameView(ElaryaGameViewModel elaryaGameViewModel)
        {
            _elaryaGameViewModel = elaryaGameViewModel;
            InitializeComponent();
        }

        private void NorthButton_Click(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.MoveNorth();
        }

        private void EastButton_Click(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.MoveEast();
        }

        private void SouthButton_Click(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.MoveSouth();
        }

        private void WestButton_Click(object sender, RoutedEventArgs e)
        {
            _elaryaGameViewModel.MoveWest();
        }
    }
}
