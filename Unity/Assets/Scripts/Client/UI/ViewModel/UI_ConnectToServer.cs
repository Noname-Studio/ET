using Common;
using FairyGUI;
using UnityEngine;

namespace Client.UI.ViewModel
{
    public class UI_ConnectToServer : UIBase<View_loading_effect>
    {
        [RuntimeInitializeOnLoadMethod]
        static void Initialize()
        {
            MessageKit.Inst.Add(EventKey.StartConnectToServer,Event_StartConnectToServer);
            MessageKit.Inst.Add(EventKey.ConnectionFailure,Event_FailedConnectToServer);
            MessageKit.Inst.Add(EventKey.ConnectionSucceeded,Event_ConnectionSucceeded);
        }

        private static void Event_ConnectionSucceeded()
        {
            var connectToServer = UIKit.Inst.Find<UI_ConnectToServer>();
            connectToServer.SetState(true);
        }

        private static void Event_FailedConnectToServer()
        {
            var connectToServer = UIKit.Inst.Find<UI_ConnectToServer>();
            connectToServer.SetState(false);
        }

        private static void Event_StartConnectToServer()
        {
            UIKit.Inst.Create<UI_ConnectToServer>();
        }

        private int State { get; set; }
        private float ShowTime { get; set; }
        
        protected override void OnInit(IUIParams p)
        {
            base.OnInit(p);
            View.position = new Vector3(GRoot.inst.width / 2, GRoot.inst.height * 0.1f);
        }

        protected override void OnEnable(IUIParams p, bool refresh)
        {
            base.OnEnable(p, refresh);
            State = 0;
            ShowTime = 0;
            View.State.selectedPage = "None";
        }

        public void SetState(bool connected)
        {
            State = connected? 1 : -1;
            View.State.selectedPage = connected? "Succeeded" : "Failed";
            View.t0.Stop();
        }

        public override void Update()
        {
            if (State != 0)
            {
                ShowTime += Time.unscaledDeltaTime;
            }

            if (ShowTime >= 3)
            {
                CloseMySelf();
            }
        }
    }
}