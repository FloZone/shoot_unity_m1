using UnityEngine;
using System.Collections;

public class moveStar : MonoBehaviour {

	private Vector3 leftTopCamera;
	private Vector3 rightTopCamera;
	private Vector3 leftBottomCamera;
	private Vector3 rightBottomCamera;
	
	private Vector3 spriteSize;


	// generate a random position out right of the screen
	Vector3 randomPosition() {
		return new Vector3 (rightTopCamera.x + (spriteSize.x / 2),
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

		// set a random size between min-max
		float scale = Random.Range(0.5f, 1.2f);
		transform.localScale = new Vector3(scale, scale, scale);

		// get the sprite size
		spriteSize = new Vector3(GetComponent<SpriteRenderer>().bounds.size.x,
		                         GetComponent<SpriteRenderer>().bounds.size.y,
		                         GetComponent<SpriteRenderer>().bounds.size.z);
		// set a random position
		transform.position = randomPosition();

		// set a random speed
		rigidbody2D.velocity = new Vector2 (Random.Range(-20f, -15f), 0);
	}
	
	// Update is called once per frame
	void Update () {
		// if the asteroid is out of the screen, destroy it
		if ((transform.position.x + (spriteSize.x / 2)) < leftTopCamera.x
		    || (transform.position.y + (spriteSize.y / 2)) < leftBottomCamera.y
		    || (transform.position.y - (spriteSize.y / 2)) > leftTopCamera.y) {
			Destroy(gameObject);
		}
	}
}
