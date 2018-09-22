using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// control the effect of the game
/// </summary>
public class SFXCtrl : MonoBehaviour {
	public SFX sfx;
	public static SFXCtrl instance;
	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}
	public void ClickingSFX(Vector3 pos){
		Instantiate (sfx.clickingArrows, pos, Quaternion.identity);
	}
	public void WrongColorSFX(Vector3 pos){
		Instantiate (sfx.wrongColor, pos, Quaternion.identity);
	}
	public void CorrectColorSFX(Vector3 pos){
		Instantiate (sfx.correctColor, pos, Quaternion.identity);
	}
}
 