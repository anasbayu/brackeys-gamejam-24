using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour{
    public Linker mLinker;
    public List<Quest> notes = new List<Quest>();

    void Start(){
        // Default quest.
        AddNote(new Quest("Get the package from grandpa. It should arrive this afternoon.", "Delivery Guy"));
        AddNote(new Quest("The Morleys, our neighbor called this morning. They wanted us to taste their Mochi.", "Neighbour"));
        AddNote(new Quest("A Plumber will come over this morning.", "Plumber"));
    }

    public void AddNote(Quest newNote){
        notes.Add(newNote);
    }

    public void ReadNotes(){
        string noteToShow = "";
        foreach(Quest note in notes){
            noteToShow += note.GetQuestText() + "<br><br>";
        }
        mLinker.mUIManager.ShowQuestBox(true, noteToShow);
    }

    public void CompleteAQuest(string questType){
        foreach(Quest quest in notes){
            if(quest.CheckQuestType(questType) && !quest.isComplete){
                quest.CompleteQuest();

            }
        }

        // everytime a quest is completed, check if all quest complete?
        int completedQuestCount = 0;
        foreach(Quest quest in notes){
            if(quest.isComplete){
                completedQuestCount++;
            }
        }

        if(completedQuestCount == notes.Count){
            Debug.Log("Game Complete!! Win!!");
        }
    }

    public bool CheckIsQuestCompleted(string peopleType){
        bool tmpIsSameQuest = false;

        foreach(Quest quest in notes){
            if(quest.isComplete && quest.CheckQuestType(peopleType)){
                tmpIsSameQuest = true;
            }
        }
        
        return tmpIsSameQuest;
    }
}
