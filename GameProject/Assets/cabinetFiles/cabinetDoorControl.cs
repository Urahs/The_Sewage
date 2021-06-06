using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabinetDoorControl : MonoBehaviour
{

    //PUBLIC GLOBAL VARIABLES<
    //[Range(0f, 180f)]
    //public float doorMaxOpenAngle = 45f;
    private AudiosController audiosController;
    //PUBLIC GLOBAK VARIABLES>

    private bool isOpen = false;
    //private GameObject leftDoor;
    //private GameObject rightDoor;
    public Animator animator;

    private void Awake()
    {
        //leftDoor = transform.GetChild(0).gameObject;
        //rightDoor = transform.GetChild(1).gameObject;
        audiosController = GameObject.FindGameObjectWithTag("AudioControlObject").GetComponent<AudiosController>();
    }

    public void doorsControl()
    {
        if (isOpen)
        {
            closeDoors();
            isOpen = false;
        }
        else
        {
            openDoors();
            isOpen = true;
        }
    }

    private void closeDoors()
    {
        animator.Play("cabinetDoorsClose");
        audiosController.playSound(0);
        //leftDoor.transform.Rotate(new Vector3(0f, -doorMaxOpenAngle, 0f));
        //rightDoor.transform.Rotate(new Vector3(0f, doorMaxOpenAngle, 0f));
    }

    private void openDoors()
    {
        animator.Play("cabinetDoorsOpen");
        audiosController.playSound(0);
        //leftDoor.transform.Rotate(new Vector3(0f, doorMaxOpenAngle, 0f));
        //rightDoor.transform.Rotate(new Vector3(0f, -doorMaxOpenAngle, 0f));
    }
}
