using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    public TankModel(int health, float force, float torque, BulletVariants bulletVariants, ID iD)
    {
        Health = health;
        Force = force;
        Torque = torque;
        BulletVariants = bulletVariants;
        ID = iD;
        //Debug.Log("Health is " + Health);
    }

    public int Health { get; private set; }
    public float Force { get; private set; }
    public float Torque { get; private set; }
    public BulletVariants BulletVariants { get; }
    public ID ID { get; }
}

