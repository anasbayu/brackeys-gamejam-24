using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event{
    string type;       // "Knock" or "Phone Ringing".
    bool isRunning;     // save the event state. true == Currently running.
    People mPeople;     // save the People data associated with this event.
    Linker mLinker;
    //TODO: Quest related to event.
    // TODO: Dialogue related to event.

    public Event(string eventType, People thePeople, Linker linker){
        type = eventType;
        isRunning = false;
        mPeople = thePeople;
        mLinker = linker;

        PlaySFX();
        PlayEvent();
    }

    void PlaySFX(){
        if(type == "Knock"){
            mLinker.mDoor.Knock();
        }else{
            mLinker.mPhone.Ring();
        }
    }

    void PlayEvent(){
        isRunning = true;
        
        if(type == "Knock"){
            mLinker.mUIManager.ShowDialogue(true, mPeople.Knocking());
        }else{
            string callMsg = "";

            if(mPeople.type == "Parents"){
                // Randomize what the parents call for.
                // 1,2 = just checkin. 3 = give an order. 4 = give information.
                int indexParentsCall = Random.Range(1, 4);
                if(indexParentsCall == 1 || indexParentsCall == 2){
                    callMsg = mPeople.GeneralCall();
                }else if(indexParentsCall == 3){
                    callMsg = mPeople.OrderCall();
                }else{
                    callMsg = mPeople.InfoCall();
                }
            }else if(mPeople.type == "Killer"){
                callMsg = mPeople.OrderCall();   // Make sure to fill in the inspector, the same value as the parents.
            }else if(mPeople.type == "Neighbour"){
                callMsg = "This is your neighbour, I have been seeing strange man wandering around your house.";
            }else if(mPeople.type == "Friend"){
                callMsg = "Hey! This is Tim, let's play at my house. I've got a new video games!";
            }else{
                // just hung up.
                callMsg = "...";
            }

            mLinker.mPhone.SetConversation(callMsg);
        }
    }

    public bool isEventRunning(){
        return isRunning;
    }

    public void FinishTheEvent(){
        isRunning = false;
    }

    public string GetEventType(){
        return type;
    }

    public People GetAssociatedPeople(){
        return mPeople;
    }
}
