using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public int selected = 0;
    public bool lockGun = false;
    public Animator animator;

    public GameObject lamp;
    public GameObject cam;
    public GameObject gun;
    public GameObject gunLamp;


    void Awake()
    {
        Initial();
    }

    public void Initial(){
        selected = 0;
        lockGun = false;
        lamp.SetActive(true);
        gun.SetActive(false);
        cam.SetActive(false);
        gunLamp.SetActive(false);
        animator.Play("lampForward");
    }

    void Update()
    {
        int prev = selected;

        if(Input.GetKeyDown(KeyCode.Alpha1))
            selected = 0;
        if(Input.GetKeyDown(KeyCode.Alpha2))
            selected = 1;
        if(Input.GetKeyDown(KeyCode.Alpha3) && lockGun)
            selected = 2;
        if(Input.GetKeyDown(KeyCode.Alpha4) && lockGun)
            selected = 3;

        if(prev != selected)
            SelectWeapon(prev, selected);
    }

    void SelectWeapon(int prev, int selected)
    {
        //int i=0;
        
        GameObject temp = null;

        if(selected == 0)   temp = lamp;
        else if(selected == 1)   temp = cam;
        else if(selected == 2)   temp = gun;
        else if(selected == 3)   temp = gunLamp;
        



        if(prev==0){
            animator.Play("lampBack");
            StartCoroutine(DestroyObj(lamp, temp));
        }
        else if(prev==1){
            animator.Play("camBack");
            StartCoroutine(DestroyObj(cam, temp));
        }
        else if(prev==2){
            animator.Play("gunBack");
            StartCoroutine(DestroyObj(gun, temp));
        }
        else if(prev==3){
            animator.Play("gunLampBack");
            StartCoroutine(DestroyObj(gun, temp));
        }



        

        Invoke("CallForwardAnim", .5f);

        
        
        /* foreach (Transform weapon in transform){
            if (i==selected)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            
            i++;
        } */
    }

    void CallForwardAnim(){
        if(selected == 1){
            animator.Play("camForward");
        }
        else if(selected == 0){
            animator.Play("lampForward");
        }
        else if(selected == 2){
            animator.Play("gunForward");
        }
        else if(selected == 3){
            animator.Play("gunLampForward");
        }
    }

    
    IEnumerator DestroyObj(GameObject go, GameObject go2)
    {
        yield return new WaitForSeconds(0.5f);
        go.SetActive(false);
        go2.SetActive(true);
    }


}
