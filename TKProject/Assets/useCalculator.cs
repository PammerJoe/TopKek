using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class useCalculator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject missionCanvas;
    private GameObject CameraRig;
    private bool useCalc;
    void Start()
    {
        CameraRig = GameObject.Find("CameraRig");
        useCalc = false;
    }
    void Update()
    {
        
        /*if(useCalc && Input.GetMouseButtonDown(0))
        {
            useCalc = false;
            //CameraRig = GameObject.Find("CameraRig");
            CameraRig.GetComponent<FirstPersonController>().observing = false;
        }*/
    }
    // Update is called once per frame
    void HitByRay()
    {
        if (Input.GetMouseButtonDown(0) && !useCalc)
        {
            //useCalc = true;
            //CameraRig = GameObject.Find("CameraRig");
            
            missionCanvas.SetActive(true);
            CameraRig.GetComponent<FirstPersonController>().observing = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
