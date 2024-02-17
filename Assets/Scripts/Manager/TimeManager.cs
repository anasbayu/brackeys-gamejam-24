using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour{
    public Linker mLinker;
    public static bool isDaytime;
    public UnityEngine.Rendering.Universal.Light2D globalLight;
    // public Light2D[] lampuRumah;

    public float lightDecrement, lightIncrement;

    float timeLeft;
    [SerializeField] int timeOfDay = 0;
    [SerializeField] int currHour;
    [SerializeField] int currMin;


    void Start(){
        // Set global light color.
        // globalLight.color = mDictColor.GetLightColor(1);
        StartTheDay();
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
        // Play SFX rooster.
        if(timeOfDay == 3){
            // mLinker.mSoundManager.PlayEnvSound("rooster");
        }

        // Pengaturan lightning global.
        // if(timeOfDay >= 50 && timeOfDay < 83){
        //     globalLight.intensity -= lightDecrement;
        // }else if(timeOfDay >= 83){
        //     globalLight.intensity += lightIncrement;
        // }else{
        //     globalLight.intensity = 1;
        // }

        timeOfDay++;
        currMin = timeOfDay%60;
        if(currMin == 0){
            currHour++;
        }
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

        // List<Color> newColor = mDictColor.GetSkyColor(tmpIndex);


        // if (timeLeft <= Time.deltaTime){
        //     timeLeft = 11f;
        // }
        // else{
        //     Color tmpColor1 = Color.Lerp(mShader.GetColor("_Color1"), newColor[0], Time.deltaTime / timeLeft);
        //     Color tmpColor2 = Color.Lerp(mShader.GetColor("_Color2"), newColor[1], Time.deltaTime / timeLeft);

        //     // Set sky color.
        //     mShader.SetColor("_Color1", tmpColor1);
        //     mShader.SetColor("_Color2", tmpColor2);
        
        //     try{
        //         // Set cloud color.
        //         Color cloudColor = Color.Lerp(cloud.color, mDictColor.GetCloudColor(tmpIndex-1), Time.deltaTime / timeLeft);
        //         cloud.color = cloudColor;
        //         // cloud.color = mDictColor.GetCloudColor(tmpIndex-1);
        //     }
        //     catch (System.Exception){
        //         Debug.Log("WARN: No color set.");
        //     }

        //     // Set global light color.
        //     Color lightColor = Color.Lerp(globalLight.color, mDictColor.GetLightColor(tmpIndex-1), Time.deltaTime / timeLeft);
        //     globalLight.color = lightColor; 
        //     // globalLight.color = mDictColor.GetLightColor(tmpIndex-1); 
            
        //     timeLeft -= Time.deltaTime;
        // }
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
