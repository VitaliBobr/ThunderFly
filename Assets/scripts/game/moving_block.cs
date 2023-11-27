using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_block : MonoBehaviour {
	[SerializeField] private float degree_z;
	[SerializeField] private float speed=2;
	void Start(){
		transform.rotation = Quaternion.Euler (0, 0, degree_z);
	}
	void Update () {
		transform.Translate (Vector2.up*Time.deltaTime*speed);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "destroyer") {
			Debug.Log ("asfasg");
			transform.rotation = Quaternion.Euler (0, 0, transform.rotation.eulerAngles.z + 180);

		}	
	}
}
