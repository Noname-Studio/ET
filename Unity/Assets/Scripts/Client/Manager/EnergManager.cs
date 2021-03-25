using System;
using Client.UI.ViewModel;
using Manager;
using UnityEngine;

public class EnergyManager : Singleton<EnergyManager>
{
	private Data_GameRecord mRecord;
	private Data_GameRecord Record
	{
		get
		{
			if (mRecord == null)
				mRecord = DBManager.Inst.Query<Data_GameRecord>();
			return mRecord;
		}
	}
	/// <summary>
	/// 每过Interval秒恢复一点体力
	/// </summary>
	private const int Interval = 60;
	/// <summary>
	/// 自然计时器
	/// </summary>
	public EnergyTimer NormalTimer { get; private set; }
	/// <summary>
	/// 无限体力计时器
	/// </summary>
	public InfineEnergyTimer InfineTimer; 
	/// <summary>
	/// 额外体力
	/// </summary>
	public int ExtensionEnergy
	{
		//get { return MaxEnergy / 2; }//功能取消
		get { return 0; }
	}
	/// <summary>
	/// 是否达到了自然上限体力
	/// </summary>
	public bool IsNormalMax
	{
		get { return CurEnergy >= MaxEnergy; }
	}
	/// <summary>
	/// 是否达到了游戏最大上限体力
	/// </summary>
	public bool IsLimit
	{
		get { return CurEnergy == MaxEnergy + ExtensionEnergy; }
	}
	/// <summary>
	/// 是否无限能量
	/// </summary>
	public bool IsInfine
	{
		get
		{
			return Record.InfineEnergy > 0;
		}
	}
	/// <summary>
	/// 无限体力当前剩余秒数
	/// </summary>
	public TimeSpan InfineTimeSpan
	{
		get { return TimeSpan.FromSeconds(Record.InfineEnergy) - TimeSpan.FromSeconds(TimeUtils.GetUtcTimeStamp()); }
	}
	/// <summary>
	/// 当前能量
	/// </summary>
	public int CurEnergy
	{
		get
		{
			return Record.Energy;
		}
		private set
		{
			if (Record.Energy != value)
			{
				Record.Energy = value;
				DBManager.Inst.Update(Record);
				MessageKit.Inst.Send(EventKey.CurEnergyChange);
			}
		}
	}
	/// <summary>
	/// 最大能量
	/// </summary>
	public int MaxEnergy
	{
		get
		{
			return Record.MaxEnergy;
		}
		
		set
		{
			if (Record.MaxEnergy != value)
			{
				Record.MaxEnergy = value;
				MessageKit.Inst.Send(EventKey.MaxEnergyChange);
			}
		}
	}
	
	public void Init()
	{
		base.OnInit();
		//初始化能量计时器
		NormalTimer = new EnergyTimer(nameof(NormalTimer),Interval);
		InfineTimer = new InfineEnergyTimer(nameof(InfineTimer),1);
		InfineTimer.SetTarget(Record.InfineEnergy);
		CalcOutlineRecover();
		SwitchTimer();
	}

	public override void OnInit()
	{
		base.OnInit();
		MessageKit.Inst.Add(EventKey.SyncServer,RefreshRecord);
		RegisterEvent();
	}

	public override void OnRelease()
	{
		base.OnRelease();
		MessageKit.Inst.Remove(EventKey.SyncServer,RefreshRecord);
		CancelEvent();
	}

	private void RefreshRecord()
	{
		mRecord = DBManager.Inst.Query<Data_GameRecord>();
		CurEnergy = Record.Energy;
		InfineTimer.SetTarget(Record.InfineEnergy);
		DBManager.Inst.UpdateLocal(this.mRecord);
		SwitchTimer();
	}
	
	public void Reset()
	{
		if(NormalTimer != null)
			NormalTimer.Reset();
		CalcOutlineRecover();
	}
	
	/// <summary>
	/// 监听体力变化事件
	/// </summary>
	private void RegisterEvent()
	{
		MessageKit.Inst.Add(EventKey.CurEnergyChange,SwitchTimer);
		MessageKit.Inst.Add(EventKey.MaxEnergyChange,SwitchTimer);
		MessageKit.Inst.Add(EventKey.InfineEnergyChange,SwitchTimer);
	}

	/// <summary>
	/// 取消监听注册事件
	/// </summary>
	private void CancelEvent()
	{
		MessageKit.Inst.Remove(EventKey.CurEnergyChange,SwitchTimer);
		MessageKit.Inst.Remove(EventKey.MaxEnergyChange,SwitchTimer);
		MessageKit.Inst.Remove(EventKey.InfineEnergyChange,SwitchTimer);
	}
	
