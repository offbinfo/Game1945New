using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameDatas
{

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
    #endregion

    #region Wave

    public static int IndexLevel
    {
        get { return SavePrefs.GetInt(GameKeys.Key_IndexLevel, 1); }
        set
        {
            SavePrefs.SetInt(GameKeys.Key_IndexLevel, value);
        }
    }

    #endregion

    #region Setting
     public static int IsThemeSongUsing
     {
            get { return SavePrefs.GetInt(GameKeys.Key_IsThemeSongUsing, 0); }
            set
            {
                SavePrefs.SetInt(GameKeys.Key_IsThemeSongUsing, value);
            }
     }
    #endregion

}