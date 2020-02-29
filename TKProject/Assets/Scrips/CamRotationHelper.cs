using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotationHelper : MonoBehaviour
{

    private Quaternion lookRotationVar;
    public GameObject cameraHolder;
    // Update is called once per frame
    void Update()
    {
        lookRotationVar = lookRotationVar * Quaternion.Inverse(this.transform.rotation);
        lookRotationVar = lookRotationVar * cameraHolder.transform.rotation;
        Vector3 newRotation = lookRotationVar.eulerAngles;
        cameraHolder.transform.localEulerAngles = newRotation;
    }
}
