using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
   public void SetVolume(float volume)
    {
        //here the minimum value on the slider is -25, however the audio mixer's min value is -80
        //so when the slider is set to minimum we want to mute the audio/ set it to the mixer's minimum
        //this is done to avoid making 80% of the slider way to quiet and unused
        //also way too sensitive in the top 20%
        if (volume <= -25f)
        {
            volume = -80f;
        }
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }
}
