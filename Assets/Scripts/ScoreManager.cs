using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// manage score and high score of the game/// </summary>
public class ScoreManager : MonoBehaviour {
	public Text text;
	public Text highscoretext;
	// Use this for initialization
	void Start () {
		text.text =" Score : "+ GameCtrl.instance.getScore ().ToString();
		highscoretext.text =" High Score : "+ PlayerPrefs.GetInt ("highScore").ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
