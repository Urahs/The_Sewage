using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public int selected = 0;


    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
    int prev = selected;

    if(Input.GetKeyDown(KeyCode.Alpha1))
        selected = 0;
    if(Input.GetKeyDown(KeyCode.Alpha2))
        selected = 1;
    if(Input.GetKeyDown(KeyCode.Alpha3))
        selected = 2;
    if(Input.GetKeyDown(KeyCode.Alpha4))
        selected = 3;

    if(prev != selected)
        SelectWeapon();
    }

    void SelectWeapon()
    {
        int i=0;
        foreach (Transform weapon in transform){
            if (i==selected)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            
            i++;
        }
    }
}
