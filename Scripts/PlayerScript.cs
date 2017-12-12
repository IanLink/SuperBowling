using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameControllerScript gcs;
	public float speedX,speedZ;
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
		r.velocity = new Vector3 (Input.GetAxis ("Horizontal") * speedX, r.velocity.y, speedZ);
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
		r.velocity = Vector3.forward * speedZ;
		hit = false;
		cms.ResetCamera ();
	}

}
