using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerController : MonoBehaviour {

	[Range (1f, 20f)]
	public float speed = 1f;
	[Range (1f, 20f)]
	public float rotateSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate() {
		float vertSpeed = Input.GetAxis ("Vertical");
		float horiSpeed = Input.GetAxis ("Horizontal");

		transform.Translate (Vector3.forward * vertSpeed * speed * Time.deltaTime);
		transform.Rotate (0f, horiSpeed * rotateSpeed * Time.deltaTime, 0f);
	}

	public void OnHitObject () {
		GetComponent<Rigidbody> ().AddForce (Vector3.up * 10f, ForceMode.Impulse);
	}

	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos() {
		Debug.DrawRay (transform.position, transform.forward, Color.blue);
		Debug.DrawRay (transform.position, transform.right, Color.red);
		Debug.DrawRay (transform.position, transform.up, Color.green);
	}
}
