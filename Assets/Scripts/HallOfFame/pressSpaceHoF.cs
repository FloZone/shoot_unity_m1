using UnityEngine;
using System.Collections;

public class pressSpaceHoF : MonoBehaviour {

	float speed;
	bool decrease;
	
	
	// Use this for initialization
	void Start () {
		speed = 0.02f;
		decrease = true;
	}
	
	// Update is called once per frame
	void Update () {
		// if space button is pressed
		if(Input.GetKeyDown ("space")) {
			Application.LoadLevel("scene2-Menu");
		}

		Color cl = gameObject.guiText.color;
		if(cl.a >= 1) {
			decrease = true;
		}
		else if(cl.a <= 0) {
			decrease = false;
		}
		
		if(decrease) {
			cl.a -= speed;
		}
		else {
			cl.a += speed;
		}
		
		gameObject.guiText.color = cl;
	}
}
