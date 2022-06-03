using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainAudio : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioSource musicSource;
    [Header("Choose clips")]
    public AudioClip click, fire;

    [Header("Music")]
    public AudioClip MainMenuTrack;


    // Start is called before the first frame update
    void Start()
    {
        musicSource.PlayOneShot(MainMenuTrack);
    }

    
    public void PlayClickSound(){
        soundSource.PlayOneShot(click);
    }
    public void PlayFireSound(){
        soundSource.PlayOneShot(fire);
    }
    
}
