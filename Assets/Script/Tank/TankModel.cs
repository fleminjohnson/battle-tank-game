using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    public TankModel(int health, float speed)
    {
        Health = health;
        Speed = speed;
    }

    public int Health { get; private set; }
    public float Speed { get; }
}
