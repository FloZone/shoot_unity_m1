using UnityEngine;
using System.Collections;

public class wait2sec : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("goMenu", 2.0f);
	}

	void goMenu() {
		Application.LoadLevel("scene2-Menu");
	}
	// Update is called once per frame
	void Update () {
		
	}
}
