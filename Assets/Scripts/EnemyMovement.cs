using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float enemySpeed = 8.0f;
	public Transform playerDeath;
	enemyHurtbox hb;

	bool faceRight = true;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		hb = GetComponentInChildren<enemyHurtbox> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hb == null) {
			Destroy (gameObject);
		}
		if (transform.position.x >= 8.23) {
			faceRight = false;
			GetComponent<SpriteRenderer> ().flipX = false;
		} else if (transform.position.x <= -8.23) {
			faceRight = true;
			GetComponent<SpriteRenderer> ().flipX = true;
		}

		if (faceRight) {
			rb.velocity = Vector2.right * enemySpeed;
		} else {
			rb.velocity = Vector2.left * enemySpeed;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			FindObjectOfType<AudioManager>().Play ("Spike");
			Instantiate (playerDeath, transform.position, transform.rotation);
			Destroy (other.gameObject);
		}
	}

}
