using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// control changing of the scene
/// </summary>
public class SceneChanger : MonoBehaviour {
	public UI ui;
	public void ChangeScene(string scene_number){
		SceneManager.LoadScene (scene_number);
		Time.timeScale = 1;

	}
}
