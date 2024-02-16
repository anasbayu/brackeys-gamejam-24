using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public Linker mLinker;
    public bool isRinging;
    public bool isOnGoingCall;
    public string phoneMsg = "";

    void Start(){
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
        mLinker.mEventManager.StopEvent();
    }

    public bool IsThereOnGoingCall(){
        return isOnGoingCall;
    }

    public void SetConversation(string msg){
        phoneMsg = msg;
        isOnGoingCall = true;
    }
}
