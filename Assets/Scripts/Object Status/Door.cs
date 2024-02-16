using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{
    public Linker mLinker;
    public Sprite mOpenedDoorSprite, mClosedDoorSprite;
    public bool isDoorOpen;
    public List<string> responseTextGeneral = new List<string>();
    
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
        // TODO: Animate the Player to walk over the door area.

        GetComponent<SpriteRenderer>().sprite = mOpenedDoorSprite;
        isDoorOpen = true;
    }

    public void Close(){
        isDoorOpen = false;
        GetComponent<SpriteRenderer>().sprite = mClosedDoorSprite;
    }

    public void Knock(){
        mLinker.mSoundManager.PlayKnock();
    }
}
