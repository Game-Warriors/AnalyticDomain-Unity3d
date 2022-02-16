namespace GameWrriors.AnalyticDomain.Abstraction
{
    public interface ICustomAnalytic
    {
        void CustomEvent(string eventName);
        void CustomEvent(string eventName, string param1Name, object param1);
        void CustomEvent(string eventName, string param1Name, object param1, string param2Name, object param2);
    }
}
