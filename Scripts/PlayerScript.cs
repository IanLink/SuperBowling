using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public SoundManagerScript sms;
	public GameControllerScript gcs;
	public float speedX,speedZ;
	private Rigidbody r;
	private Animator a;
	private CameraManagerScript cms;
	private bool hit = false;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
		a = GetComponent<Animator> ();
		a.enabled = false;
		cms = Camera.main.transform.parent.GetComponent<CameraManagerScript> ();

	}

	void OnEnable(){
		if (a != null)
			a.enabled = false;
	}

	void OnCollisionEnter(Collision c){
		if (c.collider.tag == "Pin")
			sms.PlayAudio (2);
	}

	void OnCollisionStay(Collision c){
		if (c.collider.tag == "Floor")
			sms.PlayAudio (1);
	}

	void OnCollisionExit(Collision c){
		if (c.collider.tag == "Floor")
			sms.StopAudio (1);
	}
	
	// Update is called once per frame
	void Update () {
		r.velocity = new Vector3 (Input.GetAxis ("Horizontal") * speedX, r.velocity.y, speedZ);
		//Debug.Log (r.velocity);
	}

	void OnTriggerEnter (Collider other){
		if (!hit) {
			if (other.tag == "CameraZone") {
				cms.SwitchCamera ();
				gcs.CheckPins (4f);
				hit = true;
			} else if (other.tag == "Boundary") {
				gcs.CheckPins (1f);
				hit = true;
			}
		}
	}

	public void ResetBall(){
		transform.position = Vector3.down * 1.5f;
		r.velocity = Vector3.forward * speedZ;
		hit = false;
		a.enabled = true;
		a.Rebind ();
		cms.ResetCamera ();
	}

}
