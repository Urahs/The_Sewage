using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{

    public static SaveScript instance;

    // Start is called before the first frame update
    void Awake()
    {

        if(instance==null)
            instance = this;
        else{
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.SetInt("restartScene", -1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
