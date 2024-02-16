using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{
    public Linker mLinker;
    public List<string> responseTextGeneral = new List<string>();
    
    public string Open(){
        //TODO: Check if there is an event running?

        int responseIndex = Random.Range(0, responseTextGeneral.Count);
        return responseTextGeneral[responseIndex];
    }

    public void Knock(){
        mLinker.mSoundManager.PlayKnock();
    }
}
