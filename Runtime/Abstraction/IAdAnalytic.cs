namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface IAdAnalytic
    {
        void LoadAdSuccess(string adType);
        void LoadAdFailed(string adType, int errorCode, string errorMessage);
        void ShowAdSuccess(string adType, string placement, string adSource, string responseId);
        void ShowAdFailed(string adType, string placement, int errorCode, string errorMessage);
        void AdRevenue(string adType, string adSource, string currency, double value, string precision);
    }
}