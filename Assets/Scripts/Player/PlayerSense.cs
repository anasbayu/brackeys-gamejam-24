using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSense : MonoBehaviour{
    public Linker mLinker;
    public bool isInteracting;
    public bool isMultiAction;
    public List<string> actionList = new List<string>();
    public int currActionIndex;
    GameObject interactedObj;

    void Start(){
        isInteracting = false;
        isMultiAction = false;
        currActionIndex = 0;
        mLinker.mStatusBalloon.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Interactable"){
            isInteracting = true;
            currActionIndex = 0;
            interactedObj = other.gameObject;


            actionList = interactedObj.GetComponent<TriggerInfo>().GetActionList();
            if(actionList.Count > 0){
                // If there are multiple action on the object.
                isMultiAction = true;
            }

            mLinker.mStatusBalloon.SetActive(true);
            if(actionList.Count > 0){
                mLinker.mUIManager.ShowActionBalloon(actionList[currActionIndex]);
            }else{
                mLinker.mUIManager.ShowActionBalloon("Hand");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Interactable"){
            mLinker.mStatusBalloon.SetActive(false);
            isInteracting = false;
            isMultiAction = false;
            interactedObj = null;
            actionList = null;
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

    public void CycleAction(){
        if(currActionIndex < actionList.Count-1){
            currActionIndex++;
        }else{
            currActionIndex = 0;
        }

        // Show the action UI.
        mLinker.mUIManager.ShowActionBalloon(actionList[currActionIndex]);
    }

    public void Interact(){
        string triggerName = interactedObj.GetComponent<TriggerInfo>().triggerName;

        if(triggerName == "Photo"){
            mLinker.mUIManager.ShowDialogue(true, "this is my family photo.");
        }else if(triggerName == "Door"){
            if(actionList[currActionIndex] == "Open Door"){
                // Check if there is an event going on.
                mLinker.mUIManager.ShowDialogue(true, mLinker.mDoor.OpenDialogue(mLinker.mEventManager.IsThereAnEvent()));
            }else if(actionList[currActionIndex] == "Talk"){
                // Check if there is event running.
                if(mLinker.mEventManager.IsThereAnEvent()){
                    // Talk to the person behind the door.
                    mLinker.mUIManager.ShowDialogue(true, "Who's there?.");
                    mLinker.mEventManager.GetCurrEvent().GetAssociatedPeople().StartConversation();
                }else{
                    mLinker.mUIManager.ShowDialogue(true, "There is no one behind the door.");
                }
            }else{
                // show what the Player think. (Hand)
                mLinker.mUIManager.ShowDialogue(true, mLinker.mDoor.InnerThought());
            }
        }else if(triggerName == "Fridge"){
            List<string> itemsInsideFridge = mLinker.mFridge.CheckWhatsIndside();

            string tmpItemsString = "Let's see what we have...<br>";
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
            if(actionList[currActionIndex] == "Shutter"){
                mLinker.mWindow.ToggleShutter();
            }else{
                // Peek
                mLinker.mUIManager.ShowDialogue(true, mLinker.mWindow.Peek());
            }
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
