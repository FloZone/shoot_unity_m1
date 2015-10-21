using UnityEngine;
using System.Collections;

public class fadeOut : MonoBehaviour {

	public float fade;


	// Use this for initialization
	void Start () {
		// define a fade speed
		fade = 0.10f;
	}

	// Update is called once per frame
	void Update () {
		Color cl = GetComponent<SpriteRenderer>().color;
		cl.a -= fade;
		GetComponent<SpriteRenderer>().color = cl;
		if(cl.a < 0) {
			Destroy(gameObject);
		}
	}
}
