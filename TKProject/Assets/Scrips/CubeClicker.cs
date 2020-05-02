using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClicker : MonoBehaviour
{
    public Renderer Rend;
    public GameObject cube1, cube2, cube3, cube4, cube5;
    // Start is called before the first frame update
    void Start()
    {
        /*Rend = GetComponent<Renderer>();
        Rend.enabled = true;*/
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0F))
        {
            switch(hit.transform.tag)
            {
                case "Cube1":// ur in 100 meters of the object
                    if (Input.GetMouseButtonDown(0))
                    {  //u hit  E do something
                        if (cube1.GetComponent<Renderer>().material.color == Color.red)
                        {
                            cube1.GetComponent<Renderer>().material.color = Color.green;
                        }
                    }
                    break;
                case "Cube2":// ur in 100 meters of the object
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (cube3.gameObject.GetComponent<Renderer>().material.color == Color.green)
                        {
                            GetComponent<Renderer>().material.color = Color.green;
                        }
                        else if (cube3.gameObject.GetComponent<Renderer>().material.color == Color.red)
                        {
                            GetComponent<Renderer>().material.color = Color.red;
                            cube1.gameObject.GetComponent<Renderer>().material.color = Color.red;
                        }
                    }
                    break;
                case "Cube3":// ur in 100 meters of the object

                    break;
                case "Cube4":// ur in 100 meters of the object

                    break;
                case "Cube5":// ur in 100 meters of the object

                    break;
            }
           
        }
    }
}
