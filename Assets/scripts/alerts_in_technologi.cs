using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class alerts_in_technologi : MonoBehaviour {
	public vars varsCL;
	void FixedUpdate () {
		varsCL = GameObject.Find ("controll").GetComponent<vars>(); 	
		if (varsCL.chests_opred.Count>0) {
			GetComponent<Text> ().color = Color.red;
			GetComponent<Text> ().text = varsCL.chests_opred.Count.ToString();
		} else {
			GetComponent<Text> ().color = Color.clear;
			if (GameObject.Find ("next_chest") != null) {
				GameObject.Find ("next_chest").SetActive (false);
			}
		}
	}
	public void clear_alert_technolog(){
		varsCL.alert_in_technolog = 0;
	}
}
