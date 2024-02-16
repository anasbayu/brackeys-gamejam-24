using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public Linker mLinker;
    public bool isShutterOpen;
    public GameObject mShutter;
    public GameObject mWindowLight;
    public List<string> peekResponseTextGeneral = new List<string>();

    void Start(){
        isShutterOpen = true;
        mShutter.SetActive(!isShutterOpen);
    }

    public void ToggleShutter(){
        isShutterOpen = !isShutterOpen;

        // Play shutter sfx.
        mShutter.SetActive(!isShutterOpen);
        mWindowLight.SetActive(isShutterOpen);
    }

    // Let the Player see the street from the window.
    public string Peek(){
        int responseIndex = Random.Range(0, peekResponseTextGeneral.Count);

        if(isShutterOpen){
            // Check if an event is running currently.
            if(mLinker.mEventManager.IsThereAnEvent()){
                return mLinker.mEventManager.GetCurrEvent().GetAssociatedPeople().GetWindowPeekMsg();
            }else{
                // Random peek response.
                return peekResponseTextGeneral[responseIndex];
            }
        }else{
            return "I can't see with the shutter closed.";
        }
    }
}
