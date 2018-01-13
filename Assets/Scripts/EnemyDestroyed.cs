using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyed : MonoBehaviour {

	public Transform enemyDeath;
	PlayerController player;

	// Use this for initialization
	void Start () {
		player = GetComponentInParent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "enemy") {
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			player.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 600f);
			FindObjectOfType<AudioManager>().Play ("Caw");
			Instantiate (enemyDeath, other.transform.position, other.transform.rotation);
			FindObjectOfType<AudioManager>().Play ("Explode");
			Destroy (other.gameObject);
		}
	}
}
