using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fortune : MonoBehaviour {
	[SerializeField] Image []images;
	[SerializeField] int step;
	[SerializeField] int current_item=0;
	bool execute;
	vars varsCL;
	public GameObject changeImage;
	void Start (){
		varsCL = GameObject.Find ("controll").GetComponent<vars>();
	}
	public void test_luck(){
		if (varsCL.cristal >= 30) {
			step = Random.Range (20, 80);
			varsCL.cristal -= 30;
			execute = true;
			GetComponent<Button> ().interactable = false;
		}
	}
	public void FixedUpdate(){
		if(execute){
			if (step > 0) {
				if (current_item < images.GetLength (0) - 1) {
					images [current_item].color = Color.gray;
					current_item++;
					images [current_item].color = Color.yellow;
				} else {
					images [current_item].color = Color.gray;
					current_item = 0;
					images [current_item].color = Color.yellow;
				}
				step--;
			} else {
				GetComponent<Button> ().interactable = true;
				execute = false;
				switch(current_item){
				case 0:
					varsCL.cristal += 10;					
				break;
				case 1:
					varsCL.cristal += 100;					
				break;
				case 2:
					varsCL.money += 10000;					
				break;
				case 3:
					varsCL.add_chest ("rBronze");
					break;
				case 4:
					varsCL.cristal += 30;					
					break;
				}
			}
		}
	}
}
