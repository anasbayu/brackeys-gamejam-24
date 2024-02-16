using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour{
    public Linker mLinker;
    public GameObject blinkIndicatorGreen, blinkIndicatorRed;
    public GameObject screenSnow, screenOn;
    public GameObject VFXTVLight;
    public AudioSource mSFXTVSource;
    public AudioClip TVOn, TVOff;
    bool isOn;

    void Start(){
        isOn = false;
        blinkIndicatorRed.SetActive(true);
    }

    public void ToggleTurnOnOff(){
        isOn = !isOn;

        if(isOn){
            VFXTVLight.SetActive(true);
            blinkIndicatorGreen.SetActive(true);
            blinkIndicatorRed.SetActive(false);
            mSFXTVSource.clip = TVOn;
            mSFXTVSource.Play();

            // TODO: Check if there is a news? if not, show snow.
            screenOn.SetActive(true);
            mLinker.mUIManager.ShowDialogue(true, "...");
        }else{
            VFXTVLight.SetActive(false);
            blinkIndicatorGreen.SetActive(false);
            blinkIndicatorRed.SetActive(true);
            mSFXTVSource.clip = TVOff;
            mSFXTVSource.Play();

            screenOn.SetActive(false);
            screenSnow.SetActive(false);
        }
    }

}
