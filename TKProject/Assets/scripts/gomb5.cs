using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gomb5 : MonoBehaviour
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

    void Update()
    {
        if (cube1.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        
    }

    void OnMouseDown()
    {
        gomb1 gomb_1 = cube1.GetComponent<gomb1>();
        gomb2 gomb_2 = cube2.GetComponent<gomb2>();
        gomb3 gomb_3 = cube3.GetComponent<gomb3>();
        gomb4 gomb_4 = cube4.GetComponent<gomb4>();
        
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().Play("cubePressed");
            if (gomb_1.pressed == true)
            {
                pressed = true;
            }
            else if (gomb_1.pressed == false)
            {
                pressed = false;
            }
        }
    }
}
