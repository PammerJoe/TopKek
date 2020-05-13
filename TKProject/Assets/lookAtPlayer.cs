using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    bool gotKeys = false;
    void Update()
    {
        if (gotKeys)
        {
            var lookPos = Camera.main.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 1);
        }
    }

    // Update is called once per frame
    void LookAtPlayer()
    {
        gotKeys = true;
    }
}
