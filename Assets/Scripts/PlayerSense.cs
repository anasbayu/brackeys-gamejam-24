using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSense : MonoBehaviour{
    public Linker mLinker;
    public bool isInteracting;
    GameObject interactedObj;

    void Start(){
        isInteracting = false;
        mLinker.mStatusBalloon.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Interactable"){
            mLinker.mStatusBalloon.SetActive(true);
            isInteracting = true;
            interactedObj = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Interactable"){
            mLinker.mStatusBalloon.SetActive(false);
            isInteracting = false;
            interactedObj = null;
        }
    }

    public void Interact(){
        string triggerName = interactedObj.GetComponent<TriggerInfo>().triggerName;

        if(triggerName == "Photo"){
            mLinker.mUIManager.ShowDialogue(true, "this is my family photo.");
        }else if(triggerName == "Door"){
            mLinker.mUIManager.ShowDialogue(true, "the door is locked.");
        }
    }
}
