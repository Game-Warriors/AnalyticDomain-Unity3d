using GameWarriors.AnalyticDomain.Abstraction;
using System;
using System.Collections.Generic;

namespace GameWarriors.AnalyticDomain.Extension
{
    public static class AnalyticExtension
    {
        public static void LevelStartEvent(this IAnalytic analytics, string levelId, int levelIndex)
        {
            foreach (var item in analytics.LevelAnalytics)
            {
                item.StartLevel(levelId, levelIndex);
            }
        }

        public static void LevelEndEvent(this IAnalytic analytics, string levelId, int levelIndex)
        {
            foreach (var item in analytics.LevelAnalytics)
            {
                item.LevelCompleted(levelId, levelIndex);
            }
        }

        public static void CustomEvent(this IAnalytic analytics, string eventName)
        {
            foreach (var item in analytics.CustomAnalytics)
            {
                item.CustomEvent(eventName);
            }
        }

        public static void CustomEvent<T1>(this IAnalytic analytics, string eventName, string param1Name,
            T1 param1) where T1 : IConvertible
        {
            foreach (var item in analytics.CustomAnalytics)
            {
                item.CustomEvent<T1>(eventName, param1Name, param1);
            }
        }

        public static void CustomEvent<T1, T2, T3>(this IAnalytic customAnalytics, string eventName, string param1Name,
            T1 param1, string param2Name, T2 param2, string param3Name, T3 param3) where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
        {
            foreach (var item in customAnalytics.CustomAnalytics)
            {
                item.CustomEvent(eventName, param1Name, param1, param2Name, param2, param3Name, param3);
            }
        }

        public static void CustomFalseEvent(this IAnalytic analytics, string eventName, string param1Name, object param1)
        {

        }

        public static void CustomEvent<T1, T2>(this IAnalytic analytics, string eventName, string param1Name,
            T1 param1, string param2Name, T2 param2) where T1 : IConvertible where T2 : IConvertible
        {
            foreach (var item in analytics.CustomAnalytics)
            {
                item.CustomEvent(eventName, param1Name, param1, param2Name, param2);
            }
        }

        public static void CustomEvent<T1>(this IAnalytic analytics, string eventName, string param1Name, T1 param1, params EAnalyticType[] analyticTypes) where T1 : IConvertible
        {
            foreach (var item in analytics.CustomAnalytics)
            {
                EAnalyticType type = ((IAnalyticHandler)item).AnalyticType;
                foreach (EAnalyticType analyticType in analyticTypes)
                {
                    if (analyticType == type)
                        item.CustomEvent(eventName, param1Name, param1);
                }
            }
        }

        public static void CustomEvent<T1>(this IAnalytic analytics, string eventName, string param1Name, T1 param1, EAnalyticType analyticType) where T1 : IConvertible
        {
            foreach (var item in analytics.CustomAnalytics)
            {
                EAnalyticType type = ((IAnalyticHandler)item).AnalyticType;
                if (analyticType == type)
                    item.CustomEvent(eventName, param1Name, param1);
            }
        }

        public static void EarnCoinByIAP(this IAnalytic analytics, string packId,
            int coinCount)
        {
            foreach (var item in analytics.ResourceAnalytics)
            {
                item.EarnCurrency("coin", coinCount, "iap", packId);
            }
        }

        public static void EarnXp(this IAnalytic analytic, int count, string earnType, string gainType)
        {
            foreach (var item in analytic.ResourceAnalytics)
            {
                item.EarnCurrency("Xp", count, earnType, gainType);
            }
        }

        public static void SpendXp(this IAnalytic analytic, int count, string spendType, string spendMeta)
        {
            foreach (var item in analytic.ResourceAnalytics)
            {
                item.SpendCurrency("Xp", count, spendType, spendMeta);
            }
        }

        public static void EarnGem(this IAnalytic analytic, int count, string earnType, string gainType)
        {
            foreach (var item in analytic.ResourceAnalytics)
            {
                item.EarnCurrency("Gem", count, earnType, gainType);
            }
        }

        public static void SpendGem(this IAnalytic analytic, int count, string spendType, string spendMeta)
        {
            foreach (var item in analytic.ResourceAnalytics)
            {
                item.SpendCurrency("Gem", count, spendType, spendMeta);
            }
        }

        public static void PurchaseShopPack(this IAnalytic analytic, string itemName, string purchaseId, string currencyId, float price, string location, string transactionId)
        {
            foreach (var item in analytic.ShopAnalytics)
            {
                item.PurchaseShopPack(purchaseId);
                item.PurchaseShopPack(itemName, purchaseId, currencyId, price, location, transactionId);
            }
        }

        public static void ShopPackClick(this IAnalytic analytics, string itemName,
            string purchaseId, string location)
        {
            foreach (var item in analytics.ShopAnalytics)
            {
                item.ShopPackClick(itemName, location);
            }
        }

        public static void OpenShop(this IAnalytic analytic, string location)
        {
            foreach (var item in analytic.ShopAnalytics)
            {
                item.ShopOpen(location);
            }
        }

        public static void EarnCurrencyByIAP(this IAnalytic analytics, string currencyType,
            int count, string packId)
        {
            foreach (var item in analytics.ResourceAnalytics)
            {
                item.EarnCurrency(currencyType, count, "iap", packId);
            }
        }


        public static void EarnCurrencyByCurrency(this IAnalytic analytics,
            string currencyType, int count, string spendCurrencyId)
        {
            foreach (var item in analytics.ResourceAnalytics)
            {
                item.EarnCurrency(currencyType, count, currencyType, spendCurrencyId);
            }
        }


        public static void SpendCurrency(this IAnalytic analytics, string currencyType,
            string action, int count, string type)
        {
            foreach (var item in analytics.ResourceAnalytics)
            {
                item.SpendCurrency(currencyType, count, action, type);
            }
        }


        public static void EarnCurrencyByReward(this IAnalytic analytics,
            string currencyType, int count, string type)
        {
            foreach (var item in analytics.ResourceAnalytics)
            {
                item.SpendCurrency(currencyType, count, "reward", type);
            }
        }
    }
}

