using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class writer : MonoBehaviour {
	public GameObject []objs;
	vars varsCL;
	void Start (){
		varsCL = GameObject.Find ("controll").GetComponent<vars>();
		}
	void Update () {
		for(int i=0;i < objs.GetLength(0) ;i++){
			switch (i) {
			case 0:
				if(objs[i]!=null)
				objs [i].GetComponent<Text> ().text="Скорость\nЦена:"+varsCL.cost_level_up[varsCL.select_lvl_speed[varsCL.current_flyer]+1].ToString()+
					"\n"+varsCL.select_lvl_speed[varsCL.current_flyer]+"/"+varsCL.max_lvl_speed[varsCL.current_flyer];
				break;
			case 1:
				if(objs[i]!=null)
					objs [i].GetComponent<Text> ().text ="Угол\nЦена:"+varsCL.cost_level_up [varsCL.select_lvl_degree [varsCL.current_flyer]+1].ToString()+
					"\n"+varsCL.select_lvl_degree[varsCL.current_flyer]+"/"+varsCL.max_lvl_degree[varsCL.current_flyer];
			break;
			case 2:
				if(objs[i]!=null)
				objs [i].GetComponent<Text> ().text="Пассажиры\nЦена:"+varsCL.cost_level_up[varsCL.select_lvl_seat[varsCL.current_flyer]+1].ToString()+
					"\n"+varsCL.select_lvl_seat[varsCL.current_flyer]+"/"+varsCL.max_lvl_seat[varsCL.current_flyer];
			break;
			case 3:
				if(objs[i]!=null)
				objs [i].GetComponent<Text> ().text ="Строится по чертежам!!!";
			break;
			case 4:
				if(objs[i]!=null)
				objs [i].GetComponent<Text> ().text = "Бак\nЦена:" + varsCL.cost_level_up [varsCL.select_lvl_fuel [varsCL.current_flyer] + 1].ToString () +
				"\n" + varsCL.select_lvl_fuel [varsCL.current_flyer] +"/" + varsCL.max_lvl_fuel [varsCL.current_flyer];
			break;
			case 5:
				if(objs[i]!=null)
				objs [i].GetComponent<Text> ().text = "$:" + Mathf.Round (varsCL.GetComponent<vars> ().cost_fix [varsCL.GetComponent<vars> ().current_flyer] - varsCL.GetComponent<vars> ().cost_fix [varsCL.GetComponent<vars> ().current_flyer] * varsCL.GetComponent<vars> ().hp_flyer [varsCL.GetComponent<vars> ().current_flyer] * 0.01f).ToString ();
			break;
			case 6:
				if(objs[i]!=null)
				objs [i].GetComponent<Text> ().text = "$:"+Mathf.Ceil(70*(varsCL.fuel_max[varsCL.current_flyer]-varsCL.fuel[varsCL.current_flyer])).ToString();
			break;
			}
		}
	}
}