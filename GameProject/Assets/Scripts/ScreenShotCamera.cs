using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenShotCamera : MonoBehaviour
{
    Camera snapCam;
    public TakePhoto takePhoto;

    public int photoCounter=0;
    public bool validPhoto;

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
        if(validPhoto){
            string pngName = "photo" + photoCounter.ToString() + ".png";
            Debug.Log(photoCounter);
            takePhoto.photoNum[photoCounter]++;
            photoCounter++;
            return string.Format("{0}/Snapshots/" + pngName, Application.dataPath);
        }
            
        return string.Format("{0}/Snapshots/InvalidPhoto.png", Application.dataPath);
    }


}
