using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour{
    public bool isEmpty;
    List<string> fridgeObjects = new List<string>();

    void Start() {
        isEmpty = true;
        fridgeObjects.Add("Milk");
        fridgeObjects.Add("Apple");
        fridgeObjects.Add("Coffee");
    }

    public List<string> CheckWhatsIndside(){
        return fridgeObjects;
    }

    public void AddItemToFridge(string item){
        fridgeObjects.Add(item);
    }

    public void RemoveItemFromFridge(string item){
        // Fridge.RemoveAt(0);
    }
}
