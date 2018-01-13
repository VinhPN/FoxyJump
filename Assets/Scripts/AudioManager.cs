// CREDIT GOES TO BRACKEYS https://www.youtube.com/user/Brackeys
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	// Use this for initialization
	void Awake () {
		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
	void Start(){
		
	}
	// Update is called once per frame
	public void Play (string name) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null)
			return;
		s.source.Play ();
	}
	public void StopPlaying (string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * 0;
		s.source.pitch = s.pitch * 0;

		s.source.Stop ();
	}

}
