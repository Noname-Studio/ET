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

        private AnalyticsKit(){}
        
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
            this.CacheList.Add(data);
        }

        private bool CheckCondition()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
                return false;
            return true;
        }

        public AnalyticsResult Custom(string eventName, IDictionary<string, object> eventData = null)
        {
            if (!CheckCondition())
                this.HandleError(eventName, eventData);
            AnalyticsResult result = AnalyticsEvent.Custom(eventName, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError(eventName, eventData);
            return result;
        }

        public AnalyticsResult AchievementStep(int stepIndex, string achievementId, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("step_index", stepIndex);
            this.TempDict.Add("achievement_id", achievementId);
            if (!CheckCondition())
            {
                this.HandleError("achievement_step", this.TempDict);
            }

            AnalyticsResult result = AnalyticsEvent.AchievementStep(stepIndex, achievementId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("achievement_step", this.TempDict);
            return result;
        }

        public AnalyticsResult AchievementUnlocked(string achievementId, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("achievement_id", achievementId);
            if (!CheckCondition())
                this.HandleError("achievement_unlocked", this.TempDict);
            AnalyticsResult result = AnalyticsEvent.AchievementUnlocked(achievementId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("achievement_unlocked", this.TempDict);
            return result;
        }

        public AnalyticsResult AdComplete(bool rewarded, AdvertisingNetwork network, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("rewarded", rewarded);
            this.TempDict.Add("network", network);
            this.TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
                this.HandleError("ad_complete", this.TempDict);
            AnalyticsResult result = Custom("ad_complete",this.TempDict);
            if (result != AnalyticsResult.Ok) this.HandleError("ad_complete",this.TempDict);
            return result;
        }

        public AnalyticsResult AdComplete(bool rewarded, string network = null, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("rewarded", rewarded);
            this.TempDict.Add("network", network);
            this.TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
                this.HandleError("ad_complete", this.TempDict);
            AnalyticsResult result = AnalyticsEvent.AdComplete(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("ad_complete", this.TempDict);
            return result;
        }

        public AnalyticsResult AdOffer(bool rewarded, AdvertisingNetwork network, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("rewarded", rewarded);
            this.TempDict.Add("network", network);
            this.TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
                this.HandleError("ad_offer",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.AdOffer(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("ad_offer",this.TempDict);
            return result;
        }

        public AnalyticsResult AdOffer(bool rewarded, string network = null, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }
            this.TempDict.Add("rewarded", rewarded);
            this.TempDict.Add("network", network);
            this.TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
                this.HandleError("ad_offer",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.AdOffer(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("ad_offer",this.TempDict);
            return result;
        }

        public AnalyticsResult AdSkip(bool rewarded, AdvertisingNetwork network, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("rewarded", rewarded);
            this.TempDict.Add("network", network);
            this.TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
                this.HandleError("ad_skip",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.AdSkip(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("ad_skip",this.TempDict);
            return result;
        }

        public AnalyticsResult AdSkip(bool rewarded, string network = null, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("rewarded", rewarded);
            this.TempDict.Add("network", network);
            this.TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
                this.HandleError("ad_skip",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.AdSkip(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("ad_skip",this.TempDict);
            return result;
        }

        public AnalyticsResult AdStart(bool rewarded, AdvertisingNetwork network, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("rewarded", rewarded);
            this.TempDict.Add("network", network);
            this.TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
                this.HandleError("ad_start",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.AdStart(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("ad_start",this.TempDict);
            return result;
        }

        public AnalyticsResult AdStart(bool rewarded, string network = null, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("rewarded", rewarded);
            this.TempDict.Add("network", network);
            this.TempDict.Add("placement_id", placementId);
            if (!CheckCondition())
                this.HandleError("ad_start",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.AdStart(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("ad_start",this.TempDict);
            return result;
        }

        public AnalyticsResult ChatMessageSent(IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }
            if (!CheckCondition())
                this.HandleError("chat_message_sent",eventData);
            AnalyticsResult result = AnalyticsEvent.ChatMessageSent(eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("chat_message_sent",eventData);
            return result;
        }

        public AnalyticsResult CustomEvent(IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            if (!CheckCondition())
                this.HandleError("",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.CustomEvent(eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("",this.TempDict);
            return result;
        }

        public AnalyticsResult CutsceneSkip(string name, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            if (!CheckCondition())
                this.HandleError("cutscene_start",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.CutsceneSkip(name, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("cutscene_start",this.TempDict);
            return result;
        }

        public AnalyticsResult CutsceneStart(string name, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            if (!CheckCondition())
                this.HandleError("cutscene_start",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.CutsceneStart(name, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("cutscene_start",this.TempDict);
            return result;
        }

        public AnalyticsResult FirstInteraction(string actionId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("action_id", actionId);
            if (!CheckCondition())
                this.HandleError("first_interaction",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.FirstInteraction(actionId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("first_interaction",this.TempDict);
            return result;
        }

        public AnalyticsResult GameOver(int index, string name = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }
            this.TempDict.Add("index", index);
            this.TempDict.Add("name", name);
            if (!CheckCondition())
                this.HandleError("game_over",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.GameOver(index, name, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("game_over",this.TempDict);
            return result;
        }

        public AnalyticsResult GameOver(string name = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            if (!CheckCondition())
                this.HandleError("game_over",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.GameOver(name, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("game_over",this.TempDict);
            return result;
        }

        public AnalyticsResult GameStart(IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            if (!CheckCondition())
                this.HandleError("game_start",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.GameStart(eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("game_start", this.TempDict);
            return result;
        }

        public AnalyticsResult IAPTransaction(string transactionContext, float price, string itemId, string itemType = null,
        string level = null, string transactionId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("transaction_context", transactionContext);
            this.TempDict.Add("price", price);
            this.TempDict.Add("item_id", itemId);
            this.TempDict.Add("item_type", itemType);
            this.TempDict.Add("level", level);
            this.TempDict.Add("transaction_id", transactionId);
            if (!CheckCondition())
                this.HandleError("iap_transaction",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.IAPTransaction(transactionContext, price, itemId, itemType, level, transactionId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("iap_transaction",this.TempDict);
            return result;
        }

        public AnalyticsResult ItemAcquired(AcquisitionType currencyType, string transactionContext, float amount, string itemId,
        float balance, string itemType = null, string level = null, string transactionId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("transaction_context", transactionContext);
            this.TempDict.Add("currency_type", currencyType);
            this.TempDict.Add("item_id", itemId);
            this.TempDict.Add("item_type", itemType);
            this.TempDict.Add("level", level);
            this.TempDict.Add("balance", balance);
            this.TempDict.Add("amount", amount);
            this.TempDict.Add("transaction_id", transactionId);
            if (!CheckCondition())
                this.HandleError("item_acquired",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.ItemAcquired(currencyType, transactionContext, amount, itemId, balance, itemType, level,
                transactionId,
                eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("item_acquired",this.TempDict);
            return result;
        }

        public AnalyticsResult ItemAcquired(AcquisitionType currencyType, string transactionContext, float amount, string itemId,
        string itemType = null, string level = null, string transactionId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("transaction_context", transactionContext);
            this.TempDict.Add("currency_type", currencyType);
            this.TempDict.Add("item_id", itemId);
            this.TempDict.Add("item_type", itemType);
            this.TempDict.Add("level", level);
            this.TempDict.Add("amount", amount);
            this.TempDict.Add("transaction_id", transactionId);
            this.TempDict.Add("item_acquired",this.TempDict);
            if (!CheckCondition())
                this.HandleError("item_acquired",this.TempDict);
            AnalyticsResult result =
                    AnalyticsEvent.ItemAcquired(currencyType, transactionContext, amount, itemId, itemType, level, transactionId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("item_acquired",this.TempDict);
            return result;
        }

        public AnalyticsResult ItemSpent(AcquisitionType currencyType, string transactionContext, float amount, string itemId, float balance,
        string itemType = null, string level = null, string transactionId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("transaction_context", transactionContext);
            this.TempDict.Add("currency_type", currencyType);
            this.TempDict.Add("item_id", itemId);
            this.TempDict.Add("item_type", itemType);
            this.TempDict.Add("level", level);
            this.TempDict.Add("amount", amount);
            this.TempDict.Add("transaction_id", transactionId);
            this.TempDict.Add("item_acquired",this.TempDict);
            if (!CheckCondition())
                this.HandleError("item_spent",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.ItemSpent(currencyType, transactionContext, amount, itemId, balance, itemType, level,
                transactionId,
                eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("item_spent",this.TempDict);
            return result;
        }

        public AnalyticsResult ItemSpent(AcquisitionType currencyType, string transactionContext, float amount, string itemId,
        string itemType = null, string level = null, string transactionId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("transaction_context", transactionContext);
            this.TempDict.Add("currency_type", currencyType);
            this.TempDict.Add("item_id", itemId);
            this.TempDict.Add("item_type", itemType);
            this.TempDict.Add("level", level);
            this.TempDict.Add("amount", amount);
            this.TempDict.Add("transaction_id", transactionId);
            this.TempDict.Add("item_acquired",this.TempDict);
            if (!CheckCondition())
                this.HandleError("item_spent",this.TempDict);
            AnalyticsResult result =
                    AnalyticsEvent.ItemSpent(currencyType, transactionContext, amount, itemId, itemType, level, transactionId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("item_spent",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelComplete(string name, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            if (!CheckCondition())
                this.HandleError("level_complete",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelComplete(name, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_complete",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelComplete(int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("index", index);
            if (!CheckCondition())
                this.HandleError("level_complete",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelComplete(index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_complete",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelComplete(string name, int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            this.TempDict.Add("index", index);
            if (!CheckCondition())
                this.HandleError("level_complete",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelComplete(name, index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_complete", this.TempDict);
            return result;
        }

        public AnalyticsResult LevelFail(string name, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            if (!CheckCondition())
                this.HandleError("level_fail",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelFail(name, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_fail", this.TempDict);
            return result;
        }

        public AnalyticsResult LevelFail(int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("index", index);
            if (!CheckCondition())
                this.HandleError("level_fail", this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelFail(index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_fail", this.TempDict);
            return result;
        }

        public AnalyticsResult LevelFail(string name, int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name",name);
            this.TempDict.Add("index",index);
            if (!CheckCondition())
                this.HandleError("level_fail", this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelFail(name, index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_fail", this.TempDict);
            return result;
        }

        public AnalyticsResult LevelQuit(string name, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            if (!CheckCondition())
                this.HandleError("level_quit",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelQuit(name, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_quit",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelQuit(int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("index", index);
            if (!CheckCondition())
                this.HandleError("level_quit",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelQuit(index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_quit",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelQuit(string name, int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            this.TempDict.Add("index", index);
            if (!CheckCondition())
                this.HandleError("level_quit",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelQuit(name, index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_quit",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelSkip(string name, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            if (!CheckCondition())
                this.HandleError("level_skip",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelSkip(name, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_skip",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelSkip(int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("index", index);
            if (!CheckCondition())
                this.HandleError("level_skip",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelSkip(index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_skip",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelSkip(string name, int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            this.TempDict.Add("index", index);
            if (!CheckCondition())
                this.HandleError("level_skip",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelSkip(name, index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_skip",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelStart(string name, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            if (!CheckCondition())
                this.HandleError("level_start",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelStart(name, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_start", this.TempDict);
            return result;
        }

        public AnalyticsResult LevelStart(int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("index", index);
            if (!CheckCondition())
                this.HandleError("level_start",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelStart(index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_start",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelStart(string name, int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            this.TempDict.Add("index", index);
            if (!CheckCondition())
                this.HandleError("level_start",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelStart(name, index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_start",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelUp(string name, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            if (!CheckCondition())
                this.HandleError("level_up",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelUp(name, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_up",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelUp(int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("index", index);
            if (!CheckCondition())
                this.HandleError("level_up",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelUp(index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_up",this.TempDict);
            return result;
        }

        public AnalyticsResult LevelUp(string name, int index, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("name", name);
            this.TempDict.Add("index", index);
            if (!CheckCondition())
                this.HandleError("level_up",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.LevelUp(name, index, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("level_up",this.TempDict);
            return result;
        }

        public AnalyticsResult PostAdAction(bool rewarded, AdvertisingNetwork network, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("rewarded", rewarded);
            this.TempDict.Add("network", network);
            this.TempDict.Add("placementId", placementId);
            if (!CheckCondition())
                this.HandleError("post_ad_action",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.PostAdAction(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("post_ad_action",this.TempDict);
            return result;
        }

        public AnalyticsResult PostAdAction(bool rewarded, string network = null, string placementId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("rewarded", rewarded);
            this.TempDict.Add("network", network);
            this.TempDict.Add("placementId", placementId);
            if (!CheckCondition())
                this.HandleError("post_ad_action",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.PostAdAction(rewarded, network, placementId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("post_ad_action",this.TempDict);
            return result;
        }

        public AnalyticsResult PushNotificationClick(string message_id, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("message_id", message_id);
            if (!CheckCondition())
                this.HandleError("push_notification_click",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.PushNotificationClick(message_id, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("push_notification_click",this.TempDict);
            return result;
        }

        public AnalyticsResult PushNotificationEnable(IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }
            if (!CheckCondition())
                this.HandleError("push_notification_enable",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.PushNotificationEnable(eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("push_notification_enable",this.TempDict);
            return result;
        }

        public AnalyticsResult ScreenVisit(ScreenName screenName, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("screen_name", screenName);
            if (!CheckCondition())
                this.HandleError("screen_visit",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.ScreenVisit(screenName, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("screen_visit",this.TempDict);
            return result;
        }

        public AnalyticsResult ScreenVisit(string screenName, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("screen_name", screenName);
            if (!CheckCondition())
                this.HandleError("screen_visit",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.ScreenVisit(screenName, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("screen_visit",this.TempDict);
            return result;
        }

        public AnalyticsResult SocialShare(ShareType shareType, SocialNetwork socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("share_type", shareType);
            this.TempDict.Add("social_network", socialNetwork);
            this.TempDict.Add("sender_id", senderId);
            this.TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
                this.HandleError("social_share",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.SocialShare(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("social_share",this.TempDict);
            return result;
        }

        public AnalyticsResult SocialShare(ShareType shareType, string socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("share_type", shareType);
            this.TempDict.Add("social_network", socialNetwork);
            this.TempDict.Add("sender_id", senderId);
            this.TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
                this.HandleError("social_share",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.SocialShare(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("social_share",this.TempDict);
            return result;
        }

        public AnalyticsResult SocialShare(string shareType, SocialNetwork socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("share_type", shareType);
            this.TempDict.Add("social_network", socialNetwork);
            this.TempDict.Add("sender_id", senderId);
            this.TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
                this.HandleError("social_share",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.SocialShare(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("social_share", this.TempDict);
            return result;
        }

        public AnalyticsResult SocialShare(string shareType, string socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }
            this.TempDict.Add("share_type", shareType);
            this.TempDict.Add("social_network", socialNetwork);
            this.TempDict.Add("sender_id", senderId);
            this.TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
                this.HandleError("social_share",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.SocialShare(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("social_share",this.TempDict);
            return result;
        }

        public AnalyticsResult SocialShareAccept(ShareType shareType, SocialNetwork socialNetwork, string senderId = null,
        string recipientId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }
            this.TempDict.Add("share_type", shareType);
            this.TempDict.Add("social_network", socialNetwork);
            this.TempDict.Add("sender_id", senderId);
            this.TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
                this.HandleError("social_share_accept",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.SocialShareAccept(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("social_share_accept",this.TempDict);
            return result;
        }

        public AnalyticsResult SocialShareAccept(ShareType shareType, string socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("share_type", shareType);
            this.TempDict.Add("social_network", socialNetwork);
            this.TempDict.Add("sender_id", senderId);
            this.TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
                this.HandleError("social_share_accept",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.SocialShareAccept(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("social_share_accept", this.TempDict);
            return result;
        }

        public AnalyticsResult SocialShareAccept(string shareType, SocialNetwork socialNetwork, string senderId = null,
        string recipientId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("share_type", shareType);
            this.TempDict.Add("social_network", socialNetwork);
            this.TempDict.Add("sender_id", senderId);
            this.TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
                this.HandleError("social_share_accept",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.SocialShareAccept(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("social_share_accept", this.TempDict);
            return result;
        }

        public AnalyticsResult SocialShareAccept(string shareType, string socialNetwork, string senderId = null, string recipientId = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("share_type", shareType);
            this.TempDict.Add("social_network", socialNetwork);
            this.TempDict.Add("sender_id", senderId);
            this.TempDict.Add("recipient_id", recipientId);
            if (!CheckCondition())
                this.HandleError("social_share_accept",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.SocialShareAccept(shareType, socialNetwork, senderId, recipientId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("social_share_accept", this.TempDict);
            return result;
        }

        public AnalyticsResult StoreItemClick(StoreType storeType, string itemId, string itemName = null,
        IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("store_type", storeType);
            this.TempDict.Add("item_id", itemId);
            this.TempDict.Add("item_name", itemName);
            if (!CheckCondition())
                this.HandleError("store_item_click",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.StoreItemClick(storeType, itemId, itemName, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("store_item_click",this.TempDict);
            return result;
        }

        public AnalyticsResult StoreOpened(StoreType storeType, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("store_type", storeType);
            if (!CheckCondition())
                this.HandleError("store_opened",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.StoreOpened(storeType, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("store_opened",this.TempDict);
            return result;
        }

        public AnalyticsResult TutorialComplete(string tutorialId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("tutorial_id", tutorialId);
            if (!CheckCondition())
                this.HandleError("tutorial_complete",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.TutorialComplete(tutorialId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("tutorial_complete",this.TempDict);
            return result;
        }

        public AnalyticsResult TutorialSkip(string tutorialId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("tutorial_id", tutorialId);
            if (!CheckCondition())
                this.HandleError("tutorial_skip",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.TutorialSkip(tutorialId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("tutorial_id",this.TempDict);
            return result;
        }

        public AnalyticsResult TutorialStart(string tutorialId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("tutorial_id", tutorialId);
            if (!CheckCondition())
                this.HandleError("tutorial_start",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.TutorialStart(tutorialId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("tutorial_start", this.TempDict);
            return result;
        }

        public AnalyticsResult TutorialStep(int stepIndex, string tutorialId = null, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("step_index", stepIndex);
            if (!CheckCondition())
                this.HandleError("tutorial_step",this.TempDict);
            AnalyticsResult result = AnalyticsEvent.TutorialStep(stepIndex, tutorialId, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("tutorial_step", this.TempDict);
            return result;
        }

        public AnalyticsResult UserSignup(AuthorizationNetwork authorizationNetwork, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("authorization_network", authorizationNetwork);
            if (!CheckCondition())
                this.HandleError("user_signup", this.TempDict);
            AnalyticsResult result = AnalyticsEvent.UserSignup(authorizationNetwork, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("user_signup", this.TempDict);
            return result;
        }

        public AnalyticsResult UserSignup(string authorizationNetwork, IDictionary<string, object> eventData = null)
        {
            this.TempDict.Clear();
            if (eventData != null)
            {
                foreach (var node in eventData)
                {
                    this.TempDict.Add(node.Key, node.Value);
                }
            }

            this.TempDict.Add("authorization_network", authorizationNetwork);
            if (!CheckCondition())
                this.HandleError("user_signup", this.TempDict);
            AnalyticsResult result = AnalyticsEvent.UserSignup(authorizationNetwork, eventData);
            if (result != AnalyticsResult.Ok) this.HandleError("user_signup", this.TempDict);
            return result;
        }
    }
}