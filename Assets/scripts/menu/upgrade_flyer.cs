using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class upgrade_flyer : MonoBehaviour {
	vars varsCL;
	public GameObject changeImage;
	void Start (){
		varsCL = GameObject.Find ("controll").GetComponent<vars>();
	}
	public void GiveFuel(){
		if (varsCL.fuel [varsCL.current_flyer] < varsCL.fuel_max [varsCL.current_flyer] && varsCL.current_flyer == 0) {
			varsCL.fuel[varsCL.current_flyer] = varsCL.fuel_max[varsCL.current_flyer];
			return;
		}
		else
		if (varsCL.GetComponent<vars> ().fuel [varsCL.GetComponent<vars> ().current_flyer] < varsCL.fuel_max[varsCL.current_flyer]) {
			if (70*(varsCL.fuel_max[varsCL.current_flyer]-varsCL.fuel[varsCL.current_flyer]) <= varsCL.GetComponent<vars> ().money) {
				varsCL.money -=Mathf.Ceil(70*(varsCL.fuel_max[varsCL.current_flyer]-varsCL.fuel[varsCL.current_flyer]));
				varsCL.fuel[varsCL.GetComponent<vars> ().current_flyer] = varsCL.fuel_max[varsCL.GetComponent<vars> ().current_flyer];
			} else {
				varsCL.fuel [varsCL.current_flyer] +=Mathf.Ceil(varsCL.money / 70);
				varsCL.money = 0;
			}
		} else {
			Debug.Log ("NotOne");
		}
	}
	public void FixedUpdate(){
		if (varsCL.GetComponent<vars> ().hp_flyer [varsCL.GetComponent<vars> ().current_flyer] < 1 || varsCL.fuel[varsCL.current_flyer] < 1){
			if(GameObject.Find ("tomenu")!=null)GameObject.Find ("tomenu").GetComponent<Button> ().interactable=false;
			if(GameObject.Find ("Warning")!=null)GameObject.Find ("Warning").SetActive (true);
		} else {
			if(GameObject.Find ("tomenu")!=null)GameObject.Find ("tomenu").GetComponent<Button> ().interactable=true;
			if(GameObject.Find ("Warning")!=null)GameObject.Find ("Warning").SetActive (false);
		}
	}
	public void repair(){
		if (varsCL.GetComponent<vars> ().hp_flyer [varsCL.GetComponent<vars> ().current_flyer] < 100) {
			if (varsCL.current_flyer == 0) {
				varsCL.hp_flyer[varsCL.current_flyer]= 100;
				return;
			}
			if (varsCL.GetComponent<vars> ().cost_fix [varsCL.GetComponent<vars> ().current_flyer] - varsCL.GetComponent<vars> ().cost_fix [varsCL.GetComponent<vars> ().current_flyer] * varsCL.GetComponent<vars> ().hp_flyer [varsCL.GetComponent<vars> ().current_flyer] / 100 <= varsCL.GetComponent<vars> ().money) {
				varsCL.money -= Mathf.Round (varsCL.GetComponent<vars> ().cost_fix [varsCL.GetComponent<vars> ().current_flyer] - varsCL.GetComponent<vars> ().cost_fix [varsCL.GetComponent<vars> ().current_flyer] * varsCL.GetComponent<vars> ().hp_flyer [varsCL.GetComponent<vars> ().current_flyer] * 0.01f);
				varsCL.GetComponent<vars> ().hp_flyer [varsCL.GetComponent<vars> ().current_flyer] = 100;
			} else {
				varsCL.hp_flyer [varsCL.current_flyer] += varsCL.money/(varsCL.cost_fix [varsCL.current_flyer] / 100);
				varsCL.money = 0;
			}
		}
	}
	public void UpgradeSpeed(){
		if(varsCL.GetComponent<vars> ().cost_level_up[varsCL.GetComponent<vars> ().select_lvl_speed[varsCL.GetComponent<vars> ().current_flyer]+1]<=varsCL.GetComponent<vars>().money && varsCL.fuel[varsCL.current_flyer]>0 && varsCL.hp_flyer[varsCL.current_flyer]>0){
			if (varsCL.GetComponent<vars> ().select_lvl_speed [varsCL.GetComponent<vars> ().current_flyer] < varsCL.GetComponent<vars> ().max_lvl_speed [varsCL.GetComponent<vars> ().current_flyer]) {
				varsCL.GetComponent<vars> ().select_lvl_speed [varsCL.GetComponent<vars> ().current_flyer]++;
				Debug.Log (varsCL.GetComponent<vars> ().cost_level_up [varsCL.GetComponent<vars> ().select_lvl_speed [varsCL.GetComponent<vars> ().current_flyer]]);
				varsCL.GetComponent<vars> ().money -= varsCL.GetComponent<vars> ().cost_level_up [varsCL.GetComponent<vars> ().select_lvl_speed [varsCL.GetComponent<vars> ().current_flyer]];
			}
		}
	}
	public void UpgradeDegree(){
		if(varsCL.GetComponent<vars> ().cost_level_up[varsCL.GetComponent<vars> ().select_lvl_degree[varsCL.GetComponent<vars> ().current_flyer]+1]<=varsCL.GetComponent<vars>().money  && varsCL.fuel[varsCL.current_flyer]>0 && varsCL.hp_flyer[varsCL.current_flyer]>0){
			if (varsCL.GetComponent<vars> ().select_lvl_degree [varsCL.GetComponent<vars> ().current_flyer] < varsCL.GetComponent<vars> ().max_lvl_degree [varsCL.GetComponent<vars> ().current_flyer]) {
				varsCL.GetComponent<vars> ().select_lvl_degree[varsCL.GetComponent<vars> ().current_flyer]++;
				Debug.Log (varsCL.GetComponent<vars> ().cost_level_up [varsCL.GetComponent<vars> ().select_lvl_degree[varsCL.GetComponent<vars> ().current_flyer]]);
				varsCL.GetComponent<vars> ().money -= varsCL.GetComponent<vars> ().cost_level_up [varsCL.GetComponent<vars> ().select_lvl_degree[varsCL.GetComponent<vars> ().current_flyer]];
			}
		}
	}
	public void UpgradeFuel(){
		if(varsCL.GetComponent<vars> ().cost_level_up[varsCL.GetComponent<vars> ().select_lvl_fuel[varsCL.GetComponent<vars> ().current_flyer]+1]<=varsCL.GetComponent<vars>().money && varsCL.fuel[varsCL.current_flyer]>0 && varsCL.hp_flyer[varsCL.current_flyer]>0){
			if (varsCL.GetComponent<vars> ().select_lvl_fuel [varsCL.GetComponent<vars> ().current_flyer] < varsCL.GetComponent<vars> ().max_lvl_fuel[varsCL.GetComponent<vars> ().current_flyer]) {
				varsCL.GetComponent<vars> ().select_lvl_fuel[varsCL.GetComponent<vars> ().current_flyer]++;
				Debug.Log (varsCL.GetComponent<vars> ().cost_level_up [varsCL.GetComponent<vars> ().select_lvl_fuel[varsCL.GetComponent<vars> ().current_flyer]]);
				varsCL.GetComponent<vars> ().money -= varsCL.GetComponent<vars> ().cost_level_up [varsCL.GetComponent<vars> ().select_lvl_fuel[varsCL.GetComponent<vars> ().current_flyer]];
				varsCL.fuel_max[varsCL.current_flyer] = varsCL.start_fuel[varsCL.current_flyer] + varsCL.start_fuel[varsCL.current_flyer]*varsCL.kpd_bonus_fuel[varsCL.current_flyer] * varsCL.select_lvl_fuel[varsCL.current_flyer];
			}
		}
	}
	public void UpgradeSeat(){
		if(varsCL.GetComponent<vars> ().cost_level_up[varsCL.GetComponent<vars> ().select_lvl_seat[varsCL.GetComponent<vars> ().current_flyer]+1]<=varsCL.GetComponent<vars>().money && varsCL.fuel[varsCL.current_flyer]>0 && varsCL.hp_flyer[varsCL.current_flyer]>0){
			if (varsCL.GetComponent<vars> ().select_lvl_seat [varsCL.GetComponent<vars> ().current_flyer] < varsCL.GetComponent<vars> ().max_lvl_seat[varsCL.GetComponent<vars> ().current_flyer]) {
				varsCL.GetComponent<vars> ().select_lvl_seat[varsCL.GetComponent<vars> ().current_flyer]++;
				Debug.Log (varsCL.GetComponent<vars> ().cost_level_up [varsCL.GetComponent<vars> ().select_lvl_seat[varsCL.GetComponent<vars> ().current_flyer]]);
				varsCL.GetComponent<vars> ().money -= varsCL.GetComponent<vars> ().cost_level_up [varsCL.GetComponent<vars> ().select_lvl_seat[varsCL.GetComponent<vars> ().current_flyer]];
			}
		}
	}
}
