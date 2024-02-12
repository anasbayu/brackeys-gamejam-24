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
    // Scene scene;

    void Start(){
        facingRight = true;
        isMoving = false;
    }

    void Update(){
        if(!mLinker.mUIManager.isDialogueShowing && !mLinker.mGameManager.isPaused){
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
                mAnimator.SetBool("IsWalking", false);
                isMoving = false;
            }

            // Interact action.
            if(Input.GetKeyDown(KeyCode.F) && mLinker.mPlayerSense.isInteracting){
                mLinker.mPlayerSense.Interact();
            }
        }

        // Close the dialogue box.
        if(Input.GetKeyDown(KeyCode.Space) && mLinker.mUIManager.isDialogueShowing){
                mLinker.mUIManager.ShowDialogue(false, "");
        }

        // Pause game.
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(mLinker.mGameManager.isPaused){
                mLinker.mGameManager.ResumeGame();
            }else{
                mLinker.mGameManager.PauseGame();
            }
        }
    }

    private void Flip(){
       //Switch the way the player is labelled as facing.
       facingRight = !facingRight;
 
       //Multiply the player's x local scale by -1.
       Vector3 theScale = transform.localScale;
       theScale.x *= -1;
       transform.localScale = theScale;
    }


   public string GetDirection(){
        string returnVal = "idle";

        if(isMoving){
            if(facingRight){
                returnVal = "right";
            }else{
                returnVal = "left";
            }
        }

        return returnVal;
   }
}
