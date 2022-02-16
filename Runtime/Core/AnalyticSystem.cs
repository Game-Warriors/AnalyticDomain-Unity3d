using GameWrriors.AnalyticDomain.Abstraction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameWrriors.AnalyticDomain.Core
{
    public class AnalyticSystem : IAnalytic
    {
        private IAnalyticHandler[] _analyticHandlers;

        [UnityEngine.Scripting.Preserve]
        public AnalyticSystem(IAnalyticConfig analyticConfig)
        {
            _analyticHandlers = analyticConfig.AnalyticHandlers;
        }


        [UnityEngine.Scripting.Preserve]
        public async Task WaitForLoading()
        {
            foreach (var item in _analyticHandlers)
            {
                await item.Loading();
            }
        }

        public IEnumerable<IAnalyticHandler> AnalyticHandlers
        {
            get
            {
                int length = _analyticHandlers.Length;
                for (int i = 0; i < length; ++i)
                {
                    yield return _analyticHandlers[i];
                }
            }
        }

        public IEnumerable<ICustomAnalytic> CustomAnalytics
        {
            get
            {
                int length = _analyticHandlers.Length;
                for (int i = 0; i < length; ++i)
                {
                    ICustomAnalytic tmp = _analyticHandlers[i] as ICustomAnalytic;
                    if (tmp != null)
                        yield return tmp;
                } 
            }
        }

        public IEnumerable<IEngagementAnalytic> EngagementAnalytics
        {
            get
            {
                int length = _analyticHandlers.Length;
                for (int i = 0; i < length; ++i)
                {
                    IEngagementAnalytic tmp = _analyticHandlers[i] as IEngagementAnalytic;
                    if (tmp != null)
                        yield return _analyticHandlers[i] as IEngagementAnalytic;
                }
            }
        }

        public IEnumerable<IShopAnalytic> ShopAnalytics
        {
            get
            {
                int length = _analyticHandlers.Length;
                for (int i = 0; i < length; ++i)
                {
                    IShopAnalytic tmp = _analyticHandlers[i] as IShopAnalytic;
                    if (tmp != null)
                        yield return _analyticHandlers[i] as IShopAnalytic;
                }
            }
        }

        public IEnumerable<ITutorialAnalytic> TutorialAnalytics
        {
            get
            {
                int length = _analyticHandlers.Length;
                for (int i = 0; i < length; ++i)
                {
                    ITutorialAnalytic tmp = _analyticHandlers[i] as ITutorialAnalytic;
                    if (tmp != null)
                        yield return _analyticHandlers[i] as ITutorialAnalytic;
                }
            }
        }

        public IEnumerable<ILevelAnalytic> LevelAnalytics
        {
            get
            {
                int length = _analyticHandlers.Length;
                for (int i = 0; i < length; ++i)
                {
                    ILevelAnalytic tmp = _analyticHandlers[i] as ILevelAnalytic;
                    if (tmp != null)
                        yield return _analyticHandlers[i] as ILevelAnalytic;
                }
            }
        }

        public IEnumerable<IResourceAnalytic> ResourceAnalytics
        {
            get
            {
                int length = _analyticHandlers.Length;
                for (int i = 0; i < length; ++i)
                {
                    IResourceAnalytic tmp = _analyticHandlers[i] as IResourceAnalytic;
                    if (tmp != null)
                        yield return _analyticHandlers[i] as IResourceAnalytic;
                }
            }
        }
    }
}
