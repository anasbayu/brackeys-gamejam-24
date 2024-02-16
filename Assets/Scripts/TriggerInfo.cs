using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfo : MonoBehaviour{
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

}
