using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEscMenu : MonoBehaviour
{
    public GameObject defaultCanvas;
    public GameObject pauseMenu;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape)){

            defaultCanvas.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }
}
