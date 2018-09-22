using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// cheack the colors
/// </summary>
public class CheakColor : MonoBehaviour {
	public GameObject player;
	public Transform[] positions;
	public static CheakColor instance;
 GameObject playerSpawn;
	public Color yellow;
	public Color red;
	public Color blue;
	public Color green;
	public GameObject ColorPanel;
	public static string plaTag;
	// Use this for initialization
	void Start () {
		if (instance == null) {
		
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject.tag == tag) {
			
			GameCtrl.instance.UpdateScore ();

			SFXCtrl.instance.CorrectColorSFX(gameObject.transform.position);
			Destroy(col.gameObject);
			playerSpawn = getGameobject();
			playerSpawn.tag = plaTag;

			AudioCtrl.instance.correctSound(transform.position);

		}
		if(col.gameObject.tag!=tag){
			GameCtrl.instance.EndGame();

			SFXCtrl.instance.WrongColorSFX(gameObject.transform.position);
			Destroy(col.gameObject);
			playerSpawn=getGameobject();
			playerSpawn.tag= plaTag;
			AudioCtrl.instance.wrongSound(transform.position);
		}

	}

	public GameObject getGameobject(){
		int index = Random.Range(0,positions.Length);

		playerSpawn=Instantiate(player,positions[index].position,Quaternion.identity);
		SetRandomColor(playerSpawn);
		return playerSpawn;
	}

	void SetRandomColor(GameObject pla){
		int index = Random.Range (0,6);
		switch (index) {
		case 0:
			pla.gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
			plaTag= "green";
			break;
		case 1:
			
			pla.gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
			plaTag = "darkblue";
			break;
		case 2:
			
			pla.gameObject.GetComponent<SpriteRenderer> ().color = new Color(0f,255f,237f);
			plaTag= "lightblue";
			break;
		case 3:
			
			pla.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			plaTag= "red";
			break;
		case 4:
			
			pla.gameObject.GetComponent<SpriteRenderer> ().color = Color.yellow;
			plaTag= "yellow";
			break;
		case 5:
			
			pla.gameObject.GetComponent<SpriteRenderer> ().color = new Color(255f,0f,240f);

			plaTag= "pink";
			break;
		}
	}
}
