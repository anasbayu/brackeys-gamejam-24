using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{
    public GameObject mHintSection;
    public GameObject mMenuSectionToHide;
    bool isReadyToStart = false;

    void Start(){
        Time.timeScale = 1f;
    }

    void Update(){
        if(isReadyToStart && Input.GetKey(KeyCode.Space)){
            Load("Gameplay");
        }
    }

    public void Load(string sceneName){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void ShowHint(){
        isReadyToStart = true;
        mMenuSectionToHide.SetActive(false);
        mHintSection.GetComponent<Animator>().SetBool("ScrollDown", true);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
