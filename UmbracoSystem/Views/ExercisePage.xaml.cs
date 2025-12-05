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
using System.Web;
using UmbracoSystem.Views;
using UmbracoSystem.Models;
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

        public ExercisePage(Exercise selectedExercise)
        {
            InitializeComponent();
            DataContext = (object)selectedExercise ?? mvm; // fallback if null

        }
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Video.Play();
        }
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            Video.Pause();
        }
    }
}

