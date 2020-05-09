using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventServices : SingletonGeneric<EventServices>
{
    public event Action OnPlayerDeath;
    public event Action OnEnemyDeath;
    public event Action<ID, ID> OnDeath;
    public event Action OnHundredBulletsFired;
    public event Action OnTenEnemyKills;

    public void InvokeOnplayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }

    public void InvokeOnHundredBulletsFired()
    {
        OnHundredBulletsFired?.Invoke();
    }

    public void InvokeOnTenEnemyKills()
    {
        OnTenEnemyKills?.Invoke();
    }

    public void InvokeEnemyDeath()
    {
        OnEnemyDeath?.Invoke();
    }
}
