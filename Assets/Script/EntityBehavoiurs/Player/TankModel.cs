using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private float totalHealth;
    public TankModel(int health, float force, float torque, BulletVariants bulletVariants, ID iD)
    {
        totalHealth = health;
        Health = health;
        Force = force;
        Torque = torque;
        BulletVariants = bulletVariants;
        ID = iD;
    }

    public int Health { get; private set; }
    public float Force { get; private set; }
    public float Torque { get; private set; }
    public BulletVariants BulletVariants { get; }
    public ID ID { get; }

    public static int BulletCount;

    internal float DecrementHealth(int decrementValue)
    {
        Health -= decrementValue;
        return (300/totalHealth);
    }
}

