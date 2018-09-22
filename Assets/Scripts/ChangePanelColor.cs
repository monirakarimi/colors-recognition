using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangePanelColor : MonoBehaviour {
	public GameObject player;
	public Color yellow;
	public Color red;
	public Color blue;
	public Color lightblue;
	public Color pink;
	public Color green;
	public GameObject panel;
	static bool isChange;
	public string currentcolor;
	public UI ui;
	public float maxTime;
	float timeLeft;
	bool TimerOn;
	bool isPanelOn;
	public  GameObject[] plGameObjects;

	// Use this for initialization
	void Start () {
		timeLeft = maxTime;
		TimerOn = true;
		isPanelOn = false;
		plGameObjects = new GameObject[3];
		plGameObjects [0] = GameObject.Find ("P10 (3)") as GameObject;
		plGameObjects [1] = GameObject.Find ("P10 (4)") as GameObject;
		plGameObjects [2] = GameObject.Find ("P10 (5)") as GameObject;
		print ("Pl is : "+plGameObjects.Length);

		isChange = false;

	}
	void CheackChange(){
		int time = (int)(Time.time);
		print (time);
		switch (time) {
		case 40:
			isChange = true;

			break;
		case 50:

			isChange = false;
			isPanelOn = true;
			break;
		case 60:

			isChange = true;
			break;
		case 70:

			isChange = false;
			isPanelOn = true;
			break;
		case 80:

			isChange = true;
			break;
		case 90:

			isChange = false;
			isPanelOn = true;
			break;
		}

	}
	// Update is called once per frame
	void Update () {
		if (timeLeft > 0 && TimerOn) {
		
			UpdateTimer ();
		}
		CheackChange ();

		if (isChange) {
			StartCoroutine ("changeColor", panel);

		} else {
			StopCoroutine ("changeColor");
		}
	}

	void OnMouseDown(){
		if (isPanelOn) {
			for (int i = 0; i < plGameObjects.Length; i++) {
				if (panel.gameObject.GetComponent<Image> ().color == plGameObjects [i].gameObject.GetComponent<SpriteRenderer> ().color) {
					print ("mm");
					GameCtrl.instance.UpdateScore ();
					SFXCtrl.instance.CorrectColorSFX (gameObject.transform.position);
					Destroy (plGameObjects [i].gameObject);
					player = CheakColor.instance.getGameobject ();
					plGameObjects [i] = null;
					AudioCtrl.instance.correctSound (transform.position);
					return;
				}

			}
			
			GameCtrl.instance.EndGame ();
			print ("xx");
			SFXCtrl.instance.WrongColorSFX (gameObject.transform.position);
			player = CheakColor.instance.getGameobject ();
			AudioCtrl.instance.wrongSound (transform.position);


		}
	}
		
	void UpdateTimer(){
		timeLeft -= Time.deltaTime;
		ui.textTimer.text = " " + (int)timeLeft;
		if (timeLeft <= 0) {
			ui.textTimer.text= " ";
		}
	}


	IEnumerator changeColor(GameObject panel){


		int index = Random.Range (0,6);
		switch (index) {
		case 0:

			panel.gameObject.GetComponent<Image> ().color = Color.green;

			break;
		case 1:

			panel.gameObject.GetComponent<Image> ().color = Color.blue;

			break;
		case 2:

			panel.gameObject.GetComponent<Image> ().color = new Color (0f, 255f, 237f);

			break;
		case 3:

			panel.gameObject.GetComponent<Image> ().color = Color.red;

			break;
		case 4:

			panel.gameObject.GetComponent<Image> ().color = Color.yellow;


			break;
		case 5:

			panel.gameObject.GetComponent<Image> ().color = new Color(255f,0f,240f);

			break;
			yield return new WaitForSeconds (0.1f);
	}
	}
}
