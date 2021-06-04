using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{

    public Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
        Walk();
        Run();
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
