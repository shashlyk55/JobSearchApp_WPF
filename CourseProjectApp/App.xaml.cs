using Practic_App.MVVM.Model.Data;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Practic_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base()
        {
            new ApplicationDataContext();
        }
    }
}