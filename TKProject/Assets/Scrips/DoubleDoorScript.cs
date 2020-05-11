using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorScript : MonoBehaviour
{

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        //_animator = this.GetComponent<Animator>();
    }

    /*void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "MainCamera")
        {
            
            
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        

        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1) && ((hit.transform.name == "SimpleDoubleDoor" || hit.transform.name == "SimpleDoor") || hit.transform.tag == "DoorPart"))
        {
            _animator = hit.transform.GetComponent<Animator>();
            if (!_animator.GetBool("Locked"))
            {
                GetComponent<InfoHolder>().info = "Ajtó használat";
            } else
            {
                GetComponent<InfoHolder>().info = "Zárt ajtó";
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && !_animator.GetBool("Locked"))
            {

                if (_animator.GetBool("Opened"))
                {

                    _animator.SetBool("Opened", false);
                }
                else
                {
                    _animator.SetBool("Opened", true);
                }
            }

        }
    }
}
