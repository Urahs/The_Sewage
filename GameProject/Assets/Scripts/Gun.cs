using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public Animator animator;

    void Start()
    {
        
    }

    void Update()
    {

        /* flag conditions:
            0 - idle
            1 - walk
            2 - run
            3 - reload
            4 - fire
        */ 

        //FIRE
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }


        //FIRE
        if(animator.GetInteger("flag") == 4){
            if(Run()){
                animator.SetInteger("flag", 2);
            }
            else if (Walk()){
                animator.SetInteger("flag", 1);
            }
            else{
                animator.SetInteger("flag", 0);
            }
        }


        //RELOAD
        if(animator.GetInteger("flag") == 3){
            if (Walk()){
                animator.SetInteger("flag", 1);
            }
            else{
                animator.SetInteger("flag", 0);
            }
        }

        //IDLE
        if (animator.GetInteger("flag") == 0){
            
            //run
            if(Run()){
                animator.SetInteger("flag", 2);
            }
            //reload
            else if(Reload()){
                animator.SetInteger("flag", 3);
            }
            //fire
            else if(Fire()){
                animator.SetInteger("flag", 4);
            }
            //walk
            else if (Walk()){
                animator.SetInteger("flag", 1);
            }
        }

        //WALK
        if(animator.GetInteger("flag") == 1){

            //run
            if(Run()){
                animator.SetInteger("flag", 2);
            }
            //reload
            else if(Reload()){
                animator.SetInteger("flag", 3);
            }
            //fire
            else if(Fire()){
                animator.SetInteger("flag", 4);
            }
            //walk
            else if (Walk()){
                animator.SetInteger("flag", 1);
            }
            else {
                animator.SetInteger("flag", 0);
            }
        }

        // RUN
        if(animator.GetInteger("flag") == 2){
            
            //fire
            if(Fire()){
                animator.SetInteger("flag", 4);
            }
            //run
            else if(Run()){
                animator.SetInteger("flag", 2);
            }
            //walk
            else if (Walk()){
                animator.SetInteger("flag", 1);
            }
            
            else {
                animator.SetInteger("flag", 0);
            }
        }

        




    }

    void Shoot(){
        animator.SetInteger("flag", 4);
        muzzleFlash.Play();
        
    }

    bool Run(){
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            return true;
        return false;
    }
    bool Walk(){
        if ((Input.GetAxis("Vertical") != 0) || (Input.GetAxis("Horizontal") != 0))
            return true;
        return false;
    }
    bool Idle(){
        return false;
    }
    bool Reload(){
        if(Input.GetKeyDown(KeyCode.R))
            return true;
        return false;
    }
    bool Fire(){
        if (Input.GetButtonDown("Fire1"))
            return true;
        return false;
    }
    
}
