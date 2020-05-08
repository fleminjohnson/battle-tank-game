using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyModel
    {
        public EnemyModel(int health, float force, float torque, BulletVariants bulletVariants, EnemyColor tankColor)
        {
            Health = health;
            Force = force;
            Torque = torque;
            BulletVariants = bulletVariants;
            TankColor = tankColor;
            //Debug.Log("Health is " + Health);
        }

        public int Health { get; private set; }
        public float Force { get; private set; }
        public float Torque { get; private set; }
        public BulletVariants BulletVariants { get; }
        public EnemyColor TankColor { get; }
    }
}