using UnityEngine;
using System.Collections;

public class displayMenuScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// display the highscore
		GameObject.FindWithTag("highscoreText").GetComponent<GUIText>().text =  "" + GameState.Instance.highscore;
	}

}
