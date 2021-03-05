using System.Collections.Specialized;
using Client.UI.ViewModel;
using FairyGUI;
using Kitchen;
using UnityEngine;

/// <summary>
/// 普通的顾客没有任何特殊能力
/// TODO 这个类只是临时写的.未来要全部大改
/// </summary>
public class NormalCustomer: ACustomer
{
    //把Component缓存下来.避免每次都要去拿//
    public PatienceComponent PatienceCom;
    private CustomerMoveComponent MoveCom;
    /////////////////////////////////////
    
    
    private UI_PatienceProgress PatienceProgress;
    private UI_Order mOrder;
    public NormalCustomer(UnityObject display, AKitchenSpot spot,CustomerOrder property) : base(display, spot,property)
    {
        Components.Set(MoveCom = new CustomerMoveComponent(4,Display));
        UnitManager.Inst.Register(this);
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
        Components.Set(PatienceCom = new PatienceComponent(100, KitchenRoot.Inst.LevelProperty.WaitingDecay.Rate));
        //创建订单
        mOrder = UIKit.Inst.Create<UI_Order>();
        mOrder.RefreshUI(Order);
        Order.CollectionChanged += OrderOnCollectionChanged;
        var spot = (KitchenNormalSpot) Spot;
        var screenPos = KitchenRoot.Inst.MainCamera.WorldToScreenPoint(spot.OrderPosition);
        screenPos.y =  Screen.height - screenPos.y;
        Vector2 pt = GRoot.inst.GlobalToLocal(screenPos);
        mOrder.View.position = pt;

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
        mOrder.CloseMySelf();
        PatienceProgress.CloseMySelf();
        MoveCom.To = Spot.Position + new Vector3(8, 0, 0);
        Display.GetComponent<Animator>().SetInteger(Animator.StringToHash("state"), 5);
        Display.EulerAngles = new Vector3(0, 180, 0);
        Order.CollectionChanged -= OrderOnCollectionChanged;
        MoveCom.ReachedCallback = () =>
        {
            MoveCom.ReachedCallback = null;
            Destroy();
        };
    }
    
    protected override void Update()
    {
        MoveCom.OnUpdate();
        if (PatienceProgress != null && PatienceCom != null && State != CustomerState.Exit)
        {
            PatienceCom.OnUpdate();
            PatienceProgress.Value = PatienceCom.Value;

            var value = PatienceProgress.Value;
            if(value > 60)
                Display.GetComponent<Animator>().SetInteger(Animator.StringToHash("state"), 1);
            else if(value > 30)
                Display.GetComponent<Animator>().SetInteger(Animator.StringToHash("state"), 2);
            else if (value > 0)
                Display.GetComponent<Animator>().SetInteger(Animator.StringToHash("state"), 3);
            else
            {
                if (State != CustomerState.Exit)
                {
                    State = CustomerState.Exit;
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
