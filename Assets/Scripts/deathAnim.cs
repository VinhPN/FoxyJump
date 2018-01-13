using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathAnim : MonoBehaviour {

	public float moveSpeed;
	public float despawnTime;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		rb.AddForce (Vector2.up * moveSpeed);

		StartCoroutine (Countdown ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Countdown(){
		yield return new WaitForSeconds (despawnTime);
		Destroy (gameObject);
	}
}
