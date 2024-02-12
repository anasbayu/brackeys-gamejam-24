using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public bool isPaused;

    void Start(){
        isPaused = false;
    }

    public void PauseGame(){
        isPaused = true;
    }

    public void ResumeGame(){
        isPaused = false;
    }
}
