using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheck : MonoBehaviour {

	public float jumpForce;
	public Transform playerDeath;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		PlayerController player = other.GetComponent<PlayerController> ();
		try{
			if (player.isFalling && other.tag =="Player") {
			
				if (gameObject.tag == "spikes") {
					FindObjectOfType<AudioManager> ().Play ("Spike");
					Instantiate (playerDeath, transform.position, transform.rotation);
					Destroy (other.gameObject);
				} else if (gameObject.tag == "fall") {
					FindObjectOfType<AudioManager> ().Play ("Break");
					player.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
					player.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce);
					Destroy (gameObject);
				} else {
					if (gameObject.tag == "bounce") {
						FindObjectOfType<AudioManager> ().Play ("Bounce");
					} else if (gameObject.tag == "platform") {
						FindObjectOfType<AudioManager> ().Play ("Jump");
					}
					player.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
					player.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpForce);
				}
			}
		} catch(NullReferenceException e){

		}

			
	}
}
