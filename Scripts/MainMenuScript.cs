using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public GameObject secret;
	public Text[] scores;
	public Image[] stars;

	void Start(){
		//PlayerPrefs.DeleteAll();
		if (PlayerPrefs.GetInt ("Level1Star", 0) == 1 && PlayerPrefs.GetInt ("Level2Star", 0) == 1 && PlayerPrefs.GetInt ("Level3Star", 0) == 1)
			secret.SetActive (true);
		for (int i = 0; i < scores.Length; i++) {
			int j = PlayerPrefs.GetInt ("Level" + (i + 1), 0);
			scores[i].text = j + "/10";
			if (j == 10 && PlayerPrefs.GetInt ("Level" + (i + 1) + "Star", 0) == 1)
				stars [i].enabled = true;
			//Debug.Log ("Level" + i + "Star");
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
