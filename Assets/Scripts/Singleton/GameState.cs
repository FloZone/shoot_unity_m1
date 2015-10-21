using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public int highscore = 0;
	public int scorePlayer;


	// Singleton
	public static GameState Instance;
	
	// Use this for initialization
	void Start () {
		// Singleton
		if(Instance == null) {
			Instance = this;
			DontDestroyOnLoad(Instance.gameObject);
		}
		else if(this != Instance) {
			Destroy(this.gameObject);
		}
	}

	// increase the player score
 	public void addScorePlayer(int toAdd) {
		scorePlayer += toAdd;
	}

	// get the player score
	public int getScorePlayer() {
		return scorePlayer;
	}

}
