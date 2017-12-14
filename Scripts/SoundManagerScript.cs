using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	public AudioSource[] aS;


	public void PlayAudio(int i){
		if (!aS[i].isPlaying)
			aS [i].Play ();
	}

	public void StopAudio(int i){
		aS [i].Stop ();
	}

}
