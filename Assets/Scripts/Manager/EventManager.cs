using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Linker mLinker;
    public List<People> mPeoples = new List<People>();
    
    // Change this to set how long to give the Player idle time before the first event.
    int timeBeforeFirstEvent = 5;

    // Define the interval between time. It's going to be random(min, max).
    int minTimeBetweenEvent = 10;
    int maxTimeBetweenEvent = 15;
    public int timeBetweenNextEvent;

    public int lastEventTime;  // Save the time of the last event occured,
    string lastEventType;
    int eventCount;     // Save the total event count.
    Event CurrEvent;

    void Start(){
        lastEventType = null;
        eventCount = 0;
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
        if(!IsThereAnEvent() && eventCount != 0){
            if(mLinker.mTimeManager.GetCurrTime() == lastEventTime + timeBetweenNextEvent){
                StartEvent("Random");
            }
        }

        // If there is a People event currently running, check their status.
        if(CurrEvent != null){
            if(CurrEvent.GetEventType() == "Knock"){
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
    }

    string Randomize(){
        string eventName = "";
        int tmp = Random.Range(1, 10);
        if(tmp % 2 == 1){
            eventName = "Knock";
        }else{
            eventName = "Phone Ringing";
        }   
        return eventName;
    }
    void StartEvent(string eventName){
        eventCount++;

        // Randomize the event, if not predetermined.
        if(eventName == "Random"){
            do{
                eventName = Randomize();            
            }while(lastEventType == "Phone Ringing" && eventName == "Phone Ringing");
        }

        // Randomize the people associated with the event.
        // TODO: just for testing.
        // int tmpIndex = 0;   
        int tmpIndex = Random.Range(0, mPeoples.Count);
        mPeoples[tmpIndex].SetPeople();
        CurrEvent = new Event(eventName, mPeoples[tmpIndex], mLinker);
    }

    public void StopEvent(){
        lastEventTime = mLinker.mTimeManager.GetCurrTime();
        lastEventType = CurrEvent.GetEventType();

        // calculate the next event time.
        timeBetweenNextEvent = Random.Range(minTimeBetweenEvent, maxTimeBetweenEvent);
        CurrEvent.FinishTheEvent();
        CurrEvent = null;
    }

    public bool IsThereAnEvent(){
        if(CurrEvent != null){
            return true; 
        }else{
            return false;
        }
    }

    public Event GetCurrEvent(){
        return CurrEvent;
    }
}
