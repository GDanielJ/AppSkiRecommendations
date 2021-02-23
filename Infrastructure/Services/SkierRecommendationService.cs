using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services

{
    public class SkierRecommendationService : ISkierRecommendationService
    {
        public Skier GetSkierWithRecommendations(int age, int height, string discipline)
        {
            var skier = new Skier();

            if (age >= 0 && age < 130 && height > 50 && height < 280 && (discipline == "classic" || discipline == "freestyle"))
            {
                skier.ValidLengthHeightDiscipline = true;

                skier.Discipline = discipline;

                if (age <= 4)
                {
                    skier.SkiMaxLengthRec = height;
                    skier.SkiMinLengthRec = skier.SkiMaxLengthRec;
                }

                if (age > 4 && age < 9)
                {
                    skier.SkiMinLengthRec = height + 10;
                    skier.SkiMaxLengthRec = height + 20;
                }

                if (age >= 9)
                {
                    if (discipline == "classic")
                    {
                        skier.SkiMaxLengthRec = height + 20 > 207 ? 207 : height + 20;
                        skier.SkiMinLengthRec = skier.SkiMaxLengthRec;
                    }
                    if (discipline == "freestyle")
                    {
                        skier.SkiMinLengthRec = height + 10;
                        skier.SkiMaxLengthRec = height + 15;
                    }
                }

                skier.FreestyleCompetitionMinLength = height - 10;

                if (skier.SkiMinLengthRec != skier.SkiMaxLengthRec)
                {
                    skier.VariableLength = true;
                }

                return skier;
            }

            skier.ValidLengthHeightDiscipline = false;
            return skier;
        }
    }
}
