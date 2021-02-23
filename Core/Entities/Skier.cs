
namespace Core.Entities
{
    public class Skier
    {
        public int Age { get; set; }
        public int Height { get; set; }
        public string Discipline { get; set; }
        public int SkiMinLengthRec { get; set; }
        public int SkiMaxLengthRec { get; set; }
        public int FreestyleCompetitionMinLength { get; set; }
        public bool VariableLength { get; set; }
        public bool ValidLengthHeightDiscipline { get; set; }
    }
}
