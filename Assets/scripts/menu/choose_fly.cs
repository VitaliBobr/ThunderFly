using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choose_fly : MonoBehaviour {
	GameObject varsCL;
	public GameObject changeImage;
	public GameObject panelUpgrade;
	public GameObject panelBuy;
	void Start (){
		varsCL = GameObject.Find ("controll");
		panelUpgrade= GameObject.Find("Upgrade");
		panelBuy = GameObject.Find("Buy");
		panelBuy.SetActive (false);
	}
	public void FixedUpdate(){
		changeImage.GetComponent<Image> ().sprite = varsCL.GetComponent<vars> ().view [varsCL.GetComponent<vars> ().current_flyer];
	}
	public void BuyFlyer(){
		 if (varsCL.GetComponent<vars> ().flyer_parts_1 [varsCL.GetComponent<vars> ().current_flyer] > 0 && varsCL.GetComponent<vars> ().flyer_parts_2 [varsCL.GetComponent<vars> ().current_flyer] > 0
			&& varsCL.GetComponent<vars> ().flyer_parts_3 [varsCL.GetComponent<vars> ().current_flyer] > 0 && varsCL.GetComponent<vars> ().flyer_parts_4 [varsCL.GetComponent<vars> ().current_flyer] > 0) {
			varsCL.GetComponent<vars> ().isBuy [varsCL.GetComponent<vars> ().current_flyer] = true;
			panelUpgrade.SetActive (true);
			panelBuy.SetActive (false);
		}
	}
	public void backFlyer(){
		if (varsCL.GetComponent<vars> ().current_flyer >= 1){
			varsCL.GetComponent<vars> ().current_flyer--;
			if(!varsCL.GetComponent<vars>().isBuy[varsCL.GetComponent<vars>().current_flyer]){
				panelUpgrade.SetActive (false);
				panelBuy.SetActive (true);
			}else {
				panelUpgrade.SetActive (true);
				panelBuy.SetActive (false);
			}
		}
	}
	public void nextFlyer(){
		if (varsCL.GetComponent<vars> ().current_flyer < varsCL.GetComponent<vars> ().view.GetLength(0)-1){
			varsCL.GetComponent<vars> ().current_flyer++;
			if(!varsCL.GetComponent<vars>().isBuy[varsCL.GetComponent<vars>().current_flyer]){
				panelUpgrade.SetActive (false);
				panelBuy.SetActive (true);
			}else {
				panelUpgrade.SetActive (true);
				panelBuy.SetActive (false);
			}
		}
	}
};
