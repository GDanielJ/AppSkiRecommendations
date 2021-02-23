using Infrastructure.Services;
using NUnit.Framework;

namespace Infrastructure.Tests
{
    public class Tests
    {
        private SkierRecommendationService _skierService;

        [SetUp]
        public void Setup()
        {
            _skierService = new SkierRecommendationService();
        }

        [Test]
        [TestCase(50, 180, "classic")]
        [TestCase(50, 180, "freestyle")]
        public void GetSkierWithRecommendations_SkierWithValidInputs_ReturnsValidLengthHeightDisciplineTrue(int age, int height, string discipline)
        {
            var result = _skierService.GetSkierWithRecommendations(age, height, discipline);

            Assert.That(result.ValidLengthHeightDiscipline, Is.True);
        }

        [Test]
        [TestCase(-1, 180, "classic")]
        [TestCase(131, 180, "freestyle")]
        public void GetSkierWithRecommendations_SkierWithInvalidAge_ReturnsValidLengthHeightDisciplineFalse(int age, int height, string discipline)
        {
            var result = _skierService.GetSkierWithRecommendations(age, height, discipline);

            Assert.That(result.ValidLengthHeightDiscipline, Is.False);
        }

        [Test]
        [TestCase(50, 50, "classic")]
        [TestCase(50, 281, "freestyle")]
        public void GetSkierWithRecommendations_SkierWithInvalidHeight_ReturnsValidLengthHeightDisciplineFalse(int age, int height, string discipline)
        {
            var result = _skierService.GetSkierWithRecommendations(age, height, discipline);

            Assert.That(result.ValidLengthHeightDiscipline, Is.False);
        }

        [Test]
        [TestCase(50, 180, "slalom")]
        public void GetSkierWithRecommendations_SkierWithInvalidDiscipline_ReturnsValidLengthHeightDisciplineFalse(int age, int height, string discipline)
        {
            var result = _skierService.GetSkierWithRecommendations(age, height, discipline);

            Assert.That(result.ValidLengthHeightDiscipline, Is.False);
        }

        [Test]
        [TestCase(4, 90, "classic")]
        public void GetSkierWithRecommendations_ClassicSkier0to4_ReturnsCorrectRecommendations(int age, int height, string discipline)
        {
            var result = _skierService.GetSkierWithRecommendations(age, height, discipline);

            Assert.That(result.SkiMaxLengthRec, Is.EqualTo(90));
            Assert.That(result.SkiMinLengthRec, Is.EqualTo(90));
            Assert.That(result.VariableLength, Is.False);
        }

        [Test]
        [TestCase(8, 130, "classic")]
        public void GetSkierWithRecommendations_ClassicSkier5to8_ReturnsCorrectRecommendations(int age, int height, string discipline)
        {
            var result = _skierService.GetSkierWithRecommendations(age, height, discipline);

            Assert.That(result.SkiMaxLengthRec, Is.EqualTo(150));
            Assert.That(result.SkiMinLengthRec, Is.EqualTo(140));
            Assert.That(result.VariableLength, Is.True);
        }

        [Test]
        [TestCase(20, 180, "classic")]
        public void GetSkierWithRecommendations_ClassicSkierAdult_ReturnsCorrectRecommendations(int age, int height, string discipline)
        {
            var result = _skierService.GetSkierWithRecommendations(age, height, discipline);

            Assert.That(result.SkiMaxLengthRec, Is.EqualTo(200));
            Assert.That(result.SkiMinLengthRec, Is.EqualTo(200));
            Assert.That(result.VariableLength, Is.False);
        }

        [Test]
        [TestCase(20, 200, "classic")]
        public void GetSkierWithRecommendations_TallClassicSkierAdult_Returns207CmRecommendations(int age, int height, string discipline)
        {
            var result = _skierService.GetSkierWithRecommendations(age, height, discipline);

            Assert.That(result.SkiMaxLengthRec, Is.EqualTo(207));
            Assert.That(result.SkiMinLengthRec, Is.EqualTo(207));
        }

        [Test]
        [TestCase(20, 180, "freestyle")]
        public void GetSkierWithRecommendations_FreestyleSkierAdult_ReturnsCorrectRecommendations(int age, int height, string discipline)
        {
            var result = _skierService.GetSkierWithRecommendations(age, height, discipline);

            Assert.That(result.SkiMaxLengthRec, Is.EqualTo(195));
            Assert.That(result.SkiMinLengthRec, Is.EqualTo(190));
            Assert.That(result.VariableLength, Is.True);
        }

        [Test]
        [TestCase(20, 180, "freestyle")]
        public void GetSkierWithRecommendations_Skier_ReturnsCorrectFreestyleCompRecommendation(int age, int height, string discipline)
        {
            var result = _skierService.GetSkierWithRecommendations(age, height, discipline);

            Assert.That(result.FreestyleCompetitionMinLength, Is.EqualTo(170));
        }
    }
}