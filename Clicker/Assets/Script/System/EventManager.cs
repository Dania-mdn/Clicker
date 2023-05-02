using System;
public class EventManager
{
    public static event Action SetBuy;
    public static event Action<float> SetNewAvalable;
    public static event Action<int> SetNewAchive;
    public static event Action TakeReward;

    public static void DoBuy()
    {
        SetBuy?.Invoke();
    }
    public static void DoNewAvalable(UpgradeName numberAvalable)
    {
        SetNewAvalable?.Invoke((float)numberAvalable);
    }
    public static void DoNewAchive(AchiveName numberAchive)
    {
        SetNewAchive?.Invoke((int)numberAchive);
    }
    public static void DoTakeReward()
    {
        TakeReward?.Invoke();
    }
    public enum UpgradeName
    {
        Achiw,
        Ship,
        Engine,
        Construction,
        Crew
    }
    public enum AchiveName
    {
        Ship,
        Dolfi,
        AdsPassiwX2,
        AdsClickX2,
        AdsGift,
        AdsAllX10,
        Gift
    }
}
