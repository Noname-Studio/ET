using Client.UI.ViewModel;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using FairyGUI;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Client.Logic.Helpler;

namespace Client.Effect
{
    public class ResourcesBarValueChanged: IEffect
    {
        public enum ResourceType
        {
            Coin,Gem,Energry
        }
        private float Value { get; }
        private ResourceType Type { get; }
        
        public ResourcesBarValueChanged(float value, ResourceType type)
        {
            Value = value;
            Type = type;
        }
        
        public void Dispose()
        {
        }

        public void Do()
        {
            var bar = UIKit.Inst.Find<UI_ResourcesBar>();
            if (bar == null)
            {
                return;
            }
            GTextField com = null;
            int toValue = 0;
            if (Type == ResourceType.Coin)
            {
                com = bar.View.Coin;
                toValue = ResourcesHelper.GetCoin();
            }
            else if (Type == ResourceType.Energry)
            {
                com = bar.View.Energy;
                toValue = EnergyManager.Inst.CurEnergy;
            }
            else if (Type == ResourceType.Gem)
            {
                com = bar.View.Gem;
                toValue = ResourcesHelper.GetGem();
            }
            else
            {
                return;
            }
            
            GRichTextField txt = new GRichTextField();
            txt.textFormat.CopyFrom(com.textFormat);
            txt.stroke = 1;
            txt.strokeColor = Color.white;
            txt.SetPivot(com.pivotX, com.pivotY, com.pivotAsAnchor);
            com.parent.AddChild(txt);
            if (Value < 0)
            {
                txt.text = Value.ToString();
                txt.position = com.position + new Vector3(0, -5);
                txt.color = Color.red;
                txt.TweenFade(0f, 1.3f).SetIgnoreEngineTimeScale(true);
                txt.TweenMoveY(txt.position.y - 30, 1.3f).SetIgnoreEngineTimeScale(true).OnComplete(() => { txt.Dispose(); });
            }
            else
            {
                txt.textFormat.color = new Color(0.98f, 0.85f, 0.22f, 1f);
                txt.text = "+" + Value;
                txt.position = com.position + new Vector3(0, 5);
                txt.TweenFade(0f, 1.3f).SetIgnoreEngineTimeScale(true);
                txt.TweenMoveY(txt.position.y + 30, 1.3f).SetIgnoreEngineTimeScale(true).OnComplete(() => { txt.Dispose(); });
            }

            DOTween.Kill(com, false);
            int.TryParse(com.text, out var fromValue);
            DOTween.To(() => fromValue, t1 =>
            {
                fromValue = t1;
                com.text = t1.ToString();
            }, toValue, 1.3f).SetTarget(com).SetUpdate(true);
        }

        public bool IsPlaying { get; }
    }
}