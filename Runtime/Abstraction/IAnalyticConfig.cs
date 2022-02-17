namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface IAnalyticConfig
    {
        public IAnalyticHandler [] AnalyticHandlers { get; }
    }
}