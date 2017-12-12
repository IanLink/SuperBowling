using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

	public PlayerScript ps;
	public Transform[] pins;
	public Text scoreTxt;
	public Text roundTxt;
	public Text endText;
	public Text instructionsText;
	private int score;
	private int round;
	private bool end;

	// Use this for initialization
	void Start () {
		score = 0;
		round = 1;
		end = false;
	}

	void Update(){
		if (end) {
			if (Input.GetKey ("return"))
				SceneManager.LoadScene (0);
			else if (Input.GetKey ("r"))
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	public void CheckPins(){
		StartCoroutine (Check ());
	}

	private IEnumerator Check(){
		yield return new WaitForSeconds (4f);
		foreach (Transform t in pins) {
			//Debug.Log (t.gameObject + "Before " + score);
			if (t != null) {
				if (Mathf.Abs (t.rotation.eulerAngles.x) > 10f || Mathf.Abs (t.rotation.eulerAngles.z) > 10f) {
					score++;
					//Debug.Log ("After" + score);
					Destroy (t.gameObject);
				}
			}
		}
		scoreTxt.text = "Score: " + score;
		if (score < 10) {
			if (round < 2)
				NextRound ();
			else {
				MatchEnd ();
				End ();
			}
		} else {
			if (round < 2)
				Strike ();
			else
				Spare ();
			End ();
		}
			
	}

	private void End(){
		endText.enabled = true;
		instructionsText.enabled = true;
		end = true;
		Destroy(ps.gameObject);
		if (PlayerPrefs.GetInt ("Level" + SceneManager.GetActiveScene().buildIndex, 0) < score)
			PlayerPrefs.SetInt ("Level" + SceneManager.GetActiveScene().buildIndex, score);
	}

	private void NextRound (){
		round++;
		ps.ResetBall ();
	}

	private void MatchEnd(){
		endText.text = "End";
	}

	private void Strike(){
		endText.text = "Strike!";
		PlayerPrefs.SetInt ("Level" + SceneManager.GetActiveScene().buildIndex + "Star", 1);
	}

	private void Spare(){
		endText.text = "Spare";
	}

}
