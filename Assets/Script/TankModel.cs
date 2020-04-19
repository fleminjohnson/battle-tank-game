using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    public TankModel(int health, int speed)
    {
        Health = health;
        Speed = speed;
    }

    public int Health { get; private set; }
    public int Speed { get; }
}
