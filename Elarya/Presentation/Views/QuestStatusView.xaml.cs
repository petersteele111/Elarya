using Elarya.Presentation.ViewModels;
using System.Windows;

namespace Elarya.Presentation.Views
{
    /// <summary>
    /// Interaction logic for QuestStatusView.xaml
    /// </summary>
    public partial class QuestStatusView : Window
    {
        private QuestStatusViewModel _questStatusViewModel;

        public QuestStatusView(QuestStatusViewModel questStatusViewModel)
        {
            _questStatusViewModel = questStatusViewModel;
            DataContext = questStatusViewModel;
            InitializeComponent();
        }

        private void QuestStatusWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
