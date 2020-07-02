using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/NewEnemy")]

public class EnemyScriptableObject : ScriptableObject
{
    public int health;
    public float force;
    public float torque;
    public BulletVariants bulletVariants;
    public EnemyColor enemyColor;
}