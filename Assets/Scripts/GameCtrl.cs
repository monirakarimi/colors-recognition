using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;//RSFB
using System.IO;
using UnityEngine.SceneManagement;
/// <summary>
/// Managing the important Gameplay features like keeping the score , 
/// Restarting levels ,saving loading data ,Updating the HUD etc ...
/// </summary>
public class GameCtrl : MonoBehaviour
{
	string dataFilePath;
	BinaryFormatter bf;
	public UI ui;
	public float restartDelay;
	public static GameCtrl instance;
	public GameData data;
	public GameObject player;
	public bool soundOn;

	void Awake(){
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		if (instance == null)
			instance = this;
		bf = new BinaryFormatter ();
		dataFilePath = Application.persistentDataPath + "/game.bat";
	}


	// Use this for initialization
	void Start (){
		
		soundOn = true;
	}
	
	// Update is called once per frame
	void Update ()

	{
		UpdateHeart ();
		if(Input.GetKeyDown(KeyCode.Escape)){
			ResetData ();
		}
	}
	public void UpdateScore(){
		data.score+=5;
		ui.TextScore.text = "Score :" + data.score;
	}	
	public int getScore(){
		return data.score;
	}
	public void UpdateHeart(){
		if (data.lives == 4) {
			ui.Circle1.sprite = ui.fullCircle;
			ui.Circle2.sprite = ui.fullCircle;
			ui.Circle3.sprite = ui.fullCircle;
			ui.Circle4.sprite = ui.fullCircle;
		}
		if (data.lives == 3) {
			ui.Circle1.sprite = ui.emptyCircle;
		}
		if (data.lives == 2) {
			ui.Circle1.sprite = ui.emptyCircle;
			ui.Circle2.sprite = ui.emptyCircle;
		}
		if(data.lives==1){
			ui.Circle1.sprite = ui.emptyCircle;
			ui.Circle2.sprite = ui.emptyCircle;
			ui.Circle3.sprite = ui.emptyCircle;

		}
		if(data.lives==0){
			ui.Circle1.sprite = ui.emptyCircle;
			ui.Circle2.sprite = ui.emptyCircle;
			ui.Circle3.sprite = ui.emptyCircle;
			ui.Circle4.sprite = ui.emptyCircle;

		}
	}
	void checkLive(){
		int updateLive = data.lives;
		if (updateLive > 0) {
			updateLive -= 1;
			data.lives = updateLive;
		}

		if (data.lives == 0) {
			
			if(gameObject!=null)
			AudioCtrl.instance.GamOverSound (transform.position);
			SaveData ();
			Invoke ("GameOver",0.5f);

	} 

	}
	void GameOver(){
		
		if (data.score > PlayerPrefs.GetInt ("highScore", 0)) {
			PlayerPrefs.SetInt ("highScore", data.score);
			print (PlayerPrefs.GetInt ("highScore"));

		}
		SceneManager.LoadScene ("GameOver");
	}
	void SaveData(){
		FileStream fs = new FileStream (dataFilePath , FileMode.Create);
		bf.Serialize (fs,data);
		fs.Close ();
	}
	public void EndGame(){
		checkLive ();
	}
		
	void ResetData(){
		FileStream fs = new FileStream (dataFilePath, FileMode.Create);
		data.score = 0;
		ui.TextScore.text = " Score: " + data.score;
		data.lives = 3;
		UpdateHeart ();
		bf.Serialize (fs,data);
		fs.Close ();
	}


	public void RestartLevel(){

		SceneManager.LoadScene (1);

	}

	public void PauseButton(){
		MovingArrows.ispause = true;
		Time.timeScale = 0f;
		ui.pausePanel.SetActive (true);

	}
	public void ResumeButton(){
		MovingArrows.ispause = false;
		Time.timeScale = 1f;
		ui.pausePanel.SetActive (false);

	}
	public void SoundOff(){
		if (soundOn) {
			AudioListener.pause = true;

			ui.SoundOff.image.sprite = ui.img_SoundOff;
			soundOn = false;
		} else {
			AudioListener.pause = !AudioListener.pause;

			ui.SoundOff.image.sprite = ui.img_SoundOn;
			soundOn = true;
		}

	}

}

