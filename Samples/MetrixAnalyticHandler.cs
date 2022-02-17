using GameWarriors.AnalyticDomain.Abstraction;

namespace Managements.Handlers.Analytics
{
#if METRIX
    using MetrixSDK;
    public class MetrixAnalyticHandler : IAnalyticHandler
    {
        public MetrixAnalyticHandler(string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                Metrix.Initialize(apiKey);
            }
        }

        void IAnalyticHandler.SetABTestTag(string abTestTag)
        {

        }
    }
#endif
}
