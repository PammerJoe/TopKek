using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gomb1 : MonoBehaviour
{
    public Renderer Rend;
    public GameObject cube1, cube2, cube3, cube4, cube5;
    
    void Start()
    {
        Rend = GetComponent<Renderer>();
        Rend.enabled = true;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().Play("cubePressed");
            if (cube1.gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
            
        }
    }
}
