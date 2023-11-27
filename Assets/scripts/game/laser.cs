using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {
	// Update is called once per frame
	private float speed=2;
	void FixedUpdate () {
		transform.Translate(Vector2.up*Time.deltaTime*speed);
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "destroyer") {
			Destroy (gameObject);
		}
	}

}
