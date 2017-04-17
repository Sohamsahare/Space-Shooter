using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
	public GameObject explosions;
	public GameObject explosionPlayer;
	private GameObject gameControllerObject;
	private GameController gameController;
	public int scoreValue;
	void Start(){
		gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject == null) {
			Debug.LogError ("No Game Controller assigned!!");
		} else {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Boundary") || other.CompareTag("Enemy"))
			return;
		Destroy (other.gameObject);
		Destroy (gameObject);
		if(explosions != null)
			Instantiate (explosions, transform.position, transform.rotation);
		gameController.AddScore (scoreValue);
		if (other.CompareTag ("Player")) {
			Instantiate (explosionPlayer, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
	}
}
