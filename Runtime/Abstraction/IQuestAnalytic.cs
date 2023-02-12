namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface IQuestAnalytic
    {
        void QuestStart(string name, string type, string levelId, int levelIndex);
        void QuestDone(string name, string type, string LevelId, int levelIndex, IReward reward = default);
    }
}