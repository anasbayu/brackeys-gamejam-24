using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSense : MonoBehaviour{
    public Linker mLinker;
    public bool isInteracting;
    GameObject interactedObj;

    void Start(){
        isInteracting = false;
        mLinker.mStatusBalloon.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Interactable"){
            mLinker.mStatusBalloon.SetActive(true);
            isInteracting = true;
            interactedObj = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Interactable"){
            mLinker.mStatusBalloon.SetActive(false);
            isInteracting = false;
            interactedObj = null;
        }

        if(other.gameObject.tag == "Cam Switch"){
            if(other.gameObject.name == "Cam Switch 1"){
                if(mLinker.mPlayer.GetDirection() == "Right"){
                    mLinker.mCamManager.ChangeCamPos("Foyer");
                }else{
                    mLinker.mCamManager.ChangeCamPos("Kitchen");
                }
            }else{
                if(mLinker.mPlayer.GetDirection() == "Right"){
                    mLinker.mCamManager.ChangeCamPos("Living Room");
                }else{
                    mLinker.mCamManager.ChangeCamPos("Foyer");
                }
            }
        }
    }

    public void Interact(){
        string triggerName = interactedObj.GetComponent<TriggerInfo>().triggerName;

        if(triggerName == "Photo"){
            mLinker.mUIManager.ShowDialogue(true, "this is my family photo.");
        }else if(triggerName == "Door"){
            mLinker.mUIManager.ShowDialogue(true, mLinker.mDoor.Open());
        }else if(triggerName == "Fridge"){
            mLinker.mUIManager.ShowDialogue(true, "checking the fridge...");
            List<string> itemsInsideFridge = mLinker.mFridge.CheckWhatsIndside();

            string tmpItemsString = "";
            for(int i = 0; i < itemsInsideFridge.Count; i++){
                tmpItemsString += itemsInsideFridge[i];

                if(i == itemsInsideFridge.Count - 1){
                    tmpItemsString += ".";
                }else{
                    tmpItemsString += ", ";
                }
            }

            mLinker.mUIManager.ShowDialogue(true, tmpItemsString);
        }else if(triggerName == "Window"){
            //call window.
            mLinker.mUIManager.ShowDialogue(true, mLinker.mWindow.Peek());
        }else if(triggerName == "Record Player"){
            mLinker.mSoundManager.TogglePlayBGM();
        }else if(triggerName == "Lamp"){
            interactedObj.GetComponent<Lamp>().ToogleOnOff();
            interactedObj.GetComponent<AudioSource>().Play();
        }else if(triggerName == "Phone" && mLinker.mPhone.isRinging){
            mLinker.mPhone.StopRingtone();
            mLinker.mUIManager.ShowDialogue(true, "Who is this?");
    
            // mLinker.mEventManager.StopEvent();      // TODO: Possible bug here. Should be after the dialogue box closing.
        }else if(triggerName == "Clock"){
            mLinker.mTimeManager.ShowCurrentTime();
        }else if(triggerName == "TV"){
            mLinker.mTV.ToggleTurnOnOff();
        }else if(triggerName == "Note"){
            mLinker.mNote.ReadNotes();
        }
    }
}
