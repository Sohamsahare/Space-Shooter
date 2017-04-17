using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {
	public Vector2 startwait;
	public Vector2 maneuvertime;
	public Vector2 maneuverwait;

	public float tilt;
	public float dodge;
	public float smoothing;

	private float currentSpeed;
	private float targetManeuver;

	private Rigidbody rb;

	public Boundary boundary;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		currentSpeed = rb.velocity.z;
		StartCoroutine (Evade ());
	}

	IEnumerator Evade(){
		yield return new WaitForSeconds(Random.Range(startwait.x,startwait.y));
		while (true) {
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds(Random.Range(maneuvertime.x,maneuvertime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds(Random.Range(maneuverwait.x,maneuverwait.y));
		}
	}

	void FixedUpdate () {
		float newManeuver = Mathf.MoveTowards (rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)			
		);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
