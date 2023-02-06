using System;

namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface ICustomAnalytic
    {
        void CustomEvent(string eventName);
        void CustomEvent<T1>(string eventName, string param1Name, T1 param1) where T1 : IConvertible;
        void CustomEvent<T1, T2>(string eventName, string param1Name, T1 param1, string param2Name, T2 param2) where T1 : IConvertible where T2 : IConvertible;
        void CustomEvent<T1, T2, T3>(string eventName, string param1Name, T1 param1, string param2Name, T2 param2, string param3Name, T3 param3) where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible;
        void CustomEvent<T1, T2, T3, T4>(string eventName, string param1Name, T1 param1, string param2Name, T2 param2, string param3Name, T3 param3, string param4Name, T4 param4) where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible;
        void CustomEvent(string eventName, params (string paramName, IConvertible param)[] items);
    }
}
