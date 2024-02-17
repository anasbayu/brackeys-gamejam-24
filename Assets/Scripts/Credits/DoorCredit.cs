using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCredit : MonoBehaviour
{
    public GameObject mClosedDoor;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            mClosedDoor.SetActive(false);
        }
    }
}
