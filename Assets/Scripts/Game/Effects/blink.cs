using UnityEngine;
using System.Collections;

public class blink : MonoBehaviour {

	public float speed;
	private bool decrease;
	public float nbBlink;
	
	
	// Use this for initialization
	void Start () {
		speed = 0.2f;
		nbBlink = 5;
		decrease = true;
	}
	
	// Update is called once per frame
	void Update () {
		Color cl = GetComponent<SpriteRenderer>().color;
		if(cl.a >= 1) {
			--nbBlink;
			decrease = true;
		}
		else if(cl.a <= 0) {
			decrease = false;
		}

		if(nbBlink == 0) {
			cl.a = 1;
			GetComponent<SpriteRenderer>().color = cl;
			gameObject.GetComponent<Collider2D>().enabled = true;
			Destroy(gameObject.GetComponent<blink>());
		}
		else if(decrease) {
			cl.a -= speed;
		}
		else {
			cl.a += speed;
		}
		GetComponent<SpriteRenderer>().color = cl;
	}
}
