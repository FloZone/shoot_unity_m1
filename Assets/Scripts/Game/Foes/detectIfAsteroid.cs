using UnityEngine;
using System.Collections;

public class detectIfAsteroid : MonoBehaviour {

	// Foes array
	public GameObject[] asteroids;


	// Update is called once per frame
	void Update () {
		// get all asteroids
		asteroids = GameObject.FindGameObjectsWithTag("asteroid");

		// if there are less than 10 asteroids
		if(asteroids.Length < 5) {
			// if less than 4 asteroids or a random chance
			if(asteroids.Length < 3 || Random.Range(1,3) == 1) {
				// instantiate a new one
				Instantiate(Resources.Load("asteroidSP"));
			}
		}
	}
}
