using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public BulletModel(BulletScriptableObject bulletScriptableObject, Transform transform, ID iD)
    {
        BulletSpeed = bulletScriptableObject.bulletSpeed;
        Transform = transform;
        ID = iD;
        BulletDamage = bulletScriptableObject.bulletDamage;

        Debug.Log("Bullet damage is "+ bulletScriptableObject.bulletDamage);
    }
    public float BulletSpeed { get; }
    public Transform Transform { get; }
    public ID ID { get; }
    public float BulletDamage { get; }
}
