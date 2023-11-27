using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class unlock_bar : MonoBehaviour {
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
				images [i].sprite = varsCL.view [varsCL.current_flyer];
				break;
			}
		}
		if (varsCL.current_flyer == 0) {
			GetComponent<Image> ().color =new Color (1f, 0.62f, 0.27f);
		}else
			if (varsCL.current_flyer== 1) {
				GetComponent<Image> ().color =new Color (1f, 0.62f, 0.27f);
			}
		images = GetComponentsInChildren<Image> ();
		for (int i = 0; i < images.GetLength (0); i++) {
			switch (images [i].name) {
			case "Ul":
				if(varsCL.flyer_parts_1[varsCL.current_flyer]>0){images [i].color=new Color(1,1,1,0);}
				else{images [i].color=new Color(1,1,1,1);}
				break;
			case "Ur":
				if(varsCL.flyer_parts_2[varsCL.current_flyer]>0){images [i].color=new Color(1,1,1,0);}
				else{images [i].color=new Color(1,1,1,1);}
				break;
			case "Dl":
				if(varsCL.flyer_parts_3[varsCL.current_flyer]>0){images [i].color=new Color(1,1,1,0);}
				else{images [i].color=new Color(1,1,1,1);}
				break;
			case "Dr":
				if(varsCL.flyer_parts_4[varsCL.current_flyer]>0){images [i].color=new Color(1,1,1,0);}
				else{images [i].color=new Color(1,1,1,1);}
				break;
			}
		}
	}
}