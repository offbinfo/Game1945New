using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    [SerializedDictionary("TypeMusic", "Music")]
    private SerializedDictionary<TypeSong, AudioPackClip> musicPacks;

    void Start()
    {
        OnChangeSongTheme(null);
        EventDispatcher.AddEvent(EventID.OnChangeSongTheme, OnChangeSongTheme);
    }

    private void OnChangeSongTheme(object obj)
    {
        AudioPackClip audioPackClip = musicPacks[(TypeSong)GameDatas.IsThemeSongUsing()];
        AudioManager.PlayMusicStatic(audioPackClip.name);
    }

    private void OnDisable()
    {
    }
}
