using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

	public static int score = 0;
	public static int heightScore = 0;
	public static int highscore = 0;
	public static int totalScore = 0;
	public GameObject playerScoreUI;
	public GameObject playerHighScoreUI;
	public GameObject player;
	public Transform collect;

	// Use this for initialization
	void Start () {
		score = 0;
		heightScore = 0;
		totalScore = 0;
	}

	// Update is called once per frame
	void Update () {
		totalScore = heightScore + score;
		if (player == null) {
			SceneManager.LoadScene("Main");
		}
		if (totalScore > highscore) {
			highscore = totalScore;
		}
		playerScoreUI.gameObject.GetComponent<Text> ().text = "Score: " + totalScore;
		playerHighScoreUI.gameObject.GetComponent<Text> ().text = "Highscore: " + highscore;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.name == "Gem" || other.gameObject.tag == "Gem") {
			FindObjectOfType<AudioManager> ().Play ("Collect");
			score += 30;
			Instantiate (collect, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "enemy") {
			FindObjectOfType<AudioManager> ().Play ("Collect");
			score += 90;
			Instantiate (collect, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}
	}
		
}
