using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformSpawn : MonoBehaviour {

	public int platformAmount;
	public float widthX;
	public float minY;
	public float maxY;
	public GameObject gem;
	public GameObject enemy;
	public GameObject[] platforms;
	public GameObject player;

	float spawnPlatforms; //Creates platform at a vertical location
	public float playerHeight;
	public float platformCheck = 10; //Creates more platforms if player is near

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			FindObjectOfType<AudioManager>().StopPlaying ("Theme");
			StartCoroutine (Reset ());
		}
		playerHeight = player.transform.position.y;

		if (playerHeight > platformCheck) {
			PlatformManager ();
		}
	}

	void PlatformManager(){
		platformCheck = playerHeight + 30;
		Spawn (platformCheck + 30);
	}

	void Spawn(float maxHeight){
		float y = spawnPlatforms;

		while (y < maxHeight) {
			
			int chance = Random.Range (0, 100);
			int enemyChance = Random.Range (0, 100);
			int gemChance = Random.Range (0, 100);

			if (PlayerScore.totalScore < 300) {
				if (chance <= 80) {
					Create (Random.Range (0, 3), y);
				} else if (chance <= 90) {	
					Create (Random.Range (4, 7), y);
				} else if (chance <= 100) {
					Create (Random.Range (7, 10), y);
					Create (Random.Range (0, 3), y - 0.4f);
				}
				if(gemChance <= 35){
					CreateUnit (gem,y);
				}
			
				y += Random.Range (minY, maxY); //Frequency of platforms

			} else if (PlayerScore.totalScore < 700) {
				if (chance <= 70) {
					Create (Random.Range (0, 3), y);
				} else if (chance <= 80) {	
					Create (Random.Range (4, 7), y);
				} else if (chance <= 100) {
					Create (Random.Range (7, 10), y);
					Create (Random.Range (0, 3), y - 0.4f);
				}
				if(gemChance <= 30){
					CreateUnit (gem,y);
				}
				if(enemyChance <= 5){
					CreateUnit (enemy,y);
				}

				y += Random.Range (minY+0.4f, maxY+0.4f); //Frequency of platforms

			} else {
				if (chance <= 50) {
					Create (Random.Range (0, 2), y);
				} else if (chance <= 70) {
					Create (3, y);
				} else if (chance <= 80) {	
					Create (Random.Range (4, 7), y);
				} else if (chance <= 100) {
					Create (Random.Range (7, 10), y);
					Create (Random.Range (0, 3), y - 0.4f);
				}
				if(gemChance <= 25){
					CreateUnit (gem,y);
				}
				if(enemyChance <= 8){
					CreateUnit (enemy,y);
				}

				y += Random.Range (minY+1f, maxY+1f); //Frequency of platforms
			}
		}

		spawnPlatforms = maxHeight;
	}
	void Create(int index, float y){
		Instantiate (platforms [index], new Vector3 
			(Random.Range (-widthX, widthX), y), transform.rotation);
	}

	void CreateUnit(GameObject unit, float y){
		Instantiate (unit, new Vector3 
			(Random.Range (-widthX+0.3f, widthX-0.3f), y), transform.rotation);
	}
	IEnumerator Reset(){
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene("Main");
	}
}
