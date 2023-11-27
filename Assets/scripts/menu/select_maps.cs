using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class select_maps : MonoBehaviour {
	vars varsCL;
	public GameObject panel_choose;
	public GameObject panel_buy;
	public GameObject changeImage;
	void Start (){
		varsCL = GameObject.Find ("controll").GetComponent<vars>();
		panel_choose= GameObject.Find("selects_maps");
		panel_buy = GameObject.Find("buy_maps");
		panel_buy.SetActive (false);
	}
	public void BuyMap(){
		if (varsCL.GetComponent<vars> ().maps_buy_cost [varsCL.GetComponent<vars> ().current_maps] <= varsCL.GetComponent<vars> ().money) {
			varsCL.GetComponent<vars> ().money -= varsCL.GetComponent<vars> ().maps_buy_cost [varsCL.GetComponent<vars> ().current_maps];
			varsCL.GetComponent<vars> ().map_is_buy[varsCL.GetComponent<vars>().current_maps] = true;
			GameObject.Find("money").GetComponent<Text> ().text =""+varsCL.money.ToString();
			panel_choose.SetActive (true);
			panel_buy.SetActive (false);
		}
	}
	public void FixedUpdate(){
		changeImage.GetComponent<Image> ().sprite = varsCL.GetComponent<vars> ().maps_image[varsCL.GetComponent<vars> ().current_maps];
		GameObject.Find ("marchrut").GetComponent<Text>().text=varsCL.maps_text[varsCL.current_maps];
		GameObject.Find ("maps_cost").GetComponent<Text>().text=varsCL.maps_buy_cost[varsCL.current_maps].ToString();
	}
	public void backMap(){
		if (varsCL.GetComponent<vars> ().current_maps >= 1){
			varsCL.GetComponent<vars> ().current_maps--;
			if (!varsCL.GetComponent<vars> ().map_is_buy [varsCL.GetComponent<vars> ().current_maps]) {
				panel_choose.SetActive (false);
				panel_buy.SetActive (true);
			} else {
				panel_choose.SetActive (true);
				panel_buy.SetActive (false);
			}
		}
	}
	public void nextMap(){
		if (varsCL.GetComponent<vars> ().current_maps < varsCL.GetComponent<vars> ().maps.GetLength(0)-1){
			varsCL.GetComponent<vars> ().current_maps++;
			if (!varsCL.GetComponent<vars> ().map_is_buy [varsCL.GetComponent<vars> ().current_maps]) {
				panel_choose.SetActive (false);
				panel_buy.SetActive (true);
			} else {
				panel_choose.SetActive (true);
				panel_buy.SetActive (false);
			}
		}
	}
	public void GoToMap(){
		scene_controll.scene_load (varsCL.GetComponent<vars>().maps[varsCL.GetComponent<vars>().current_maps]);
	}
}