using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfo : MonoBehaviour{
    string[] triggerData = {"Photo", "Door"};
    
    [Dropdown("triggerData")]
    public string triggerName;

}
