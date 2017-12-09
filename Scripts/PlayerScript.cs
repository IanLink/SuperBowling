using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameControllerScript gcs;
	public float speed;
	private Rigidbody r;
	private CameraManagerScript cms;
	private bool hit = false;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
		cms = Camera.main.transform.parent.GetComponent<CameraManagerScript> ();
		ResetBall ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (r.velocity);
		if (r.velocity.z <= speed)
			r.velocity = new Vector3 (r.velocity.x, r.velocity.y, speed);
		//if (!hit)
		r.AddForce (Vector3.right * Input.GetAxis ("Horizontal"));
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "CameraZone" && !hit) {
			cms.SwitchCamera ();
			gcs.CheckPins ();
			hit = true;
		}
	}

	public void ResetBall(){
		transform.position = Vector3.down * 1.5f;
		r.velocity = Vector3.forward * speed;
		hit = false;
		cms.ResetCamera ();
	}

}
