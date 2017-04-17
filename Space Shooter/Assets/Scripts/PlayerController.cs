using System.Collections;
using UnityEngine;

[System.Serializable]
public class Boundary {
	 public float xMin,xMax,zMin,zMax;
}
public class PlayerController : MonoBehaviour {
	[SerializeField]
	private GameObject bolt;
	[SerializeField]
	private Transform muzzle;
	[SerializeField]
	private float speed;
	private Rigidbody rb;
	[SerializeField]
	private float tilt;
	public Boundary boundary;
	private float nextFire = 0.0f;
	public float fireRate = 0.25f;
	void Awake(){
		rb = GetComponent<Rigidbody> ();

	}
	void Update(){
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Shoot ();
		}
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;
		rb.position = new Vector3(Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),0.0f,Mathf.Clamp(rb.position.z,boundary.zMin,boundary.zMax));
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, tilt * -rb.velocity.x); 
	}
	void Shoot(){
		Instantiate (bolt, muzzle.transform.position,muzzle.transform.rotation);
		GetComponent<AudioSource> ().Play ();
	}
}
