﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroduceTrigger : MonoBehaviour
{
    public GameObject infoCanvas;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;

            infoCanvas.SetActive(true);
            Destroy(gameObject);
        }   



    }


}