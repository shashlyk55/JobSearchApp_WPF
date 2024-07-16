using Practic_App.MVVM.Model.Data.UW;
using Practic_App.MVVM.Model.Data;
using Practic_App.MVVM.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practic_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            //Icon = new BitmapImage(new Uri("pack://application:,,,/assets/icons/icon.ico", UriKind.Absolute));
            /*Uri iconUri = new Uri("pack://application:,,,/assets/icons/icon.ico", UriKind.RelativeOrAbsolute);
            this.Resources["ApplicationIcon"] = new System.Windows.Media.Imaging.BitmapImage(iconUri);*/
        }
    }
}