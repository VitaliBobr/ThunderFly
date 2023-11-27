using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achivement : MonoBehaviour {
	vars varsCL;
	[SerializeField]
	int id;
	Image []images;
	GameObject []gm;
	void Start(){
		varsCL = GameObject.Find ("controll").GetComponent<vars>();
	}
	// Update is called once per frame
	void Update () {
		images = GetComponentsInChildren<Image> ();
		for(int i=0;i<images.GetLength(0);i++){
			switch (images [i].name) {
			case "Image":
				images [i].sprite = varsCL.view [id];
				break;
			}

		}
		if (id == 0) {
			GetComponent<Image> ().color =new Color (1f, 0.62f, 0.27f);
		}else
		if (id == 1) {
			GetComponent<Image> ().color =new Color (1f, 0.62f, 0.27f);
		}
		images = GetComponentsInChildren<Image> ();
		for (int i = 0; i < images.GetLength (0); i++) {
			switch (images [i].name) {
			case "Ul":
				if(varsCL.flyer_parts_1[id]>0){images [i].CrossFadeAlpha(0,1,true);}
				else{images [i].color=new Color(1,1,1,1);}
				break;
			case "Ur":
				if(varsCL.flyer_parts_2[id]>0){images [i].CrossFadeAlpha(0,1,true);}
				else{images [i].color=new Color(1,1,1,1);}
				break;
			case "Dl":
				if(varsCL.flyer_parts_3[id]>0){images [i].CrossFadeAlpha(0,1,true);}
				else{images [i].color=new Color(1,1,1,1);}
				break;
			case "Dr":
				if(varsCL.flyer_parts_4[id]>0){images [i].CrossFadeAlpha(0,1,true);}
				else{images [i].color=new Color(1,1,1,1);}
				break;

			}
		}
	}
}

