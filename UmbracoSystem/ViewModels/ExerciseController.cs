using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UmbracoSystem.Models;

namespace UmbracoSystem.ViewModels
{
    public class ExerciseController
    {
        public ObservableCollection<Tag> ExerciseTagList()
        {
            ObservableCollection<Tag> tags = new ObservableCollection<Tag>();

            List<Tag> tagList = TagRepository.GetTags();

            foreach (Tag item in tagList)
            {
                tags.Add(item);
            }

            return tags;
        }

        public List<Exercise> ChooseMuscleGroup(string tag)
        {
            List<Exercise> exercises = ExerciseRepository.GetListByTag(tag);

            return exercises;
        }

        public Exercise ChooseExercise(int id)
        {
            return ExerciseRepository.GetById(id);
        }
    }
}
