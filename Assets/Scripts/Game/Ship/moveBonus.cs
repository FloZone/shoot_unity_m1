using UnityEngine;
using System.Collections;

public class moveBonus : MonoBehaviour {
	
	private Vector3 leftTopCamera;
	private Vector3 rightTopCamera;
	private Vector3 leftBottomCamera;
	private Vector3 rightBottomCamera;
	
	private Vector3 spriteSize;
	
	
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
		
		// set the movement
		rigidbody2D.velocity = new Vector3(-4, 0, 0);
		
		// get the sprite size
		spriteSize = new Vector3(GetComponent<SpriteRenderer>().bounds.size.x,
		                         GetComponent<SpriteRenderer>().bounds.size.y,
		                         GetComponent<SpriteRenderer>().bounds.size.z);
		
		// set a random position
		transform.position = randomPosition();
	}
	
	// Update is called once per frame
	void Update () {
		// if the bonus is out of the screen, destroy it
		if((transform.position.x + (spriteSize.x / 2)) < leftTopCamera.x
		   || (transform.position.y + (spriteSize.y / 2)) < leftBottomCamera.y
		   || (transform.position.y - (spriteSize.y / 2)) > leftTopCamera.y) {
			Destroy(gameObject);
		}
	}

	// When hits an object
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag.Equals("Player")) {
			gameObject.AddComponent<fadeOut>();
		}
	}

}
