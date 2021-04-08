using System;
using System.Collections.Generic;
using System.Linq;
using Client.Event;
using Client.Manager;
using DG.Tweening;
using ET;
using FairyGUI;
using Module.Panthea.Utils;
using TheGuild;
using UnityEngine;

namespace Client.UI.ViewModel
{
    public class UI_GuildChat: InternalComponent
    {
        public UI_JoinedGuild Parent { get; }
        public View_LiaoTianZuJian View { get; }

        /// <summary>
        /// 缓存自己发送的内容
        /// 一是为了防止玩家一段时间内发送重复的内容
        /// 二是为了收到协议的时候把自己的内容剔除出去避免在UI重复显示(自己发送的内容会立刻显示在UI上而不需要等待协议返回)
        /// </summary>
        private Dictionary<long, string> CacheMySendConent { get; } = new Dictionary<long, string>();
        private long mLastMessageTimeStamp;
        /// <summary>
        /// 每次消息进入的时候重新写入新的时间戳
        /// 每当时间戳间隔超出5分钟(300秒)则生成一条时间消息插入聊天列表中
        /// </summary>
        private long LastMessageTimeStamp {
            get
            {
                return mLastMessageTimeStamp;
            }
            set
            {
                if (Mathf.Abs(value - mLastMessageTimeStamp) >= 300)
                    AddTimeMsg(value);
                mLastMessageTimeStamp = value;
            } 
        }
        public UI_GuildChat(UI_JoinedGuild parent, View_LiaoTianZuJian view)
        {
            Parent = parent;
            View = view;
            InitUI();
        }

        private void InitUI()
        {
            View.Input.onFocusIn.Set(Input_OnFocusIn);
            View.Input.onFocusOut.Set(Input_OnFocusOut);
            View.Send.onClick.Set(Send_OnClick);
            View.RequestEnergy.onClick.Set(RequestEnergy_OnClick);
            //汇总列表
            Dictionary<long, List<Action>> dict = new Dictionary<long, List<Action>>();
            foreach (var node in GuildManager.Inst.GuildMessage)
            {
                foreach (var info in node.Value)
                {
                    if (!dict.TryGetValue(info.Time, out var value))
                    {
                        value = new List<Action>(3);
                        dict.Add(info.Time, value);
                    }
                    value.Add(() => AddChatMsg(info));
                }
            }
            
            foreach (var node in GuildManager.Inst.Data.AskEnergyList)
            {
                if (!dict.TryGetValue(node.Time, out var value))
                {
                    value = new List<Action>(3);
                    dict.Add(node.Time, value);
                }
                value.Add(() => AddAskEnergyMsg(node));
            }
            
            var sort = dict.OrderBy(t1 => t1.Key);
            foreach (var node in sort)
            {
                foreach (var ac in node.Value)
                {
                    ac();
                }
            }
        }

        private void Input_OnFocusOut()
        {
            GRoot.inst.y = 0;
        }

        private void Input_OnFocusIn()
        {
            var keyboardHeight = NativeUtils.GetKeyboardHeight();
            if (keyboardHeight == 0)
            {
                GRoot.inst.y = 0;
                return;
            }

            var radio = GRoot.inst.height / Screen.height;
            var startY = -(keyboardHeight - (GRoot.inst.height - View.TransformPoint(new Vector2(0, View.Send.y), GRoot.inst).y) / radio);
            if (Stage.inst.y != startY && !DOTween.IsTweening(Stage.inst))
            { 
                DOTween.To(() =>GRoot.inst.position, t1 => GRoot.inst.position = t1, new Vector3(0, startY, 0),
                    0.1f).SetUpdate(true);
            }
        }

        private void Send_OnClick()
        {
            var time = TimeUtils.GetUtcTimeStamp();
            if (CacheMySendConent.ContainsKey(time))
                return;//不能太快发送消息.
            NetworkManager.Inst.Send(new C2G_ChatMessage { Type = 1, SendMessage = View.Input.text });
            var gameRecord = DBManager.Inst.Query<Data_GameRecord>();
            var info = new ChatMessageInfo
            {
                SenderMsg = View.Input.text,
                Time = time,
                SenderHead = gameRecord.Head,
                SenderId = PlayerManager.Id,
                SenderName = gameRecord.Name
            };
            AddChatMsg(info);
            CacheMySendConent.Add(info.Time,info.SenderMsg);
            View.Input.text = "";
        }
        
