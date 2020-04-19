using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    public TankModel(int health, int speed, TankColor color)
    {
        Health = health;
        Speed = speed;

        switch (color)
        {
            case TankColor.Green: print("sdsds");
        }
    }

    public int Health { get; private set; }
    public int Speed { get; }
}
