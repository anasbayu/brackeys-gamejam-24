using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest{
    string questText;
    bool isComplete;

    public Quest(string newQuest){
        isComplete = false;
        questText = newQuest;
    }

    public void SetQuestText(string text){
        questText = text;
    }

    public string GetQuestText(){
        return questText;
    }
}
