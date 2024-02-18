using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public Linker mLinker;
    public bool isRinging;
    public bool isOnGoingCall;
    public string phoneMsg = "";
    bool isCallMom;

    void Start(){
        isCallMom = false;
        isRinging = false;
        isOnGoingCall = false;
    }

    public void Ring(){
        mLinker.mSoundManager.PlayRingtone();
        isRinging = true;
    }

    public void StopRingtone(){
        mLinker.mSoundManager.StopRingtone();
        isRinging = false;
    }

    public void PhoneConversation(){
        // For now, there is just one conversation, and then hung up.
        mLinker.mUIManager.ShowDialogue(true, phoneMsg);
        isOnGoingCall = false;
        
        // if not from call mom, stop the event. (it means it is a phone ringing event).
        if(!isCallMom){
            mLinker.mEventManager.StopEvent();
        }else{
            isCallMom = false;
        }
    }

    public bool IsThereOnGoingCall(){
        return isOnGoingCall;
    }

    public void SetConversation(string msg){
        phoneMsg = msg;
        isOnGoingCall = true;
    }

    public void CallMom(){
        // Check who is at the front door?
        string whoKnock = mLinker.mEventManager.GetCurrEvent().GetAssociatedPeople().type;
        string msg = "";

        if(whoKnock == "Delivery Guy"){
            if(mLinker.mTimeManager.GetCurrHour() > 12){
                msg = "Oh yeah, he must be the Delivery officer.";
            }else{
                msg = "I think he mistake our house for somebody else house. The delivery officer should arrive this afternoon.";
            }
        }else if(whoKnock == "Neighbour"){
            msg = "The Morleys? yeah he called this morning. Don't you read my notes!?";
        }else if(whoKnock == "Plumber"){
            if(mLinker.mTimeManager.GetCurrHour() > 12){
                msg = "oh the Plumber? He is late then.";
            }else{
                msg = "Yes, somebody will fix the plumbing today.";
            }
        }else{
            msg = "We shouldn't have a visitor at this time";
        }
        SetConversation(msg);
        isCallMom = true;
    }
}
