using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTrigger : MonoBehaviour
{
    public TakePhoto takePhoto;
    public GameObject endGame, player, defaultCanvas, gunCamCanvas;

    
    
    public Text text;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            
            if(takePhoto.photoNum[2] == 0 && PlayerPrefs.GetInt("monsterDead") == 0){
                text.text = "\tOur Hero!!!\n"+
                "A young man (John) killed the monster in the sewage, and took 3 photos of that cursed demon."+ 
                " He broke the disaster chain. From now on, we can go out at night without getting worried thanks to our brave hero.";
                Destroy_Create();
            }
            else if(takePhoto.photoNum[2] == 0){
                text.text = "\tLegend is officially confirmed"+
                "The rumor that has been talked about for years is officially confirmed by a young journalist named John."+ 
                "This brave young man went into the sewage with just his photo camera and a rustic lantern. He took three photos of that sewage monster and escape all in one piece.";
                Destroy_Create();
            }
            else if(PlayerPrefs.GetInt("monsterDead") == 1){
                Destroy_Create();
            }
            
            
            
            
            
            
            
            
            /* Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;

            //infoCanvas.SetActive(true);
            Destroy(gameObject); */
        }   



    }

    void Destroy_Create(){
        player.GetComponent<TakePhoto>().CallmePls();
        player.SetActive(false);
        endGame.SetActive(true);
        gunCamCanvas.SetActive(false);
        defaultCanvas.SetActive(false);
    }

}
