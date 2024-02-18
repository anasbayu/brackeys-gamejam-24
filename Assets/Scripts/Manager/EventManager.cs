using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public Linker mLinker;
    public List<People> mPeoples = new List<People>();
    
    // Change this to set how long to give the Player idle time before the first event.
    int timeBeforeFirstEvent = 45;

    // Define the interval between time. It's going to be random(min, max).
    int minTimeBetweenEvent = 45;
    int maxTimeBetweenEvent = 60;
    public int timeBetweenNextEvent;

    public int lastEventTime;  // Save the time of the last event occured,
    string lastEventType;
    int eventCount;     // Save the total event count.
    Event CurrEvent;
    public GameObject mPlumberAction;

    void Start(){
        mPlumberAction.SetActive(false);
        lastEventType = null;
        eventCount = 0;
        lastEventTime = mLinker.mTimeManager.GetCurrTime();
        timeBetweenNextEvent = Random.Range(minTimeBetweenEvent, maxTimeBetweenEvent);
    }

    public void PlumberToWork(){
        mPlumberAction.SetActive(true);
        mPlumberAction.GetComponent<Plumber>().StartWork();
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
                    if(CurrEvent.GetAssociatedPeople().type != "Killer"){
                        mLinker.mGameManager.DecreaseHeart();
                    }
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
        //event rules here.
        // 0 = killer plumber, 1 = neighbor, 2 = delivery, 3 = plumber, 4 = killer neighbor, 5 = killer delivery
        int tmpIndex = 0;
        do{
            if(mLinker.mTimeManager.GetCurrHour() < 12){
                // morning 0,1,3,4,5
                do{
                    tmpIndex = Random.Range(0, mPeoples.Count);
                }while(tmpIndex == 2);
            }else{
                tmpIndex = Random.Range(0, mPeoples.Count);
            }
        // Check if there is a completed quest with this people?
        }while(mLinker.mNote.CheckIsQuestCompleted(mPeoples[tmpIndex].type));

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
