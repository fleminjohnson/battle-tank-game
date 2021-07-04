using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="BulletScriptableObject",menuName ="ScriptableObject/NewBullet")]
public class BulletScriptableObject : ScriptableObject
{
    public float bulletSpeed;
    public float bulletDamage;
    public BulletVariants bulletVariants;
}
