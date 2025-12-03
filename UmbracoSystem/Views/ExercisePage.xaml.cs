using System;
using System.Collections.Generic;
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
using UmbracoSystem.Views;
using UmbracoSystem.ViewModels;

namespace UmbracoSystem.Views
{
    /// <summary>
    /// Interaction logic for ExercisePage.xaml
    /// </summary>
    public partial class ExercisePage : Page
    {
        MainViewModel mvm = new MainViewModel();
        public ExercisePage()
        {
            InitializeComponent();
            DataContext = mvm;
        }
    }
}
