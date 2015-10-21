using UnityEngine;
using System.Collections;

public class playButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// if play button is clicked
		if(Input.GetMouseButtonDown(0)) {
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 pos = new Vector2(wp.x, wp.y);
			if(collider2D == Physics2D.OverlapPoint(pos)) {
				Application.LoadLevel("scene3-Game");
			}
		}
	}

}
