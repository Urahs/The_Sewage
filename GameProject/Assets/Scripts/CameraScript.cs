using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public Text ammoText;
    public Text currentText;
    public Camera mainCam;
    public Animator animator;
    public Animator animatorLight;
    public TakePhoto takePhoto;
    public bool focus;
    public int ammo = 2;            // >>>>>>>>>>>>>>>>> şuraya el at sonra
    int current = 1;
    float range = 100f;

    // Start is called before the first frame update
    void Start()
    {
        focus = true;
    }

    // Update is called once per frame
    void Update()
    {

        ammoText.text = ammo.ToString();
        currentText.text = current.ToString();


        if(!focus)
            animatorLight.SetInteger("flag", 0);

        if(current>0)
            focus = true;
        else
            focus = false;


        if(!Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButton(1) && focus){
            animator.SetInteger("flag", 3);
            PlayerPrefs.SetInt("focusing", 1);
            takePhoto.Charge();
            animatorLight.SetInteger("flag", 1);
            if(takePhoto.GetValue() == 100f){
                if(Input.GetMouseButtonDown(0)){
                    RaycastHit raycastHit;
                    animatorLight.SetInteger("flag", 2);
                    focus = false;
                    
                    current--;
                    if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out raycastHit, range))
                        if(raycastHit.transform.name == "Monster"){
                            takePhoto.CallTakeSnapShot();
                            takePhoto.temp = true;
                            takePhoto.ResetBars();
                        }
                        else
                            takePhoto.temp = false;
                    return;
                }
            }
                
            return;
        }
        if(!Input.GetMouseButton(1) || !focus)
        {
            Release();
        }
    }

    void Release()
    {
        PlayerPrefs.SetInt("focusing", 0);
        animatorLight.SetInteger("flag", 0);
        takePhoto.ResetBars();
        
        Idle();
        Walk();
        Run();
        Reload();
    }


    /*
    void SetLightAnimDefault(){
        animatorLight.SetInteger("flag", 0);
    }
    */



    /*
    0- idle
    1- walk
    2- run
    3- focus
    */
    void Reload(){
        if(Input.GetKeyDown(KeyCode.R))
            if(ammo>0 && current!=1){
                ammo--;
                current++;
                animator.SetInteger("flag", 4);
            }
    }
    void Idle(){
        if ((Input.GetAxis("Vertical") == 0) && (Input.GetAxis("Horizontal") == 0)){
            animator.SetInteger("flag", 0);
        }
    }
    void Walk(){
        if ((Input.GetAxis("Vertical") != 0) || (Input.GetAxis("Horizontal") != 0)){
            animator.SetInteger("flag", 1);
        }
    }
    void Run(){
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)){
            animator.SetInteger("flag", 2);
        }
    }
}
