using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorScript : MonoBehaviour
{

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "MainCamera")
        {
            
            if (Input.GetKeyDown(KeyCode.E) && !_animator.GetBool("Locked"))
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
