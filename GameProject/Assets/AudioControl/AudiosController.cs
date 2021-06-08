using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosController : MonoBehaviour
{
    
    private AudioSource[] audios;

    void Awake(){
        audios = GetComponents<AudioSource>();
    }

    public void playSound(int soundId)
    {
        audios[soundId].Play();
    }

    public void playIfNotPlay(int soundId){
        if(!audios[soundId].isPlaying)
            audios[soundId].Play();
    }
    
    public void StopAudios(int soundId){
        audios[soundId].Stop();
    }

    public void PauseSound(int soundId){
        audios[soundId].Pause();
    }

}

/* 
0 - cabinetSound    +
1 - CameraFlash     +
2 - clickButton
3 - FlareFire       +
4 - FlareReload     +
5 - MasterMusic
6 - monsterAttack   +
7 - monsterIdle     +
8 - pickUpItem      +
9 - runSound        +
10 - walkSound      +
*/