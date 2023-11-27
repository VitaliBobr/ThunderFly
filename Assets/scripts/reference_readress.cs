using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reference_readress : MonoBehaviour {
	vars varsCL;
	void Start(){
		varsCL = GameObject.Find ("controll").GetComponent<vars>();
	}
	public void chest_open(){
		varsCL.open_chest ();
	}
	public void Bronze(){
		varsCL.add_chest ("rBronze");
	}
	public void Silver(){
		varsCL.add_chest ("rSilver");
	}
	public void Gold(){
		varsCL.add_chest ("rGold");
	}
	public void Platina(){
		varsCL.add_chest ("rPlatina");
	}
}
