using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform player;
	public Transform playerDeath;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Camera movement
		if (player.position.y > transform.position.y+0.5f && player.transform.position.y > 0) {
			gameObject.transform.position = new Vector3 
				(transform.position.x, player.transform.position.y-0.5f, transform.position.z);
		}

		// Player loses
		if (player.position.y < (transform.position.y - 5.6975)) {
			Instantiate (playerDeath, player.position, player.rotation);
			Destroy (player.gameObject);
		}

		// Score
		if (player.position.y > PlayerScore.heightScore) {
			PlayerScore.heightScore = (int)player.position.y;
		}
	}

}