        private async void RequestEnergy_OnClick()
        {
            View_HaoYouGuKeZhiYuanQiPao obj = GetRequestEnergyMsg(PlayerManager.Id);
            obj.c1.selectedPage = "发送中";
            try
            {
                await NetworkManager.Inst.Call(new C2G_GuildAskEnergyRequest());
            }
            catch(Exception e)
            {
                Log.Error(e);
                View.List.RemoveChildToPool(obj);
            }
        }

        private void AddTimeMsg(long timeStamp)
        {
            var label = (GLabel)View.List.AddItemFromPool("ui://TheGuild/日期气泡");
            var msgTime = DateTimeOffset.FromUnixTimeSeconds(timeStamp).LocalDateTime;
            var now = DateTime.Now;
            label.title = msgTime.ToString((now - msgTime).Days > 0 ? "g" : "hh:mm:ss");
        }

        /// <summary>
        /// 通常我们创建消息控件的时候我们是插入在最后的.通过这个方法我们可以根据时间戳给他找到正确的位置进行插入
        /// </summary>
        /// <param name="com"></param>
        private void FixedChatViewIndex(GComponent com)
        {
            
        }
        
        private void AddChatMsg(ChatMessageInfo message)
        {
            LastMessageTimeStamp = message.Time;
            bool isMe = message.SenderId == PlayerManager.Id;
            var chatView = View.List.AddItemFromPool(isMe ? View_PuTongQiPao_You.URL : View_PuTongQiPao_Zuo.URL).asCom;
            chatView.GetChild("Head").icon = message.SenderHead ?? "ui://Settings/0";
            chatView.GetChild("Desc").text = message.SenderMsg;
            chatView.GetChild("Name").text = message.SenderName;
            if (chatView.GetChild("Desc").width < chatView.GetChild("Name").width)
                chatView.GetChild("Bubble").width = chatView.GetChild("Name").width + 67;
            chatView.data = message.Time;
        }

        private void AddAskEnergyMsg(AskEnergyInfo info)
        {
            LastMessageTimeStamp = info.Time;
            string key = info.Id.ToString();
            var obj = GetRequestEnergyMsg(info.Id);
            if (info.Id == PlayerManager.Id)
                obj.c1.selectedPage = "自己";
            obj.Name.text = obj.Name2.text = info.Name;
            obj.Head.icon = info.Head;
            var timeData = TimerKit.Inst.Get(key);
            if (timeData != null)
            {
                TimerKit.Inst.Stop(key, true);
            }
            TimerKit.Inst.Invoke(key, 1, timer =>
            {
                var sub = Countdown(info.Time);
                if (sub.Days > 0)
                {
                    View.List.RemoveChildToPool(obj);
                    TimerKit.Inst.Stop(timer.Key, true);
                    return;
                }
                obj.Time.text = sub.ToString(@"hh\:mm\:ss");
            });
        }

        private TimeSpan Countdown(long time)
        {
            var msgTime = DateTimeOffset.FromUnixTimeSeconds(time).LocalDateTime;
            var now = DateTime.Now;
            var sub = (now - msgTime);
            return sub;
        }

        private View_HaoYouGuKeZhiYuanQiPao GetRequestEnergyMsg(long id)
        {
            var obj = (View_HaoYouGuKeZhiYuanQiPao) View.List.GetChild(id.ToString());
            if (obj == null)
            {
                obj = (View_HaoYouGuKeZhiYuanQiPao) View.List.AddItemFromPool(View_HaoYouGuKeZhiYuanQiPao.URL);
                obj.name = id.ToString();
            }
            return obj;
        }
        
        public override void OnEnable()
        {
            MessageKit.Inst.Add<GuildMessageChanged>(Event_GuildMessageChanged);
            MessageKit.Inst.Add<GuildAskEnergyChanged>(Event_GuildAskEnergyChanged);
        }
        
        public override void OnDisable()
        {
            MessageKit.Inst.Remove<GuildMessageChanged>(Event_GuildMessageChanged);
            MessageKit.Inst.Remove<GuildAskEnergyChanged>(Event_GuildAskEnergyChanged);
        }
        
        private void Event_GuildAskEnergyChanged(GuildAskEnergyChanged e)
        {
            foreach (var node in e.List)
            {
                AddAskEnergyMsg(node);
            }
        }
        
        private void Event_GuildMessageChanged(GuildMessageChanged evt)
        {
            foreach (var node in evt.Message.Value)
            {
                if (node.SenderId == PlayerManager.Id)
                    continue;
                if(!CacheMySendConent.ContainsKey(node.Time))//检测到没有发送过.玩家可能退出了游戏重新进入游戏了
                    AddChatMsg(node);
            }
        }
    }
}