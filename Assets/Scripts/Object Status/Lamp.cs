using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lamp : MonoBehaviour{
    public bool isLightOn;
    public GameObject mLight, mLight2;

    void Start(){
        isLightOn = false;
        mLight.SetActive(isLightOn);
        mLight2.SetActive(isLightOn);
    }

    public void ToogleOnOff(){
        isLightOn = !isLightOn;
        mLight.SetActive(isLightOn);
        mLight2.SetActive(isLightOn);
    }
}
