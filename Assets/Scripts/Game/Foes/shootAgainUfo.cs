using UnityEngine;
using System.Collections;

public class shootAgainUfo : MonoBehaviour {

	private Vector3 spriteSize;
	
	// Use this for initialization
	void Start () {
		// get the sprite size
		spriteSize = new Vector3(GetComponent<SpriteRenderer>().bounds.size.x,
		                         GetComponent<SpriteRenderer>().bounds.size.y,
		                         GetComponent<SpriteRenderer>().bounds.size.z);
	}
	
	// Update is called once per frame
	void Update () {
		// random shoot
		if(Random.Range(1,50) == 1) {
			// create a position in front of the ufo
			Vector3 shootPos = new Vector3(transform.position.x - spriteSize.x,
			                               transform.position.y,
			                               transform.position.z);
			// instantiate the shoot
			Instantiate(Resources.Load("shootUfo"), shootPos, Quaternion.identity);
			// play the shoot sound
			SoundState.Instance.playUfoLaserSound();
		}
	}
}
