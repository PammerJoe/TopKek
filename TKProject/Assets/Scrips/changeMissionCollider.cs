using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class changeMissionCollider : MonoBehaviour
{
    private bool activated;
    public int missionNum;
    public GameObject missionShower;
    
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activated) {

            //mainCam.GetComponent<AudioSource>().clip = missionSound;
            
            missionShower.GetComponent<MissionProgress>().changeMission(missionNum);
            activated = true;
        }
    }
}
