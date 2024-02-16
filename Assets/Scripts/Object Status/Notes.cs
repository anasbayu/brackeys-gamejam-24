using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour{
    public Linker mLinker;
    public List<Quest> notes = new List<Quest>();

    void Start(){
        // Default quest.
        AddNote(new Quest("Get the package from grandpa. It should arrive this afternoon."));
        AddNote(new Quest("The Morleys, our new neighbour called this morning. They wanted to visit our house."));
        AddNote(new Quest("Don't go to Tim house before I come home! I'll arrive around 5 PM."));
    }

    public void AddNote(Quest newNote){
        notes.Add(newNote);
    }

    public void ReadNotes(){
        string noteToShow = "";
        foreach(Quest note in notes){
            noteToShow += note.GetQuestText() + "<br>";
        }
        mLinker.mUIManager.ShowQuestBox(true, noteToShow);
    }
}
