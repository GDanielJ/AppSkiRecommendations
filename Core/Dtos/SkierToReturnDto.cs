using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos
{
    public class SkierToReturnDto
    {
        public string Discipline { get; set; }
        public int SkiMinLengthRec { get; set; }
        public int SkiMaxLengthRec { get; set; }
        public int FreestyleCompetitionMinLength { get; set; }
        public bool VariableLength { get; set; }
    }
}
