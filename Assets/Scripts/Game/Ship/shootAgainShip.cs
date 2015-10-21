using UnityEngine;
using System.Collections;

public class shootAgainShip : MonoBehaviour {

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
		// if fire if pressed (space)
		if(Input.GetKeyDown(KeyCode.Space)) {
			// create a position in front of the ship
			Vector3 shootPos = new Vector3(transform.position.x + spriteSize.x,
			                             transform.position.y,
			                             transform.position.z);
			switch(GameObject.FindGameObjectWithTag("Player").GetComponent<moveShip>().bonus) {
			case 0:
				// instantiate the shoot
				Instantiate(Resources.Load("shootShip"), shootPos, Quaternion.identity);
				// play the shoot sound
				SoundState.Instance.playShootSound();
				break;
			case 1:
				// instantiate the shoot
				Instantiate(Resources.Load("shoot2Ship"), shootPos, Quaternion.identity);
				// play the shoot sound
				SoundState.Instance.playShootSound();
				break;
			case 2:
				// instantiate the laser
				Instantiate(Resources.Load("laserShip"), shootPos, Quaternion.identity);
				// play the laser sound
				SoundState.Instance.playLaserSound();
				break;
			}

		}
	}
}
