using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// dublicate game object a few times to create more lightning sound
/// </summary>
public class RandomAudioPlay : MonoBehaviour
{

    AudioSource audioSource;

    float randomVolume; // this change everytime the play sound is invoked
    [SerializeField] public float sourceVolume;

    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log(audioSource.name);
    }
    void Start()
    {
        
        float randomRepeatRate = Random.Range(32, 42);//random repeate rate between 4s and 10s 
        InvokeRepeating("playSound", 1, randomRepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        sourceVolume = audioSource.volume;
    }

    void playSound()
    {
        randomVolume = Random.Range(0.1f, 1f);
        // play only if not playing already 
        if (!audioSource.isPlaying)
        {
            audioSource.volume = randomVolume;
            audioSource.Play();
        }
    }
}
