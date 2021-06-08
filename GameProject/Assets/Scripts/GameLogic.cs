using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GameLogic : MonoBehaviour
{
    public Canvas canvasGunCam;
    public Canvas canvasCam;
    public SwitchWeapon switchWeapon;
    public Camera fpsCam;
    public CameraScript cameraScript;
    public AudiosController audiosController;
    public MonsterNavMeshControl monsterScript;
    
    public bool reloadLevel;

    public float pickUpRange = 38f;

    void Awake(){
        reloadLevel = false;
        PlayerPrefs.SetInt("monsterDead", -1);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("gunTotal", 2);
        PlayerPrefs.SetInt("gunCurrent", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(fpsCam.transform.position, fpsCam.transform.position+fpsCam.transform.forward*pickUpRange);
        UpdateCanvas();
        PickUpObject();


        CheatKeys();
    }

    private void PickUpObject()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, pickUpRange)){
                
                PickUpObject target = hit.transform.GetComponent<PickUpObject>();
                
        
                switch (hit.transform.tag)
                {
                    case "pickUpGun":
                        target.PickUp();
                        if(switchWeapon.lockGun)
                            PlayerPrefs.SetInt("gunTotal", PlayerPrefs.GetInt("gunTotal")+1);
                        else
                            switchWeapon.lockGun = true;
                        audiosController.playSound(8);
                        break;
                    case "pickUpBullet":
                        PlayerPrefs.SetInt("gunTotal", PlayerPrefs.GetInt("gunTotal")+1);
                        target.PickUp();
                        audiosController.playSound(8);
                        break;
                    case "pickUpFilm":
                        target.PickUp();
                        cameraScript.ammo++;
                        audiosController.playSound(8);
                        break;
                    case "cabinet":
                        cabinetDoorControl targetCabinet = hit.transform.GetComponent<cabinetDoorControl>();
                        targetCabinet.doorsControl();
                        break;
                    default:
                        break;
                }
            }

            



            
        }
    }



    private void UpdateCanvas()
    {
        //lamp
        if(switchWeapon.selected == 0){
            canvasCam.enabled = false;
            canvasGunCam.enabled = false;
        }
        //cam
        else if(switchWeapon.selected == 1){
            canvasCam.enabled = true;
            canvasGunCam.enabled = true;
        }
        //pistol
        else if(switchWeapon.selected == 2 || switchWeapon.selected == 3){
            canvasCam.enabled = false;
            canvasGunCam.enabled = true;
        }
        
    }


    public void PauseSound(int soundId){
        audiosController.PauseSound(soundId);
    }

    public void CheatKeys(){
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            if(monsterScript.runSpeed == 100f)  monsterScript.runSpeed = 1f;
            else                                monsterScript.runSpeed = 100f;
        }
    }
    
}
