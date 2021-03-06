using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerScript : MonoBehaviour {

	public Camera[] cameras;
	public AudioListener[] al;
	private int activeCamera;

	void Start(){
		activeCamera = 0;
	}

	public void ChangeCamera(int i){
		//Debug.Log ("Change Camera");
		cameras [activeCamera].enabled = false;
		al [activeCamera].enabled = false;
		activeCamera = i;
		cameras [activeCamera].enabled = true;
		al [activeCamera].enabled = true;
	}

	public void SwitchCamera(){
		ChangeCamera (Mathf.Abs (activeCamera - 1));
	}

	public void ResetCamera(){
		ChangeCamera (0);
	}

}
