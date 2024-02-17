using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{
    public Linker mLinker;
    public GameObject mOpenedDoorSprite, mClosedDoorSprite;
    public bool isDoorOpen;
    public List<string> responseTextGeneral = new List<string>();
    public Sprite mOpenedDoorMidday, mOpenedDoorEvening, mOpenedDoorNight, mOpenedDoorMorning;
    
    void Start(){
        isDoorOpen = false;
    }

    public string InnerThought(){
        int responseIndex = Random.Range(0, responseTextGeneral.Count);
        return responseTextGeneral[responseIndex];
    }

    public string OpenDialogue(bool isSomeoneHere){
        //TODO: Check if there is an event running?
        Open();

        if(isSomeoneHere){
            return "Yess? Who is it?";
        }else{
            return "I shouldn't go outside until Mom come home.";
        }
    }

    public void Open(){
        // When opened, check the current time and assign the suitable sprite.
        if(mLinker.mTimeManager.GetCurrHour() < 12){
            mOpenedDoorSprite.GetComponent<SpriteRenderer>().sprite = mOpenedDoorMorning;
        }else if(mLinker.mTimeManager.GetCurrHour() < 17){
            mOpenedDoorSprite.GetComponent<SpriteRenderer>().sprite = mOpenedDoorMidday;
        }else if(mLinker.mTimeManager.GetCurrHour() < 19){
            mOpenedDoorSprite.GetComponent<SpriteRenderer>().sprite = mOpenedDoorEvening;
        }else if(mLinker.mTimeManager.GetCurrHour() < 24){
            mOpenedDoorSprite.GetComponent<SpriteRenderer>().sprite = mOpenedDoorNight;
        }

        // TODO: Animate the Player to walk over the door area.

        mOpenedDoorSprite.SetActive(true);
        mClosedDoorSprite.SetActive(false);
        isDoorOpen = true;
    }

    public void Close(){
        isDoorOpen = false;
        mClosedDoorSprite.SetActive(true);
        mOpenedDoorSprite.SetActive(false);
    }
    public void Knock(){
        mLinker.mSoundManager.PlayKnock();
    }
}
