using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public BulletModel(float bulletSpeed, Transform position, float bulletDamage)
    {
        BulletSpeed = bulletSpeed;
        Position = position;

        Debug.Log("Bullet damage is "+ bulletDamage);
    }
    public float BulletSpeed { get; }
    public Transform Position { get; }
}
