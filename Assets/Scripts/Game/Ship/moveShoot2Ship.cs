using UnityEngine;
using System.Collections;

public class moveShoot2Ship : MonoBehaviour {
	
	//private Vector3 leftTopCamera;
	private Vector3 rightTopCamera;
	//private Vector3 leftBottomCamera;
	//private Vector3 rightBottomCamera;
	
	private Vector3 spriteSize;
	public Vector2 movement;
	public int power;
	
	
	// Use this for initialization
	void Start () {
		// get screen borders
		//leftTopCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightTopCamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		//leftBottomCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		//rightBottomCamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		
		// get the sprite size
		spriteSize = new Vector3(GetComponent<SpriteRenderer>().bounds.size.x,
		                         GetComponent<SpriteRenderer>().bounds.size.y,
		                         GetComponent<SpriteRenderer>().bounds.size.z);
		
		// define a movement for the shoot
		movement = new Vector2(13f, 0f);
		// set the power of the shoot
		power = 2;
	}
	
	// Update is called once per frame
	void Update () {
		// Set the movement for the shoot
		rigidbody2D.velocity = movement;
		
		// destroy if the shoot is out of the screen
		if ((transform.position.x - (spriteSize.x/2)) > rightTopCamera.x) {
			Destroy(gameObject);
		}
	}
	
	// When hits an object
	void OnTriggerEnter2D(Collider2D other) {
		// If it's an asteroid
		if(other.tag.Equals("asteroid")) {
			// hit it
			other.gameObject.GetComponent<moveAsteroid>().hit(power);
			// destroy
			Destroy(gameObject);
		}
		// If it's an ufo
		if(other.tag.Equals("ufo")) {
			// hit it
			other.gameObject.GetComponent<moveUfo>().hit(power);
			// destroy
			Destroy(gameObject);
		}
		// If it's an ufo shoot
		if(other.tag.Equals("shootUfo")) {
			// destroy
			Destroy(gameObject);
		}
	}
}
