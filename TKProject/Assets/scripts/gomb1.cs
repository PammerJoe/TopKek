using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gomb1 : MonoBehaviour
{
    public Renderer Rend;
    public GameObject cube1, cube2, cube3, cube4, cube5;
    public bool pressed;
    
    void Start()
    {
        Rend = GetComponent<Renderer>();
        Rend.enabled = true;
        pressed = false;
    }

    void OnMouseDown()
    {
        gomb5 gomb_5 = cube5.GetComponent<gomb5>();
        gomb2 gomb_2 = cube2.GetComponent<gomb2>();
        gomb3 gomb_3 = cube3.GetComponent<gomb3>();
        gomb4 gomb_4 = cube4.GetComponent<gomb4>();
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().Play("cubePressed");
            if (pressed == false)
            {
                pressed = true; ;
            }
            
        }
    }
}
