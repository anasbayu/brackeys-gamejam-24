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

    public string Knocking(){
        return openingDialogues[Random.Range(0, openingDialogues.Count)];
    }

    public string Angry(){
        return waitingDialogues[Random.Range(0, waitingDialogues.Count)];
    }

    public string Left(){
        return endingDialogues[Random.Range(0, endingDialogues.Count)];
    }

    public string GeneralCall(){
        return generalCallMessage[Random.Range(0, generalCallMessage.Count)];
    }

    public string InfoCall(){
        return infoCallMessage[Random.Range(0, infoCallMessage.Count)];
    }

    public string OrderCall(){
        return orderCallMessage[Random.Range(0, orderCallMessage.Count)];
    }
}
