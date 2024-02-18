using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroDialogue : MonoBehaviour
{
    public List<string> dialogues = new List<string>();
    public GameObject mIntroSection;
    public TMP_Text mTxtIntro;
    int currIntroIndex;
    public SceneLoader mUI;


    bool isIntroStarting;

    void Start(){
        currIntroIndex = 0;
        isIntroStarting = false;
        mIntroSection.SetActive(false);
        mTxtIntro.text = dialogues[0];
    }

    public void StartIntro(){
        isIntroStarting = true;
        mIntroSection.SetActive(true);
    }

    void Update(){
        if(isIntroStarting){
            if(Input.GetKeyDown(KeyCode.Space)){
                currIntroIndex++;

                if(currIntroIndex >= dialogues.Count){
                    mUI.Load("Gameplay");
                }else{
                    mTxtIntro.text = dialogues[currIntroIndex];
                }
            }
        }
    }
}
