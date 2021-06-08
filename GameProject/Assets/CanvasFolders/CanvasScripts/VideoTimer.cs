using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class VideoTimer : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public float waitTime = 3f;
    private void Awake()
    {
        if(PlayerPrefs.GetInt("restartScene") != -1){
            if(gameObject.transform.name == "Video Player Intro")
                Destroy(gameObject);
        }
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.time > waitTime)
        {
            Destroy(gameObject);
        }
    }
}
