using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class pickKey : MonoBehaviour
{
    public GameObject missionPanel;
    public GameObject headBone;
    
    // Start is called before the first frame update
    void Update()
    {
        
    }

    // Update is called once per frame
    void HitByRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            headBone.SendMessage("LookAtPlayer");
            missionPanel.GetComponent<MissionProgress>().gotKeys = true;
            missionPanel.GetComponent<MissionProgress>().changeMission(8);
            Destroy(gameObject);
        }
    }
}
