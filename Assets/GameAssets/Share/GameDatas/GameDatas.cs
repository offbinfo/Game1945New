using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameDatas
{

    #region Resource data
    public static float Gold
    {
        get { return SavePrefs.GetFloat(GameKeys.KEY_Gold, 0); }
        set
        {
            SavePrefs.SetFloat(GameKeys.KEY_Gold, value);
            EventDispatcher.PostEvent(EventID.OnGoldChanged, 0);
        }
    }

    public static float Gem
    {
        get { return SavePrefs.GetFloat(GameKeys.KEY_Gem, 0); }
        set
        {
            SavePrefs.SetFloat(GameKeys.KEY_Gem, value);
            EventDispatcher.PostEvent(EventID.OnGemChanged, 0);
        }
    }

    public static float PowerStone
    {
        get { return SavePrefs.GetFloat(GameKeys.KEY_power_stone, 0); }
        set
        {
            SavePrefs.SetFloat(GameKeys.KEY_power_stone, value);
            EventDispatcher.PostEvent(EventID.OnPowerStoneChanged, 0);
        }
    }

    public static float Tourament
    {
        get { return SavePrefs.GetFloat(GameKeys.KEY_tourament, 0); }
        set
        {
            SavePrefs.SetFloat(GameKeys.KEY_tourament, value);
            EventDispatcher.PostEvent(EventID.OnTouramentChanged, 0);
        }
    }

    public static float Badges
    {
        get { return SavePrefs.GetFloat(GameKeys.KEY_Badges, 0); }
        set
        {
            SavePrefs.SetFloat(GameKeys.KEY_Badges, value);
            EventDispatcher.PostEvent(EventID.OnBadgesChanged, 0);
        }
    }

    public static float ArmorSphere
    {
        get { return SavePrefs.GetFloat(GameKeys.KEY_ArmorSphere, 0); }
        set
        {
            SavePrefs.SetFloat(GameKeys.KEY_ArmorSphere, value);
            EventDispatcher.PostEvent(EventID.OnArmorSphereChanged, 0);
        }
    }

    public static float IsLoopSong
    {
        get { return SavePrefs.GetFloat(GameKeys.KEY_IsLoopSong, 1); }
        set
        {
            SavePrefs.SetFloat(GameKeys.KEY_IsLoopSong, value);
            EventDispatcher.PostEvent(EventID.OnLoopSong, 0);
        }
    }

    public static float PowerSphere
    {
        get { return SavePrefs.GetFloat(GameKeys.KEY_PowerSphere, 0); }
        set
        {
            SavePrefs.SetFloat(GameKeys.KEY_PowerSphere, value);
            EventDispatcher.PostEvent(EventID.OnPowerSphereChanged, 0);
        }
    }

    public static float EngineSphere
    {
        get { return SavePrefs.GetFloat(GameKeys.KEY_EngineSphere, 0); }
        set
        {
            SavePrefs.SetFloat(GameKeys.KEY_EngineSphere, value);
            EventDispatcher.PostEvent(EventID.OnEngineSphereChanged, 0);
        }
    }

    public static float CryogenicSphere
    {
        get { return SavePrefs.GetFloat(GameKeys.KEY_CryogenicSphere, 0); }
        set
        {
            SavePrefs.SetFloat(GameKeys.KEY_CryogenicSphere, value);
            EventDispatcher.PostEvent(EventID.OnCryogenicSphereChanged, 0);
        }
    }

    public static void BuyUsingCurrency(CurrencyType currency, float amount, Action<bool> OnBuySuccess)
    {
        float currentAmount = GetCurrency(currency);

        if (currentAmount >= amount)
        {
            SetCurrency(currency, currentAmount - amount);
            OnBuySuccess?.Invoke(true);
        }
        else
        {
            OnBuySuccess?.Invoke(false);
        }
    }

    private static float GetCurrency(CurrencyType currency)
    {
        return currency switch
        {
            CurrencyType.GOLD => Gold,
            CurrencyType.GEM => Gem,
            CurrencyType.POWER_STONE => PowerStone,
            CurrencyType.BADGES => Badges,
            _ => throw new ArgumentException("Invalid currency type"),
        };
    }

    private static void SetCurrency(CurrencyType currency, float value)
    {
        switch (currency)
        {
            case CurrencyType.GOLD:
                Gold = value;
                break;
            case CurrencyType.GEM:
                Gem = value;
                break;
            case CurrencyType.POWER_STONE:
                PowerStone = value;
                break;
            case CurrencyType.BADGES:
                Badges = value;
                break;
            default:
                throw new ArgumentException("Invalid currency type");
        }
    }


    #endregion

    #region X2 time
    public static bool activeX2
    {
        get
        {
            var now = DateTime.Now;
            return (now.Hour >= 12 && now.Hour < 14) || (now.Hour >= 19 && now.Hour < 22);
        }
    }
    #endregion

    #region Upgraders Tower Data
    public static int CountBuyXUpgrader
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_CountBuyXUpgrader, 1);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_CountBuyXUpgrader, value);
            EventDispatcher.PostEvent(EventID.OnChangeCountBuyX, 0);
        }
    }
    #endregion

    #region Cards Tower Data
    public static DateTime LastQuestCheckDate
    {
        get
        {
            string savedDate = PlayerPrefs.GetString(GameKeys.Key_LastQuestCheckDate, "");
            if (string.IsNullOrEmpty(savedDate))
            {
                return DateTime.MinValue;
            }

            if (DateTime.TryParse(savedDate, out DateTime parsedDate))
            {
                return parsedDate.Date;
            }

            return DateTime.MinValue;
        }
        set
        {
            PlayerPrefs.SetString(GameKeys.Key_LastQuestCheckDate, value.ToString("yyyy-MM-dd"));
            PlayerPrefs.Save();
        }
    }

    public static int countSpinCard
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_countSpinCard, 0);
        }
        set
        {
            if (levelCardUnlock >= 7)
            {
                SavePrefs.SetInt(GameKeys.Key_countSpinCard, 30);
                return;
            }
            SavePrefs.SetInt(GameKeys.Key_countSpinCard, value);
            if (value >= 30)
            {
                levelCardUnlock += 1;
                SavePrefs.SetInt(GameKeys.Key_countSpinCard, value - 30);
            }
        }
    }
    public static int levelCardUnlock
    { // level unlock ra các loại card để mở , unlock = số lượt quay
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_levelCardUnlock, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_levelCardUnlock, value);
            EventDispatcher.PostEvent(EventID.OnLevelUnlockCardChanged, null);
        }
    }

    public static int IndexSlotCardUnlockByGold
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.KEY_IndexSlotCardUnlockByGold, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.KEY_IndexSlotCardUnlockByGold, value);
            EventDispatcher.PostEvent(EventID.OnRefreshUnlockSlotCard, 0);
        }
    }

    public static int IndexSlotCard
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.KEY_IndexSlotCard, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.KEY_IndexSlotCard, value);
            EventDispatcher.PostEvent(EventID.OnRefreshUnlockSlotCard, 0);
        }
    }

    public static bool IsUnlockSlotCard(int id)
    {
        return SavePrefs.GetInt($"{GameKeys.KEY_IsUnlockSlotCard}{id}", 0) == 1 ? true : false;
    }
    public static void UnlockSlotCard(int id)
    {
        SavePrefs.SetInt($"{GameKeys.KEY_IsUnlockSlotCard}{id}", 1);
        EventDispatcher.PostEvent(EventID.OnNewCardUnlock, id);
    }

    #endregion

    #region Labs Tower Data
    public static int CountSlotLabUnlock
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.KEY_CountSlotUnlock, 1);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.KEY_CountSlotUnlock, value);
        }
    }
    #endregion

    #region Init Default In Game Data
    public static bool IsFirstDoneWave40
    {
        get { return SavePrefs.GetInt(GameKeys.Key_IsFirstDoneWave40, 0) == 1 ? true : false; }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IsFirstDoneWave40, 1);
        }
    }

    public static string StartTimeFirstInGame
    {
        get { return SavePrefs.GetString(GameKeys.Key_StartTimeKey, DateTime.Now.ToString()); }
        set
        {
            SavePrefs.SetString(GameKeys.Key_StartTimeKey, DateTime.UtcNow.ToString("o"));
        }
    }

    public static bool IsTut_Play
    {
        get
        {
            return (SavePrefs.GetInt(GameKeys.Key_IsTut_Play, 1) == 1 /*&& !IsTut_PlayDemo*/) ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IsTut_Play, value ? 1 : 0);
        }
    }

    public static bool isTutLab
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_isTutLab, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isTutLab, value ? 1 : 0);
        }
    }

    public static bool isTutSpeed
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_isTutSpeed, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isTutSpeed, value ? 1 : 0);
        }
    }

    public static bool isTutBuildPhase2
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_isTutBuildPhase2, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isTutBuildPhase2, value ? 1 : 0);
        }
    }

    public static bool IsFirstTimeGoHome
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_IsFirstTimeGoHome, 1) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IsFirstTimeGoHome, value ? 1 : 0);
        }
    }

    public static bool IsFirstClaimOfflineReward
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_IsFirstClaimOfflineReward, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IsFirstClaimOfflineReward, value ? 1 : 0);
        }
    }

    public static bool IsResetData
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_IsResetData, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IsResetData, value ? 1 : 0);
        }
    }

    public static bool IsTut_0_Upgrade
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_IsTut_0_Upgrade, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IsTut_0_Upgrade, value ? 1 : 0);
        }
    }

    public static bool IsTut_PlayDemo
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_IsTutPlayDemo, 1) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IsTutPlayDemo, value ? 1 : 0);
        }
    }

    public static bool IsEndTutorial
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_IsEndTutorial, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IsEndTutorial, value ? 1 : 0);
        }
    }

    public static bool IsFirstInGame
    {
        get { return SavePrefs.GetInt(GameKeys.KEY_IsFirstInGame, 0) == 1 ? true : false; }
        set
        {
            SavePrefs.SetInt(GameKeys.KEY_IsFirstInGame, value ? 1 : 0);
        }
    }

    public static bool IsActiveTutorial
    {
        get { return SavePrefs.GetInt(GameKeys.KEY_IsActiveTutorial, 0) == 1 ? true : false; }
        set
        {
            SavePrefs.SetInt(GameKeys.KEY_IsActiveTutorial, value ? 1 : 0);
        }
    }

    public static void DefaultFirstInGame()
    {
        UnlockSlotCard(0);
        if (!IsFirstInGame)
        {
            StartTimeFirstInGame = DateTime.UtcNow.ToString("o");
            //SetDataUpgraderTowerTutorial();
            ResetUpgraderTowerDefault();
        }
    }

    public static void ResetUpgraderTowerDefault()
    {
        
    }

    public static void SetDataUpgraderTowerTutorial()
    {
        
    }
    #endregion

    #region World and wave
    public static int GetHighestWaveInWorld(int indexWorld)
    {
        return SavePrefs.GetInt($"{GameKeys.KEY_HighestWaveInWorld}{indexWorld}", 0);
    }
    public static void SetHighestWaveInWorld(int indexWorld, int highestWave)
    {
        if (GetHighestWaveInWorld(indexWorld) >= highestWave) return;
        SavePrefs.SetInt($"{GameKeys.KEY_HighestWaveInWorld}{indexWorld}", highestWave);
    }

    static int currentWorld;
    public static int CurrentWorld
    {
        get { return currentWorld; }
        set
        {
            currentWorld = value;
        }
    }

    public static int GetHighestWorld()
    {
        return SavePrefs.GetInt(GameKeys.KEY_HighestWorld, 0);
    }
    public static void SetHighestWorld(int highestWorld)
    {
        SavePrefs.SetInt(GameKeys.KEY_HighestWorld, highestWorld);
    }
    #endregion

    #region technology
    public static float timeGameMax
    {
        get
        {
            return SavePrefs.GetFloat(GameKeys.KEY_timeGameMax, 2f);
        }
        set
        {
            if (value < timeGameMax) return;
            SavePrefs.SetFloat(GameKeys.KEY_timeGameMax, value);
        }
    }

    public static float TimeGamePlaySpeed
    {
        get
        {
            return SavePrefs.GetFloat(GameKeys.KEY_TimeGamePlaySpeed, 1f);
        }
        set
        {
            SavePrefs.SetFloat(GameKeys.KEY_TimeGamePlaySpeed, value);
        }
    }

    #endregion

    #region Function
    public static void SaveObject(string key, object obj)
    {
        var json = JsonParse.ToJson(obj);
        SavePrefs.SetString(key, json);
    }
    public static T LoadObject<T>(string key)
    {
        var json = SavePrefs.GetString(key, null);
        if (string.IsNullOrEmpty(json))
            return default;

        return JsonParse.FromJson<T>(json);
    }
    #endregion

    #region Revive Tower
    public static int ReviveTowerCount
    {
        get { return SavePrefs.GetInt(GameKeys.KEY_ReviveTowerCount, 5); }
        set
        {
            SavePrefs.SetInt(GameKeys.KEY_ReviveTowerCount, value);
            EventDispatcher.PostEvent(EventID.OnChangeAmountRevive, 0);
        }
    }

    public static DateTime timeTargetFullRevive
    {
        get
        {
            return LoadObject<DateTime>(GameKeys.KEY_timeTargetFullRevive);
        }
        set
        {
            SaveObject(GameKeys.KEY_timeTargetFullRevive, value);
        }
    }
    #endregion

    #region SHOP
    public static bool isX2
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_isX2, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isX2, value ? 1 : 0);
        }
    }
    public static bool isX3
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_isX3, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isX3, value ? 1 : 0);
        }
    }
    public static bool isX4
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_isX4, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isX4, value ? 1 : 0);
        }
    }
    public static float x_sum
    {
        get
        {
            var value = (isX2 ? 2 : 0) + (isX3 ? 3 : 0) + (isX4 ? 4 : 0) + (isX_2Gold ? 1.5f : 0);
            return value;
        }
    }

    public static DateTime timeClaimFreeGem_Target
    {
        get
        {
            return LoadObject<DateTime>(GameKeys.Key_timeClaimFreeGem);
        }
        set
        {
            SaveObject(GameKeys.Key_timeClaimFreeGem, value);
        }
    }
    public static DateTime timeClaimFreeGold_Target
    {
        get
        {
            return LoadObject<DateTime>(GameKeys.Key_timeClaimFreeGold);
        }
        set
        {
            SaveObject(GameKeys.Key_timeClaimFreeGold, value);
        }
    }
    #endregion

    #region Bonus gold in game
    public static DateTime timeTargetBonusGold
    {
        get
        {
            return LoadObject<DateTime>(GameKeys.Key_timeTargetBonusGold);
        }
        set
        {
            SaveObject(GameKeys.Key_timeTargetBonusGold, value);
        }
    }
    public static bool isX_2Gold => timeTargetBonusGold > DateTime.Now;

    public static int XBonusGoldDailyQuest
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_XBonusGoldDailyQuest, 1);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_XBonusGoldDailyQuest, value);
            EventDispatcher.PostEvent(EventID.XBonusGoldDailyQuest, 0);
        }
    }

    public static float TimeBonusGold
    {
        get
        {
            return SavePrefs.GetFloat(GameKeys.Key_TimeBonusGold, 15f);
        }
        set
        {
            SavePrefs.SetFloat(GameKeys.Key_TimeBonusGold, value);
        }
    }
    #endregion

    #region Ultimate Weapon

    public static int IsUnlockSLotUltimateWeapon()
    {
        return SavePrefs.GetInt(GameKeys.Key_UnlockSLotUltimateWeapon, 0);
    }
    public static void UnlockSLotUltimateWeapon(int value)
    {
        SavePrefs.SetInt(GameKeys.Key_UnlockSLotUltimateWeapon, value);
        EventDispatcher.PostEvent(EventID.OnUnlockSlotUW, 0);
    }
    #endregion

    #region RemoveAds 

    public static bool RemoveAdsForever
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_RemoveAdsForever, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_RemoveAdsForever, value ? 1 : 0);
        }
    }
    #endregion

    #region User Power

    public static float basePower => 6.8f;
    public static float userPower
    {
        get
        {
            var sum = 4f;
            /*if(ConfigManager.instance != null)
            {
                foreach (var data in ConfigManager.instance.
                    upgraderCtrl.UpgradeInforManager.upgradeInforDatas)
                {
                    sum += data.GetCoefficient(GetLevelUpgraderInforTower(data.upgraderID));
                }
            } else
            {
                sum = 4f;   
            }*/
            return sum;
        }
    }
    #endregion

    #region rewardTime
    public static int secondToGetReward
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_SecondToGetReward, 60 * 60 * 4); //4 hour
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_SecondToGetReward, value);
        }
    }
    public static int SecondsAccumulate
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_SecondsAccumulate, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_SecondsAccumulate, value);
        }
    }
    public static DateTime LastLogoutTime
    {
        get
        {
            long binary = Convert.ToInt64(SavePrefs.GetString(GameKeys.Key_LastLogoutTimeOfflineReward, "0"));
            return binary == 0 ? DateTime.UtcNow : DateTime.FromBinary(binary);
        }
        set
        {
            SavePrefs.SetString(GameKeys.Key_LastLogoutTimeOfflineReward, value.ToBinary().ToString());
        }
    }
    #endregion

    #region MileStone
    public static bool IsUsingPremiumMileStones
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_IsUsingPremiumMileStones, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IsUsingPremiumMileStones, value ? 1 : 0);
            EventDispatcher.PostEvent(EventID.OnUsingPremiumMileStones, 0);
        }
    }

    #endregion

    #region Unlock Features

    public static bool isUnlockRanking
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_isUnlockRanking, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isUnlockRanking, value ? 1 : 0);
        }
    }

    public static bool isUnlockAchievement
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_isUnlockAchievement, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isUnlockAchievement, value ? 1 : 0);
        }
    }

    public static bool isUnlockLuckyDraw
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_isUnlockLuckyDraw, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isUnlockLuckyDraw, value ? 1 : 0);
        }
    }

    public static bool isUnlockDailyGift
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_isUnlockDailyGift, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isUnlockDailyGift, value ? 1 : 0);
        }
    }

    public static bool isUnlockLab
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_isUnlockLab, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isUnlockLab, value ? 1 : 0);
        }
    }

    public static bool IsUnlockFeatureCard
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_IsUnlockFeatureCard, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IsUnlockFeatureCard, value ? 1 : 0);
        }
    }

    public static bool IsUnlockFeatureArena
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_IsUnlockFeatureArena, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IsUnlockFeatureArena, value ? 1 : 0);
        }
    }

    #endregion

    #region Lucky Spin
    public static string GetLastPurchaseDate()
    {
        return PlayerPrefs.GetString(GameKeys.Key_LastPurchaseDate, "");
    }

    public static void SetLastPurchaseDate()
    {
        PlayerPrefs.SetString(GameKeys.Key_LastPurchaseDate, DateTime.Now.ToString("yyyy-MM-dd"));
    }

    public static int GetMoreTurnPurchaseCount()
    {
        return PlayerPrefs.GetInt(GameKeys.Key_MoreTurnPurchaseCount, 0);
    }

    public static void SetMoreTurnPurchaseCount(int purchaseCount)
    {
        PlayerPrefs.SetInt(GameKeys.Key_MoreTurnPurchaseCount, purchaseCount);
    }

    public static bool IsSpinFree
    {
        get
        {
            string lastSpinTimeStr = SavePrefs.GetString(GameKeys.Key_lastSpinTime, "0");
            long lastSpinTime = long.Parse(lastSpinTimeStr);

            if (lastSpinTime == 0 || (DateTime.UtcNow - DateTimeOffset.FromUnixTimeSeconds(lastSpinTime).UtcDateTime).TotalHours >= 24)
            {
                return true;
            }

            return SavePrefs.GetInt(GameKeys.Key_isSpinFree, 1) == 1;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_isSpinFree, value ? 1 : 0);

            if (!value)
            {
                SavePrefs.SetString(GameKeys.Key_lastSpinTime, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString());
            }
        }
    }

    public static int CountSpinFree
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_CountSpinFree, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_CountSpinFree, value);
        }
    }
    #endregion

    #region DailyReward

    public static void DayDailyReceived(int day, int value)
    {
        SavePrefs.SetInt($"{GameKeys.Key_IsDayReceived}{day}", value);
    }

    public static bool IsDayDailyReceived(int day)
    {
        return SavePrefs.GetInt($"{GameKeys.Key_IsDayReceived}{day}", 0) == 1 ? true : false;
    }

    public static void LastLoginDateDailyReward(string day)
    {
        SavePrefs.SetString($"{GameKeys.Key_LastLoginDateDailyReward}", day);
    }

    public static string IsLastLoginDateDailyReward()
    {
        return SavePrefs.GetString($"{GameKeys.Key_LastLoginDateDailyReward}", "");
    }

    public static void CurrentDayDailyReward(int day)
    {
        SavePrefs.SetInt($"{GameKeys.Key_CurrentDayDailyReward}", day);
    }

    public static int IsCurrentDayDailyReward()
    {
        return SavePrefs.GetInt($"{GameKeys.Key_CurrentDayDailyReward}", 0);
    }

    public static void SetAccumulateDailyReward(int day)
    {
        if (day > 30)
        {
            SavePrefs.SetInt($"{GameKeys.Key_IsAccumulateDailyReward}", 0);
        }
        else
        {
            SavePrefs.SetInt($"{GameKeys.Key_IsAccumulateDailyReward}", day);
        }
        EventDispatcher.PostEvent(EventID.OnRefreshDailyReward, 0);
    }

    public static int GetAccumulateDailyReward()
    {
        return SavePrefs.GetInt($"{GameKeys.Key_IsAccumulateDailyReward}", 0);
    }

    public static void ClaimedAccumulateDailyReward(int day, bool claimed)
    {
        SavePrefs.SetInt($"{GameKeys.Key_ClaimedAccumulateDailyReward}{day}", claimed == true ? 1 : 0);
    }

    public static bool IsClaimedAccumulateDailyReward(int day)
    {
        return SavePrefs.GetInt($"{GameKeys.Key_ClaimedAccumulateDailyReward}{day}", 0) == 1 ? true : false;
    }
    #endregion

    #region DailyGift
    public static void LastLoginDateDailyQuest(string day)
    {
        SavePrefs.SetString($"{GameKeys.Key_LastLoginDateDailyQuest}", day);
    }

    public static string IsLastLoginDateDailyQuest()
    {
        return SavePrefs.GetString($"{GameKeys.Key_LastLoginDateDailyQuest}", "");
    }

    public static void ClaimedQuestReward(Enum typeQuest, bool claimed)
    {
        SavePrefs.SetInt($"{GameKeys.Key_ClaimedAccumulateDailyGift}{typeQuest}", claimed == true ? 1 : 0);
    }

    public static bool IsClaimedQuestReward(Enum typeQuest)
    {
        return SavePrefs.GetInt($"{GameKeys.Key_ClaimedAccumulateDailyGift}{typeQuest}", 0) == 1 ? true : false;
    }

    public static void ClaimedAccumulateDailyGift(int day, bool claimed)
    {
        SavePrefs.SetInt($"{GameKeys.Key_ClaimedAccumulateDailyGift}{day}", claimed == true ? 1 : 0);
    }

    public static bool IsClaimedAccumulateDailyGift(int day)
    {
        return SavePrefs.GetInt($"{GameKeys.Key_ClaimedAccumulateDailyGift}{day}", 0) == 1 ? true : false;
    }

    public static void SetTotalQuestDone(Enum typeQuest, int countQuest)
    {
        //if (countQuest == 0) return;
        SavePrefs.SetInt($"{GameKeys.Key_TotalQuestDone}{typeQuest}", countQuest);
    }

    public static int GetTotalQuestDone(Enum typeQuest)
    {
        return SavePrefs.GetInt($"{GameKeys.Key_TotalQuestDone}{typeQuest}", 0);
    }

    public static void SetAccumulateDailyGift(int accumulate)
    {
        SavePrefs.SetInt($"{GameKeys.Key_AccumulateDailyGift}", accumulate);
        EventDispatcher.PostEvent(EventID.OnRefreshDailyGift, 0);
    }

    public static int GetAccumulateDailyGift()
    {
        return SavePrefs.GetInt($"{GameKeys.Key_AccumulateDailyGift}", 0);
    }

    public static bool IsChangeQuestReward
    {
        get
        {
            string lastSpinTimeStr = SavePrefs.GetString(GameKeys.Key_IsChangeQuestReward, "0");
            long lastSpinTime = long.Parse(lastSpinTimeStr);

            if (lastSpinTime == 0 || (DateTime.UtcNow - DateTimeOffset.FromUnixTimeSeconds(lastSpinTime).UtcDateTime).TotalHours >= 24)
            {
                return true;
            }

            return false;
        }
        set
        {
            if (!value)
            {
                SavePrefs.SetString(GameKeys.Key_IsChangeQuestReward, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString());
            }
        }
    }

    public static void DeleteAllQuests()
    {
        if (PlayerPrefs.HasKey(GameKeys.QuestKey))
        {
            PlayerPrefs.DeleteKey(GameKeys.QuestKey);
        }
    }

    #endregion

    #region WelcomeBack Round
    public static int GetWaveInResume(int world)
    {
        return SavePrefs.GetInt($"{GameKeys.Key_GetWaveInResume}{world}", 0);
    }
    public static void SetWaveInResume(int world, int wave)
    {
        SavePrefs.SetInt($"{GameKeys.Key_GetWaveInResume}{world}", wave);
    }

    public static int GetWorldInResume()
    {
        return SavePrefs.GetInt($"{GameKeys.Key_GetWorldInResume}", 0);
    }
    public static void SetWorldInResume(int world)
    {
        SavePrefs.SetInt($"{GameKeys.Key_GetWorldInResume}", world);
    }

    public static bool IsResumeWave(int world)
    {
        return SavePrefs.GetInt($"{GameKeys.Key_ResumeWave}{world}", 0) == 1 ? true : false;
    }
    public static void ResumeWave(int world, bool resume)
    {
        SavePrefs.SetInt($"{GameKeys.Key_ResumeWave}{world}", resume == true ? 1 : 0);
    }

    public static bool IsActiveWelcomeBack()
    {
        return SavePrefs.GetInt(GameKeys.Key_IsActiveWelcomeBack, 0) == 1 ? true : false;
    }
    public static void ActiveWelcomeBack(bool resume)
    {
        SavePrefs.SetInt(GameKeys.Key_IsActiveWelcomeBack, resume == true ? 1 : 0);
    }
    #endregion

    #region data
    public static void CheckAndDeleteJsonData()
    {
        if (!PlayerPrefs.HasKey(GameKeys.Key_GameInstalled))
        {
            DebugCustom.Log("PlayerPrefs đã bị reset! Xóa dữ liệu JSON...");

            // Xóa tất cả file JSON
            string filePathQuest = Path.Combine(Application.persistentDataPath, GameConstants.Key_filePathQuestsUnlock);
            string filePathMilestone = Path.Combine(Application.persistentDataPath, GameConstants.Key_filePathMileStoneUnlock);
            if (File.Exists(filePathQuest))
            {
                File.Delete(filePathQuest);
                DebugCustom.Log("Đã xóa file JSON: " + filePathQuest);
            }
            if (File.Exists(filePathMilestone))
            {
                File.Delete(filePathMilestone);
                DebugCustom.Log("Đã xóa file JSON: " + filePathMilestone);
            }

            PlayerPrefs.SetInt(GameKeys.Key_GameInstalled, 1);
            PlayerPrefs.Save();
        }
    }
    #endregion

    #region Profile

    public static string userID
    {
        get
        {
            return SystemInfo.deviceUniqueIdentifier;
        }
    }
    public static string user_name
    {
        get
        {
            return SavePrefs.GetString(GameKeys.Key_user_name, "playerid_1");
        }
        set
        {
            SavePrefs.SetString(GameKeys.Key_user_name, value);
            EventDispatcher.PostEvent(EventID.OnChangedName, null);
        }
    }
    public static int id_avatar
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_id_avatar, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_id_avatar, value);
            EventDispatcher.PostEvent(EventID.OnChangedAvatar, null);
        }
    }
    //Player
    public static DateTime StartDate
    {
        get
        {
            var time = LoadObject<DateTime>(GameKeys.Key_StartDate);
            if (time == default)
            {
                time = DateTime.Now;
                SaveObject(GameKeys.Key_StartDate, time);
            }
            return time;
        }
    }
    [RuntimeInitializeOnLoadMethod]
    private static void SetStartDate()
    {
        Debug.Log(StartDate);
    }

    public static int countUpgraderTime
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_countUpgraderTime, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_countUpgraderTime, value);
        }
    }

    public static int countDoneQuest
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_countDoneQuest, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_countDoneQuest, value);
        }
    }

    public static int countLoseGame
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_countLoseGame, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_countLoseGame, value);
        }
    }

    public static int countEnemyDestroy
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_countEnemyDestroy, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_countEnemyDestroy, value);
        }
    }

    #endregion

    #region Arena
    public static string GetLastLogTimeRank()
    {
        return PlayerPrefs.GetString(GameKeys.lastLogTimeKey);
    }

    public static void SetLastLogTimeRank()
    {
        PlayerPrefs.SetString(GameKeys.lastLogTimeKey, DateTime.Now.ToString());
        PlayerPrefs.Save();
    }

    public static bool CheckNewArenaEvent()
    {
        if (!Extensions.CheckArenaTime()) return false;

        DateTime today = DateTime.Today;
        string lastEventDateStr = PlayerPrefs.GetString(GameKeys.lastEventDateKey, "");
        DateTime lastEventDate = string.IsNullOrEmpty(lastEventDateStr) ? DateTime.MinValue : DateTime.Parse(lastEventDateStr);

        if (lastEventDate != today)
        {
            DebugCustom.Log("Sự kiện mới bắt đầu!");
            PlayerPrefs.SetString(GameKeys.lastEventDateKey, today.ToString("yyyy-MM-dd"));
            PlayerPrefs.Save();
            return true;
        }
        else
        {
            DebugCustom.Log("Đã trong cùng một sự kiện.");
        }

        return false;
    }

    public static bool IsFirstPlayArena
    {
        get { return SavePrefs.GetInt(GameKeys.KEY_IsFirstPlayArena, 0) == 1 ? true : false; }
        set
        {
            SavePrefs.SetInt(GameKeys.KEY_IsFirstPlayArena, 1);
        }
    }

    public static int TotalArenaRankPlay
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.KEY_TotalArenaRankPlay, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.KEY_TotalArenaRankPlay, value);
        }
    }
    public static int TotalArenaRankActive
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.KEY_TotalArenaRankActive, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.KEY_TotalArenaRankActive, value);
        }
    }

    public static void StartBattleTimer()
    {
        // Nếu chưa có thời gian bắt đầu, thì lưu lại
        if (!PlayerPrefs.HasKey(GameKeys.KEY_PlayStartTicks))
        {
            PlayerPrefs.SetString(GameKeys.KEY_PlayStartTicks, DateTime.Now.Ticks.ToString());
        }
    }

    public static bool IsResetRank()
    {
        return PlayerPrefs.HasKey(GameKeys.lastLogTimeKey);
    }

    public static void StopBattleAndAddTime()
    {
        if (!PlayerPrefs.HasKey(GameKeys.KEY_PlayStartTicks))
            return;

        long startTicks = long.Parse(PlayerPrefs.GetString(GameKeys.KEY_PlayStartTicks, "0"));
        DateTime startTime = new DateTime(startTicks);
        TimeSpan sessionDuration = DateTime.Now - startTime;

        int totalMinutesPlayed = PlayerPrefs.GetInt(GameKeys.KEY_PlayTotalMinutes, 0);
        totalMinutesPlayed += (int)sessionDuration.TotalMinutes;

        PlayerPrefs.SetInt(GameKeys.KEY_PlayTotalMinutes, totalMinutesPlayed);

        // Reset start time
        PlayerPrefs.DeleteKey(GameKeys.KEY_PlayStartTicks);
    }

    public static int GetPlayTimeMinutesPerDay()
    {
        return PlayerPrefs.GetInt(GameKeys.KEY_PlayTotalMinutes, 0);
    }

    public static void ResetPlayTime()
    {
        PlayerPrefs.DeleteKey(GameKeys.KEY_PlayTotalMinutes);
        PlayerPrefs.DeleteKey(GameKeys.KEY_PlayStartTicks);
    }

    public static bool IsArenaChain()
    {
        return SavePrefs.GetInt($"{GameKeys.Key_ArenaChain}", 0) == 1 ? true : false;
    }

    public static void ArenaChain(bool isChain)
    {
        SavePrefs.SetInt($"{GameKeys.Key_ArenaChain}", isChain == true ? 1 : 0);
    }

    public static bool IsBattleArena()
    {
        return SavePrefs.GetInt($"{GameKeys.Key_ArenaChain}", 0) == 1 ? true : false;
    }

    public static void StartBattleArena(bool isChain)
    {
        SavePrefs.SetInt($"{GameKeys.Key_ArenaChain}", isChain == true ? 1 : 0);
    }

    public static bool IsActiveEventArena()
    {
        return SavePrefs.GetInt($"{GameKeys.Key_ResetRankArena}", 0) == 1 ? true : false;
    }

    public static void ActiveEventArena(bool isChain)
    {
        SavePrefs.SetInt($"{GameKeys.Key_ResetRankArena}", isChain == true ? 1 : 0);
    }

    static int currentRank;
    public static int CurrentRank
    {
        get { return currentRank; }
        set
        {
            currentRank = value;
        }
    }

    public static int TotalReplayArena
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_TotalReplayArena, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_TotalReplayArena, value);
        }
    }

    public static int GetHighestRank()
    {
        return SavePrefs.GetInt(GameKeys.KEY_HighestRank, 0);
    }

    public static bool IsResetTouramentArena()
    {
        return SavePrefs.GetInt($"{GameKeys.Key_IsResetTouramentArena}", 0) == 1 ? true : false;
    }

    public static void ResetTouramentArena(bool isChain)
    {
        SavePrefs.SetInt($"{GameKeys.Key_IsResetTouramentArena}", isChain == true ? 1 : 0);
    }

    public static bool IsClaimRewardArenaRank()
    {
        return SavePrefs.GetInt($"{GameKeys.Key_IsClaimRewardArenaRank}", 0) == 1 ? true : false;
    }

    public static void ClaimRewardArenaRank(bool isChain)
    {
        SavePrefs.SetInt($"{GameKeys.Key_IsClaimRewardArenaRank}", isChain == true ? 1 : 0);
    }
    #endregion

    #region Challenge

    public static bool IsThemeSongUnlock(TypeSong typeSong)
    {
        return SavePrefs.GetInt($"{GameKeys.Key_ThemeSongUnlock}{typeSong}", 0) == 1 ? true : false;
    }

    public static void ThemeSongUnlock(TypeSong typeSong)
    {
        SavePrefs.SetInt($"{GameKeys.Key_ThemeSongUnlock}{typeSong}", 1);
    }

    public static bool IsX2BadgesEvent()
    {
        return SavePrefs.GetInt(GameKeys.KEY_IsX2BadgesEvent, 0) == 1 ? true : false;
    }

    public static void X2BadgesEvent(bool isX2)
    {
        SavePrefs.SetInt(GameKeys.KEY_IsX2BadgesEvent, isX2 ? 1 : 0);
    }

    public static bool IsRandomRelicReward()
    {
        return SavePrefs.GetInt(GameKeys.KEY_RandomRelicReward, 0) == 1 ? true : false;
    }

    public static void RandomRelicReward(bool isRand)
    {
        SavePrefs.SetInt(GameKeys.KEY_RandomRelicReward, isRand ? 1 : 0);
    }

    //check new day
    public static string LastCheckNewDayChallenge
    {
        get
        {
            string timeStr = PlayerPrefs.GetString(GameKeys.KEY_LastCheckNewDayChallenge, "");
            return timeStr;
        }
        set
        {
            SavePrefs.SetString(GameKeys.KEY_LastCheckNewDayChallenge, value.ToString());
        }
    }

    public static bool CheckNewDayEventChallenge()
    {
        if (LastCheckNewDayChallenge == "")
        {
            LastCheckNewDayChallenge = DateTime.Now.ToString();
        }
        DateTime lastLogin = DateTime.Parse(LastCheckNewDayChallenge);
        DateTime now = DateTime.Now;

        bool isNewDay = now.Date > lastLogin.Date;

        if (isNewDay)
        {
            LastCheckNewDayChallenge = DateTime.Now.ToString();
            return true;
        }
        else
        {
            return false;
        }
    }

    private static readonly TimeSpan EventDuration = TimeSpan.FromDays(14);
    private static readonly DateTime FirstEventStartDate = DateTime.Now;

    public static bool IsDuringEvent(DateTime now)
    {
        int weeksPassed = (int)((now - FirstEventStartDate).TotalDays / 14);
        DateTime currentEventStart = FirstEventStartDate.AddDays(weeksPassed * 14);
        DateTime currentEventEnd = currentEventStart + EventDuration;

        return now >= currentEventStart && now < currentEventEnd;
    }

    public static bool HasEventEnded(DateTime now)
    {
        return !IsDuringEvent(now);
    }

    public static bool IsNewEventCycle(DateTime lastCheckedTime, DateTime now)
    {
        int lastCycle = (int)((lastCheckedTime - FirstEventStartDate).TotalDays / 14);
        int currentCycle = (int)((now - FirstEventStartDate).TotalDays / 14);

        return currentCycle > lastCycle;
    }

    public static DateTime LastCheckTimeChallenge
    {
        get
        {
            string timeStr = PlayerPrefs.GetString(GameKeys.KEY_LastCheckKey, DateTime.Now.ToString());
            return DateTime.Parse(timeStr);
        }
        set
        {
            SavePrefs.SetString(GameKeys.KEY_LastCheckKey, value.ToString());
        }
    }

    public static int TotalMissionChallenge
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_TotalMissionChallenge, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_TotalMissionChallenge, value);
        }
    }

    public static bool IsFirstStartEventChallenge()
    {
        return SavePrefs.GetInt($"{GameKeys.Key_IsFirstStartEventChallenge}", 0) == 1 ? true : false;
    }

    public static void FirstStartEventChallenge(bool isFirst)
    {
        SavePrefs.SetInt($"{GameKeys.Key_IsFirstStartEventChallenge}", isFirst == true ? 1 : 0);
    }
    #endregion

    #region banner Pack
    public static bool IsActiveBannerPack()
    {
        return SavePrefs.GetInt(GameKeys.Key_ActiveBannerPack, 0) == 1 ? true : false;
    }
    public static void ActiveBannerPack(bool isClaim)
    {
        SavePrefs.SetInt(GameKeys.Key_ActiveBannerPack, isClaim ? 1 : 0);
    }

    public static DateTime FirstOpenDate
    {
        get
        {
            if (!PlayerPrefs.HasKey(GameKeys.FirstOpenKey))
            {
                var now = DateTime.UtcNow;
                PlayerPrefs.SetString(GameKeys.FirstOpenKey, now.ToString());
                return now;
            }
            return DateTime.Parse(PlayerPrefs.GetString(GameKeys.FirstOpenKey));
        }
        set => PlayerPrefs.SetString(GameKeys.FirstOpenKey, value.ToString());
    }

    public static int LastBannerCycle
    {
        get => PlayerPrefs.GetInt(GameKeys.LastCycleKey, 0);
        set => PlayerPrefs.SetInt(GameKeys.LastCycleKey, value);
    }

    public static void ResetBannerCycle(DateTime now)
    {
        BuyBeginnerPack(0, false);
        BuyBeginnerPack(1, false);
        FirstOpenDate = now;
    }

    public static bool IsBuyBeginnerPack(int indexPack)
    {
        return SavePrefs.GetInt($"{GameKeys.Key_BuyBeginnerPack}{indexPack}", 0) == 1 ? true : false;
    }

    public static void BuyBeginnerPack(int indexPack, bool isBuy)
    {
        SavePrefs.SetInt($"{GameKeys.Key_BuyBeginnerPack}{indexPack}", isBuy == true ? 1 : 0);
    }
    #endregion

    #region beginner quests reward
    public static DateTime timeTargetBeginnerQuest
    {
        get
        {
            return LoadObject<DateTime>(GameKeys.Key_timeTargetBeginnerQuest);
        }
        set
        {
            SaveObject(GameKeys.Key_timeTargetBeginnerQuest, value);
        }
    }

    public static DateTime timeStart
    {
        get
        {
            return LoadObject<DateTime>(GameKeys.Key_timeStartBeginnerQuests);
        }
        set
        {
            SaveObject(GameKeys.Key_timeStartBeginnerQuests, value);
        }
    }
    public static int CountDaysLogin
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_CountDaysLoginBeginner, 0);
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_CountDaysLoginBeginner, value);
        }
    }
    public static DateTime timeStart_30minRemain
    {
        get
        {
            return LoadObject<DateTime>(GameKeys.Key_timeStart_30minRemainBeginner);
        }
        set
        {
            SaveObject(GameKeys.Key_timeStart_30minRemainBeginner, value);
        }
    }

    public static bool ActiveBeginnerQuests
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_ActiveBeginnerQuests, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_ActiveBeginnerQuests, 1);
        }
    }

    public static bool FirstInGameActiveBeginnerQuest
    {
        get
        {
            return SavePrefs.GetInt(GameKeys.Key_FirstInGameActiveBeginnerQuest, 0) == 1 ? true : false;
        }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_FirstInGameActiveBeginnerQuest, 1);
        }
    }
    #endregion

    #region Double event Gold and Gem

    /*    public static bool IsDoubleEventGold()
        {
            return SavePrefs.GetInt("DoubleEventGold", 0) == 1 ? true : false;
        }
        public static void DoubleEventGold(bool isActive)
        {
            SavePrefs.SetInt("DoubleEventGold", isActive ? 1 : 0);
        }

        public static bool IsDoubleEventGem()
        {
            return SavePrefs.GetInt("DoubleEventGem", 0) == 1 ? true : false;
        }
        public static void DoubleEventGem(bool isActive)
        {
            SavePrefs.SetInt("DoubleEventGem", isActive ? 1 : 0);
        }

        public static bool ActiveDoubleEventGold
        {
            get
            {
                return SavePrefs.GetInt("ActiveDoubleEventGold", 0) == 1 ? true : false;
            }
            set
            {
                SavePrefs.SetInt("ActiveDoubleEventGold", 1);
            }
        }

        public static bool ActiveDoubleEventGem
        {
            get
            {
                return SavePrefs.GetInt("ActiveDoubleEventGem", 0) == 1 ? true : false;
            }
            set
            {
                SavePrefs.SetInt("ActiveDoubleEventGem", 1);
            }
        }*/
    #endregion

    #region Relics

    public static bool IsMaxSlotRelic()
    {
        if (IndexSlotRelic == maxSlotRelic)
        {
            return true;
        }
        return false;
    }

    public static int maxSlotRelic = 10;
    public static int IndexSlotRelic
    {
        get { return SavePrefs.GetInt(GameKeys.Key_IndexSlotRelic, 0); }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IndexSlotRelic, value);
            EventDispatcher.PostEvent(EventID.OnRefreshRelicEquip, 0);
        }
    }

    #endregion

    #region Music Challenge
    public static int IsThemeSongUsing()
    {
        return SavePrefs.GetInt(GameKeys.Key_ThemeSongUsing, 1);
    }

    public static void ThemeSongUsing(TypeSong typeSong)
    {
        SavePrefs.SetInt(GameKeys.Key_ThemeSongUsing, (int)typeSong);
        EventDispatcher.PostEvent(EventID.OnChangeSongTheme, 0);
    }
    #endregion

    #region Claimed Reward
    public static string GetLastClaimdX2OfflineRewardDate()
    {
        return SavePrefs.GetString(GameKeys.Key_LastClaimdX2OfflineRewardDate, "");
    }

    public static void SetLastClaimdX2OfflineRewardDate()
    {
        SavePrefs.SetString(GameKeys.Key_LastClaimdX2OfflineRewardDate, DateTime.Now.ToString("yyyy-MM-dd"));
    }

    public static int GetClaimedX2OfflineReward()
    {
        return SavePrefs.GetInt(GameKeys.Key_ClaimedX2OfflineReward, 0);
    }

    public static void SetClaimedX2OfflineReward(int purchaseCount)
    {
        SavePrefs.SetInt(GameKeys.Key_ClaimedX2OfflineReward, purchaseCount);
    }
    #endregion

    #region TechSystem

    public static int GetPitySystem()
    {
        return SavePrefs.GetInt(GameKeys.Key_PitySystem, 0);
    }

    public static void SetPitySystem(int pitySystem)
    {
        SavePrefs.SetInt(GameKeys.Key_PitySystem, pitySystem);
    }

    public static int GetUniqueTechSystem()
    {
        return SavePrefs.GetInt(GameKeys.Key_UniqueTechSystem, 0);
    }

    public static void SetUniqueTechSystem()
    {
        int uniqueTech = GetUniqueTechSystem() + 1;
        SavePrefs.SetInt(GameKeys.Key_UniqueTechSystem, uniqueTech);
    }

    #endregion
}
[System.Serializable]
public class UserID
{
    public string userID;
}

[System.Serializable]
public class User_BossKilled : UserID
{
    public string name;
    public int idAvatar;
    public float bossKilled;
}
