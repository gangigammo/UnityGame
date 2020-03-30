using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public const int SHAPE_CIRCLE = 1;
	public const int SHAPE_TRIANGLE = 2;
	public const int SHAPE_SQUARE = 3;

	public const int COLOR_YELLOW = 1;
	public const int COLOR_RED = 2;
	public const int COLOR_BLUE = 3;

	public const int YELLOW_CIRCLE = 0;
	public const int YELLOW_TRIANGLE = 1;
	public const int YELLOW_SQUARE = 2;
	public const int RED_CIRCLE = 3;
	public const int RED_TRIANGLE = 4;
	public const int RED_SQUARE = 5;
	public const int BLUE_CIRCLE = 6;
	public const int BLUE_TRIANGLE = 7;
	public const int BLUE_SQUARE = 8;

	public int score = 0;

	public GameObject[] buttonShape = new GameObject[3];

	public GameObject ImageTarget;

	public Sprite[] Obje = new Sprite[9];

	private int[] buttonselect = new int[3];

	private int target;

	public GameObject[] ImageShape = new GameObject[3];

	public GameObject TextPoint;

	public GameObject TextGameOver;

	public GameObject[] ImageMove = new GameObject[3];

	// Use this for initialization
	void Start () {
		buttonselect [0] = YELLOW_CIRCLE;
		buttonselect [1] = RED_CIRCLE;
		buttonselect [2] = BLUE_CIRCLE;
		target = YELLOW_TRIANGLE;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PushButonLeft(){
		ChangeTarget (0);
	}
	public void PushButonCenter(){
		ChangeTarget (1);
	}
	public void PushButonRight(){
		ChangeTarget (2);
	}

	void ChangeTarget(int buttonNo){
		target = buttonselect [buttonNo];
		buttonselect [buttonNo] = UnityEngine.Random.Range(0, 9);
		//ImageTarget.GetComponent<Image> ().sprite = Obje [target];
		ImageMove[buttonNo].GetComponent<Image> ().sprite = Obje [target];//

		buttonShape [buttonNo].GetComponent<Image> ().sprite = Obje [buttonselect [buttonNo]];
		ImageShape [buttonNo].GetComponent<Image> ().sprite = Obje [buttonselect [buttonNo]];
		for (int i = 0; i < 3; i++) {
			if ((buttonselect [i] / 3 != target / 3) && (buttonselect [i] % 3 != target % 3)) {
				buttonShape [i].SetActive (false);
				ImageShape [i].SetActive (true);
			} else {
				buttonShape [i].SetActive (true);
				ImageShape [i].SetActive (false);
			}
		}
		for (int i = 0; i < 3; i++) {//
			if (i == buttonNo) {
				ImageMove [i].SetActive (false);
				ImageMove [i].SetActive (true);
			} else {
				ImageMove [i].SetActive (false);
			}
		}
		switch (target) {
		case 0:
			score++;
			break;
		case 1:
			score += 2;
			break;
		case 2:
			score += 3;
			break;
		case 3:
			score += 2;
			break;
		case 4:
			score += 4;
			break;
		case 5:
			score += 6;
			break;
		case 6:
			score += 3;
			break;
		case 7:
			score += 6;
			break;
		case 8:
			score += 9;
			break;
		}

		StartCoroutine ("TargetVanish");

		//ImageTarget.GetComponent<Image> ().sprite = Obje [target];

		DisplayScore (score);
		if ((buttonShape [0].activeSelf == false) && (buttonShape [1].activeSelf == false) && (buttonShape [2].activeSelf == false)) {
			TextGameOver.GetComponent<Text> ().text = "得点 : " + score.ToString() ;
			if (score < 30) {
				TextGameOver.GetComponent<Text> ().text += "\n低すぎて草\nいとわろし";
			} else if (30 < score && score < 70) {
				TextGameOver.GetComponent<Text> ().text += "\nこれが・・・\nあなたの・・・\n実力・・・!";
			} else if (70 < score && score < 100) {
				TextGameOver.GetComponent<Text> ().text += "\n神社に来たのに５円玉がない\nそんな気分";
			} else if (100 < score && score < 200) {
				TextGameOver.GetComponent<Text> ().text += "\nおめでとう!\n今日は焼肉だ!";
			} else if (200 < score) {
				TextGameOver.GetComponent<Text> ().text　 += "\nここが最先端だ";
			}
			StartCoroutine ("Ending");
			//TextGameOver.SetActive (true);
			//yield return new WaitForSeconds(2);
			//TextGameOver.SetActive (false);
		}
	}

	IEnumerator TargetVanish(){
		ImageTarget.SetActive (true);
		yield return new WaitForSeconds(0.4f);
		ImageTarget.SetActive (false);
		ImageTarget.GetComponent<Image> ().sprite = Obje [target];
	}

	IEnumerator Ending (){
		TextGameOver.SetActive (true);
		yield return new WaitForSeconds(8);
		TextGameOver.SetActive (false);
	}


	void DisplayScore(int score){
		TextPoint.GetComponent<Text> ().text = score.ToString();
	}
}
