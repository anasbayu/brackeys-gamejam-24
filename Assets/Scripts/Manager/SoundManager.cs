using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{
    public AudioSource BGMSource, knockSource;
    public List<AudioClip> mKnockSFX = new List<AudioClip>();
    public AudioSource mPhoneSource;
    public bool isPlaying;

    void Start(){
        isPlaying = true;
    }

    public void TogglePlayBGM(){
        isPlaying = !isPlaying;
        if(isPlaying){
            BGMSource.Play();
        }else{
            BGMSource.Stop();
        }
    }

    public void PlayKnock(){
        int randIndex = Random.Range(0,mKnockSFX.Count);
        knockSource.clip = mKnockSFX[randIndex];
        knockSource.Play();
    }

    public void PlayRingtone(){
        mPhoneSource.Play();
    }
    public void StopRingtone(){
        mPhoneSource.Stop();
    }
}
