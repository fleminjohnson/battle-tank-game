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
    private Image NotificationBar;
    [SerializeField]
    private TMP_Text NotificationMessage;


    private float killCount;


    private void Start()
    {
        EventServices eventServices = new EventServices();
        EventServices.GenericInstance.OnHundredBulletsFired += HundredBullets;
        EventServices.GenericInstance.OnTenEnemyKills += TenEnemyKilled;
        EventServices.GenericInstance.OnEnemyDeath += EnemyKilled;
        NotificationBar.gameObject.SetActive(false);
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
