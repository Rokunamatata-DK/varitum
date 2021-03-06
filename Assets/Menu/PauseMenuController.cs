﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Canvas canvasPause, canvasSettings;
    public Toggle toggleSound, toggleMusic;

    private Color toggleColor = new Color(0.240566f, 0.817987f, 1.0f);

    void Start()
    {
        canvasPause.gameObject.SetActive(false);
        canvasSettings.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.inPlay)
            SetPaused(!canvasPause.gameObject.activeInHierarchy);

        if (Input.GetKeyDown(KeyCode.R) && GameManager.inPlay)
            ResetClicked();
    }

    private void SetPaused(bool paused)
    {
        canvasPause.gameObject.SetActive(paused);
        canvasSettings.gameObject.SetActive(false);
        Time.timeScale = paused ? 0 : 1;
    }

    public void ContinueClicked()
    {
        SetPaused(false);
    }

    public void ResetClicked()
    {
        SetPaused(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SettingsClicked()
    {
        canvasPause.gameObject.SetActive(false);

        toggleSound.isOn = GameManager.soundEnabled;
        //toggleSound.GetComponentInChildren<Image>().color = GameManager.soundEnabled ? toggleColor : Color.white;
        toggleMusic.isOn = GameManager.musicEnabled;
        //toggleMusic.GetComponentInChildren<Image>().color = GameManager.musicEnabled ? toggleColor : Color.white;

        canvasSettings.gameObject.SetActive(true);
    }

    public void SettingsBackClicked()
    {
        SetPaused(true);
    }


    public void SettingsToggleSoundChanged()
    {
        //toggleSound.GetComponentInChildren<Image>().color = GameManager.soundEnabled ? toggleColor : Color.white;
        GameManager.SetSound(toggleSound.isOn);
    }

    public void SettingsToggleMusicChanged()
    {
        //toggleMusic.GetComponentInChildren<Image>().color = GameManager.musicEnabled ? toggleColor : Color.white;
        GameManager.SetMusic(toggleMusic.isOn);
    }

    public void QuitClicked()
    {
        SetPaused(false);
        SceneManager.LoadScene("MainMenu");
    }


}
