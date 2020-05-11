using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InfoHolder : MonoBehaviour
{
    public string info;
    private GameObject CameraRig;
    public bool Opened;
    void Start(){
        Opened = false;
        CameraRig = GameObject.Find("CameraRig");
    }
    // Start is called before the first frame update
    public string getName()
    {
        return info;
    }
    
    void HitByRay(){
        CameraRig.GetComponent<FirstPersonController>().setInfoTextString(info);
    }
}
