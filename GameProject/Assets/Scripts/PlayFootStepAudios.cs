using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootStepAudios : MonoBehaviour
{
    public AudiosController audiosController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (((Input.GetAxis("Vertical") == 1) || (Input.GetAxis("Horizontal") == 1) || (Input.GetAxis("Horizontal") == -1) || (Input.GetAxis("Vertical") == -1)) && (Input.GetKey(KeyCode.LeftShift))){
            audiosController.StopAudios(10);
            audiosController.playIfNotPlay(9);
        }
        else if ((Input.GetAxis("Vertical") == 1) || (Input.GetAxis("Horizontal") == 1) || (Input.GetAxis("Horizontal") == -1) || (Input.GetAxis("Vertical") == -1)){
            audiosController.StopAudios(9);
            audiosController.playIfNotPlay(10);
        }
        else{
            audiosController.StopAudios(9);
            audiosController.StopAudios(10);
        }
    }
}
