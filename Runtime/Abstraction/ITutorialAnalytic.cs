namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface ITutorialAnalytic
    {
        void StartTutorial(string tutorialKey, string LevelId, int levelIndex);
        void CompleteTutorial(string tutorialKey, string LevelId, int levelIndex);
    }
}