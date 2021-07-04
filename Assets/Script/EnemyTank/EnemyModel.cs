using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyModel
    {
        public EnemyModel(int health, float force, float torque, BulletVariants bulletVariants, EnemyColor tankColor, ID iD)
        {
            Health = health;
            Force = force;
            Torque = torque;
            BulletVariants = bulletVariants;
            TankColor = tankColor;
            ID = iD;
            //Debug.Log("Health is " + Health);
        }

        public int Health { get; private set; }
        public float Force { get; private set; }
        public float Torque { get; private set; }
        public BulletVariants BulletVariants { get; }
        public EnemyColor TankColor { get; }
        public ID ID { get; }

        public void DecrementHealth(int decrementValue)
        {
            Health -= decrementValue;
        }
    }
}