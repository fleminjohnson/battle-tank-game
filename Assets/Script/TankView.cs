using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public MeshRenderer[] mesh;
    public Material tankMaterialRed;
    public Material tankMaterialGreen;
    public Material tankMaterialBlue;

    private void Awake()
    {
        //mesh = GetComponent<MeshRenderer>();  
        //ColorSelector(TankColor.Blue);
    }
    public void ColorSelector(TankColor color)
    {
        for (int index = 0; index < 4; index++)
        {
            switch (color)
            {
                case TankColor.BLUE:
                    mesh[index].material = tankMaterialBlue;
                    break;
                case TankColor.GREEN:
                    mesh[index].material = tankMaterialGreen;
                    break;
                case TankColor.RED:
                    mesh[index].material = tankMaterialRed;
                    break;
            }
        }
    }
}
