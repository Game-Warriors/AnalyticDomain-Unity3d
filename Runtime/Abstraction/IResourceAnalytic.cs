namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface IResourceAnalytic
    {
        void EarnCurrency(string currencyType, int count, string earnType, string gainType);
        void SpendCurrency(string currencyType, int count, string spendType, string spendMeta);
    }
}
