using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Collect the Garbage things in the game /// </summary>
public class GarbageCollector : MonoBehaviour {
	 GameObject player;
	 
	void OnTriggerEnter2D(Collider2D other){
		GameCtrl.instance.EndGame();

		SFXCtrl.instance.WrongColorSFX(other.gameObject.transform.position);
		Destroy(other.gameObject);
		player=CheakColor.instance.getGameobject();
		player.tag = CheakColor.plaTag;
		AudioCtrl.instance.wrongSound(transform.position);
		
	}
}
