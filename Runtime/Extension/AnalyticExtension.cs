﻿using GameWarriors.AnalyticDomain.Abstraction;
using System;

namespace GameWarriors.AnalyticDomain.Extension
{
    public static class AnalyticExtension
    {
        public static void StartLevelEvent(this IAnalytic analytics, string levelId, int levelIndex, int? score = default)
        {
            foreach (var item in analytics.LevelAnalytics)
            {
                item.StartLevel(levelId, levelIndex, score);
            }
        }

        public static void CompleteLevelEvent(this IAnalytic analytics, string levelId, int levelIndex, int? score = default)
        {
            foreach (var item in analytics.LevelAnalytics)
            {
                item.LevelCompleted(levelId, levelIndex, score);
            }
        }

        public static void FailLevelEvent(this IAnalytic analytics, string levelId, int levelIndex, int? score = default)
        {
            foreach (var item in analytics.LevelAnalytics)
            {
                item.LevelFailed(levelId, levelIndex, score);
            }
        }

        public static void StartQuestEvent(this IAnalytic analytics, string name, string type, string levelId, int levelIndex)
        {
            foreach (var item in analytics.QuestAnalytics)
            {
                item.QuestStart(name, type, levelId, levelIndex);
            }
        }

        public static void QuestDoneEvent(this IAnalytic analytics, string name, string type, string levelId, int levelIndex, IReward reward = default)
        {
            foreach (var item in analytics.QuestAnalytics)
            {
                item.QuestDone(name, type, levelId, levelIndex, reward);
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

        public static void CustomEvent<T1, T2>(this IAnalytic analytics, string eventName, string param1Name,
            T1 param1, string param2Name, T2 param2) where T1 : IConvertible where T2 : IConvertible
        {
            foreach (var item in analytics.CustomAnalytics)
            {
                item.CustomEvent(eventName, param1Name, param1, param2Name, param2);
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

        public static void CustomEvent<T1, T2, T3, T4>(this IAnalytic customAnalytics, string eventName, string param1Name,
            T1 param1, string param2Name, T2 param2, string param3Name, T3 param3, string param4Name, T4 param4) where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
        {
            foreach (var item in customAnalytics.CustomAnalytics)
            {
                item.CustomEvent(eventName, param1Name, param1, param2Name, param2, param3Name, param3, param4Name, param4);
            }
        }

        public static void CustomEvent(this IAnalytic customAnalytics, string eventName, params (string paramName, IConvertible param)[] items)
        {
            foreach (var item in customAnalytics.CustomAnalytics)
            {
                item.CustomEvent(eventName, items);
            }
        }

        public static void CustomFalseEvent(this IAnalytic analytics, string eventName, string param1Name, object param1)
        {

        }


        public static void CustomEvent<T1>(this IAnalytic analytics, string eventName, string param1Name, T1 param1, params string[] analyticTypes) where T1 : IConvertible
        {
            foreach (var item in analytics.CustomAnalytics)
            {
                string type = ((IAnalyticHandler)item).AnalyticType;
                foreach (string analyticType in analyticTypes)
                {
                    if (analyticType == type)
                        item.CustomEvent(eventName, param1Name, param1);
                }
            }
        }

        public static void CustomEvent<T1>(this IAnalytic analytics, string eventName, string param1Name, T1 param1, string analyticType) where T1 : IConvertible
        {
            foreach (var item in analytics.CustomAnalytics)
            {
                string type = ((IAnalyticHandler)item).AnalyticType;
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

        public static void LoadAdSucessEvent(this IAnalytic analytic, string adType)
        {
            foreach (var item in analytic.AdAnalytics)
            {
                item.LoadAdSuccess(adType);
            }
        }

        public static void LoadAdFailEvent(this IAnalytic analytic, string adType, int errorCode, string errorMessage)
        {
            foreach (var item in analytic.AdAnalytics)
            {
                item.LoadAdFailed(adType, errorCode, errorMessage);
            }
        }

        public static void ShowAdSuccessEvent(this IAnalytic analytic, string adType, string placement, string adSource, string responseId)
        {
            foreach (var item in analytic.AdAnalytics)
            {
                item.ShowAdSuccess(adType, placement, adSource, responseId);
            }
        }

        public static void ShowAdFailEvent(this IAnalytic analytic, string adType, string placement, int errorCode, string errorMessage)
        {
            foreach (var item in analytic.AdAnalytics)
            {
                item.ShowAdFailed(adType, placement, errorCode, errorMessage);
            }
        }

        public static void AdRevenueEvent(this IAnalytic analytic, string adType, string adSource, string currency, double value, string precision)
        {
            foreach (var item in analytic.AdAnalytics)
            {
                item.AdRevenue(adType, adSource, currency, value, precision);
            }
        }

        public static void PurchaseFailedResult(this IAnalytic analytic, string sku, string packName, string isoCurrencyCode, double localizedPrice, string transactionID, string reason)
        {
            foreach (var item in analytic.ShopAnalytics)
            {
                item.PurchaseFailedResult(sku, packName, isoCurrencyCode, localizedPrice, transactionID, reason);
            }
        }

        public static void PurchaseStartFailed(this IAnalytic analytic, string sku, string packName, string reason)
        {
            foreach (var item in analytic.ShopAnalytics)
            {
                item.PurchaseStartFailed(sku, packName, reason);
            }
        }

        public static void PurchaseStartSuccess(this IAnalytic analytic, string sku, string packName, string isoCurrencyCode, double localizedPrice, string transactionID)
        {
            foreach (var item in analytic.ShopAnalytics)
            {
                item.PurchaseStartSuccess(sku, packName, isoCurrencyCode, localizedPrice, transactionID);
            }
        }

        public static void PurchaseSuccessResult(this IAnalytic analytic, string sku, string packName, string isoCurrencyCode, double localizedPrice, string transactionID)
        {
            foreach (var item in analytic.ShopAnalytics)
            {
                item.PurchaseSuccessResult(sku, packName, isoCurrencyCode, localizedPrice, transactionID);
            }
        }

        public static void PurchaseComplete(this IAnalytic analytic, string sku, string packName, string isoCurrencyCode, double localizedPrice, string transactionID)
        {
            foreach (var item in analytic.ShopAnalytics)
            {
                item.PurchaseComplete(sku, packName, isoCurrencyCode, localizedPrice, transactionID);
            }
        }
    }
}

