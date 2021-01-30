using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void setMasterVolume(float vol)
    {
        masterMixer.SetFloat("MasterVol", vol);
    }

    public void setSFXVolume(float vol)
    {
        masterMixer.SetFloat("SFXVol", vol);
    }
}
