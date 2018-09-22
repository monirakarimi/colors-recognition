using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// control the movement of player
/// </summary>
public class playercontroller : MonoBehaviour {
	Rigidbody2D rb;
	public Vector2 speed;
	public static playercontroller instance;

	void Awake(){
		if (instance == null)
			instance = this;
	}
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = speed;


	}

	IEnumerator x(Collider2D other){
		yield return new WaitForSeconds (0.2f);
		if (other.gameObject.GetComponent<MovingArrows> ().currentState == "right") {
			rb.velocity = new Vector2 (1.5f, 0);
		} else if (other.gameObject.GetComponent<MovingArrows> ().currentState == "left") {
			rb.velocity = new Vector2 (-1.5f, 0);
		} else if (other.gameObject.GetComponent<MovingArrows> ().currentState == "top") {
			rb.velocity = new Vector2 (0, 1.5f);
		} else if (other.gameObject.GetComponent<MovingArrows> ().currentState == "buttom") {
			rb.velocity = new Vector2 (0, -1.5f);
		}

	}

	void OnTriggerEnter2D (Collider2D col) {
		if(gameObject!=null)
		StartCoroutine ("x",col);

	
	}
}
