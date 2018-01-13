using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float playerSpeed;
	public bool isFalling;

	float moveX;
	Rigidbody2D rb;	
	Animator anim;
	// Use this for initialization
	void Start () {
		FindObjectOfType<AudioManager>().Play ("Theme");
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		Movement ();
			
		if (moveX < 0.0f) {
			GetComponent<SpriteRenderer> ().flipX = true;
		} else if (moveX > 0.0f) {
			GetComponent<SpriteRenderer> ().flipX = false;
		}
		if (rb.velocity.y <= -0.1f) {
			isFalling = true;
		} else {
			isFalling = false;
		}
		anim.SetBool("isFalling", isFalling);
	}

	void Movement(){
		moveX = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (playerSpeed * moveX, rb.velocity.y);

		//Wrap
		if (transform.position.x <= -7.07f) {
			transform.position = new Vector3 (7.07f, transform.position.y,0);	
		} else if(transform.position.x >= 7.07f){
			transform.position = new Vector3 (-7.07f, transform.position.y,0);	
		}
	}
		
}
