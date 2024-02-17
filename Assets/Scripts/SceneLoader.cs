using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{
    public GameObject mCreditSection;

    public void Load(string sceneName){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void ShowCredits(){
        // mCreditSection.GetComponent<Animator>().Play();
    }
    public void QuitGame(){
        Application.Quit();
    }
}
