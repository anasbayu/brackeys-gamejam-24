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
    public List<string> doorOpenedMessage = new List<string>();

    string msgOpening, msgAngry, msgEnding, msgGeneralCall, msgInfoCall, msgOrderCall, msgDoorOpened;
    public string msgWindowPeek;

    public bool isLetInside;
    public bool isHavingVehicle;

    public void SetPeople(){
        isLetInside = false;
        msgOpening = openingDialogues[Random.Range(0, openingDialogues.Count)];
        msgAngry = waitingDialogues[Random.Range(0, waitingDialogues.Count)];
        msgEnding = endingDialogues[Random.Range(0, endingDialogues.Count)];
        msgGeneralCall = generalCallMessage[Random.Range(0, generalCallMessage.Count)];
        msgInfoCall = infoCallMessage[Random.Range(0, infoCallMessage.Count)];
        msgOrderCall = orderCallMessage[Random.Range(0, orderCallMessage.Count)];
        msgDoorOpened = doorOpenedMessage[Random.Range(0, doorOpenedMessage.Count)];

        // Delivery has random chance to have a vehicle.
        if(type == "Delivery Guy"){
            int tmpVehicleChance = Random.Range(0,1);
            if(tmpVehicleChance == 1){
                isHavingVehicle = true;
                msgWindowPeek = "There is a big truck in the front yard.";
            }else{
                msgWindowPeek = "Just my neighborhood";
                isHavingVehicle = false;
            }
        }
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

    public string LettingInsideHouse(){
        isLetInside = true;
        return msgDoorOpened;
    }

    public string GetWindowPeekMsg(){
        return msgWindowPeek;
    }
}
