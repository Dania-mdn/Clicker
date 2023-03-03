using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public static event Action SetBuy;
    public static event Action<int> SetNewAvalable;
    public static event Action<int> SetNewAchive;

    public static void DoBuy()
    {
        SetBuy?.Invoke();
    }
    public static void DoNewAvalable(UpgradeName numberAvalable)
    {
        SetNewAvalable?.Invoke((int)numberAvalable);
    }
    public static void DoNewAchive(AchiveName numberAchive)
    {
        SetNewAchive?.Invoke((int)numberAchive);
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
    //корабль
    //дельфин
    //х2 пасивный
    //х2 за тап
    //подарок за рекламу
    //х10
    //подарок
    //enum Achiwment
    //{
    //    Ship,
    //    Dolfi,
    //    AdsPassiwX2,
    //    AdsClickX2,
    //    AdsGift,
    //    AdsAllX10,
    //    Gift
    //}
}
