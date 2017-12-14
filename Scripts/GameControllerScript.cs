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
	private float[] initPinY = new float[10];
	private int score;
	private int round;
	private bool end;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < pins.Length; i++){
			initPinY [i] = pins [i].position.y;
			//Debug.Log (initPinY [i]);
		}
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

	public void CheckPins(float f){
		StartCoroutine (Check (f));
	}

	private IEnumerator Check(float k){
		yield return new WaitForSeconds (k);
		for (int i = 0; i < pins.Length; i++) {
			//Debug.Log (t.gameObject + "Before " + score);
			if (pins[i] != null) {
				if (Mathf.Abs (pins[i].rotation.eulerAngles.x) > 10f || Mathf.Abs (pins[i].rotation.eulerAngles.z) > 10f || pins[i].position.y > initPinY[i] + 1f || pins[i].position.y < initPinY[i] - 1f) {
					score++;
					//Debug.Log ("After" + score);
					Destroy (pins[i].gameObject);
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
