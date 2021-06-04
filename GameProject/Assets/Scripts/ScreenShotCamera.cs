using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenShotCamera : MonoBehaviour
{
    Camera snapCam;

    int resWidth = 256;
    int resHeight = 256;

    void Awake(){
        snapCam = GetComponent<Camera>();
        if(snapCam.targetTexture == null){
            snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else{
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }
        snapCam.gameObject.SetActive(false);
    }

    public void CallTakeSnapShot(){
        snapCam.gameObject.SetActive(true);
    }


    void LateUpdate() {
        if(snapCam.gameObject.activeInHierarchy){
            Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string filename = SnapShotName();
            System.IO.File.WriteAllBytes(filename, bytes);
            //UnityEditor.AssetDatabase.Refresh();
            UnityEditor.AssetDatabase.ImportAsset(filename);
            Debug.Log("Foto taken!");
            snapCam.gameObject.SetActive(false);
        }
    }


    string SnapShotName(){
        //return string.Format("{0}/Snapshots/snap_{1}x{2}_{3}.png", Application.dataPath, resWidth, resHeight,  System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        return string.Format("{0}/Snapshots/resim00.png", Application.dataPath);
    }


}
