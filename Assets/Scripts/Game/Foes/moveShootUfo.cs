using UnityEngine;
using System.Collections;

public class moveShootUfo: MonoBehaviour {

	private Vector3 leftTopCamera;
	//private Vector3 rightTopCamera;
	//private Vector3 leftBottomCamera;
	//private Vector3 rightBottomCamera;
	
	private Vector3 spriteSize;
	public Vector2 movement;
	
	
	// Use this for initialization
	void Start () {
		// get screen borders
		leftTopCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		//rightTopCamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		//leftBottomCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		//rightBottomCamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		
		// get the sprite size
		spriteSize = new Vector3(GetComponent<SpriteRenderer>().bounds.size.x,
		                         GetComponent<SpriteRenderer>().bounds.size.y,
		                         GetComponent<SpriteRenderer>().bounds.size.z);
		
		// define a movement for the shoot
		movement = new Vector2(-10f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		// Set the movement for the shoot
		rigidbody2D.velocity = movement;
		
		// destroy if the shoot is out of the screen
		if ((transform.position.x - (spriteSize.x/2)) < leftTopCamera.x) {
			Destroy(gameObject);
		}
	}

	// When hits an object
	void OnTriggerEnter2D(Collider2D other) {
		// If it's an asteroid
		if(other.tag.Equals("Player") || other.tag.Equals("shootShip")) {
			// destroy
			Destroy(gameObject);
		}
	}
}
