using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMovement : MonoBehaviour{

    public float speed;
    public CreditUI mUIManager;
    public Animator mAnimator;
    public CamMovement mCamManager;

    void Start(){
        mAnimator.SetBool("IsWalking", true);
    }

    void Update(){
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Credit Open"){
            mAnimator.SetBool("IsWalking", false);
            speed = 0;
            mUIManager.OpenCreditMsg();
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Cam Switch"){
            if(other.gameObject.name == "Cam Switch 1"){
                mCamManager.ChangeCamPos("Foyer");
            }else{
                mCamManager.ChangeCamPos("Living Room");                
            }
        }
    }
}
