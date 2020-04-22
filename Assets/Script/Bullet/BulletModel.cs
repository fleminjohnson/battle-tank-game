using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public BulletModel(float bulletSpeed, Vector3 position)
    {
        BulletSpeed = bulletSpeed;
        Position = position;
    }
    public float BulletSpeed { get; }
    public Vector3 Position { get; }
}
