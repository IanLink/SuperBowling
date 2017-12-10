using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public Text[] scores;

	void Start(){
		for (int i = 0; i < scores.Length; i++) {
			scores[i].text = PlayerPrefs.GetInt ("Level" + (i + 1), 0) + "/10";
			Debug.Log ("Level" + (i + 1));
			//Debug.Log (PlayerPrefs.GetInt ("Level" + i + 1, 0));
		}
	}

	public void LoadLevel(int i){
		SceneManager.LoadScene (i);
	}

	public void Exit(){
		Application.Quit ();
	}

}
