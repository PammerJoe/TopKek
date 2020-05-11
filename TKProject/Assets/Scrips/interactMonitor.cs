using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class interactMonitor : MonoBehaviour
{
    public bool missionChanger;
    private Material originalMaterial;
    private Renderer render;
    public GameObject cameraRig;
    private Vector3 posStart;
    private Quaternion rotStart;
    public GameObject cameraPlace;
    public GameObject missionShower;
    public AudioClip missionSound;
    public GameObject mainCam;
    private bool activated;
    FirstPersonController FPSC;
    public GameObject monitorCanvas;
    // Start is called before the first frame update
    void Start()
    {
        //render = GetComponent<Renderer>();
        //posStart = transform.position;
        //rotStart = transform.rotation;
        //originalMaterial = render.material;
        //activated = false;
        FPSC = cameraRig.GetComponent<FirstPersonController>();
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
                monitorCanvas.SetActive(true);
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
        Debug.Log("yeer");
        monitorCanvas.SetActive(false);
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
