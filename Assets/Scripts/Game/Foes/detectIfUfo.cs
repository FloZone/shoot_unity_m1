using UnityEngine;
using System.Collections;

public class detectIfUfo : MonoBehaviour {

	// Foes array
	public GameObject[] ufos;
	
	
	// Update is called once per frame
	void Update () {
		// get all ufos
		ufos = GameObject.FindGameObjectsWithTag("ufo");

		// a random chance
		if(ufos.Length < 2 && Random.Range(1,100) == 1) {
			// instantiate a new one
			Instantiate(Resources.Load("ufo"));
		}
	}
}
