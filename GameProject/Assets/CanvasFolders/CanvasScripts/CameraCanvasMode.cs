using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCanvasMode : MonoBehaviour
{
    //PUBLIC GLOBAL VARIABLES<
    [Range(0f, 10f)]
    public float cameraRotateSpeed = 1;
    //PUBLIC GLOBAL VARIABLES>
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, cameraRotateSpeed * Time.deltaTime, 0f), Space.World);
    }
}
