using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class observeObject : MonoBehaviour
{
    public Material observeMaterial;
    public bool missionChanger;
    private Material originalMaterial;
    private Renderer render;
    public GameObject MainCam;
    public GameObject FPSController;
    private Vector3 posStart;
    private Quaternion rotStart;

    public GameObject missionShower;
    public AudioClip missionSound;
    public GameObject mainCam;
    private bool activated;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        posStart = transform.position;
        rotStart = transform.rotation;
        originalMaterial = render.material;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        FirstPersonController FPSC = FPSController.GetComponent<FirstPersonController>();
        if (Input.GetMouseButtonDown(0) && !FPSC.showMenu)
        {
            
            if (!FPSC.observing && FPSC.canObserve)
            {
                if (missionChanger && !activated)
                {
                    if (missionShower.GetComponent<MissionProgress>().getCurrentMission() == 1)
                    {
                        int missionNum = 2;
                        mainCam.GetComponent<AudioSource>().PlayOneShot(missionSound);
                        missionShower.GetComponent<MissionProgress>().changeMission(missionNum);
                        activated = true;
                    }
                }
                this.gameObject.transform.position = MainCam.transform.position;
                this.gameObject.transform.rotation = MainCam.transform.rotation;
                
                this.gameObject.transform.Translate(0.0f, 0.0f, 0.3f);
                float newz = this.gameObject.transform.eulerAngles.z + 90;
                

                // move away from the camera 
                this.gameObject.transform.LookAt(MainCam.transform.position);
                this.gameObject.transform.Rotate(0, 0, newz);
                FPSC.observing = true;
                FPSC.canObserve = false;
                render.material = observeMaterial;
            }
            else {
                
                this.gameObject.transform.position = posStart;
                this.gameObject.transform.rotation = rotStart;
                FPSC.observing = false;
                render.material = originalMaterial;
            }
        }
    }
}
