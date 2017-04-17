using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}
	void Start(){
		rb.velocity = transform.forward * speed;
	}

}
