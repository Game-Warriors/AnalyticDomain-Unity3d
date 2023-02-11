namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface IQuestAnalytic
    {
        void QuestStart(string Id, string levelId, int levelIndex);
        void QuestDone(string Id, string LevelId, int levelIndex, IReward reward = default);
    }
}