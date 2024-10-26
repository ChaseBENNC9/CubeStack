using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private static SoundManager instance;



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

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
