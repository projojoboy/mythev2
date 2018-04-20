using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {
	public AudioClip[] clips;
	public float endTimer;
	public float Timer;

	void Start () {
	Timer = 0f;
	endTimer = Random.Range(30f, 60f);
	}

	void Update () {
		Timer += Time.deltaTime;
		if (Timer >= endTimer){
			playSound ();
			Timer = 0;
		}
	}
	void playSound (){
	int randomClip = Random.Range (0, clips.Length);
	AudioSource source = gameObject.AddComponent<AudioSource> ();
		source.clip = clips[randomClip];
		source.Play();
		endTimer = Random.Range (30f, 60f);
		Destroy (source, clips[randomClip].length);
	}
}


