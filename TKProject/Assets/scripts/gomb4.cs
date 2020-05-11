using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gomb4 : MonoBehaviour
{
    public Renderer Rend;
    public GameObject cube1, cube2, cube3, cube4, cube5, firstDoor;
    public GameObject szoveg;
    private Animator _animator;
    bool mindenzold = false;
    public bool pressed;
    public GameObject missionPanel;
    private bool completedMission;

    void Start()
    {
        _animator = firstDoor.GetComponent<Animator>();
        Rend = GetComponent<Renderer>();
        Rend.enabled = true;
        pressed = false;
        completedMission = false;
    }

    void Update()
    {
        gomb1 gomb_1 = cube1.GetComponent<gomb1>();
        gomb2 gomb_2 = cube2.GetComponent<gomb2>();
        gomb3 gomb_3 = cube3.GetComponent<gomb3>();
        gomb5 gomb_5 = cube5.GetComponent<gomb5>();
        if (gomb_2.pressed == false)
        {
            pressed = false;
        }
        if (gomb_1.pressed == true &&
            gomb_5.pressed == true &&
            gomb_3.pressed == true &&
            gomb_2.pressed == true &&
            pressed == true)
        {
            mindenzold = true;
        }
        if (mindenzold == true && completedMission == false)
        {
            completedMission = true;
            _animator.SetBool("Locked", false);
            _animator.SetBool("Opened", true);
            szoveg.SetActive(true);
            missionPanel.GetComponent<MissionProgress>().changeMission(3);

        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gomb1 gomb_1 = cube1.GetComponent<gomb1>();
            gomb2 gomb_2 = cube2.GetComponent<gomb2>();
            gomb3 gomb_3 = cube3.GetComponent<gomb3>();
            gomb4 gomb_4 = cube4.GetComponent<gomb4>();
            GetComponent<Animator>().Play("cubePressed");
            if (gomb_2.pressed == true)
            {
                pressed = true;
            }
            else if (gomb_2.pressed == false)
            {
                pressed = false;
                gomb_1.pressed = false;
            }
        }
    }
}
