using System.Collections.Generic;
using System.Threading.Tasks;
using GameWrriors.AnalyticDomain.Abstraction;

namespace Managements.Handlers.Analytics
{
#if APPS_FLYER
    using AppsFlyerSDK;

    public class AppsFlyerAnalyticHandler : IAnalyticHandler, ICustomAnalytic, IShopAnalytic
    {
        public EAnalyticType AnalyticType => EAnalyticType.AppsFlyer;

        public AppsFlyerAnalyticHandler(string devKey, string appleAppId)
        {
            if (!string.IsNullOrEmpty(devKey))
            {
                AppsFlyer.initSDK(devKey, appleAppId);
                AppsFlyer.startSDK();
            }
        }

        public void SetABTestTag(string abTestTag)
        {
        }

        public Task Loading()
        {
            return Task.CompletedTask;
        }

        public void CustomEvent(string eventName)
        {
            Dictionary<string, string> eventValues = new Dictionary<string, string>();
            AppsFlyer.sendEvent(eventName, eventValues);
        }

        public void CustomEvent(string eventName, string param1Name, object param1)
        {
            Dictionary<string, string> eventValues = new Dictionary<string, string>();
            eventValues.Add(param1Name, param1.ToString());
            AppsFlyer.sendEvent(eventName, eventValues);
        }

        public void CustomEvent(string eventName, string param1Name, object param1, string param2Name, object param2)
        {
            Dictionary<string, string> eventValues = new Dictionary<string, string>();
            eventValues.Add(param1Name, param1.ToString());
            eventValues.Add(param2Name, param2.ToString());
            AppsFlyer.sendEvent(eventName, eventValues);
        }

        public void PurchaseShopPack(string packId)
        {
        }

        public void ShopPackClick(string itemName, string location)
        {
        }

        public void ShopOpen(string location)
        {
        }

        public void PurchaseShopPack(string itemName, string purchaseId, string currencyId, float price, string location, string transactionId)
        {
            Dictionary<string, string> eventValues = new Dictionary<string, string>();
            eventValues.Add(AFInAppEvents.CURRENCY, currencyId);
            eventValues.Add(AFInAppEvents.REVENUE, price.ToString());
            eventValues.Add(AFInAppEvents.QUANTITY, "1");
            eventValues.Add("SKU", purchaseId);
            eventValues.Add("TRANSACTION_ID", transactionId);
            AppsFlyer.sendEvent("af_purchase", eventValues);
        }
    }
#endif
}