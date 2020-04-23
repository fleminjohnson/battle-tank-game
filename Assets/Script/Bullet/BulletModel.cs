using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public BulletModel(float bulletSpeed, Transform position)
    {
        BulletSpeed = bulletSpeed;
        Position = position;
    }
    public float BulletSpeed { get; }
    public Transform Position { get; }
}
