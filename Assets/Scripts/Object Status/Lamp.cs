using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lamp : MonoBehaviour{
    public bool isLightOn;
    public GameObject mLight;

    void Start(){
        isLightOn = false;
        mLight.SetActive(isLightOn);
    }

    public void ToogleOnOff(){
        isLightOn = !isLightOn;
        mLight.SetActive(isLightOn);
    }
}
