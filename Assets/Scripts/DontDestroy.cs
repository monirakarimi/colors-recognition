using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// control that the audios do not destroy
/// </summary>
public class DontDestroy : MonoBehaviour {

	
void Awake(){
		GameObject[] objs=GameObject.FindGameObjectsWithTag("BGAudio");
		
		if (objs.Length > 1) {
			
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	
}
	void Update () {
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 1 || UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 4) {
			gameObject.GetComponent<AudioSource> ().mute = true;
		} else {
			gameObject.GetComponent<AudioSource> ().mute = false;
		}
	}
}
