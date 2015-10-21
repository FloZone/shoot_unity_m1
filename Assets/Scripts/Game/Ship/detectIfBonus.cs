using UnityEngine;
using System.Collections;

public class detectIfBonus : MonoBehaviour {

	public int previous;
	public int threshold;


	// Use this for initialization
	void Start () {
		previous = 0;
		threshold = 15;
	}

	// Update is called once per frame
	void Update () {
		// each time the score pass the threshold (and if there is no bonus on the screen)
		if( (previous > GameState.Instance.scorePlayer % threshold) && (GameObject.FindGameObjectsWithTag("bonus").Length == 0) ) {
			// spawn a bonus
			Instantiate(Resources.Load("bonus"));
		}
		// remember previous score
		previous = GameState.Instance.scorePlayer % threshold;
	}
}
