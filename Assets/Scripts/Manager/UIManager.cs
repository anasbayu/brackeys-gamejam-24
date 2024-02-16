using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour{
    public Linker mLinker;
    public GameObject mTextBox;
    public GameObject mQuestBox;
    public TMP_Text mTxt;
    public TMP_Text mQuestTxt;
    public bool isDialogueShowing, isQuestShowing;
    public GameObject mOverlay;
    bool isPaused;

    void Start(){
        isDialogueShowing = false;
        isQuestShowing = false;
        mTextBox.SetActive(false);
        isPaused = false;
    }

    public void ShowDialogue(bool isShowing, string text){
        mTextBox.SetActive(isShowing);
        mTxt.text = text;
        isDialogueShowing = isShowing;

        if(isShowing){
            mLinker.mTimeManager.PauseTimeCount();
            mLinker.mPlayer.StopAnimateWalk();
        }else{
            mLinker.mTimeManager.ContinueGame();
        }
    }

    public void ShowQuestBox(bool isShowing, string quests){
        mQuestBox.SetActive(isShowing);
        mQuestTxt.text = quests;
        isQuestShowing = isShowing;

        if(isShowing){
            mLinker.mTimeManager.PauseTimeCount();
            mLinker.mPlayer.StopAnimateWalk();
        }else{
            mLinker.mTimeManager.ContinueGame();
        }
    }

    public void ToggleShowPauseMenu(){
        isPaused = !isPaused;

        mOverlay.SetActive(isPaused);
    }
}
