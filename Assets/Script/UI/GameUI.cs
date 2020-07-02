using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUI : SingletonBehaviour<GameUI>
{
    [SerializeField]
    private TMP_Text EnemiesKilled;
    [SerializeField]
    private TMP_Text EnemiesHit;
    [SerializeField]
    private TMP_Text RespawnCount;
    [SerializeField]
    private Image NotificationBar;
    [SerializeField]
    private TMP_Text NotificationMessage;


    private int killCount;
    private int respawnCount = 0;
    private int enemyHit;

    private void Start()
    {
        EventServices eventServices = new EventServices();
        EventServices.GenericInstance.OnHundredBulletsFired += HundredBullets;
        EventServices.GenericInstance.OnTenEnemyKills += TenEnemyKilled;
        EventServices.GenericInstance.OnEnemyDeath += EnemyKilled;
        EventServices.GenericInstance.OnGameOver += GameOverRoutine;
        EventServices.GenericInstance.OnRespawn += UpdateRespawnCount;
        EventServices.GenericInstance.OnEnemyHit += EnemyHit;
        NotificationBar.gameObject.SetActive(false);
        ShowNotification("Battle Begin");
    }

    private void EnemyHit()
    {
        enemyHit += 1;
        UpdateUI(enemyHit.ToString(), EnemiesHit);
    }

    private void UpdateRespawnCount()
    {
        respawnCount += 1;
        UpdateUI(respawnCount.ToString(),RespawnCount);
    }

    private void GameOverRoutine(int bulletCount)
    {
        ShowNotification("Game Over");
        SaveData(bulletCount);
    }

    private void SaveData(int bulletCount)
    {
        PlayerPrefs.SetInt("BulletCount", bulletCount +
        PlayerPrefs.GetInt("BulletCount", 0));
        PlayerPrefs.SetInt("KillCount", killCount + PlayerPrefs.GetInt("KillCount", 0 ));
        PlayerPrefs.SetInt("EnemyHit", enemyHit + PlayerPrefs.GetInt("EnemyHit", 0));
    }

    private void EnemyKilled()
    {
        killCount += 1;
        UpdateUI(killCount.ToString(), EnemiesKilled);
    }

    private void TenEnemyKilled()
    {
        ShowNotification("Ten Enemies Killed");
    }

    private void HundredBullets()
    {
        ShowNotification("Hundred Bullets Fired");
    }

    private void ShowNotification(string displayText)
    {
        StopCoroutine(FadeOut());
        UpdateUI(displayText, NotificationMessage);
        NotificationBar.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }
    private void UpdateUI(string displayText, TMP_Text field)
    {
        field.text = displayText;
    }
    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.0f);
        NotificationBar.gameObject.SetActive(false);
    }
}
