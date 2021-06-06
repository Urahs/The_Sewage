using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{

    public GameObject player;
    public GameObject monster;
    public GameObject defaultCanvas;
    public GameObject MainMenuCanvas;
    public GameObject pauseMenu;
    public GameObject infoCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        player.SetActive(true);
        monster.SetActive(true);
        defaultCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
    }

    public void Resume(){
        Time.timeScale = 1f;
        defaultCanvas.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }



    public void Options(){

    }

    public void Help(){

    }

    public void ExitGame(){
        Application.Quit();
    }


    public void Skip(){
        infoCanvas.SetActive(false);
        Time.timeScale = 1f;
        defaultCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
