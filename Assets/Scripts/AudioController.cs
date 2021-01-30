using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController current;

    public AudioClip mainMenuBackgroundClip;
    public AudioClip mainMenuEnvironmentClip;
    public AudioClip buttonCLickClip;

    public AudioClip playingModeBackgroundClip;
    public List<AudioClip> playingModeEnvironmentSFXClips;

    public AudioClip ghostClip;
    public AudioClip UIClickClip;

    public AudioClip pointClip;
    public AudioClip missClickClip;
    public AudioClip timerClip;

    public AudioClip gameOverClip;

    AudioSource backgroundMusic; // switch between main menu sound and game play maybe in smooth transition 
    AudioSource environmentSounds; // Play random clips from the list Switch between main menu and playing mode sounds

    AudioSource UIClickSound; // play every time ui click event occuer ! maybe audiosource should be attached to each button !
    AudioSource ghostSound; // this should be attach to ghost gameobject 

    AudioSource timerTicking; // this should be attach to timer 

    AudioSource gameOverSound; // this should play only when gameover occuer 

    public float volume;// should adjust by setting ui 
    public float music; // should adjust by setting ui 

    public float Volume
    {
        get { return volume; }
        set
        {
            // set volume
            volume = value;
            // update volume
            updateVolume();
        }
    }

    private void Awake()
    {
        //singltonSCript 
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //set needed audio source 
        backgroundMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateVolume()
    {
        backgroundMusic.volume = volume;
    }
}
