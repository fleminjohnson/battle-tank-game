using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    BulletController bulletcontroller;
    Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Start()
    {
        //rb.velocity = Vector3.left * 500.0f;
        Fire(5.0f);
    }

    public void Fire(float speed)
    {
        rb.AddForce(Vector3.forward * speed,ForceMode.Impulse);
        print(speed);
    }

    public void Initialize(BulletController bulletControl)
    {
        bulletcontroller = bulletControl;
    }
}
