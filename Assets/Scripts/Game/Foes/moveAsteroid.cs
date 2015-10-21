using UnityEngine;
using System.Collections;

public class moveAsteroid : MonoBehaviour {

	private Vector3 leftTopCamera;
	private Vector3 rightTopCamera;
	private Vector3 leftBottomCamera;
	private Vector3 rightBottomCamera;

	private Vector3 spriteSize;
	public float rotateSpeed;
	public int life;


	// generate a random position out right of the screen
	Vector3 randomPosition() {
		return new Vector3 (rightTopCamera.x + spriteSize.x,
		                    Random.Range (rightBottomCamera.y + (spriteSize.y / 2), rightTopCamera.y + (spriteSize.y / 2)),
		                    transform.position.z);
	}

	// generate a random movement
	Vector2 randomMovement(int scale) {
		return new Vector2 (Random.Range(-9f+(2f*scale), -7f+(1.5f*scale)), // speed
		                    // Random.Range (-2f, 2f)); // angle
		                    0); // horizontal
	}

	// Use this for initialization
	void Start () {
		// get screen borders
		leftTopCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightTopCamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		leftBottomCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightBottomCamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));

		// set a random size between 1 & 3 (4 exclusive)
		int scale = Random.Range(1,4);
		transform.localScale = new Vector3(scale, scale, 1);
		// set a random movement relative to the scale
		rigidbody2D.velocity = randomMovement(scale);

		// get the sprite size
		spriteSize = new Vector3(GetComponent<SpriteRenderer>().bounds.size.x,
		                  		 GetComponent<SpriteRenderer>().bounds.size.y,
		                		 GetComponent<SpriteRenderer>().bounds.size.z);

		// set a random position
		transform.position = randomPosition();

		// set a life relative to the size
		life = scale;

		// set the rotation speed
		rotateSpeed = Random.Range(0f,1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		// if the asteroid is out of the screen, destroy it
		if((transform.position.x + (spriteSize.x / 2)) < leftTopCamera.x
		    || (transform.position.y + (spriteSize.y / 2)) < leftBottomCamera.y
		    || (transform.position.y - (spriteSize.y / 2)) > leftTopCamera.y) {
			Destroy(gameObject);
		}
		// else do a rotation
		else {
			transform.Rotate(Vector3.forward, rotateSpeed, Space.Self);
		}
	}

	// explode asteroid
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
			GameState.Instance.addScorePlayer(1);
			// play the explosion sound
			SoundState.Instance.playAsteroidExplosionSound();
			// destroy
			explode();
		}
	}

	// When hits an object
	void OnTriggerEnter2D(Collider2D other) {
		// If it's an asteroid, destroy
		if(other.tag.Equals("asteroid")) {
			explode();
		}
	}
	
}
