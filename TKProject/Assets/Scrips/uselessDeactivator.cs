using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uselessDeactivator : MonoBehaviour
{
    // Start is called before the first frame update


    void OnBecameInvisible()
    {
        enabled = false;
    }

    void OnBecameVisible()
    {
        enabled = true;
    }
}
