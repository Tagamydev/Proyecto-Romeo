using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public	AudioClip[]	Sounds;
	public	AudioSource	Source;
	[SerializeField, Range(0, 1)]private	float		BackgroundMusicVolume;
	[SerializeField, Range(0, 1)]private	float		SFXVolume;
    // Start is called before the first frame update
    void Start()
    {
		Source = GetComponent<AudioSource>();
		Source.PlayOneShot(Sounds[0], 1);
        
    }

    public void PlayHitSound()
    {
		PlaySound(Sounds[2], SFXVolume);
    }

    public void PlayBackgroundMainMenuMusic()
    {
		PlaySound(Sounds[0], BackgroundMusicVolume);
    }


    public void PlaySound(AudioClip sound, float volume = 1)
    {
		Source.PlayOneShot(sound, volume);
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown("space"))
	    {
		Source.PlayOneShot(Sounds[3], 1);
		
	    }
        
    }
}
