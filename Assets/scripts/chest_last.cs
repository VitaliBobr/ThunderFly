using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chest_last : MonoBehaviour {
	vars varsCL;
	Image []images;
	void Start(){
		varsCL = GameObject.Find ("controll").GetComponent<vars>();
	}
	// Update is called once per frame
	void Update () {
		images = GetComponentsInChildren<Image> ();
		for (int i = 0; i < images.GetLength (0); i++) {
			switch (images [i].name) {
			case "Image":
				images [i].sprite = varsCL.view [varsCL.last_chest.x];
				break;
			}
		}
		if (varsCL.last_chest.x == 0) {
			GetComponent<Image> ().color =new Color (1f, 0.62f, 0.27f);
		}else if (varsCL.last_chest.x== 1) {
			GetComponent<Image> ().color =new Color (1f, 0.62f, 0.27f);
		}images = GetComponentsInChildren<Image> ();
		for (int i = 0; i < images.GetLength (0); i++) {
			switch (images [i].name) {
			case "Ul":
				if (varsCL.flyer_parts_1 [varsCL.last_chest.x] > 0){
					if (varsCL.last_chest.y == 1f) {
						images [i].color = new Color(1,1,0,0.5f);
					} else {
						images [i].color = new Color (1, 1, 1, 0);
					}
				}else{
					images [i].color=new Color(1,1,1,1);}
				break;
			case "Ur":
				if (varsCL.flyer_parts_2 [varsCL.last_chest.x] > 0){
					if (varsCL.last_chest.y == 2f) {
						images [i].color = new Color(1,1,0,0.5f);
					} else {
						images [i].color = new Color (1, 1, 1, 0);
					}
				}else{
					images [i].color=new Color(1,1,1,1);}
				break;
			case "Dl":
				if (varsCL.flyer_parts_3 [varsCL.last_chest.x] > 0){
					if (varsCL.last_chest.y == 3f) {
						images [i].color = new Color(1,1,0,0.5f);
					} else {
						images [i].color = new Color (1, 1, 1, 0);
					}
				}else{
					images [i].color=new Color(1,1,1,1);}
				break;
			case "Dr":
				if (varsCL.flyer_parts_4 [varsCL.last_chest.x] > 0){
					if (varsCL.last_chest.y == 4f) {
						images [i].color = new Color(1,1,0,0.5f);
					} else {
						images [i].color = new Color (1, 1, 1, 0);
					}
				}else{
					images [i].color=new Color(1,1,1,1);}
				break;

			}
		}
	}
}

