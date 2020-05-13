using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class interactMonitor : MonoBehaviour
{
    private Material originalMaterial;
    private Renderer render;
    public GameObject cameraRig;
    private Vector3 posStart;
    private Quaternion rotStart;
    public GameObject cameraPlace;
    public GameObject mainCam;
    private bool activated;
    FirstPersonController FPSC;
    public GameObject monitorCanvas;
    public GameObject monitorPanel;
    public GameObject missionShowerPanel;
    private int score = 0;
    private int task = 0;
    public Sprite bg, task1, task2, task3, task4, end;
    public GameObject starto, task1o, task2o, task3o, task4o, endo,scoreText;
    bool didIt = false;
    // Start is called before the first frame update
    void Start()
    {
        FPSC = cameraRig.GetComponent<FirstPersonController>();
    }
    void Update()
    {
        if(score == 4 && !didIt)
        {
            didIt = true;
            missionShowerPanel.GetComponent<MissionProgress>().changeMission(7); //TODO: kesobb 7
        }
        
    }

    void setActiveTask(int num)
    {
        switch (num)
        {
            case 4:
                starto.SetActive(false);
                task1o.SetActive(false);
                task2o.SetActive(false);
                task3o.SetActive(false);
                task4o.SetActive(false);
                endo.SetActive(true);
                break;
            case 3:
                starto.SetActive(false);
                task1o.SetActive(false);
                task2o.SetActive(false);
                task3o.SetActive(false);
                task4o.SetActive(true);
                endo.SetActive(false);
                break;
            case 2:
                starto.SetActive(false);
                task1o.SetActive(false);
                task2o.SetActive(false);
                task3o.SetActive(true);
                task4o.SetActive(false);
                endo.SetActive(false);
                break;
            case 1:
                starto.SetActive(false);
                task1o.SetActive(false);
                task2o.SetActive(true);
                task3o.SetActive(false);
                task4o.SetActive(false);
                endo.SetActive(false);
                break;
            case 0:
                starto.SetActive(false);
                task1o.SetActive(true);
                task2o.SetActive(false);
                task3o.SetActive(false);
                task4o.SetActive(false);
                endo.SetActive(false);
                break;
            default:
                starto.SetActive(true);
                task1o.SetActive(false);
                task2o.SetActive(false);
                task3o.SetActive(false);
                task4o.SetActive(false);
                endo.SetActive(false);
                break;
        }
    }
    public void taskNum(int num)
    {
        switch (num)
        {
            case 4:
                monitorPanel.GetComponent<Image>().sprite = end;
                scoreText.GetComponent<Text>().text = ("Elért pontszám:\n" + score + "/4");
                task = num;
                break;
            case 3:
                monitorPanel.GetComponent<Image>().sprite = task4;
                task = num;
                break;
            case 2:
                monitorPanel.GetComponent<Image>().sprite = task3;
                task = num;
                break;
            case 1:
                monitorPanel.GetComponent<Image>().sprite = task2;
                task = num;
                break;
            case 0:
                monitorPanel.GetComponent<Image>().sprite = task1;
                task = num;
                break;
            default:
                monitorPanel.GetComponent<Image>().sprite = bg;
                task = 0;
                score = 0;
                break;
        }
        setActiveTask(num);
    }
    
    public void addScore()
    {
        if (score < 4) score++;
    }
    public void removeScore()
    {
        if (score > 0) score--;
    }
    // Update is called once per frame
    void OnMouseDown()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            if (!FPSC.observing && FPSC.canObserve)
            {
                posStart = mainCam.transform.position;
                rotStart = mainCam.transform.rotation;
                
                /*if (missionChanger && !activated)
                {
                    if (missionShower.GetComponent<MissionProgress>().getCurrentMission() == 1)
                    {
                        int missionNum = 2;
                        mainCam.GetComponent<AudioSource>().PlayOneShot(missionSound);
                        missionShower.GetComponent<MissionProgress>().changeMission(missionNum);
                        activated = true;
                    }
                }*/
                FPSC.observing = true;
                FPSC.canObserve = false;
                //monitorCanvas.SetActive(true);
                Vector3 newPos = cameraPlace.transform.position;
                Quaternion newRot = cameraPlace.transform.rotation;
                StartCoroutine(LerpFromTo(mainCam.transform.position, newPos, mainCam.transform.rotation, newRot, 1f, false));
                //this.gameObject.transform.position = MainCam.transform.position;
                //this.gameObject.transform.rotation = MainCam.transform.rotation;

                //this.gameObject.transform.Translate(0.0f, 0.0f, 0.3f);
                //float newz = this.gameObject.transform.eulerAngles.z + 90;


                //// move away from the camera 
                //this.gameObject.transform.LookAt(MainCam.transform.position);
                //this.gameObject.transform.Rotate(0, 0, newz);
                
                //render.material = observeMaterial;
            }
            else
            {
                /*this.gameObject.transform.position = posStart;
                this.gameObject.transform.rotation = rotStart;
                FPSC.observing = false;*/
                //render.material = originalMaterial;
            }
        }
    }

    public void standUp()
    {
        StartCoroutine(LerpFromTo(cameraPlace.transform.position, posStart, cameraPlace.transform.rotation, rotStart, 1f, true));
        //Debug.Log("yeer");
        //monitorCanvas.SetActive(false);
    }

    IEnumerator LerpFromTo(Vector3 pos1, Vector3 pos2, Quaternion rot1, Quaternion rot2, float duration, bool controlBack)
    {
        //Debug.Log("yeet");
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            mainCam.transform.position = Vector3.Lerp(pos1, pos2, t / duration);
            mainCam.transform.rotation = Quaternion.Lerp(rot1, rot2, t / duration);
            Debug.Log("Load " + t);
            yield return 0;
        }
        mainCam.transform.rotation = rot2;
        mainCam.transform.position = pos2;
        if (controlBack) // vissza
        {
            FPSC.observing = false;
            FPSC.canObserve = true;
        }
        else { // oda
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
