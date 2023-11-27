using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spell_controll : MonoBehaviour {
	vars varsCL;
	public GameObject []spells;
	void Start(){
		varsCL = GameObject.Find ("controll").GetComponent<vars> ();
	}
	void FixedUpdate(){
		if (varsCL.colvo_skills [varsCL.current_flyer] > 0) {
			if(!spells[0].gameObject.activeSelf){
				spells[0].gameObject.SetActive (true);
			}
			spells[0].GetComponent<Image> ().sprite = varsCL.icon_one_spell [varsCL.current_flyer];
			spells[0].GetComponentInChildren<Text> ().text =varsCL.current_upgrade_one_spell[varsCL.current_flyer].ToString() +"/"+ varsCL.max_upgrade_one_spell[varsCL.current_flyer].ToString()+"\n"+varsCL.name_one_spell [varsCL.current_flyer];
		} else if(spells[0].gameObject.activeSelf){
				spells[0].gameObject.SetActive (false);
		}
		/////////
		if (varsCL.colvo_skills [varsCL.current_flyer] > 1) {
			if(!spells[1].gameObject.activeSelf){
				spells[1].gameObject.SetActive (true);
			}
			spells[1].GetComponent<Image> ().sprite = varsCL.icon_two_spell [varsCL.current_flyer];
			spells[1].GetComponentInChildren<Text> ().text = varsCL.current_upgrade_two_spell[varsCL.current_flyer].ToString() +"/"+ varsCL.max_upgrade_two_spell[varsCL.current_flyer].ToString()+varsCL.name_two_spell [varsCL.current_flyer];
		} else if(spells[1].gameObject.activeSelf){
			spells[1].gameObject.SetActive (false);
		}
		///////////////////
		if (varsCL.colvo_skills [varsCL.current_flyer] > 2) {
			if(!spells[2].gameObject.activeSelf){
				spells[2].gameObject.SetActive (true);
			}
			spells[2].GetComponent<Image> ().sprite = varsCL.icon_three_spell [varsCL.current_flyer];
			spells[2].GetComponentInChildren<Text> ().text =varsCL.current_upgrade_three_spell[varsCL.current_flyer].ToString() +"/"+ varsCL.max_upgrade_three_spell[varsCL.current_flyer].ToString()+ varsCL.name_three_spell [varsCL.current_flyer];
		} else if(spells[2].gameObject.activeSelf){
			spells[2].gameObject.SetActive (false);
		}
	}
	public void Improve_one_skill(){
		if (varsCL.current_upgrade_one_spell [varsCL.current_flyer] < varsCL.max_upgrade_one_spell [varsCL.current_flyer] && varsCL.money >= varsCL.cost_level_up_skills [varsCL.current_upgrade_one_spell [varsCL.current_flyer]]) {
			varsCL.current_upgrade_one_spell [varsCL.current_flyer]++;
			varsCL.money -= varsCL.cost_level_up_skills [varsCL.current_upgrade_one_spell [varsCL.current_flyer]];
		}
	}
	public void Improve_two_skill(){
		if (varsCL.current_upgrade_two_spell [varsCL.current_flyer] < varsCL.max_upgrade_two_spell [varsCL.current_flyer] && varsCL.money >= varsCL.cost_level_up_skills [varsCL.current_upgrade_two_spell [varsCL.current_flyer]]) {
			varsCL.current_upgrade_two_spell [varsCL.current_flyer]++;
			varsCL.money -= varsCL.cost_level_up_skills [varsCL.current_upgrade_two_spell [varsCL.current_flyer]];
		}
	}
	public void Improve_three_skill(){
		if (varsCL.current_upgrade_three_spell [varsCL.current_flyer] < varsCL.max_upgrade_three_spell [varsCL.current_flyer] && varsCL.money >= varsCL.cost_level_up_skills [varsCL.current_upgrade_three_spell [varsCL.current_flyer]]) {
			varsCL.current_upgrade_three_spell [varsCL.current_flyer]++;
			varsCL.money -= varsCL.cost_level_up_skills [varsCL.current_upgrade_three_spell [varsCL.current_flyer]];
		}
	}
}

