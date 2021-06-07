using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CanvasController : MonoBehaviour
{
   
    public GameObject Jumpscare;
    public GameObject MainCanvas;
    public GameObject playerCanvas;
    public GameObject endGame;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayScaryVideo(){
        Jumpscare.SetActive(true);
        Invoke("BackToMainMenu", 4f);
    }

    public void BackToMainMenu(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Jumpscare.SetActive(false);
        endGame.SetActive(false);
        MainCanvas.SetActive(true);
    }


    public void ActivePlayerCanvas(){
        playerCanvas.SetActive(true);
    }

    

}
