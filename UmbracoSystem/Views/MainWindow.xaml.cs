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
using UmbracoSystem.ViewModels;
using UmbracoSystem.Views;

namespace UmbracoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm = new MainViewModel();

        //Genbruger homepage istedet for forskelige instanser
        private readonly HomePage homePage;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvm;

            // En instans, bruger samme mvm
            homePage = new HomePage(mvm);

            // Starter op på homepage
            MainFrame.Navigate(homePage);            
            mvm.StartUp();

        }

        private void btnØvelser_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ExercisePicker());
        }

        private void btnEvents_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(homePage);
        }
    }
}