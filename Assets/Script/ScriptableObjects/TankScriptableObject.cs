using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TankScriptableObject",menuName ="ScriptableObject/NewTank")]

public class TankScriptableObject : ScriptableObject
{
    public int health;
    public float force; 
    public float torque;
    public BulletVariants bulletVariants;
    public TankColor tankColor;
}