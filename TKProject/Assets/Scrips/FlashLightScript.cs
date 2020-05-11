using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip clickSound;
    public GameObject mainCam;
    void Start()
    {
        
    }
    //public AudioSource clickSound;
    public GameObject SpotLight;
    bool turned = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mainCam.GetComponent<AudioSource>().PlayOneShot(clickSound);

            if (turned == false)
            {
                SpotLight.SetActive(true);
                turned = true;
            }
            else {
                SpotLight.SetActive(false);
                turned = false;
            }
        }
    }
}
