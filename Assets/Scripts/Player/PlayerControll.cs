using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour{
    public Linker mLinker;
    public int speed;
    bool facingRight;           // direction indicator
    bool isMoving;
    // public GameObject indicator;
    public Animator mAnimator;
    public GameObject charSprite;
    void Start(){
        facingRight = true;
        isMoving = false;
    }

    void Update(){
        // DEBUG PURPOSE ONLY.
        if(Input.GetKey(KeyCode.G)){
            mLinker.mSoundManager.PlayKnock();
        }
        if(Input.GetKey(KeyCode.H)){
            mLinker.mSoundManager.PlayRingtone();
        }


        if(!mLinker.mUIManager.isDialogueShowing && !mLinker.mUIManager.isQuestShowing 
            && !mLinker.mGameManager.isPaused){
            // Move right.
            if(Input.GetKey(KeyCode.D)){
                isMoving = true;
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                
                if(!facingRight){
                    Flip();
                }

                // Play the animation.    
                mAnimator.SetBool("IsWalking", true);
                
                // Play SFX.
                // mLinker.mSFX.PlaySFX("Walk");
            }

            // Move left.
            if(Input.GetKey(KeyCode.A)){
                isMoving = true;
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                
                if(facingRight){
                    Flip();
                }

                // Play the animation.
                mAnimator.SetBool("IsWalking", true);
                            

                // Play SFX.
                // mLinker.mSFX.PlaySFX("Walk");
            }

            if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)){
                StopAnimateWalk();
            }

            // Interact action.
            if(Input.GetKeyDown(KeyCode.F) && mLinker.mPlayerSense.isInteracting){
                mLinker.mPlayerSense.Interact();
            }

            if(Input.GetKeyDown(KeyCode.Q) && mLinker.mPlayerSense.isInteracting && mLinker.mPlayerSense.isMultiAction){
                mLinker.mPlayerSense.CycleAction();
            }
        }

        // Close the dialogue box.
        if(Input.GetKeyDown(KeyCode.Space) && mLinker.mUIManager.isDialogueShowing){
            if(mLinker.mPhone.IsThereOnGoingCall()){
                mLinker.mPhone.PhoneConversation();
            }else{
                mLinker.mUIManager.ShowDialogue(false, "");
            }
        }

        // Close the Quest Box.
        if(Input.GetKeyDown(KeyCode.Space) && mLinker.mUIManager.isQuestShowing){
            mLinker.mUIManager.ShowQuestBox(false, "");
        }

        // Pause game.
        if(Input.GetKeyDown(KeyCode.Escape)){
            mLinker.mGameManager.TooglePauseGame();
        }
    }

    private void Flip(){
       //Switch the way the player is labelled as facing.
       facingRight = !facingRight;
 
       //Multiply the player's x local scale by -1.
       Vector3 theScale = charSprite.transform.localScale;
       theScale.x *= -1;
       charSprite.transform.localScale = theScale;
    }


   public string GetDirection(){
        string returnVal = "idle";

        if(isMoving){
            if(facingRight){
                returnVal = "Right";
            }else{
                returnVal = "Left";
            }
        }

        return returnVal;
   }


    public void StopAnimateWalk(){
        mAnimator.SetBool("IsWalking", false);
        isMoving = false;
    }
}
