using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;

	public float startWait;
	public float spawnWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gamOverText;

	bool restart;
	bool gameover;

	private int score;

	void Start(){
		score = 0;
		restart = false;
		gameover = false;
		restartText.text = "";
		gamOverText.text = "";
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	void Update(){
		if (restart) {
			if (Input.GetKey (KeyCode.R)) {
				SceneManager.LoadScene (0);
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length - 1)];
				Vector3 spawnPos = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion	spawnRot = Quaternion.identity;
				Instantiate (hazard, spawnPos, spawnRot);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameover) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}

	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void AddScore(int newScore){
		score += newScore;
		UpdateScore ();
	}

	public void GameOver(){
		gamOverText.text = "GAME OVER BUDDY!";
		gameover = true;
	}
}
