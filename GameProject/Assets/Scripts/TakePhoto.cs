using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    public ScreenShotCamera snapCam;
    
    public Text photoText;
    public RawImage[] rawImages;
    public int[] photoNum;
    

    
    [SerializeField] float consumeAmount = 0.1f;
    public DelayBar delayBarRight;
    public DelayBar delayBarLeft;


    void Start(){
        delayBarRight.SetMaxValue(100);
        delayBarRight.SetValue(0);
        delayBarLeft.SetMaxValue(100);
        delayBarLeft.SetValue(0);
        delayBarLeft.ResetSlider();
        delayBarRight.ResetSlider();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            //snapCam.CallTakeSnapShot();               // take photo
            Invoke("CallmePls", 2.0f);                  // upload photo
        }

        if(photoNum[2] == 0){
            photoText.text = "3";
        }
        else if(photoNum[1] == 0){
            photoText.text = "2";
        }
        else if(photoNum[0] == 0){
            photoText.text = "1";
        }
        else{
            photoText.text = "0";
        }
        



        /*
        if(Input.GetMouseButton(1)){
            delayBarRight.IncreaseValue(consumeAmount);
            delayBarLeft.IncreaseValue(consumeAmount);
        }        
        if(Input.GetKeyDown(KeyCode.R)){
            delayBarRight.SetValue(0);
            delayBarLeft.SetValue(0);
        }
        */    
    }

    //took photo
    public void CallTakeSnapShot(){
        snapCam.CallTakeSnapShot();
    }

    public void ResetBars(){
        delayBarRight.SetValue(0);
        delayBarLeft.SetValue(0);
    }
    public void Charge(){
        delayBarRight.IncreaseValue(consumeAmount);
        delayBarLeft.IncreaseValue(consumeAmount);
    }
    public float GetValue(){
        return delayBarLeft.GetValue();
    }



    public void CallmePls(){
       

        string pngFileName;

        for(int i=0; i<3; i++){
            if(photoNum[i] == 0){
                pngFileName = Application.dataPath + "/Resources/photo" + i.ToString() + ".png";
            }
            else if(PlayerPrefs.GetInt("monsterDead") == 1){
                pngFileName = "Assets/Snapshots/dead" + i.ToString() + ".png";
            }
            else{
                pngFileName = "Assets/Snapshots/DefaultMonster.png";
            }
            Texture2D tex = null;
            byte[] fileData;

            if (File.Exists(pngFileName))
            {
                fileData = File.ReadAllBytes(pngFileName);
                tex = new Texture2D(2, 2);
                tex.LoadImage(fileData);
                
            }
            rawImages[i].texture = tex;
        }











        /* 
        if(rawImage.texture == null)
            Debug.Log("Raw Image Null Error!");
         */

        

    }

    
}
