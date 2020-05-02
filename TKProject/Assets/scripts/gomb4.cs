using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gomb4 : MonoBehaviour
{
    public Renderer Rend;
    public GameObject cube1, cube2, cube3, cube4, cube5, firstDoor;
    public GameObject szoveg;
    private Animator _animator;
    bool mindenzold = false;

    void Start()
    {
        _animator = firstDoor.GetComponent<Animator>();
        Rend = GetComponent<Renderer>();
        Rend.enabled = true;
    }

    void Update()
    {
        if (cube2.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        if (cube1.gameObject.GetComponent<Renderer>().material.color == Color.green && 
            cube5.gameObject.GetComponent<Renderer>().material.color == Color.green &&
            cube3.gameObject.GetComponent<Renderer>().material.color == Color.green &&
            cube2.gameObject.GetComponent<Renderer>().material.color == Color.green &&
            cube4.gameObject.GetComponent<Renderer>().material.color == Color.green)
        {
            mindenzold = true;
        }
        if(mindenzold == true)
        {
            _animator.SetBool("Locked", false);
            szoveg.SetActive(true);
        }

    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().Play("cubePressed");
            if (cube2.gameObject.GetComponent<Renderer>().material.color == Color.green)
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
            else if (cube2.gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                GetComponent<Renderer>().material.color = Color.red;
                cube1.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
