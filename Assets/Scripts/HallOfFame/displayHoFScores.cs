using UnityEngine;
using System.Collections;

public class displayHoFScores : MonoBehaviour {

	public bool newHighscore;
	public bool decrease;
	public float speed;


	// Use this for initialization
	void Start () {
		// stop the music
//		SoundState.Instance.stopSound();
		// make an explosion sound
		SoundState.Instance.playShipExplosionSound();
		// gamover music
		SoundState.Instance.playGameOverSound();
		
		// if highscore is reached, update it
		if(GameState.Instance.scorePlayer > GameState.Instance.highscore) {
			newHighscore = true;
			GameState.Instance.highscore = GameState.Instance.scorePlayer;
		}
		else {
			newHighscore = false;
		}

		// display the scores
		GameObject.FindWithTag("scoreText").GetComponent<GUIText>().text = "" + GameState.Instance.scorePlayer;
		GameObject.FindWithTag("highscoreText").GetComponent<GUIText>().text = "" + GameState.Instance.highscore;

		// if no new highscore, hide message
		if(!newHighscore) {
			Color cl = GameObject.FindWithTag("congratText").GetComponent<GUIText>().color;
			cl.a = 0;
			GameObject.FindWithTag("congratText").GetComponent<GUIText>().color = cl;
		}
		else {
			decrease = true;
			speed = 0.05f;
		}
	}


	// Update is called once per frame
	void Update () {
		// if new highscore, get fun with the message
		if(newHighscore) {
			Color cl = GameObject.FindWithTag("congratText").GetComponent<GUIText>().color;

			if(cl.a >= 1) {
				decrease = true;
			}
			else if(cl.a <= 0) {
				decrease = false;
			}
			
			if(decrease) {
				cl.a -= speed;
			}
			else {
				cl.a += speed;
			}

			GameObject.FindWithTag("congratText").GetComponent<GUIText>().color = cl;
		}
	}

}
