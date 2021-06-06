using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    public ScreenShotCamera snapCam;
    

    TextureImporter importer;
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
        
        UnityEditor.AssetDatabase.Refresh();

        string pngFileName;

        for(int i=0; i<3; i++){
            if(photoNum[i] == 0){
                pngFileName = "Assets/Snapshots/photo" + i.ToString() + ".png";
            }
            else if(PlayerPrefs.GetInt("monsterDead") == 1){
                pngFileName = "Assets/Snapshots/dead" + i.ToString() + ".png";
            }
            else{
                pngFileName = "Assets/Snapshots/DefaultMonster.png";
            }

            rawImages[i].texture = (Texture2D)AssetDatabase.LoadAssetAtPath(pngFileName, typeof(Texture2D));
        }











        /* 
        if(rawImage.texture == null)
            Debug.Log("Raw Image Null Error!");
         */

        

    }

    
}
