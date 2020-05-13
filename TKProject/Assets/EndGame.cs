using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FPSController, finishCanvas;
    FirstPersonController FPSC;
    bool finished = false;
    void Start()
    {
        FPSC = FPSController.GetComponent<FirstPersonController>();

    }

    


    // Update is called once per frame
    void HitByRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FPSC.observing = true;
            FPSC.canObserve = false;
            finished = true;
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        CanvasGroup cg = finishCanvas.GetComponent<CanvasGroup>();
        while (cg.alpha < 1)
        {
            cg.alpha += Time.deltaTime / 2;
            yield return null;
        }
        cg.interactable = false;
        yield return null;
    }
}
