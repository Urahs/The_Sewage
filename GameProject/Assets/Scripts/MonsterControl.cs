using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{


    public GameObject target;

    public float changeDirectionTime;
    public float maxTurnAngle;
    public float walkSpeedCoefficient;
    public float turnSpeed;
    public float maxAttackRadius;
    public float runAccelerationCoefficient;

    private float changeDirectionTimeCounter;
    private float turnAngle = 0;

    private Animator animator;
    private Rigidbody rb;

    //BOOLS
    private bool isTurningLeft = false;
    private bool isTurningRight = false;

    private int turnDirection = 0;//0: Right, 1: Left



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        changeDirectionTimeCounter = changeDirectionTime;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = calculateDistance();
        //Player is in safe zone
        if (maxAttackRadius < distance)
        {
            wander();
        }
        //Player is in attack zone
        else
        {
            float howClose = (maxAttackRadius - distance) / maxAttackRadius;
            //Run toward to player
            if(howClose < 0.95)
            {
                runTowardToVictim(howClose);
            }
            //Attack to player
            else
            {
                attackToVictim();
            }

        }
    }

    private float calculateDistance()
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }

    private void attackToVictim()
    {
        animator.Play("bite&up");
    }

    private void runTowardToVictim(float howClose)
    {
        //animator.SetFloat("runSpeed", 1 )
        animator.Play("run");
        transform.LookAt(target.transform);
        rb.velocity = transform.forward * (walkSpeedCoefficient + walkSpeedCoefficient * howClose * runAccelerationCoefficient);
    }

    private void wander()
    {
        animator.Play("walk");
        changeDirectionTimeCounter -= Time.deltaTime;

        //Change direction
        if (changeDirectionTimeCounter < 0)
        {
            isTurningRight = false; 
            isTurningLeft = false;
            turnDirection = Random.Range(0, 2);
            turnAngle = Random.Range(0, maxTurnAngle);
            if (turnDirection == 0) isTurningRight = true;
            if (turnDirection == 1) isTurningLeft = true;
            changeDirectionTimeCounter = changeDirectionTime;
        }

        //Turn right slowly
        if (isTurningRight)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f,  turnAngle, 0f), turnSpeed *Time.deltaTime);
        }
        //Turn left slowly
        else if (isTurningLeft)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, -turnAngle, 0f), turnSpeed * Time.deltaTime);
        }

        //WALK
        rb.velocity = transform.forward * walkSpeedCoefficient;
    }


    /*
    public GameObject targetObject;
    public float monsterZoneRadius = 2f;
    public float walkSpeed = 1f;
    public float maxTurnAngle = 90f;
    public float changeDirectionTime = 1f;
 
    private Rigidbody rb;
    private bool isTurning = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeCounter = changeDirectionTime;
        turnTimeCounter = turnTime;
    }

    // Update is called once per frame
    void Update()
    {
        wander();
    }

    //calculateDistanceBetweenMonsterAndTarget()
    private float calculateDistance()
    {
        return Vector3.Distance(transform.position, targetObject.transform.position);
    }

    private void wander()
    {
        timeCounter -= Time.deltaTime;
        turnTimeCounter -= Time.deltaTime;
        //WALK
        if (timeCounter > 0 && isTurning == false)
        {
            rb.AddForce(transform.forward * walkSpeed, ForceMode.Acceleration);
            rb.velocity = transform.forward * walkSpeed;
            //transform.position = transform.position + transform.forward * walkSpeed * Time.deltaTime;
        }
        //TURN
        else
        {
            int randomVal = Random.Range(0, 2);
            //TURN RIGHT
            if (randomVal == 0)
            {
                isTurning = true;
                //transform.Rotate(new Vector3(0, Random.Range(0f, maxTurnAngle), 0f), Space.World);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, Random.Range(0f, maxTurnAngle), 0f), Time.deltaTime * turnTime);
                turnTimeCounter = turnTime;
            }
            //TURN LEFT
            else
            {
                isTurning = true;
                //transform.Rotate(new Vector3(0, Random.Range(-maxTurnAngle, 0f), 0f), Space.World);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, Random.Range(-maxTurnAngle, 0f), 0f), Time.deltaTime * turnTime);
                turnTimeCounter = turnTime;
            }
            timeCounter = changeDirectionTime;
        }
    }*/
}
