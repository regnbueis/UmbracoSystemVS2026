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
using UmbracoSystem.Models;
using UmbracoSystem.ViewModels;
namespace UmbracoSystem.Views
{
    /// <summary>
    /// Interaction logic for ExercisePicker.xaml
    /// </summary>
    public partial class ExercisePicker : Page
    {
        MainViewModel mvm = new MainViewModel();

        public ExercisePicker()
        {
            InitializeComponent();
            DataContext = mvm;
            mvm.StartUp();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(new ExercisePage());

        }

        private void Tags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // SelectedTag has already been updated via SelectedValue binding.
            // Trigger recompute of the right-hand list using your existing setter logic:
            mvm.FilteredExerciseList = mvm.GetFilteredExerciseList();
        }

        private void ExercisesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var exercise = ExerciseList.SelectedItem as Exercise;
            if (exercise == null)
                return;

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(new ExercisePage(exercise));


        }

    }
}
