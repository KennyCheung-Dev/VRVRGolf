using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitSound : MonoBehaviour {

	public GameObject club;
	public GameObject clubHeads;
	public float clubSpeed;
	private AudioSource audiBoi;

	public AudioClip smolSound;
	public AudioClip biigSound;

	public float soundCoolDown;

	public float speedThreshold;

	public Rigidbody rigidBoi;

	public bool canSound = true;

	public GameObject soundPrefab;
	// Use this for initialization
	void Start () {
		//OVRInput.SetControllerVibration(freq, trigger, OVRInput.Controller.RTouch);
		//StartCoroutine(stopVibrating(vibrateLength));
		audiBoi = GetComponent<AudioSource>();
		rigidBoi = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

	}

//	void OnCollisionEnter(Collision collision)
//	{
//		if (collision.gameObject.tag == ("Ball"))
//		{
//			if (canSound) {
//				//if (rigidBoi.velocity.magnitude > speedThreshold) {
//				StartCoroutine (MakeSound (clubSpeed));
				//canSound = false;
///			}
//		}

//	}

	void OnCollisionEnter(Collision collision) {
		//print ("hit");
		if (collision.gameObject.tag == ("Club"))
		{
			if (canSound) {
				float velocity = collision.transform.root.GetComponent<Rigidbody> ().GetRelativePointVelocity (collision.transform.position).magnitude;
				//print (velocity);
				GameObject soundInstance = Instantiate (soundPrefab, gameObject.transform.position, Quaternion.identity);

				if (velocity < speedThreshold) {
                    try {
                        audiBoi.Play();
                    } catch
                    {
                        //print("whups");
                    }
					//soundInstance.GetComponent<SoundScript> ().audioC = smolSound;
				} else {
					//soundInstance.GetComponent<SoundScript>().audioC = biigSound;

				}
					soundInstance.GetComponent<SoundScript> ().destroyAfterPlay = true;

				
				//StartCoroutine (MakeSound (clubSpeed));
				//canSound = false;
			}
		}
	}

	/*
	private void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag == ("Ball"))
		{
			if (canSound) {
				GameObject soundInstance = Instantiate (soundPrefab, gameObject.transform.position, Quaternion.identity);

				//if(lowSpeed) {
				soundInstance.GetComponent<SoundScript>().audioC = smolSound;
				//} else {
				//soundInstance.GetComponent<SoundScript>().audioC = biigSound;

				//StartCoroutine (MakeSound (clubSpeed));
				//canSound = false;
			}
		}

	}*/

	/*
	private IEnumerator MakeSound (float speed) {
		//if (rigidBoi.GetRelativePointVelocity(
			audiBoi.PlayOneShot (biigSound, 1.0f);
		print ("I am making Sounds!");

			//audiBoi.PlayOneShot (smolSound, 1.0f);

		yield return new WaitForSeconds(soundCoolDown);
		canSound = true;
	}*/
}
