using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    public TankModel(int health, float speed, float sensitivity)
    {
        Health = health;
        Speed = speed;
        Sensitivity = sensitivity;
    }

    public int Health { get; private set; }
    public float Speed { get; private set; }
    public float Sensitivity { get; private set; }
}
