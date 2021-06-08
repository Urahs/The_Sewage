using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterNavMeshControl : MonoBehaviour
{
    //PRIVATE GLOBAL VARIABLES
    private NavMeshAgent navMeshAgent;
    private float wanderTimeCounter;
    private Animator animator;
    private bool killVictim = false;

    public GameObject PlayerCanvas;
    public GameObject MainMenuCanvas;
    public GameObject scaryVideo;
    public CanvasController canvasController;

    public GameLogic gameLogic;

    
    

    //PUBLIC GLOBAL VARIABLES
    public GameObject victimTarget;
    public float runSpeed = 100;
    public int health = 1;

    public float walkSpeed = 50;
    public float maxAttackDistance;
    public float wanderTime = 10;
    public float wanderRadius = 40;
    [Range(0.01f, 0.99f)]
    public float ClosenessPercentageToAttack = 0.9f;
    [Range(0.00f, 1f)]
    public float walkAnimationSpeed = 0.5f;
    [Range(0.00f, 1f)]
    public float runAnimationSpeed = 0.5f;




    void Start()
    {

        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        wanderTimeCounter = wanderTime;

    }

    void Update()
    {
        //SET ANIMATION SPEED
        animator.SetFloat("walkAnimationSpeed", walkAnimationSpeed);
        animator.SetFloat("runAnimationSpeed", runAnimationSpeed);
        if (killVictim && health>0)
        {
            //animator.Play("bite&up");
            //animator.Play("attack");

            
            gameLogic.reloadLevel = true;
            PlayerPrefs.SetInt("restartScene", PlayerPrefs.GetInt("restartScene")+1);
            PlayerCanvas.SetActive(false);
            victimTarget.SetActive(false);
            canvasController.PlayScaryVideo();
            killVictim = false;
            gameObject.SetActive(false);
            
            
        }
        else if(health>0)
        {
            wanderTimeCounter += Time.deltaTime;
            float distance = distanceFromVictim();
            //SAFE
            if (distance > maxAttackDistance)
            {
                //Debug.Log("WANDER");
                wander();
            }
            //NOT SAFE
            else
            {
                attack((maxAttackDistance - distance) / maxAttackDistance);
            }
        }



        if(health <= 0){
            PlayerPrefs.SetInt("monsterDead", 1);
            animator.Play("death");
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezeAll;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }


    }

    private void attack(float howClose)
    {
        //RUN TOWARD TO VICTIM
        if(howClose < ClosenessPercentageToAttack)
        {
            //Debug.Log("RUN");
            navMeshAgent.speed = runSpeed;
            animator.Play("run");
            navMeshAgent.SetDestination(victimTarget.transform.position);
        }
        //KILL VICTIM
        else
        {
            Debug.Log("ATTACK");
            animator.Play("attack");
            killVictim = true;
            //navMeshAgent.SetDestination(victimTarget.transform.position);
        }

    }
    
    private void wander()
    {
        if(wanderTimeCounter >= wanderTime)
        {
            animator.Play("idle");
            Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
            randomDirection += transform.position;
            NavMeshHit navMeshHit;
            NavMesh.SamplePosition(randomDirection, out navMeshHit, wanderRadius, -1);
            navMeshAgent.SetDestination(navMeshHit.position);
            wanderTimeCounter = 0;
        }
        else
        {
            if (navMeshAgent.remainingDistance >= 1)
            {
                animator.Play("walk");
            }
            else
            {
                animator.Play("idle");
            }
            navMeshAgent.speed = walkSpeed;
        }
    }

    private float distanceFromVictim()
    {
        return Vector3.Distance(transform.position, victimTarget.transform.position);
    }



    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "Bullet"){   
            other.transform.tag = "Untagged";
            health--;
        }
    }


}
