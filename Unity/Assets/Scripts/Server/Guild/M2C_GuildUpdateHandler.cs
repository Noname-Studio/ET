using System;
using System.Collections;
using System.Collections.Generic;
using Client.Event;
using UnityEngine.AI;

namespace ET
{
    [MessageHandler]
    public class M2C_GuildUpdateHandler : AMHandler<M2C_GuildUpdate>
    {
        protected override async ETVoid Run(Session session, M2C_GuildUpdate message)
        {
            if (GuildManager.Inst.Data == null)
            {
                if (!message.Id.HasValue)
                    return;
                GuildManager.Inst.Data = new M2C_GuildUpdate();
            }
            var data = GuildManager.Inst.Data;
            if (message.IsPublic.HasValue)
                data.IsPublic = message.IsPublic;
            if (message.Desc != null)
                data.Desc = message.Desc;
            if (message.Frame.HasValue)
                data.Frame = message.Frame;
            if (message.Id.HasValue)
                data.Id = message.Id;
            if (message.Inside.HasValue)
                data.Inside = message.Inside;
            if (message.Language.HasValue)
                data.Language = message.Language;
            if (message.Members != null)
                AddChild(message.Members, data.Members, (message, data) => message.Id == data.Id);
            if(message.RemoveMembers != null)
                RemoveChild(message.RemoveMembers, data.Members, (message, data) => message == data.Id);
            if (message.Message != null)
                data.Message = message.Message;
            if (message.Name != null)
                data.Name = message.Name;
            if (message.ApplicationList != null)
                AddChild(message.ApplicationList, data.ApplicationList, (message, data) => message.Id == data.Id);
            if (message.RemoveApplicationList != null)
                RemoveChild(message.RemoveApplicationList, data.ApplicationList,(message, data) => message == data.Id);
            if(message.CreateTime.HasValue)
                data.CreateTime = message.CreateTime;
            if(message.MinLevel.HasValue)
                data.MinLevel = message.MinLevel;
            if(message.OwnerId.HasValue)
                data.OwnerId = message.OwnerId;
            if (message.AskEnergyList != null)
            {
                AddChild(message.AskEnergyList, data.AskEnergyList, (message, data) => message.Id == data.Id);
                MessageKit.Inst.Send(new GuildAskEnergyChanged(message.AskEnergyList));
            }
            if (message.RemoveAskEnergyList != null)
            {
                RemoveChild(message.RemoveAskEnergyList, data.AskEnergyList, (message, data) => message == data.Id);
            }
            if (message.MaxMemberNum.HasValue)
                data.MaxMemberNum = message.MaxMemberNum;
            MessageKit.Inst.Send(EventKey.GuildChanged);
        }

        private static void RemoveChild<T1,T2>(List<T1> message, List<T2> data,Func<T1,T2,bool> compare)
        {
            for (int i = 0; i < message.Count; i++)
            {
                for (int j = data.Count - 1; j >= 0; j--)
                {
                    var node = data[j];
                    if (compare(message[i],node))
                        data.Remove(node);
                }
            }
        }

        private static void AddChild<T>(List<T> message, List<T> data,Func<T,T,bool> compare)
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                var node = data[i];
                for (int j = 0; j < message.Count; j++)
                {
                    if (compare(message[j],node))
                    {
                        data.RemoveAt(i);
                        break;
                    }
                }
            }
            data.AddRange(message);
        }
    }
}