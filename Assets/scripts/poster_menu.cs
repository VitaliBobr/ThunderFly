using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class poster_menu : MonoBehaviour {
	vars varsCL;
	GameObject temp;
	void Start(){
		varsCL = GameObject.Find ("controll").GetComponent<vars>();	
	}
	void FixedUpdate(){
		GameObject.Find ("descriptions").GetComponent<Text> ().text = varsCL.description_flyers[varsCL.current_flyer];
	}
}
