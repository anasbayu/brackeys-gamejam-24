using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public Linker mLinker;
    public bool isPaused;
    public bool isGameOver;

    void Start(){
        isGameOver = false;
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

    public void SetGameOver(){
        isGameOver = true;
        mLinker.mUIManager.ShowGameOver();
    }
}
