using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWanderTargetControl : MonoBehaviour
{
    //PUBLIC GLOBAL VARIABLES
    public float turnSpeedCoefficient = 30;
    public float speedCoefficient = 360;

    //PRIVATE GLOBAL VARIABLES
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, turnSpeedCoefficient * Time.deltaTime, 0f), Space.World);
        rb.velocity = transform.forward * speedCoefficient;
        Debug.DrawLine(transform.position, transform.position + transform.forward * 100f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.Rotate(new Vector3(0f,  transform.rotation.y + 180, 0f), Space.World);
    }


    /*
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        clldr = GetComponent<Collider>();
    }

    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * 100f);
        transform.Rotate(new Vector3(0f, turnSpeedCoefficient * Time.deltaTime, 0f), Space.World);
        rb.velocity = transform.forward * speedCoefficient;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "monster" || collision.transform.tag == "player")
        {
            Debug.Log("asdasd");
            Physics.IgnoreCollision(clldr, collision.collider);
        }
    }
    */
}
