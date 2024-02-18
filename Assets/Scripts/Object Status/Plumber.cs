using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plumber : MonoBehaviour
{
    public void StartWork(){
        // stay and work for 30 sec.
        Invoke("Dissappear", 30f);
    }

    void Dissappear(){
        gameObject.SetActive(false);
    }
}
