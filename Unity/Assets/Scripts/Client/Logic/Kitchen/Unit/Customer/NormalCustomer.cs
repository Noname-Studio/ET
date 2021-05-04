using System.Collections.Specialized;
using Client.UI.ViewModel;
using FairyGUI;
using GamingUI;
using Kitchen;
using RestaurantPreview.Config;
using UnityEngine;

/// <summary>
/// 普通的顾客没有任何特殊能力
/// TODO 这个类只是临时写的.未来要全部大改
/// </summary>
public class NormalCustomer: ACustomer
{
    //把Component缓存下来.避免每次都要去拿//
    public PatienceComponent PatienceCom { get; private set; }

    private CustomerMoveComponent MoveCom;
    /////////////////////////////////////

    private UI_PatienceProgress PatienceProgress;
    private UI_Order mOrder;

    public NormalCustomer(UnityObject display, KitchenNormalSpot spot, LevelProperty.CustomerOrder property): base(display, spot, property)
    {
        display.Active = true;
        Components.Set(MoveCom = new CustomerMoveComponent(4, Display));
        KitchenRoot.Inst.Units.Register(this);
        OnEnter();
    }

    /// <summary>
    /// 入场
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        Display.GetComponent<Animator>().Play("walk");
        MoveCom.To = Spot.Position;
        Display.EulerAngles = new Vector3(0, 0, 0);
        MoveCom.ReachedCallback = () =>
        {
            State = CustomerState.Wait;
            Wait();
            MoveCom.ReachedCallback = null;
        };
    }

    private void Wait()
    {
        var decay = KitchenRoot.Inst.LevelProperty.WaitingDecay;
        Components.Set(PatienceCom = new PatienceComponent(1));
        mOrder = new UI_Order((View_Order) ((KitchenNormalSpot) Spot).OrderUI.ui);
        mOrder.Visible = true;
        mOrder.RefreshUI(Order);
        Order.CollectionChanged += OrderOnCollectionChanged;
        var spot = (KitchenNormalSpot) Spot;
        var screenPos = KitchenRoot.Inst.MainCamera.WorldToScreenPoint(spot.OrderUI.GetUIWorldPosition());
        screenPos.y = Screen.height - screenPos.y;
        Vector2 pt = GRoot.inst.GlobalToLocal(screenPos);
        PatienceProgress = UIKit.Inst.Create<UI_PatienceProgress>();
        PatienceProgress.View.position = pt + new Vector2(20, -50);
    }

    private void OrderOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        mOrder.RefreshUI(Order);
    }

    public override void OnExit()
    {
        base.OnExit();
        State = CustomerState.Exit;
        if (mOrder != null)
            mOrder.Visible = false;
        PatienceProgress?.CloseMySelf();
        MoveCom.To = Spot.Position + new Vector3(8, 0, 0);
        Animator.SetInteger("state", 5);
        Display.EulerAngles = new Vector3(0, 180, 0);
        Order.CollectionChanged -= OrderOnCollectionChanged;
        MoveCom.ReachedCallback = () =>
        {
            MoveCom.ReachedCallback = null;
            Dispose();
        };
    }

    public override void Update()
    {
        MoveCom.OnUpdate();
        if (PatienceProgress != null && PatienceCom != null && State != CustomerState.Exit)
        {
            PatienceCom.OnUpdate();
            PatienceProgress.Value = PatienceCom.Value;

            var value = PatienceProgress.Value;
            if (value > 60)
            {
                Animator.SetInteger("state", 1);
            }
            else if (value > 30)
            {
                Animator.SetInteger("state", 2);
            }
            else if (value > 0)
            {
                Animator.SetInteger("state", 3);
            }
            else
            {
                if (State != CustomerState.Exit)
                {
                    KitchenRoot.Inst.Record.LostCustomerCount++;
                    OnExit();
                }
            }
        }

        if (Order.Count == 0 && State != CustomerState.Exit)
        {
            State = CustomerState.Exit;
            OnExit();
        }
    }
}