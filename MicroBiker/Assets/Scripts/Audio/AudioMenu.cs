﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    [Header("On/Off")]
    public GameObject musicOnBtn;
    public GameObject musicOffBtn;
    public GameObject soundOnBtn;
    public GameObject soundOffBtn;

    MenuSettingsData menuSettings;

    private void Start()
    {
        menuSettings = AudioPersister.LoadAudioSettings();

        UpdateMusicVolume(menuSettings.MusicStatus);
        UpdateSoundVolume(menuSettings.SoundStatus);
        InitAudioMenuButtons();
    }

    public void UpdateMusicVolume(bool on)
    {
        AudioManager.instance.mixer.SetFloat("MusicVolume", on ? 0 : -80);
        if (on != menuSettings.MusicStatus)
        {
            menuSettings.MusicStatus = on;
            UpdateAudioSettings();
        }
    }

    public void UpdateSoundVolume(bool on)
    {
        AudioManager.instance.mixer.SetFloat("SoundVolume", on ? 0 : -80);
        if (on != menuSettings.SoundStatus)
        {
            menuSettings.SoundStatus = on;
            UpdateAudioSettings();
        }
    }

    void UpdateAudioSettings()
    {
        AudioPersister.UpdateAudioSettings(menuSettings);
    }

    void InitAudioMenuButtons()
    {
        musicOnBtn.SetActive(menuSettings.MusicStatus);
        musicOffBtn.SetActive(!menuSettings.MusicStatus);
        soundOnBtn.SetActive(menuSettings.SoundStatus);
        soundOffBtn.SetActive(!menuSettings.SoundStatus);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}