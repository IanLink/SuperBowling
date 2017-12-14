using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

	private bool right;

	// Use this for initialization
	void Start () {
		if (Random.value > 0.5f)
			right = true;
		else
			right = false;
		StartCoroutine (Oscilate ());
	}
	
	// Update is called once per frame
	void Update () {
		if (right) {
			if (transform.position.x < 4f)
				transform.Translate (Vector3.right * 0.07f);
			else
				right = false;
		} else {
			if (transform.position.x > -4f)
				transform.Translate (Vector3.right * -0.07f);
			else
				right = true;
		}
	}

	IEnumerator Oscilate(){
		while (true) {
			yield return new WaitForSeconds (Random.Range (0.8f, 1.3f));
			right = !right;
		}
	}

}
