using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditUI : MonoBehaviour{
   public GameObject mCreditMsg;

   public void OpenCreditMsg(){
        mCreditMsg.SetActive(true);
   }

   public void Load(string sceneName){
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
