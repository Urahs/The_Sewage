using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    [SerializeField] public GameObject projectile;
    [SerializeField] public float launchVelocity = 700f;
    [SerializeField] public float launchVelocityUp = -100;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FireBullet() {
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, -launchVelocityUp));
    }

}
