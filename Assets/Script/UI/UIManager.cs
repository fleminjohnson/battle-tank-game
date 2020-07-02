using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : SingletonBehaviour<UIManager>
{
    [SerializeField]
    private Image leftPanel;
    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject profilePanel;
    [SerializeField]
    private Toggle muteButton;
    [SerializeField]
    private TMP_Text bulletCountText;
    [SerializeField]
    private TMP_Text killCountText;
    [SerializeField]
    private TMP_Text enemyHitText;

    private bool mute = false;
    private int bulletCount = 0;
    private int killCount = 0;
    private int enemyHit = 0;

    protected override void Awake()
    {
        base.Awake();
        bulletCount = PlayerPrefs.GetInt("BulletCount", 0);
        killCount   = PlayerPrefs.GetInt("KillCount", 0);
        enemyHit    = PlayerPrefs.GetInt("EnemyHit", 0);
        //EventServices.GenericInstance.OnMute += PanelFunction;
    }

    void Start()
    {
        bulletCountText.text = bulletCount.ToString();
        killCountText.text   = killCount.ToString();
        enemyHitText.text    = enemyHit.ToString();
        muteButton.isOn      = false;
        leftPanel.gameObject.SetActive(false);
        profilePanel.SetActive(false);
    }

    private void PanelFunction()
    {
        leftPanel.gameObject.SetActive(true);
    }

    public void MuteFunction()
    {
        mute = !mute;
        //EventServices.GenericInstance.InvokeMute();
        PlayerPrefs.SetInt("MuteStatus", Convert.ToInt32(mute));
    }

    public void SettingsFunction()
    {
        PanelFunction();
        settingsPanel.SetActive(true);
        profilePanel.SetActive(false);
    }

    public void ProfileInfo()
    {
        PanelFunction();
        profilePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void Back()
    {
        leftPanel.gameObject.SetActive(false);
    }

    public void Play()
    {
        // StartCoroutine(SceneLoading());
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
    }

    IEnumerator SceneLoading()
    {
        yield return new WaitForEndOfFrame();
    }
}
