using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private AudioSource audiosource;
	public GameObject shotEnemy;
	public Transform shotSpawn;
	public float delay;
	public float fireRate;
	void Start(){
		audiosource = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, fireRate);
	}
	void Fire(){
		Instantiate (shotEnemy, shotSpawn.position, shotSpawn.rotation);
		audiosource.Play ();
	}
}
