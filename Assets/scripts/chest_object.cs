using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chest_object : MonoBehaviour {
	public int choose_case;
	public int choose_part;
	public vars varsCL;
	void Start(){
		varsCL = GameObject.Find ("controll").GetComponent<vars>();
		if (varsCL.chestisclosed [SceneManager.GetActiveScene().buildIndex]<=0) {
			Destroy (gameObject);
		}
	}

}