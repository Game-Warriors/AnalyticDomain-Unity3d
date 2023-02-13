using System.Collections.Generic;

namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface IAnalytic
    {
        IEnumerable<IAnalyticHandler> AnalyticHandlers { get; }
        IEnumerable<ICustomAnalytic> CustomAnalytics { get; }
        IEnumerable<IEngagementAnalytic> EngagementAnalytics { get; }
        IEnumerable<IShopAnalytic> ShopAnalytics { get; }
        IEnumerable<ITutorialAnalytic> TutorialAnalytics { get; }
        IEnumerable<ILevelAnalytic> LevelAnalytics { get; }
        IEnumerable<IResourceAnalytic> ResourceAnalytics { get; }
        IEnumerable<IQuestAnalytic> QuestAnalytics { get; }
        IEnumerable<IAdAnalytic> AdAnalytics { get; }
    }
}

