using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {
	public int damage;
	public void Update(){
		switch(name){
		case "bird":
			transform.Translate (Vector2.left * 2 * Time.deltaTime);
			break;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		switch (name) {
		case "bird":
			switch (col.name) {
			case "end_horizontal_left":
				Destroy (this.gameObject);
				print ("adsa");
				break;
			case "bullet_ggn":
				Destroy (this.gameObject);
				break;
			}
		break;
		case "end_horizontal_right":
			switch (col.name) {
			case "bullet_ggn":
				Destroy (col.gameObject);
				break;
			}
		break;
		}
	}
}