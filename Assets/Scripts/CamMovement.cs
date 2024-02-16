using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour{
    public GameObject camera;
    public GameObject camPosLivingRoom;
    public GameObject camPosFoyer;
    public GameObject camPosKitchen;
    string currTargetCamPos;
    public float moveSpeed;

    void Start(){
        camera.transform.position = camPosKitchen.transform.position;
        currTargetCamPos = "Kitchen";
    }

    void Update(){
        SlowlyMoveTo(currTargetCamPos);
    }

    void SlowlyMoveTo(string pos){
        if(pos == "Living Room"){
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, 
                camPosLivingRoom.transform.position, moveSpeed * Time.deltaTime);
        }else if(pos == "Foyer"){
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, 
                camPosFoyer.transform.position, moveSpeed * Time.deltaTime);
        }else if(pos == "Kitchen"){
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, 
                camPosKitchen.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    public void ChangeCamPos(string pos){
        currTargetCamPos = pos;
    }
}
