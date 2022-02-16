using GameWrriors.AnalyticDomain.Abstraction;

namespace Managements.Handlers.Analytics
{
#if FIREBASE
    using Firebase.Analytics;
    using System.Threading.Tasks;

    public class FirebaseAnalyticHandler : IAnalyticHandler, ILevelAnalytic, IShopAnalytic, IResourceAnalytic, ICustomAnalytic
    {
        private readonly string Start_Analytic_Event;

        public EAnalyticType AnalyticType => EAnalyticType.Firebase;

        public FirebaseAnalyticHandler(string startAnalyticEvent)
        {
            Start_Analytic_Event = startAnalyticEvent;
        }

        Task IAnalyticHandler.Loading()
        {
#if !DEVELOPMENT
            return Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                    // Create and hold a reference to your FirebaseApp,
                    // where app is a Firebase.FirebaseApp property of your application class.
                    //   app = Firebase.FirebaseApp.DefaultInstance;
                    //Debug.Log("Firebase Initialized");

                    // Set a flag here to indicate whether Firebase is ready to use by your app.
                    if (!string.IsNullOrEmpty(Start_Analytic_Event))
                        FirebaseAnalytics.LogEvent(Start_Analytic_Event);
                }
                else
                {
                    UnityEngine.Debug.LogError(string.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                    // Firebase Unity SDK is not safe to use here.
                }
            });
#else
            return Task.CompletedTask;
#endif
        }

        void ICustomAnalytic.CustomEvent(string eventName)
        {
            FirebaseAnalytics.LogEvent(eventName);
        }

        void ICustomAnalytic.CustomEvent(string eventName, string param1Name, object param1)
        {
            if (param1 is float)
            {
                FirebaseAnalytics.LogEvent(eventName, new Parameter(param1Name, (float)param1));
            }
            else if (param1 is double)
            {
                FirebaseAnalytics.LogEvent(eventName, new Parameter(param1Name, (double)param1));
            }
            else if (param1 is int)
            {
                FirebaseAnalytics.LogEvent(eventName, new Parameter(param1Name, (int)param1));
            }
            else if (param1 is long)
            {
                FirebaseAnalytics.LogEvent(eventName, new Parameter(param1Name, (long)param1));
            }
            else
                FirebaseAnalytics.LogEvent(eventName, new Parameter(param1Name, param1.ToString()));
        }

        void ICustomAnalytic.CustomEvent(string eventName, string param1Name, object param1, string param2Name, object param2)
        {
            FirebaseAnalytics.LogEvent(eventName, CreateParameter(param1Name, param1), CreateParameter(param2Name, param2));
        }

        void IAnalyticHandler.SetABTestTag(string abTestTag)
        {
        }

        void IShopAnalytic.ShopOpen(string location)
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventScreenView, new Parameter(FirebaseAnalytics.ParameterScreenName, "Shop"), new Parameter(FirebaseAnalytics.ParameterShipping, location));
        }

        void IShopAnalytic.ShopPackClick(string itemName, string location)
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAddToCart, new Parameter(FirebaseAnalytics.ParameterItemName, itemName), new Parameter(FirebaseAnalytics.ParameterShipping, location));
        }

        void IShopAnalytic.PurchaseShopPack(string itemName, string purchaseId, string currencyId, float price, string location, string transactionId)
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventPurchase, new Parameter(FirebaseAnalytics.ParameterItemName, itemName), new Parameter(FirebaseAnalytics.ParameterItemId, purchaseId), new Parameter(FirebaseAnalytics.ParameterCurrency, currencyId), new Parameter(FirebaseAnalytics.ParameterValue, price), new Parameter(FirebaseAnalytics.ParameterShipping, location));
        }

        void IResourceAnalytic.EarnCurrency(string currencyType, int count, string earnType, string gainType)
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventEarnVirtualCurrency, new Parameter(FirebaseAnalytics.ParameterVirtualCurrencyName, currencyType), new Parameter(FirebaseAnalytics.ParameterValue, count), new Parameter(FirebaseAnalytics.ParameterMethod, earnType), new Parameter("GainType", gainType));
        }

        void IResourceAnalytic.SpendCurrency(string currencyType, int count, string action, string type)
        {
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventSpendVirtualCurrency, new Parameter(FirebaseAnalytics.ParameterVirtualCurrencyName, currencyType), new Parameter(FirebaseAnalytics.ParameterValue, count), new Parameter(FirebaseAnalytics.ParameterMethod, action), new Parameter("Type", type));
        }

        void IShopAnalytic.PurchaseShopPack(string packId)
        {
            FirebaseAnalytics.LogEvent("Purchase", new Parameter(FirebaseAnalytics.ParameterItemId, packId));
        }

        void ILevelAnalytic.StartLevel(string levelId, int levelIndex)
        {
            FirebaseAnalytics.LogEvent("level_start", new Parameter("level_name", levelId), new Parameter("level_number", levelIndex));
        }

        void ILevelAnalytic.LevelCompleted(string levelId, int levelIndex)
        {
            FirebaseAnalytics.LogEvent("level_finish", new Parameter("level_name", levelId), new Parameter("level_number", levelIndex));
        }

        private Parameter CreateParameter(string paramName, object param)
        {
            if (param is float)
            {
                return new Parameter(paramName, (float)param);
            }
            else if (param is double)
            {
                return new Parameter(paramName, (double)param);
            }
            else if (param is int)
            {
                return new Parameter(paramName, (int)param);
            }
            else if (param is long)
            {
                return new Parameter(paramName, (long)param);
            }
            else
                return new Parameter(paramName, param.ToString());
        }
    }
#endif
}