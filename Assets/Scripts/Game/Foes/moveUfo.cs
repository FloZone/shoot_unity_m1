using UnityEngine;
using System.Collections;

public class moveUfo : MonoBehaviour {

	private Vector3 leftTopCamera;
	private Vector3 rightTopCamera;
	private Vector3 leftBottomCamera;
	private Vector3 rightBottomCamera;
	
	private Vector3 spriteSize;
	public int life;
	
	
	// generate a random position out right of the screen
	Vector3 randomPosition() {
		return new Vector3 (rightTopCamera.x + spriteSize.x,
		                    Random.Range (rightBottomCamera.y + (spriteSize.y / 2), rightTopCamera.y + (spriteSize.y / 2)),
		                    transform.position.z);
	}

	// Use this for initialization
	void Start () {
		// get screen borders
		leftTopCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightTopCamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		leftBottomCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightBottomCamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		
		// get the sprite size
		spriteSize = new Vector3(GetComponent<SpriteRenderer>().bounds.size.x,
		                         GetComponent<SpriteRenderer>().bounds.size.y,
		                         GetComponent<SpriteRenderer>().bounds.size.z);
		// set a random position
		transform.position = randomPosition();
		
		// set the life
		life = 5;
	}
	
	// Update is called once per frame
	void Update () {
		// if the ufo is out of the screen, destroy it
		if((transform.position.x + (spriteSize.x / 2)) < leftTopCamera.x
		   || (transform.position.y + (spriteSize.y / 2)) < leftBottomCamera.y
		   || (transform.position.y - (spriteSize.y / 2)) > leftTopCamera.y) {
			Destroy(gameObject);
		}
		// else move the ufo
		else {
			rigidbody2D.velocity = new Vector2(-5f, 5*Mathf.Cos(transform.position.x));
		}
	}
	
	
	// explode ufo
	public void explode() {
		// remove the collider
		collider2D.enabled = false;
		// explosion
		gameObject.AddComponent<fadeOut>();
	}
	
	// when hit by a shoot
	public void hit(int power) {
		// decrease the life
		life -= power;

		// if is destroyed
		if(life <= 0) {
			// increase the player score
			GameState.Instance.addScorePlayer(5);
			// play the explosion sound
			SoundState.Instance.playUfoExplosionSound();
			// destroy
			explode();
		}
	}
}
