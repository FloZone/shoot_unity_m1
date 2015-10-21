using UnityEngine;
using System.Collections;

public class moveShip : MonoBehaviour {
	
	private Vector3 leftTopCamera;
	private Vector3 rightTopCamera;
    //private Vector3 leftBottomCamera;
	private Vector3 rightBottomCamera;
	
	private Vector3 spriteSize;
	public float speed;
	public int bonus;
	
	
	// Use this for initialization
	void Start () {
		// get screen borders
		leftTopCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightTopCamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		//leftBottomCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightBottomCamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		
		// get the sprite size
		spriteSize = new Vector3(GetComponent<SpriteRenderer>().bounds.size.x,
		                         GetComponent<SpriteRenderer>().bounds.size.y,
		                         GetComponent<SpriteRenderer>().bounds.size.z);

		// define the movement speed
		speed = 15f;

		// set the position (1/4 left of the screen)
		transform.position = new Vector3(0.75f*leftTopCamera.x, 0f, 0f);

		// set the bonus
		bonus = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// get inputs
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		// if the ship is out of the screen, don't move in the direction
		if((transform.position.x + (spriteSize.x/2)) >= rightTopCamera.x
		   && horizontal > 0f) {
			horizontal = 0f;
		}
		else if((transform.position.x - (spriteSize.x/2)) <= leftTopCamera.x
		   && horizontal < 0f) {
			horizontal = 0f;
		}
		if((transform.position.y + (spriteSize.y/2)) >= rightTopCamera.y
		   && vertical > 0f) {
			vertical = 0f;
		}
		else if((transform.position.y - (spriteSize.y/2)) <= rightBottomCamera.y
		        && vertical < 0f) {
			vertical = 0f;
		}

		// move the ship
		rigidbody2D.velocity = new Vector2(horizontal*speed, vertical*speed);
	}

	// When hits an object
	void OnTriggerEnter2D(Collider2D other) {	
		// if asteroid or ufo hits the ship
		if(other.tag.Equals("asteroid") || other.tag.Equals("ufo") || other.tag.Equals("shootUfo")) {
			gameObject.GetComponent<Collider2D>().enabled = false;
			SoundState.Instance.playShipHitSound();
			gameObject.AddComponent<blink>();

			// decrease the bonus
			if(bonus > 0) {
				--bonus;
			}

			// remove a life
			if(GameObject.FindGameObjectWithTag("life5")) {
				GameObject.FindGameObjectWithTag("life5").AddComponent<fadeOut>();
			}
			else if(GameObject.FindGameObjectWithTag("life4")) {
				GameObject.FindGameObjectWithTag("life4").AddComponent<fadeOut>();
			}
			else if(GameObject.FindGameObjectWithTag("life3")) {
				GameObject.FindGameObjectWithTag("life3").AddComponent<fadeOut>();
			}
			else if(GameObject.FindGameObjectWithTag("life2")) {
				GameObject.FindGameObjectWithTag("life2").AddComponent<fadeOut>();
			}
			else if(GameObject.FindGameObjectWithTag("life1")) {
				GameObject.FindGameObjectWithTag("life1").AddComponent<fadeOut>();
			}
			else {
				Application.LoadLevel("scene4-HallOfFame");
			}
		}
		// else if it's a bonus
		else if(other.tag.Equals("bonus")) {
			// increase the bonus
			if(bonus < 2) {
				++bonus;
			}
		}
	}
}
