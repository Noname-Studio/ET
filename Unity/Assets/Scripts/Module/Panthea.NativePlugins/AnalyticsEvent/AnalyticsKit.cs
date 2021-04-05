using System;
using System.Collections.Generic;
using System.IO;
using Manager;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Analytics;

namespace Panthea.NativePlugins.Analytics
{
    public class AnalyticsKit: Singleton<AnalyticsKit>
    {
        private class CacheAnalyticsData
        {
            public long TimeStamp { get; set; }
            public string EventName { get; set; }
            public IDictionary<string, object> EventData { get; set; }
        }

        private readonly List<CacheAnalyticsData> CacheList = new List<CacheAnalyticsData>();
        private readonly IDictionary<string, object> TempDict = new Dictionary<string, object>();

        private AnalyticsKit()
        {
        }

        public override void OnInit()
        {
            base.OnInit();
            UnityEngine.Analytics.Analytics.enabled = true;
            UnityEngine.Analytics.Analytics.ResumeInitialization();
            UnityEngine.Analytics.Analytics.deviceStatsEnabled = true;
            MessageKit.Inst.Add(EventKey.OnApplicationPause, WriteMessage);
        }

        private void WriteMessage()
        {
            var obj = JsonConvert.SerializeObject(CacheList);
            File.WriteAllText(Application.persistentDataPath + "/Analytics.json", obj);
        }

        private void HandleError(string eventName, IDictionary<string, object> eventData)
        {
            var data = new CacheAnalyticsData { TimeStamp = DateTime.UtcNow.Ticks, EventData = eventData, EventName = eventName };
            CacheList.Add(data);
        }

        private bool CheckCondition()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                return false;
            }

