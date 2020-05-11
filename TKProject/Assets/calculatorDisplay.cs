using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculatorDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    Text textC;
    int charNum;
    public AudioClip buttonSound;
    public GameObject targetDoor;
    public GameObject missionShowerPanel;
    public GameObject cameraRig;
    bool opened;
    
    void Start()
    {
        textC = GetComponent<Text>();
        textC.text = "";
        charNum = 0;
        

    }


    public void addNum(int _num)
    {
        if(charNum < 5)
        {
            //Debug.Log("yeet");
            charNum++;
            textC.text += _num.ToString();
            cameraRig.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        }
    }

    public void deleteNum() { 
        if(charNum > 0)
        {
            charNum--;
            textC.text = textC.text.Remove(textC.text.Length - 1);
            cameraRig.GetComponent<AudioSource>().PlayOneShot(buttonSound);
        }
    }

    public void checkNum() { 
        if(textC.text == "1332" && missionShowerPanel.GetComponent<MissionProgress>().getCurrentMission() == 4)
        {
            //open

            cameraRig.GetComponent<AudioSource>().PlayOneShot(buttonSound);
            missionShowerPanel.GetComponent<MissionProgress>().changeMission(5);
            targetDoor.GetComponent<Animator>().SetBool("Locked",false);
            targetDoor.GetComponent<Animator>().SetBool("Opened", true);
        }
    }

    public void clearNum() {
        charNum = 0;
        textC.text = "";
        cameraRig.GetComponent<AudioSource>().PlayOneShot(buttonSound);
    }
}
