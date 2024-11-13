using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Manages the sound effects and music in the game
/// </summary>
public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public static SoundManager instance;



    private float musicVolume = 1;

    public float MusicVolume
    {
        get { return musicVolume; }
        set
        {
            musicVolume = value;
            musicSource.volume = musicVolume;

        }
    }
    private float sfxVolume = 1;



    public float SfxVolume
    {
        get { return sfxVolume; }
        set
        {
            sfxVolume = value;
            sfxSource.volume = sfxVolume;
        }
    }


    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSfx()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    void Awake()
    {
        instance = this;
    }


}
