namespace GameWrriors.AnalyticDomain.Abstraction
{
    public interface ILevelAnalytic
    {
        void StartLevel(string levelId, int levelIndex);
        void LevelCompleted(string levelId, int levelIndex);
    }
}
