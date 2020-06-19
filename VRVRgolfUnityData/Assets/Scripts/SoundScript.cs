using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

	public bool destroyAfterPlay;

	private AudioSource audioS;
	public AudioClip audioC;

	// Use this for initialization
	void Start () {
		audioS = GetComponent<AudioSource> ();
		if (audioC) {
			audioS.clip = audioC;
		}
		audioS.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audioS.isPlaying && destroyAfterPlay) {
			//destroySelf once done playing
			Destroy (gameObject);
		}
	}

}
