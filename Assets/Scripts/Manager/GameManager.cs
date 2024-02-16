using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public Linker mLinker;
    public bool isPaused;

    void Start(){
        isPaused = false;
    }

    public void TooglePauseGame(){
        isPaused = !isPaused;
        mLinker.mUIManager.ToggleShowPauseMenu();
        
        if(isPaused){
            mLinker.mTimeManager.StopTime();
        }else{
            mLinker.mTimeManager.ResumeTime();
        }
    }
}
