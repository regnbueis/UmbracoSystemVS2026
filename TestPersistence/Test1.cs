using UmbracoSystem.ViewModels;
using UmbracoSystem.Models;
namespace TestPersistence
{
    [TestClass]
    public sealed class ExerciseControllerTests
    {
        private ExerciseController _controller;

        [TestInitialize]
        public void Setup()
        {
            Persist.exercises = new List<Exercise>();
            Persist.events = new List<Event>();
            Persist.altWorkTypes = new List<AltWorkType>();

            _controller = new ExerciseController();
        }

        [TestMethod]
        public void ChooseExercise_ReturnsExercise_WhenIdExists()
        {
            // Arrange
            var e1 = ExerciseRepository.Add("Title A", "Desc A", 10, "imgA.png", "TagA");
            var e2 = ExerciseRepository.Add("Title B", "Desc B", 5, "imgB.png", "TagB");

            // Act
            var result = _controller.ChooseExercise(e1.ExerciseId);

            // Assert
            Assert.IsNotNull(result, "Expected an exercise for existing id.");
            Assert.AreEqual(e1.ExerciseId, result.ExerciseId);
            Assert.AreEqual("Title A", result.Title);
        }

        [TestMethod]
        public void ChooseExercise_ReturnsNull_WhenIdDoesNotExist()
        {
            // Arrange
            var _ = ExerciseRepository.Add("Title A", "Desc A", 10, "imgA.png", "TagA");

            // Act
            var result = _controller.ChooseExercise(999999);

            // Assert
            Assert.IsNull(result, "Expected null for non-existing id.");
        }
    }
}
