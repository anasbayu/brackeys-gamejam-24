using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Linker mLinker;
    public List<People> mPeoples = new List<People>();
    People currPeopleKnocking;
    
    // Change this to set how long to give the Player idle time before the first event.
    int timeBeforeFirstEvent = 15;

    // Define the interval between time. It's going to be random(min, max).
    int minTimeBetweenEvent = 5;
    int maxTimeBetweenEvent = 10;
    public int timeBetweenNextEvent;

    public int lastEventTime;  // Save the time of the last event occured,
    int eventCount;     // Save the total event count.
    public bool isEventRunning;     // true if there is an event going on.

    void Start(){
        eventCount = 0;
        isEventRunning = false;
        lastEventTime = mLinker.mTimeManager.GetCurrTime();
        timeBetweenNextEvent = Random.Range(minTimeBetweenEvent, maxTimeBetweenEvent);
    }

    void Update(){
        // The first event always a knock.
        if(eventCount == 0){
            if(mLinker.mTimeManager.GetCurrTime() == lastEventTime + timeBeforeFirstEvent){
                StartEvent("Knock");            
                lastEventTime = mLinker.mTimeManager.GetCurrTime(); // khusus event pertama.
            }
        }

        // Start random event when it is not the first event & there is no event currently running.
        if(!isEventRunning && eventCount != 0){
            if(mLinker.mTimeManager.GetCurrTime() == lastEventTime + timeBetweenNextEvent){
                StartEvent("Random");
            }
        }

        // If there is a People event currently running, check their status.
        if(isEventRunning && currPeopleKnocking != null){
            // If he get angry.
            if(mLinker.mTimeManager.GetCurrTime() == lastEventTime + currPeopleKnocking.timeBeforeAngry){
                mLinker.mUIManager.ShowDialogue(true, currPeopleKnocking.Angry());
            }

            if(mLinker.mTimeManager.GetCurrTime() == lastEventTime + currPeopleKnocking.timeWillingToWait){
                mLinker.mUIManager.ShowDialogue(true, currPeopleKnocking.Left());
                StopEvent();
            }
        } 
    }

    void StartEvent(string eventName){
        isEventRunning = true;
        eventCount++;

        // Randomize the event.
        if(eventName == "Random"){
            int tmp = Random.Range(1, 10);
            if(tmp % 2 == 1){
                eventName = "Knock";
            }else{
                eventName = "Phone Ringing";
            }
        }

        if(eventName == "Knock"){
            mLinker.mDoor.Knock();

            // Randomize who knocks.
            int tmpIndex = Random.Range(0, mPeoples.Count);
            currPeopleKnocking = mPeoples[tmpIndex];

            mLinker.mUIManager.ShowDialogue(true, currPeopleKnocking.Knocking());

        }else if(eventName == "Phone Ringing"){
            mLinker.mPhone.Ring();

            // Randomize who call.
            int indexWhoIsCalling = Random.Range(0, mPeoples.Count);
            currPeopleKnocking = mPeoples[indexWhoIsCalling];

            string callMsg = "";
            
            // TEST Purpose.
            // callMsg = "Hey let's play!";
            // mLinker.mPhone.SetConversation(callMsg);

            if(currPeopleKnocking.type == "Parents"){
                // Randomize what the parents call for.
                // 1,2 = just checkin. 3 = give an order. 4 = give information.
                int indexParentsCall = Random.Range(1, 4);
                if(indexParentsCall == 1 || indexParentsCall == 2){
                    callMsg = currPeopleKnocking.GeneralCall();
                }else if(indexParentsCall == 3){
                    callMsg = currPeopleKnocking.OrderCall();
                }else{
                    callMsg = currPeopleKnocking.InfoCall();
                }
            }else if(currPeopleKnocking.type == "Killer"){
                callMsg = currPeopleKnocking.OrderCall();   // Make sure to fill in the inspector, the same value as the parents.
            }else if(currPeopleKnocking.type == "Neighbour"){
                callMsg = "This is your neighbour, I have been seeing strange man wandering around your house.";
            }else if(currPeopleKnocking.type == "Friend"){
                callMsg = "Hey! This is Tim, let's play at my house. I've got a new video games!";
            }else{
                // just hung up.
                callMsg = "...";
            }

            mLinker.mPhone.SetConversation(callMsg);
        }
    }

    public void StopEvent(){
        isEventRunning = false;
        lastEventTime = mLinker.mTimeManager.GetCurrTime();

        // calculate the next event time.
        timeBetweenNextEvent = Random.Range(minTimeBetweenEvent, maxTimeBetweenEvent);
        currPeopleKnocking = null;
    }
}
