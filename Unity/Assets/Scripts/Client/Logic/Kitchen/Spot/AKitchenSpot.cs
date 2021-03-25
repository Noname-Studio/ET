using Kitchen;
using UnityEngine;

/// <summary>
/// 餐位接口类
/// </summary>
public abstract class AKitchenSpot
{
    public Vector3 Position
    {
        get
        {
            return this.Display.Position;
        }
    }

    /// <summary>
    /// 当前餐位状态
    /// </summary>
    public KitchenSpotState State { get; protected set; } = KitchenSpotState.Free;
    /// <summary>
    /// 当前餐位被哪个顾客占据
    /// </summary>
    public ACustomer Customer { get; private set; }
    
    public UnityObject Display { get; }
    public AKitchenSpot(UnityObject display)
    {
        Display = display;
    }

    /// <summary>
    /// 设置当前位置得状态
    /// </summary>
    /// <param name="state"></param>
    public void SetState(KitchenSpotState state)
    {
        State = state;
    }

    /// <summary>
    /// 设置当前位置使用中得顾客
    /// </summary>
    /// <param name="customer"></param>
    public void SetCustomer(ACustomer customer)
    {
        Customer = customer;
    }
}
