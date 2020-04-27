using Elarya.Business;
using System.Windows;

namespace Elarya
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public partial class App : Application
    {

        void Application_Startup(object sender, StartupEventArgs e)
        {
            GameBusiness gameBusiness = new GameBusiness();
        }

    }
}
