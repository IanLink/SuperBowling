using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	private bool follow;

	void Start(){
		follow = true;
	}

	// Update is called once per frame
	void Update () {
		if (target != null && follow)
			transform.position = target.position + offset;
	}
}
