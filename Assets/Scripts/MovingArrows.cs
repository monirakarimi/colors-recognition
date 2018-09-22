using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// change the state of arrows
/// </summary>
public class MovingArrows : MonoBehaviour {
	public string currentState;
	public static bool ispause;
	void Start () {
		
	}
	void changeState(){
		if (currentState == "top") {
			currentState = "left";

		} else if (currentState == "left") {
			currentState = "buttom";

		}
		else if (currentState == "buttom") {
			currentState = "right";
		
		}
		else if (currentState == "right") {
			currentState = "top";

		}
	}
	
	void OnMouseDown(){
		if (ispause==false) {
			gameObject.transform.Rotate (new Vector3 (gameObject.transform.rotation.x, gameObject.transform.rotation.y, 90f));
			SFXCtrl.instance.ClickingSFX (transform.position);
			changeState ();
			AudioCtrl.instance.clicking (transform.position);
		}

	
	}

}
