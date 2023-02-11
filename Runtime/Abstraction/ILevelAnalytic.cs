namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface ILevelAnalytic
    {
        void StartLevel(string levelId, int levelIndex, int? score = default);
        void LevelCompleted(string levelId, int levelIndex, int? score = default);
        void LevelFailed(string levelId, int levelIndex, int? score = default);
    }
}
