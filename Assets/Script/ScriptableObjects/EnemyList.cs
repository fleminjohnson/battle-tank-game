using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/NewEnemyList")]

public class EnemyListScriptableObject : ScriptableObject
{
    public EnemyScriptableObject[] enemy;
}