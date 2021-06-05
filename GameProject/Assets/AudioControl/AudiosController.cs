using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosController : MonoBehaviour
{
    //PUBLIC GLOBAL VARIABLES<
    public AudioSource[] audios;
    //PUBLIC GLOBAK VARIABLES>

    public void playSound(int soundId)
    {
        audios[soundId].Play();
    }


}