            return true;
        }

        public AnalyticsResult Custom(string eventName, IDictionary<string, object> eventData = null)
        {
            if (!CheckCondition())
            {
                HandleError(eventName, eventData);
            }

            AnalyticsResult result = AnalyticsEvent.Custom(eventName, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError(eventName, eventData);
            }

            return result;
        }

        public AnalyticsResult AchievementStep(int stepIndex, string achievementId, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("step_index", stepIndex);
            TempDict.Add("achievement_id", achievementId);
            if (!CheckCondition())
            {
                HandleError("achievement_step", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.AchievementStep(stepIndex, achievementId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("achievement_step", TempDict);
            }

            return result;
        }

        public AnalyticsResult AchievementUnlocked(string achievementId, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("achievement_id", achievementId);
            if (!CheckCondition())
            {
                HandleError("achievement_unlocked", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.AchievementUnlocked(achievementId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("achievement_unlocked", TempDict);
            }

            return result;
        }

        public AnalyticsResult AdComplete(bool rewarded, AdvertisingNetwork network, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("rewarded", rewarded);
            TempDict.Add("network", network);
            TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
            {
                HandleError("ad_complete", TempDict);
            }

            AnalyticsResult result = Custom("ad_complete", TempDict);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("ad_complete", TempDict);
            }

            return result;
        }

        public AnalyticsResult AdComplete(bool rewarded, string network = null, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("rewarded", rewarded);
            TempDict.Add("network", network);
            TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
            {
                HandleError("ad_complete", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.AdComplete(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("ad_complete", TempDict);
            }

            return result;
        }

        public AnalyticsResult AdOffer(bool rewarded, AdvertisingNetwork network, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("rewarded", rewarded);
            TempDict.Add("network", network);
            TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
            {
                HandleError("ad_offer", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.AdOffer(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("ad_offer", TempDict);
            }

            return result;
        }

        public AnalyticsResult AdOffer(bool rewarded, string network = null, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("rewarded", rewarded);
            TempDict.Add("network", network);
            TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
            {
                HandleError("ad_offer", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.AdOffer(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("ad_offer", TempDict);
            }

            return result;
        }

        public AnalyticsResult AdSkip(bool rewarded, AdvertisingNetwork network, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("rewarded", rewarded);
            TempDict.Add("network", network);
            TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
            {
                HandleError("ad_skip", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.AdSkip(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("ad_skip", TempDict);
            }

            return result;
        }

        public AnalyticsResult AdSkip(bool rewarded, string network = null, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("rewarded", rewarded);
            TempDict.Add("network", network);
            TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
            {
                HandleError("ad_skip", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.AdSkip(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("ad_skip", TempDict);
            }

            return result;
        }

        public AnalyticsResult AdStart(bool rewarded, AdvertisingNetwork network, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("rewarded", rewarded);
            TempDict.Add("network", network);
            TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
            {
                HandleError("ad_start", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.AdStart(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("ad_start", TempDict);
            }

            return result;
        }

        public AnalyticsResult AdStart(bool rewarded, string network = null, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("rewarded", rewarded);
            TempDict.Add("network", network);
            TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
            {
                HandleError("ad_start", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.AdStart(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("ad_start", TempDict);
            }

            return result;
        }

        public AnalyticsResult ChatMessageSent(IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            if (!CheckCondition())
            {
                HandleError("chat_message_sent", eventData);
            }

            AnalyticsResult result = AnalyticsEvent.ChatMessageSent(eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("chat_message_sent", eventData);
            }

            return result;
        }

        public AnalyticsResult CustomEvent(IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            if (!CheckCondition())
            {
                HandleError("", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.CustomEvent(eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("", TempDict);
            }

            return result;
        }

        public AnalyticsResult CutsceneSkip(string name, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            if (!CheckCondition())
            {
                HandleError("cutscene_start", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.CutsceneSkip(name, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("cutscene_start", TempDict);
            }

            return result;
        }

        public AnalyticsResult CutsceneStart(string name, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            if (!CheckCondition())
            {
                HandleError("cutscene_start", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.CutsceneStart(name, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("cutscene_start", TempDict);
            }

            return result;
        }

        public AnalyticsResult FirstInteraction(string actionId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("action_id", actionId);
            if (!CheckCondition())
            {
                HandleError("first_interaction", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.FirstInteraction(actionId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("first_interaction", TempDict);
            }

            return result;
        }

        public AnalyticsResult GameOver(int index, string name = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("index", index);
            TempDict.Add("name", name);
            if (!CheckCondition())
            {
                HandleError("game_over", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.GameOver(index, name, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("game_over", TempDict);
            }

            return result;
        }

        public AnalyticsResult GameOver(string name = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            if (!CheckCondition())
            {
                HandleError("game_over", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.GameOver(name, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("game_over", TempDict);
            }

            return result;
        }

        public AnalyticsResult GameStart(IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            if (!CheckCondition())
            {
                HandleError("game_start", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.GameStart(eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("game_start", TempDict);
            }

            return result;
        }

        public AnalyticsResult IAPTransaction(string transactionContext, float price, string itemId, string itemType = null,
        string level = null, string transactionId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("transaction_context", transactionContext);
            TempDict.Add("price", price);
            TempDict.Add("item_id", itemId);
            TempDict.Add("item_type", itemType);
            TempDict.Add("level", level);
            TempDict.Add("transaction_id", transactionId);
            if (!CheckCondition())
            {
                HandleError("iap_transaction", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.IAPTransaction(transactionContext, price, itemId, itemType, level, transactionId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("iap_transaction", TempDict);
            }

            return result;
        }

        public AnalyticsResult ItemAcquired(AcquisitionType currencyType, string transactionContext, float amount, string itemId,
        float balance, string itemType = null, string level = null, string transactionId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("transaction_context", transactionContext);
            TempDict.Add("currency_type", currencyType);
            TempDict.Add("item_id", itemId);
            TempDict.Add("item_type", itemType);
            TempDict.Add("level", level);
            TempDict.Add("balance", balance);
            TempDict.Add("amount", amount);
            TempDict.Add("transaction_id", transactionId);
            if (!CheckCondition())
            {
                HandleError("item_acquired", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.ItemAcquired(currencyType, transactionContext, amount, itemId, balance, itemType, level,
                transactionId,
                eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("item_acquired", TempDict);
            }

            return result;
        }

        public AnalyticsResult ItemAcquired(AcquisitionType currencyType, string transactionContext, float amount, string itemId,
        string itemType = null, string level = null, string transactionId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("transaction_context", transactionContext);
            TempDict.Add("currency_type", currencyType);
            TempDict.Add("item_id", itemId);
            TempDict.Add("item_type", itemType);
            TempDict.Add("level", level);
            TempDict.Add("amount", amount);
            TempDict.Add("transaction_id", transactionId);
            TempDict.Add("item_acquired", TempDict);
            if (!CheckCondition())
            {
                HandleError("item_acquired", TempDict);
            }

            AnalyticsResult result =
                    AnalyticsEvent.ItemAcquired(currencyType, transactionContext, amount, itemId, itemType, level, transactionId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("item_acquired", TempDict);
            }

            return result;
        }

        public AnalyticsResult ItemSpent(AcquisitionType currencyType, string transactionContext, float amount, string itemId, float balance,
        string itemType = null, string level = null, string transactionId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("transaction_context", transactionContext);
            TempDict.Add("currency_type", currencyType);
            TempDict.Add("item_id", itemId);
            TempDict.Add("item_type", itemType);
            TempDict.Add("level", level);
            TempDict.Add("amount", amount);
            TempDict.Add("transaction_id", transactionId);
            TempDict.Add("item_acquired", TempDict);
            if (!CheckCondition())
            {
                HandleError("item_spent", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.ItemSpent(currencyType, transactionContext, amount, itemId, balance, itemType, level,
                transactionId,
                eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("item_spent", TempDict);
            }

            return result;
        }

        public AnalyticsResult ItemSpent(AcquisitionType currencyType, string transactionContext, float amount, string itemId,
        string itemType = null, string level = null, string transactionId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("transaction_context", transactionContext);
            TempDict.Add("currency_type", currencyType);
            TempDict.Add("item_id", itemId);
            TempDict.Add("item_type", itemType);
            TempDict.Add("level", level);
            TempDict.Add("amount", amount);
            TempDict.Add("transaction_id", transactionId);
            TempDict.Add("item_acquired", TempDict);
            if (!CheckCondition())
            {
                HandleError("item_spent", TempDict);
            }

            AnalyticsResult result =
                    AnalyticsEvent.ItemSpent(currencyType, transactionContext, amount, itemId, itemType, level, transactionId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("item_spent", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelComplete(string name, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            if (!CheckCondition())
            {
                HandleError("level_complete", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelComplete(name, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_complete", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelComplete(int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_complete", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelComplete(index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_complete", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelComplete(string name, int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_complete", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelComplete(name, index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_complete", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelFail(string name, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            if (!CheckCondition())
            {
                HandleError("level_fail", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelFail(name, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_fail", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelFail(int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_fail", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelFail(index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_fail", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelFail(string name, int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_fail", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelFail(name, index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_fail", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelQuit(string name, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            if (!CheckCondition())
            {
                HandleError("level_quit", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelQuit(name, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_quit", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelQuit(int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_quit", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelQuit(index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_quit", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelQuit(string name, int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_quit", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelQuit(name, index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_quit", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelSkip(string name, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            if (!CheckCondition())
            {
                HandleError("level_skip", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelSkip(name, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_skip", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelSkip(int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_skip", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelSkip(index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_skip", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelSkip(string name, int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_skip", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelSkip(name, index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_skip", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelStart(string name, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            if (!CheckCondition())
            {
                HandleError("level_start", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelStart(name, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_start", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelStart(int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_start", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelStart(index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_start", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelStart(string name, int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_start", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelStart(name, index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_start", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelUp(string name, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            if (!CheckCondition())
            {
                HandleError("level_up", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelUp(name, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_up", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelUp(int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_up", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelUp(index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_up", TempDict);
            }

            return result;
        }

        public AnalyticsResult LevelUp(string name, int index, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("name", name);
            TempDict.Add("index", index);
            if (!CheckCondition())
            {
                HandleError("level_up", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.LevelUp(name, index, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("level_up", TempDict);
            }

            return result;
        }

        public AnalyticsResult PostAdAction(bool rewarded, AdvertisingNetwork network, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("rewarded", rewarded);
            TempDict.Add("network", network);
            TempDict.Add("placementId", placementId);
            if (!CheckCondition())
            {
                HandleError("post_ad_action", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.PostAdAction(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("post_ad_action", TempDict);
            }

            return result;
        }

        public AnalyticsResult PostAdAction(bool rewarded, string network = null, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("rewarded", rewarded);
            TempDict.Add("network", network);
            TempDict.Add("placementId", placementId);
            if (!CheckCondition())
            {
                HandleError("post_ad_action", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.PostAdAction(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("post_ad_action", TempDict);
            }

            return result;
        }

        public AnalyticsResult PushNotificationClick(string message_id, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("message_id", message_id);
            if (!CheckCondition())
            {
                HandleError("push_notification_click", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.PushNotificationClick(message_id, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("push_notification_click", TempDict);
            }

            return result;
        }

        public AnalyticsResult PushNotificationEnable(IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            if (!CheckCondition())
            {
                HandleError("push_notification_enable", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.PushNotificationEnable(eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("push_notification_enable", TempDict);
            }

            return result;
        }

        public AnalyticsResult ScreenVisit(ScreenName screenName, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("screen_name", screenName);
            if (!CheckCondition())
            {
                HandleError("screen_visit", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.ScreenVisit(screenName, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("screen_visit", TempDict);
            }

            return result;
        }

        public AnalyticsResult ScreenVisit(string screenName, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("screen_name", screenName);
            if (!CheckCondition())
            {
                HandleError("screen_visit", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.ScreenVisit(screenName, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("screen_visit", TempDict);
            }

            return result;
        }

        public AnalyticsResult SocialShare(ShareType shareType, SocialNetwork socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("share_type", shareType);
            TempDict.Add("social_network", socialNetwork);
            TempDict.Add("sender_id", senderId);
            TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
            {
                HandleError("social_share", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.SocialShare(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("social_share", TempDict);
            }

            return result;
        }

        public AnalyticsResult SocialShare(ShareType shareType, string socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("share_type", shareType);
            TempDict.Add("social_network", socialNetwork);
            TempDict.Add("sender_id", senderId);
            TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
            {
                HandleError("social_share", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.SocialShare(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("social_share", TempDict);
            }

            return result;
        }

        public AnalyticsResult SocialShare(string shareType, SocialNetwork socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("share_type", shareType);
            TempDict.Add("social_network", socialNetwork);
            TempDict.Add("sender_id", senderId);
            TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
            {
                HandleError("social_share", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.SocialShare(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("social_share", TempDict);
            }

            return result;
        }

        public AnalyticsResult SocialShare(string shareType, string socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("share_type", shareType);
            TempDict.Add("social_network", socialNetwork);
            TempDict.Add("sender_id", senderId);
            TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
            {
                HandleError("social_share", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.SocialShare(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("social_share", TempDict);
            }

            return result;
        }

        public AnalyticsResult SocialShareAccept(ShareType shareType, SocialNetwork socialNetwork, string senderId = null,
        string recipientId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("share_type", shareType);
            TempDict.Add("social_network", socialNetwork);
            TempDict.Add("sender_id", senderId);
            TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
            {
                HandleError("social_share_accept", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.SocialShareAccept(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("social_share_accept", TempDict);
            }

            return result;
        }

        public AnalyticsResult SocialShareAccept(ShareType shareType, string socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("share_type", shareType);
            TempDict.Add("social_network", socialNetwork);
            TempDict.Add("sender_id", senderId);
            TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
            {
                HandleError("social_share_accept", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.SocialShareAccept(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("social_share_accept", TempDict);
            }

            return result;
        }

        public AnalyticsResult SocialShareAccept(string shareType, SocialNetwork socialNetwork, string senderId = null,
        string recipientId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("share_type", shareType);
            TempDict.Add("social_network", socialNetwork);
            TempDict.Add("sender_id", senderId);
            TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
            {
                HandleError("social_share_accept", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.SocialShareAccept(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("social_share_accept", TempDict);
            }

            return result;
        }

        public AnalyticsResult SocialShareAccept(string shareType, string socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("share_type", shareType);
            TempDict.Add("social_network", socialNetwork);
            TempDict.Add("sender_id", senderId);
            TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
            {
                HandleError("social_share_accept", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.SocialShareAccept(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("social_share_accept", TempDict);
            }

            return result;
        }

        public AnalyticsResult StoreItemClick(StoreType storeType, string itemId, string itemName = null,
        IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("store_type", storeType);
            TempDict.Add("item_id", itemId);
            TempDict.Add("item_name", itemName);
            if (!CheckCondition())
            {
                HandleError("store_item_click", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.StoreItemClick(storeType, itemId, itemName, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("store_item_click", TempDict);
            }

            return result;
        }

        public AnalyticsResult StoreOpened(StoreType storeType, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("store_type", storeType);
            if (!CheckCondition())
            {
                HandleError("store_opened", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.StoreOpened(storeType, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("store_opened", TempDict);
            }

            return result;
        }

        public AnalyticsResult TutorialComplete(string tutorialId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("tutorial_id", tutorialId);
            if (!CheckCondition())
            {
                HandleError("tutorial_complete", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.TutorialComplete(tutorialId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("tutorial_complete", TempDict);
            }

            return result;
        }

        public AnalyticsResult TutorialSkip(string tutorialId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("tutorial_id", tutorialId);
            if (!CheckCondition())
            {
                HandleError("tutorial_skip", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.TutorialSkip(tutorialId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("tutorial_id", TempDict);
            }

            return result;
        }

        public AnalyticsResult TutorialStart(string tutorialId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("tutorial_id", tutorialId);
            if (!CheckCondition())
            {
                HandleError("tutorial_start", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.TutorialStart(tutorialId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("tutorial_start", TempDict);
            }

            return result;
        }

        public AnalyticsResult TutorialStep(int stepIndex, string tutorialId = null, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("step_index", stepIndex);
            if (!CheckCondition())
            {
                HandleError("tutorial_step", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.TutorialStep(stepIndex, tutorialId, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("tutorial_step", TempDict);
            }

            return result;
        }

        public AnalyticsResult UserSignup(AuthorizationNetwork authorizationNetwork, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("authorization_network", authorizationNetwork);
            if (!CheckCondition())
            {
                HandleError("user_signup", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.UserSignup(authorizationNetwork, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("user_signup", TempDict);
            }

            return result;
        }

        public AnalyticsResult UserSignup(string authorizationNetwork, IDictionary<string, object> eventData = null)
        {
            TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    TempDict.Add(node.Key, node.Value);
                }
            }

            TempDict.Add("authorization_network", authorizationNetwork);
            if (!CheckCondition())
            {
                HandleError("user_signup", TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.UserSignup(authorizationNetwork, eventData);
            if (result != AnalyticsResult.Ok)
            {
                HandleError("user_signup", TempDict);
            }

            return result;
        }
    }
}