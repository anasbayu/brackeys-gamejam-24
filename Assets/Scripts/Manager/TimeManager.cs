using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour{
    public Linker mLinker;
    public static bool isDaytime;
   
    // public Light2D[] lampuRumah;
    public UnityEngine.Rendering.Universal.Light2D mWindowLight;    
    public UnityEngine.Rendering.Universal.Light2D mGlobalLight;   
    public UnityEngine.Rendering.Universal.Light2D mKitchenLight;   

    
    public string hexMorning, hexMidday, hexEvening, hexNight;

    [SerializeField] int timeOfDay = 0;
    [SerializeField] int currHour;
    [SerializeField] int currMin;


    void Start(){
        StartTheDay();
        ChangeLightColor();
    }

    public void isGameOver(){
        CancelInvoke();
    }

    public void StartTheDay(){
        isDaytime = true;
        InvokeRepeating("CycleStart", 0, 1f);

        timeOfDay = 0;
        currHour = 8;       // Change here to change the default starting hour. Using 24 hour format.
    }

    public void ContinueGame(){
        InvokeRepeating("CycleStart", 0, 1f);
    }

    public void PauseTimeCount(){
        CancelInvoke("CycleStart");
    }

    void CycleStart(){
        timeOfDay++;
        currMin = timeOfDay%60;
        if(currMin == 0){
            currHour++;

            ChangeLightColor();
        }
    }

    void ChangeLightColor(){
        string colorHex = "";

        // Pengaturan lightning global.
        if(currHour < 12){
            mGlobalLight.intensity = 0.5f;
            colorHex = hexMorning;

            mKitchenLight.intensity = 0f;
        }else if(currHour < 16){
            mGlobalLight.intensity = 0.7f;
            colorHex = hexMidday;
        }else if(currHour < 19){
            mGlobalLight.intensity = 0.5f;
            colorHex = hexEvening;
        }else{
            mGlobalLight.intensity = 0.2f;
            colorHex = hexNight;

            mKitchenLight.intensity = 1f;
        }

        Color newCol;
        ColorUtility.TryParseHtmlString(colorHex, out newCol);
        mWindowLight.color = newCol;
    }

    void Update(){
        int tmpIndex = 0;
        if(timeOfDay <= 5){
            tmpIndex = 2;
        }else if(timeOfDay <= 38){
            tmpIndex = 3;
        }else if(timeOfDay <= 40){
            tmpIndex = 4;
        }else if(timeOfDay <= 43){
            tmpIndex = 5;
        }else if(timeOfDay <= 50){
            tmpIndex = 6;
        }else if(timeOfDay <= 85){
            tmpIndex = 7;
        }else if(timeOfDay <= 90){
            tmpIndex = 1;
        }
    }

    
    public void ResumeTime(){
        // Resume the time in-game.
        Time.timeScale = 1f;
    }
    public void StopTime(){
        // Pause the time in-game.
        Time.timeScale = 0f;
    }

    public int GetCurrTime(){
        // Return total minutes.
        return timeOfDay;   
    }

    public int GetCurrHour(){
        return currHour;
    }

    public void ShowCurrentTime(){
        // convert hours & minutes to the correct format.
        string tmpMinutesToDisplay;
        string tmpHoursToDisplay;
        if(currMin < 10){
            tmpMinutesToDisplay = "0" + currMin.ToString();
        }else{
            tmpMinutesToDisplay = currMin.ToString();
        }
        if(currHour < 10){
            tmpHoursToDisplay = "0" + currHour.ToString();
        }else{
            tmpHoursToDisplay = currHour.ToString();
        }
        
        mLinker.mUIManager.ShowDialogue(true, "Current time is " + tmpHoursToDisplay + ":" + tmpMinutesToDisplay);
    }
}
