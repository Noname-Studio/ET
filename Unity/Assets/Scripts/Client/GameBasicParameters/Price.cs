using System;
using System.Text;
using Sirenix.OdinInspector;

[Serializable]
public class Price
{
    [LabelText("金币")]
    public int Coin;

    [LabelText("钻石")]
    public int Gem;

    private StringBuilder SB;

    public string ConvertToString(int width, int height)
    {
        if (SB == null)
        {
            SB = new StringBuilder();
        }
        else
        {
            SB.Clear();
        }

        if (Coin > 0)
        {
            SB.Append(
                $"<img src='ui://Common/coin_icon{PlayerManager.Inst.CurrentLevel.RestaurantId.Index}' width='{width}' height='{height}'/>{Coin}");
        }
        else if (Gem > 0)
        {
            SB.Append($"<img src='ui://Common/钻石' width='{width}' height='{height}'/>{Gem}");
        }

        return SB.ToString();
    }

    public bool IsFree()
    {
        return Coin == 0 && Gem == 0;
    }
}