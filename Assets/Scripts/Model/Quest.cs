using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest{
    string questText;
    string questType;

    public bool isComplete;

    public Quest(string newQuest, string type){
        isComplete = false;
        questText = newQuest;
        questType = type;
    }

    public void SetQuestText(string text){
        questText = text;
    }

    public string GetQuestText(){
        return questText;
    }

    public bool CheckQuestType(string typeToCheck){
        if(typeToCheck == questType){
            return true;
        }else{
            return false;
        }
    }

    public void CompleteQuest(){
        isComplete = true;
        questText = "<s>" + questText + "</s>";
    }
}
