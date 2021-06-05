using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class VideoTimer : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.time > 7)
        {
            Destroy(gameObject);
        }
    }
}
