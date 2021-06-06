using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float destryoTime = 10f;
    
    void Update()
    {
        Destroy(gameObject, destryoTime);
    }


}
