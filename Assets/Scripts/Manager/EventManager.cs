using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Linker mLinker;
    public List<People> mPeoples = new List<People>();
    
    // Change this to set how long to give the Player idle time before the first event.
    int timeBeforeFirstEvent = 15;

    // Define the interval between time. It's going to be random(min, max).
    int minTimeBetweenEvent = 5;
    int maxTimeBetweenEvent = 10;
    public int timeBetweenNextEvent;

    public int lastEventTime;  // Save the time of the last event occured,
    int eventCount;     // Save the total event count.
    public bool isEventRunning;     // true if there is an event going on.
    Event CurrEvent;

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

        // TODO: It should not be here. It should be in the People Class.
        // If there is a People event currently running, check their status.
        if(isEventRunning && CurrEvent != null){
            // If he get angry.
            if(mLinker.mTimeManager.GetCurrTime() == lastEventTime + CurrEvent.GetAssociatedPeople().timeBeforeAngry){
                mLinker.mUIManager.ShowDialogue(true, CurrEvent.GetAssociatedPeople().Angry());
            }

            if(mLinker.mTimeManager.GetCurrTime() == lastEventTime + CurrEvent.GetAssociatedPeople().timeWillingToWait){
                mLinker.mUIManager.ShowDialogue(true, CurrEvent.GetAssociatedPeople().Left());
                StopEvent();
            }
        } 
    }

    void StartEvent(string eventName){
        isEventRunning = true;
        eventCount++;

        // Randomize the event, if not predetermined.
        if(eventName == "Random"){
            int tmp = Random.Range(1, 10);
            if(tmp % 2 == 1){
                eventName = "Knock";
            }else{
                eventName = "Phone Ringing";
            }   
        }

        // Randomize the people associated with the event.
        int tmpIndex = Random.Range(0, mPeoples.Count);
        mPeoples[tmpIndex].SetPeople();
        CurrEvent = new Event(eventName, mPeoples[tmpIndex], mLinker);
    }

    public void StopEvent(){
        isEventRunning = false;
        lastEventTime = mLinker.mTimeManager.GetCurrTime();

        // calculate the next event time.
        timeBetweenNextEvent = Random.Range(minTimeBetweenEvent, maxTimeBetweenEvent);
        CurrEvent = null;
    }
}
