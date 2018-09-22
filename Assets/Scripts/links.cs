using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// controling the link of our social medias/// </summary>
public class links : MonoBehaviour {

	public void twiter(){
		Application.OpenURL ("https://twitter.com/monira_karimi");
	}
	public void LinkIn(){
		Application.OpenURL ("https://www.linkedin.com/in/monira-karimi-5b0a4b156/");
	}
	public void Github(){
		Application.OpenURL ("https://github.com/Monira2");
	}
}
