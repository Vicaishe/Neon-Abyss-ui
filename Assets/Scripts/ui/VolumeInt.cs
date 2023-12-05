using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeInt : MonoBehaviour
{

    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;



    // Start is called before the first frame update
    void Start()
    {
        var volumeValue = PlayerPrefs.GetFloat(volumeParameter, volumeParameter == "SoundVol" ? 0f : -80f);
        mixer.SetFloat(volumeParameter, volumeValue);
    }

    
}
