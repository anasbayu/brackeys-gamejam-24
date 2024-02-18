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
    public GameObject mGameOverSection;
    public GameObject mGameCompleteSection;
    public GameObject heart1, heart2, heart3;

    void Start(){
        isDialogueShowing = false;
        isQuestShowing = false;
        mTextBox.SetActive(false);
        isPaused = false;
        mGameOverSection.SetActive(false);
        mGameCompleteSection.SetActive(false);
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

    public void ShowGameOver(){
        mLinker.mTimeManager.StopTime();
        mGameOverSection.SetActive(true);
        heart1.SetActive(false);
        heart2.SetActive(false);   
        heart3.SetActive(false);   
    }

    public void ShowGameComplete(){
        mLinker.mTimeManager.StopTime();
        mGameCompleteSection.SetActive(true);
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

    public void DecreaseHeart(int heartLeft){
        if(heartLeft == 2){
            heart3.SetActive(false);
        }else if(heartLeft == 1){
            heart2.SetActive(false);
        }else{
            heart1.SetActive(false);
        }
    }
}
