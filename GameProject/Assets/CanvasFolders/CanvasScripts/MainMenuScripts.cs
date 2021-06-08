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
    public GameObject MainMenuCanvasChildren;
    public GameObject pauseMenu;
    public GameObject helpCanvas;
    public GameObject infoCanvas;
    public GameObject guncamCanvas;
    public CanvasController canvasController;
    public CameraScript cameraScript;
    public ScreenShotCamera screenShotCamera;
    public TakePhoto takePhoto;
    public SwitchWeapon switchWeapon;
    public GameObject optionsCanvas;
    


    Vector3 pos;
    Quaternion rot = new Quaternion();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        //RESET OPERATIONS

        //monster
        monster.SetActive(true);
        monster.GetComponent<MonsterNavMeshControl>().health = 3;
        monster.GetComponent<CapsuleCollider>().enabled = true;
        PlayerPrefs.SetInt("monsterDead", -1);

        //player
        PlayerPrefs.SetInt("gunTotal", 2);
        PlayerPrefs.SetInt("gunCurrent", 0);
        cameraScript.ammo = 2;
        cameraScript.current = 1;
        screenShotCamera.photoCounter = 0;
        takePhoto.photoNum[0] = -1;
        takePhoto.photoNum[1] = -1;
        takePhoto.photoNum[2] = -1;
        switchWeapon.Initial();


        canvasController.ActivePlayerCanvas();
        player.SetActive(true);
        
        rot = Quaternion.Euler(0f, -43.054f, 0f);  
        player.transform.rotation = rot;
        player.transform.rotation = rot;

        player.transform.position = new Vector3(599.9041f, -66.40546f, -597.6862f);
        
        
        

        pos = new Vector3(-44.7f, -78f, -48.2f);
        monster.transform.position = pos;
        monster.SetActive(true);
        
        guncamCanvas.SetActive(true);
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



    

    public void Help(){
        helpCanvas.SetActive(true);
        MainMenuCanvasChildren.SetActive(false);
    }

    public void HelpBack(){
        helpCanvas.SetActive(false);
        MainMenuCanvasChildren.SetActive(true);
    }

    public void Options(){
        optionsCanvas.SetActive(true);
        MainMenuCanvasChildren.SetActive(false);
    }

    public void OptionsBack(){
        optionsCanvas.SetActive(false);
        MainMenuCanvasChildren.SetActive(true);
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
