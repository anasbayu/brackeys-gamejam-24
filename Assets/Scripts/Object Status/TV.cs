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
    bool isThereNews;       // only display news once.
    string news;
    int newsCount;

    void Start(){
        newsCount = 0;
        isThereNews = false;
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

            if(isThereNews){
                mLinker.mUIManager.ShowDialogue(true, news);
                news = "";
                isThereNews = false;
            }else{
                mLinker.mUIManager.ShowDialogue(true, "...<br>Nothing good to watch.");
            }
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

    public void AddNews(){
        newsCount++;
        People peopleKilled = mLinker.mEventManager.GetCurrEvent().GetAssociatedPeople();
        int timeKilled = mLinker.mTimeManager.GetCurrHour();
        
        string timeKilledConverted;
        if(timeKilled < 13){
            timeKilledConverted = timeKilled.ToString() + " AM";
        }else{
            timeKilled = timeKilled%12;
            timeKilledConverted = timeKilled.ToString() + " PM";
        }

        news = "<b>Breaking News.</b><br>";
        news += "A body wearing " + peopleKilled.cloth + " has been found around " + timeKilledConverted + "<br>";
        
        if(newsCount <= 1){
            news += "Be careful and always lock your door.";
        }else{
            news += "This is rather concerning because the body was found in the same area near a house.";
        }

        isThereNews = true;
    }
}
