using UnityEngine;
using System.Collections;

public class detectIfStar : MonoBehaviour {

	// Stars array
	public GameObject[] stars;
	
	
	// Update is called once per frame
	void Update () {
		// get all stars
		stars = GameObject.FindGameObjectsWithTag("star");
		
		// if there are less than 10 stars or random chance, instantiate a new one
		if(stars.Length < 10 || Random.Range(1,3) == 1) {
			Instantiate(Resources.Load("star"));
		}
	}
}
