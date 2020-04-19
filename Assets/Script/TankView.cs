using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public MeshRenderer mesh;

    private void Awake()
    {
        //mesh = GetComponent<MeshRenderer>();  
        //ColorSelector(TankColor.Blue);
    }
    public void ColorSelector(TankColor color)
    {
        switch (color)
        {
            case TankColor.Blue:
                mesh.sharedMaterial.color = Color.blue;
                break;
            case TankColor.GREEN:
                mesh.sharedMaterial.color = Color.green;
                break;
            case TankColor.RED:
                mesh.sharedMaterial.color = Color.red;
                break;
        }
    }
}
