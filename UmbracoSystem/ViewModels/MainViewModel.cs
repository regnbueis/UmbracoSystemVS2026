using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls.Primitives;
using UmbracoSystem.Models;

namespace UmbracoSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //private int ChosenTag = 0;
        //TODO:
        //det her handler om, at vi ville prøve at gemme hvilket tag, brugeren har valgt,
        //så man i skiftet fra øvelsesviewet med listerne af hhv. tags og sorterede øvelser
        //kan gemme det valgte tag, og man i viewet, hvor man ser selve øvelsen, kan have
        //den tag-filtrerede liste med ude i siden. Vi må lige se, om det bliver relevant.
        //Ellers kan ChosenTag slettes uden videre.
        //load fra værdi og ændre værdi skal ligge som metoder på taglisten i UI.
        //on load eller got focus skal den tjekke chosentag
        //når brugeren vælger et tag skal chosentag ændres så det stemmer overens med valget


        //TODO:
        //Lav metoder, der specifikt er lavet til hver forskellig navigation
        public void StartUp()
        {
            Persist.Initialize();
            EmployeeRepository.Initialize();
            LogRepository.Initialize();
            NextEvent = new Event();
            Employees = new ObservableCollection<Employee>();
            Tagslist = new ObservableCollection<Tag>();
            TagRepository.GetTags();
            PlacementList();
            SelectedTag = "";
            FilteredExerciseList = new ObservableCollection<Exercise>();

            //CreateExercises();
            //CreateEmployees();
            //LogActivity();
        }

        #region Instantierede controllere
        EventController eventController = new EventController();
        ExerciseController exerciseController = new ExerciseController();
        #endregion

        #region Next Upcoming Event stuff
        private Event _nextEvent;

        public Event NextEvent
        {
            get { return _nextEvent; }
            set
            {
                _nextEvent = eventController.UpcomingEvent();
                OnPropertyChanged("NextEvent");
            }
        }
        #endregion

        #region Top Five Employees Leaderboard stuff
        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = TopFiveEmployees();
            }
        }

        public List<int> Placement = new List<int>();

        public void PlacementList()
        {
            Placement.Add(1);
            Placement.Add(2);
            Placement.Add(3);
            Placement.Add(4);
            Placement.Add(5);
        }

        public ObservableCollection<Employee> TopFiveEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            LogController logController = new LogController();

            Dictionary<int, int> scoreboard = logController.LoadScoreboard();
            if (scoreboard.Count > 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Employee employee = EmployeeRepository.GetById(scoreboard.ElementAt(i).Key);

                    employees.Add(employee);
                }
            }
            return employees;
        }
        #endregion

        #region Choose Exercise stuff
        private ObservableCollection<Tag> _tagslist;

        public ObservableCollection<Tag> Tagslist
        {
            get { return _tagslist; }
            set
            {
                _tagslist = exerciseController.ExerciseTagList();
            }
        }

        private string _selectedTag;

        public string SelectedTag
        {
            get { return _selectedTag; }
            set
            {
                _selectedTag = value;
            }
        }

        private ObservableCollection<Exercise> _filteredExerciseList;

        public ObservableCollection<Exercise> FilteredExerciseList
        {
            get { return _filteredExerciseList; }
            set
            {
                _filteredExerciseList = GetFilteredExerciseList();
                OnPropertyChanged("FilteredExerciseList");
            }
        }

        public ObservableCollection<Exercise> GetFilteredExerciseList()
        {
            List<Exercise> listOfExercises = exerciseController.ChooseMuscleGroup(SelectedTag);

            ObservableCollection<Exercise> result = new ObservableCollection<Exercise>();

            foreach (Exercise item in listOfExercises)
            {
                result.Add(item);
            }

            return result;
        }


        //lav metode, der kan bære en string med fra frontend til ChooseMuscleGroup() fra ExerciseController


        /*        public void GetSelectedExercise()
                {

                }*/

        #endregion

        public void CreateEmployees()
        {
            EmployeeRepository.Add("Leif Dixon", false);
            EmployeeRepository.Add("Jan Brown", false);
            EmployeeRepository.Add("Lars ???", false);
            EmployeeRepository.Add("Peter Obling", false);
            EmployeeRepository.Add("Per Valter", false);
        }

        public void LogActivity()
        {
            LogRepository.Add(DateTime.Now, 905, 101, 1);
            LogRepository.Add(DateTime.Now, 906, 101, 1);
            LogRepository.Add(DateTime.Now, 907, 101, 1);
            LogRepository.Add(DateTime.Now, 908, 101, 1);
            LogRepository.Add(DateTime.Now, 909, 101, 1);
        }

        public void CreateExercises()
        {
            ExerciseRepository.Add("Skulderblads-klem", "Gør elastikken kortere til cirka skulderbredde og hold armene strakt frem foran kroppen. Træk nu armene ud til siden og bagud til elastikken rammer brystkassen. Fornem, at du klemmer skulderbladene sammen på ryggen. Før armene kontrolleret tilbage igen. Hold dine albuer let bøjede under hele bevægelsen.", 1, "https://youtu.be/TqcEwTM-Fe0", "Skulder");
            ExerciseRepository.Add("Skulderblads-klem", "Gør elastikken kortere til cirka skulderbredde og hold armene strakt frem foran kroppen. Træk nu armene ud til siden og bagud til elastikken rammer brystkassen. Fornem, at du klemmer skulderbladene sammen på ryggen. Før armene kontrolleret tilbage igen. Hold dine albuer let bøjede under hele bevægelsen.", 1, "https://youtu.be/TqcEwTM-Fe0", "Balder");
        }

        /*        private Exercise _selectedExercise;

            public Exercise SelectedExercise
            {
                get { return _selectedExercise; }
                set
                {
                    _selectedExercise = value;
                    OnPropertyChanged("SelectedExercise");
                }
            }*/

    }
}
