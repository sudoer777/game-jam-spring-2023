using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class volumeMaster : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        // Set the slider's value to the current master volume
        volumeSlider.value = AudioListener.volume;
    }

    public void SetMasterVolume(float volume)
    {
        // Set the AudioListener's volume to the value of the slider
        AudioListener.volume = volume;
    }
    
}
