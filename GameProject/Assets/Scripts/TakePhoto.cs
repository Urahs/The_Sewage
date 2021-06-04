using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    public ScreenShotCamera snapCam;
    
    public bool temp;

    TextureImporter importer;
    public RawImage rawImage;

    
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



    void CallmePls(){
        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        UnityEditor.AssetDatabase.Refresh();
        if(temp)        rawImage.texture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Snapshots/resim00.png", typeof(Texture2D));
        else            rawImage.texture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Snapshots/default.png", typeof(Texture2D));
        if(rawImage.texture == null)
            Debug.Log("Raw Image Null Error!");
        

        /*
        importer = (TextureImporter)TextureImporter.GetAtPath("Assets/snapShots/resim00.png");
        importer.textureType = TextureImporterType.Sprite;

        Invoke("CallmeAgain", 2.0f);
        */

    }

    /*
    void CallmeAgain(){
        //UnityEditor.AssetDatabase.Refresh();
        photo.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Snapshots/resim00.png");
    }
    */
}
