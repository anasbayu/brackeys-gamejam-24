using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public bool isShutterOpen;
    public GameObject mShutter;
    public List<string> peekResponseTextGeneral = new List<string>();

    void Start(){
        isShutterOpen = true;
    }

    public void ToggleShutter(){
        isShutterOpen = !isShutterOpen;

        //TODO. Close the shutter.
        // mShutter.Close();
    }

    // Let the Player see the street from the window.
    public string Peek(){
        int responseIndex = Random.Range(0, peekResponseTextGeneral.Count);
        return peekResponseTextGeneral[responseIndex];
    }
}
