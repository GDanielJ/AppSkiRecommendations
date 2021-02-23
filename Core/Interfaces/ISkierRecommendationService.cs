using Core.Entities;

namespace Core.Interfaces
{
    public interface ISkierRecommendationService
    {
        Skier GetSkierWithRecommendations(int age, int height, string discipline);
    }
}
