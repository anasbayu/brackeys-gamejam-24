using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfo : MonoBehaviour{
    public List<string> actionList = new List<string>();
    string[] triggerData = {"Photo", 
                            "Door", 
                            "Fridge", 
                            "Phone", 
                            "TV", 
                            "Window", 
                            "Clock", 
                            "Note",
                            "Record Player",
                            "Lamp"};
    
    [Dropdown("triggerData")]
    public string triggerName;

    void SetActionList(){
        if(triggerName == "Window"){
            actionList.Add("Peek");
            actionList.Add("Shutter");       // Close or Open with the same action (toggle).
        }else if(triggerName == "Door"){
            actionList.Add("Open Door");
            actionList.Add("Talk");
            actionList.Add("Hand");
        }
    }

    public List<string> GetActionList(){
        return actionList;
    }

    void Start(){
        SetActionList();
    }
}
