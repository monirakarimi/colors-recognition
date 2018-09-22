using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Control the audio of the game
/// </summary>
public class AudioCtrl : MonoBehaviour {
	public static AudioCtrl instance;
	public GameSound gamesound;

	[Tooltip("Use to on/off the audio of game from inspector")]

	public bool soundOn;


	public GameObject bgMusic;

	public bool bgMusicOn;

	void Awake(){
		if (instance == null)
			instance = this;
	}

	// Use this for initialization
	void Start () {
		
		if(bgMusicOn){
			bgMusic.gameObject.SetActive (true);

		}


	}

	public void clicking(Vector3 pos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (gamesound.clickSound, pos);
		}
	}
	public void correctSound(Vector3 pos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (gamesound.correctSound,pos);
		}
	}
	public void wrongSound(Vector3 pos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (gamesound.wrongSound, pos);
		}
	}
	public void GamOverSound(Vector3 pos){
		if (soundOn) {
			AudioSource.PlayClipAtPoint (gamesound.GameOver, pos);
		}
	}
	void Update () {
		
	}
}
