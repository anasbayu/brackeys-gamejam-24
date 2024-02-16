using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Sprite mDoor, mPeek, mTalk, mShutter, mHand;
    public SpriteRenderer mActionIcon;

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

    public void ShowActionBalloon(string actionName){
        if(actionName == "Talk"){
            mActionIcon.sprite = mTalk;
        }else if(actionName == "Open Door"){
            mActionIcon.sprite = mDoor;
        }else if(actionName == "Peek"){
            mActionIcon.sprite = mPeek;
        }else if(actionName == "Shutter"){
            mActionIcon.sprite = mShutter;
        }else{
            mActionIcon.sprite = mHand;
            // Default action, hand icon. Interact.
        }
    }
}
