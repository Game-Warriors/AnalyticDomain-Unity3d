namespace GameWrriors.AnalyticDomain.Abstraction
{
    public interface IAnalyticConfig
    {
        public IAnalyticHandler [] AnalyticHandlers { get; }
    }
}