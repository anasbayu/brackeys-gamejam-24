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
        if(!mLinker.mUIManager.isDialogueShowing && !mLinker.mUIManager.isQuestShowing 
            && !mLinker.mGameManager.isPaused && !mLinker.mGameManager.isGameOver){
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
                // if from phone
                Debug.Log(mLinker.mPlayerSense.interactedObj.name);
                if(mLinker.mPlayerSense.interactedObj.name == "Telephone"){
                    mLinker.mPhone.PhoneConversation();
                }else{
                    mLinker.mUIManager.ShowDialogue(false, "");
                }
            }else{
                mLinker.mUIManager.ShowDialogue(false, "");

                // If the door is open & there is no event, close it.
                if(mLinker.mDoor.isDoorOpen && !mLinker.mEventManager.IsThereAnEvent()){
                    mLinker.mDoor.Close();
                // If the door is open & there is event going on, reply.
                }else if(mLinker.mDoor.isDoorOpen && mLinker.mEventManager.IsThereAnEvent()){
                    // When there is an event, set the reply IF the Person is not let in yet.
                    if(mLinker.mEventManager.GetCurrEvent().
                        GetAssociatedPeople().isLetInside){
                        
                        // If the current People is a killer. Game Over.
                        if(mLinker.mEventManager.GetCurrEvent().
                            GetAssociatedPeople().type == "Killer"){


                            // Play gameover SFX.


                            // Play death scene.
                            mLinker.mGameManager.SetGameOver();
                        }else if(mLinker.mEventManager.GetCurrEvent().
                            GetAssociatedPeople().type == "Plumber"){
                            // If the person is a Plumber.
                            mLinker.mEventManager.PlumberToWork();
                        }

                        mLinker.mDoor.Close();
                        mLinker.mEventManager.StopEvent();
                    }else{
                        People tmpPeople = mLinker.mEventManager.GetCurrEvent().GetAssociatedPeople();
                        string textToDisplay = tmpPeople.LettingInsideHouse();
                        mLinker.mUIManager.ShowDialogue(true, textToDisplay);

                        // Set the Quest.
                        mLinker.mNote.CompleteAQuest(tmpPeople.type);
                    }                
                }else if(mLinker.mEventManager.GetCurrEvent().GetAssociatedPeople().isHavingConversation){
                    string textToDisplay = mLinker.mEventManager.GetCurrEvent().
                        GetAssociatedPeople().GetConversationMsg();
                        mLinker.mUIManager.ShowDialogue(true, textToDisplay);
                }
            }
        }

        // Close the Quest Box.
        if(Input.GetKeyDown(KeyCode.Space) && mLinker.mUIManager.isQuestShowing){
            mLinker.mUIManager.ShowQuestBox(false, "");
        }

        // Pause game.
        if(Input.GetKeyDown(KeyCode.Escape) && !mLinker.mGameManager.isGameOver){
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
