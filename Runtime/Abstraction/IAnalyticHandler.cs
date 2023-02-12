using System.Threading.Tasks;

namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface IAnalyticHandler
    {
        string AnalyticType { get; }

        void SetABTestTag(string abTestTag);
        Task Loading();
    }
}