using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public BulletModel(BulletScriptableObject bulletScriptableObject, Transform position)
    {
        BulletSpeed = bulletScriptableObject.bulletSpeed;
        Position = position;

        Debug.Log("Bullet damage is "+ bulletScriptableObject.bulletDamage);
    }
    public float BulletSpeed { get; }
    public Transform Position { get; }
}
