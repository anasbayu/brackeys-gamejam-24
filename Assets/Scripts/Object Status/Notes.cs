using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour{
    public Linker mLinker;
    public List<Quest> notes = new List<Quest>();

    void Start(){
        // Default quest.
        AddNote(new Quest("Get the package from grandpa. It should arrive this afternoon.", "Delivery Guy"));
        AddNote(new Quest("The Morleys, our neighbor called this morning. They wanted us to taste their Mochi.", "Neighbor"));
        AddNote(new Quest("A Plumber will vome over this morning", "Plumber"));
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
