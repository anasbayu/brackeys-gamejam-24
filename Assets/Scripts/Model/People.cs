using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour{
    public string name;
    string[] peopleTypes = {"Killer", 
                            "Parents", 
                            "Delivery Guy", 
                            "Neighbour", 
                            "Scout Boys", 
                            "Friend"};
    
    [Dropdown("peopleTypes")]
    public string type;
    public int timeWillingToWait;
    public int timeBeforeAngry;
    public List<string> openingDialogues = new List<string>();
    public List<string> waitingDialogues = new List<string>();
    public List<string> endingDialogues = new List<string>();
    public List<string> generalCallMessage = new List<string>();
    public List<string> infoCallMessage = new List<string>();
    public List<string> orderCallMessage = new List<string>();

    string msgOpening, msgAngry, msgEnding, msgGeneralCall, msgInfoCall, msgOrderCall;

    public void SetPeople(){
        msgOpening = openingDialogues[Random.Range(0, openingDialogues.Count)];
        msgAngry = waitingDialogues[Random.Range(0, waitingDialogues.Count)];
        msgEnding = endingDialogues[Random.Range(0, endingDialogues.Count)];
        msgGeneralCall = generalCallMessage[Random.Range(0, generalCallMessage.Count)];
        msgInfoCall = infoCallMessage[Random.Range(0, infoCallMessage.Count)];
        msgOrderCall = orderCallMessage[Random.Range(0, orderCallMessage.Count)];
    }

    public string Knocking(){
        return msgOpening;
    }

    public string Angry(){
        return msgAngry;
    }

    public string Left(){
        return msgEnding;
    }

    public string GeneralCall(){
        return msgGeneralCall;
    }

    public string InfoCall(){
        return msgInfoCall;
    }

    public string OrderCall(){
        return msgOrderCall;
    }
}
