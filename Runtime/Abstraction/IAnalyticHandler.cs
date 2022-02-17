using System.Threading.Tasks;

namespace GameWarriors.AnalyticDomain.Abstraction
{
    public enum EAnalyticType
    {
        None,
        AppsFlyer,
        GameAnalytic,
        Firebase,
        AppMetrica
    }

    public interface IAnalyticHandler
    {
        EAnalyticType AnalyticType { get; }

        void SetABTestTag(string abTestTag);
        Task Loading();
    }
}