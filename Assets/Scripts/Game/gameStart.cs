using UnityEngine;
using System.Collections;

public class gameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// reset the current score
		GameState.Instance.scorePlayer = 0;

		// start the game music
		SoundState.Instance.playGameMusic();
	}
	
	// Update is called once per frame
	void Update () {
		// display the score
		GameObject.FindWithTag("scoreText").GetComponent<GUIText>().text = "" + GameState.Instance.scorePlayer;
	}
	
}
