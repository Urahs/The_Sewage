using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    public ScreenShotCamera snapCam;
    

    TextureImporter importer;
    public RawImage rawImage;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            snapCam.CallTakeSnapShot();
            Invoke("CallmePls", 2.0f);
        }
    }

    void CallmePls(){
        
        UnityEditor.AssetDatabase.Refresh();
        
        rawImage.texture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Snapshots/resim00.png", typeof(Texture2D));
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
