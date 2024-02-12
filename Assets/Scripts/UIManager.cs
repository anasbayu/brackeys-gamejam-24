using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour{
    public Linker mLinker;
    public GameObject mTextBox;
    public TMP_Text mTxt;
    public bool isDialogueShowing;

    void Start(){
        isDialogueShowing = false;
        mTextBox.SetActive(false);
    }

    public void ShowDialogue(bool isShowing, string text){
        mTextBox.SetActive(isShowing);
        mTxt.text = text;
        isDialogueShowing = isShowing;
    }
}
