using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class lookCloser : MonoBehaviour
{
    public GameObject cameraRig;
    public GameObject cameraPlace;
    public GameObject mainCam;
    private Vector3 posStart;
    private Quaternion rotStart;
    FirstPersonController FPSC;
    bool observed;
    // Start is called before the first frame update
    void Start()
    {
        FPSC = cameraRig.GetComponent<FirstPersonController>();
    }

    void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (!FPSC.observing && FPSC.canObserve && !observed)
            {
                observed = true;
                posStart = mainCam.transform.position;
                rotStart = mainCam.transform.rotation;
                FPSC.observing = true;
                FPSC.canObserve = false;
                Vector3 newPos = cameraPlace.transform.position;
                Quaternion newRot = cameraPlace.transform.rotation;
                StartCoroutine(LerpFromTo(mainCam.transform.position, newPos, mainCam.transform.rotation, newRot, 1f, false));
                
            } else
            {
                observed = false;
                standUp();
            }
        }
    }

    public void standUp()
    {
        StartCoroutine(LerpFromTo(cameraPlace.transform.position, posStart, cameraPlace.transform.rotation, rotStart, 1f, true));
    }


    IEnumerator LerpFromTo(Vector3 pos1, Vector3 pos2, Quaternion rot1, Quaternion rot2, float duration, bool controlBack)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            mainCam.transform.position = Vector3.Lerp(pos1, pos2, t / duration);
            mainCam.transform.rotation = Quaternion.Lerp(rot1, rot2, t / duration);
            Debug.Log("Load " + t);
            yield return 0;
        }
        mainCam.transform.rotation = rot2;
        mainCam.transform.position = pos2;
        if (controlBack)
        {
            FPSC.observing = false;
            FPSC.canObserve = true;
        }
    }
}
