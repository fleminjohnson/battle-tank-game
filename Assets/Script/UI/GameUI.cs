using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public event Action OnDeath;
    public event Action<ID, ID> onDeath;

    private void Start()
    {
        OnDeath += GameUI_OnDeath;
        OnDeath?.Invoke();

        onDeath?.Invoke(ID.ENEMY,ID.PLAYER);

        onDeath += GameUI_onDeath;
    }

    private void GameUI_onDeath(ID dead, ID killed)
    {
        throw new NotImplementedException();
    }

    private void GameUI_OnDeath()
    {
        throw new NotImplementedException();
    }
}