	/// <summary>
	/// 计算离线恢复.然后保存到用户的数据库中
	/// </summary>
	private void CalcOutlineRecover()
	{
		var utc = TimeUtils.GetUtcTimeStamp();
		//玩家第一次进入游戏时间戳还没有被初始化或已经被计算过了.
		if (Record.CosumeEnergy != -1)
		{
			var seconds = utc - Record.CosumeEnergy;
			var pass = (float) seconds / Interval;
			//取了最小值以后当前的体力还是超过了最大体力值.说明玩家在下线以前可能购买了一些增加体力的商品.体力本身就是溢出的状态.我们不做任何处理
			if(!IsNormalMax)
				Recover((int)pass, false);
			if (CurEnergy < MaxEnergy)
			{
				var @decimal = pass - (float) Math.Truncate(pass);
				NormalTimer.CountingTime = Interval * @decimal;
			}
		}
		//计算结束后体力居然还是小于最大体力得.我们重置一下倒计时
		if (CurEnergy < MaxEnergy)
			Record.CosumeEnergy = utc;
		DBManager.Inst.Update(this.mRecord);
	}
	
	/// <summary>
	/// 消耗体力
	/// </summary>
	public bool Cosume(int value)
	{
		if (CurEnergy < value)
			return false;
		if (IsInfine)
			return true;
		CurEnergy -= value;
		Record.CosumeEnergy =  TimeUtils.GetUtcTimeStamp();
		return true;
	}

	public int GetEnergyFillUpTime()
	{
		var less = MaxEnergy - CurEnergy;
		if (less <= 0)
			return 0;
		return less * 60;
	}

	/// <summary>
	/// 恢复体力
	/// </summary>
	public int Recover(int value,bool ingoreMax)
	{
		int sub = CurEnergy;
		if (ingoreMax)
			value = Mathf.Min(CurEnergy + value, MaxEnergy + ExtensionEnergy);
		else
			value = Mathf.Min(CurEnergy + value, MaxEnergy);
		if (value < 0)
			value = 0;
		CurEnergy = value;
		Record.CosumeEnergy = TimeUtils.GetUtcTimeStamp();

		return CurEnergy - sub;
	}

	/// <summary>
	/// 恢复体力至体力上限
	/// 如果当前体力超过上限则不会产生任何效果
	/// </summary>
	private void RecoverToMax()
	{
		if (CurEnergy > MaxEnergy)
			return;
		Recover(MaxEnergy, false);
	}

	/// <summary>
	/// 给无限体力续秒
	/// </summary>
	/// <param name="second"></param>
	public void AddInfineTime(int second)
	{
		var infineTime = Record.InfineEnergy;
		var utcTime = TimeUtils.GetUtcTimeStamp();
		if (infineTime > utcTime)
		{
			infineTime += second;
		}
		else
		{
			infineTime = (int)utcTime + second;
		}

		Record.InfineEnergy = infineTime;
		Log.Print("=========================AddInfineTime:"+infineTime);
		InfineTimer.SetTarget(Record.InfineEnergy);
		InfineTimer.Resume();
		MessageKit.Inst.Send(EventKey.InfineEnergyChange);
	}

	/// <summary>
	/// 解除无限体力状态
	/// </summary>
	public void ClearInfine()
	{
		Log.Print("=========================ClearInfine:"+Record.InfineEnergy);
		Record.InfineEnergy = 0;
		InfineTimer.SetTarget(Record.InfineEnergy);
		InfineTimer.Pause();
		RecoverToMax();
		MessageKit.Inst.Send(EventKey.InfineEnergyChange);
	}

	/// <summary>
	/// 切换计时器类型
	/// 内部使用.当无限体力计时器结束的时候自动切换为体力计时器
	/// 如果体力已经满了.则自动切换为无计时器状态
	/// </summary>
	private void SwitchTimer()
	{
		if (IsInfine)
		{
			if(!InfineTimer.IsRunning)
				InfineTimer.Play();
			NormalTimer.Stop();
		}
		else if (!IsNormalMax)
		{
			if (!NormalTimer.IsRunning)
			{
				NormalTimer.Play();
			}
			InfineTimer.Stop();
		}
		else
		{
			NormalTimer.Stop();
			InfineTimer.Stop();
		}
	}
	
	public bool CheckEnergy(int energy,bool showTips = true)
	{
		if (IsInfine)
			return true;

		if (Inst.CurEnergy - energy < 0)
		{
			/*if (isGiftUnlimitedEnergy())
			{//每日赠送无限能量半小时
				if (showTips)
				{
					var rewardsList = new List<RewardViewInfo>();
					rewardsList.Add(new RewardViewInfo(GameRes.URL_ICON_UNLIMITED_ENERGY,30,GameRes.ID_UNLIMITED_ENERY,nameof(AWSDATA_GameRecord.infine_energy),true,false,"无限能量半小时"));
					FairyManager.Create<UI_PopRewardMult>(new UI_PopRewardMult.Args(null,rewardsList));			
				}
			}
			else
			{*/
				if (showTips)
				{
					UIKit.Inst.Create<UI_NoEnergyTips>();
				}
			//}
			return false;
		}
		return true;
	}
}
