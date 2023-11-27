using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class vars:MonoBehaviour {
	public Vector2Int last_chest = new Vector2Int ();
	public List<chest> chests_opred= new List <chest>();
	public int alert_in_technolog;
	public string[] maps;
	public int cristal;
	public GameObject display_number_chest;
	public bool[] isBuy;
	public string[] description_flyers;
	public string[] maps_text;
	public short[]chestisclosed;
	public int[] cost_flyer;
	public int[] maps_cost;
	public int[] maps_buy_cost;
	public bool[] map_is_buy;
	public Sprite []maps_image;
	public int current_maps;
	public int[] cost_level_up={150,310,630,1250,3000,7000,18000,40000,100000};
	public int[] cost_level_up_skills = { 3000, 9000, 81000, 200000 };
	public short[]max_lvl_speed;
	public short[]max_lvl_degree;
	public short[]max_lvl_fuel;
	public short []max_lvl_seat;
	public short []select_lvl_speed;
	public short[]select_lvl_degree;
	public short[] flyer_parts_1;
	public short[] flyer_parts_2;
	public short[] flyer_parts_3;
	public short[] flyer_parts_4;
	public short[]select_lvl_fuel;
	public short[]select_lvl_seat;
	public short[]start_fuel;
	public float[] fuel;
	public float[] fuel_max;
	public Sprite []view;
	public float[] kpd_bonus_speed;
	public float []kpd_bonus_degree;
	public float[] kpd_bonus_fuel;
	public float[] cost_fix;
	public int current_flyer;
	public int max_buy_flyer;
	public float money=0;
	public float []hp_flyer;
	//Skills
	public int[] colvo_skills;
	//1
	public int[] number_upgrade_one_skill;
	public int[] max_upgrade_one_spell;
	public Sprite[] icon_one_spell;
	public string[] name_one_spell;
	public int[] current_upgrade_one_spell;
	//2
	public int[] number_upgrade_two_skill;
	public int[] max_upgrade_two_spell;
	public Sprite[] icon_two_spell;
	public string[] name_two_spell;
	public int[] current_upgrade_two_spell;
	//3
	public int[] number_upgrade_three_skill;
	public int[] max_upgrade_three_spell;
	public Sprite[] icon_three_spell;
	public string[] name_three_spell;
	public int[] current_upgrade_three_spell;

	public PolygonCollider2D[] poligons_flyer;
	public 
	void Start(){
		Application.targetFrameRate = 60;
		Input.simulateMouseWithTouches = true;
		DontDestroyOnLoad(gameObject);
		var controlls = GameObject.FindGameObjectsWithTag ("controll");
		for (int i = controlls.GetLength (0)-1; i > 0; i--) {
			DestroyImmediate(controlls[i]);
		}
	}
	void FixedUpdate(){
		if(Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.G))){
			money=10000000;
			cristal=100000;
			for (int i = 0; i < flyer_parts_1.GetLength (0); i++) {
				flyer_parts_1 [i] = 1;
			}
			for (int i = 0; i < flyer_parts_2.GetLength (0); i++) {
				flyer_parts_2 [i] = 1;
			}
			for (int i = 0; i < flyer_parts_3.GetLength (0); i++) {
				flyer_parts_3 [i] = 1;
			}
			for (int i = 0; i < flyer_parts_4.GetLength (0); i++) {
				flyer_parts_4 [i] = 1;
			}
		}
		if(display_number_chest!=null)display_number_chest.GetComponent<Text> ().text =chests_opred.Count.ToString();
		if (GameObject.Find ("fuels") != null) {
			GameObject.Find ("fuels").GetComponentInChildren<Text> ().text = fuel [current_flyer].ToString () + "/" + fuel_max [current_flyer].ToString ();
		}
		if(GameObject.Find ("money")!=null)GameObject.Find("money").GetComponent<Text> ().text =money.ToString();
		if(GameObject.Find ("cristal")!=null)GameObject.Find ("cristal").GetComponent<Text> ().text = cristal.ToString ();
		if (GameObject.Find ("hp") != null) {
			GameObject.Find ("hp").GetComponent<Text> ().text = "Здоровье\n" + hp_flyer [current_flyer].ToString () + "/100";
		}if (hp_flyer[current_flyer]<0) {
			hp_flyer[current_flyer] = 0;
		}if (fuel[current_flyer]<0) {
			fuel[current_flyer] = 0;
		}
	}
	public void add_chest(int what_flyer,int what_part){
		chests_opred.Add(new chest(what_flyer,what_part));
	}
	public void open_chest(){
		switch (chests_opred [0].choose_part) {
		case 1:
			flyer_parts_1 [chests_opred [0].choose_case]++;
			break;
		case 2:
			flyer_parts_2 [chests_opred [0].choose_case]++;
			break;
		case 3:
			flyer_parts_3 [chests_opred [0].choose_case]++;
			break;
		case 4:
			flyer_parts_4 [chests_opred [0].choose_case]++;
			break;
		}
		print ("opened"+chests_opred[0].choose_case.ToString()+"\npart "+ chests_opred[0].choose_part.ToString());
		last_chest = new Vector2Int (chests_opred [0].choose_case, chests_opred [0].choose_part);
		chests_opred.RemoveAt (0);
	}
	public void check_chest(){
		print (chests_opred.Count);
	}
	public void add_chest (string rand){
		switch(rand){
		case "rBronze":
			if (cristal>=80){
				cristal-=80;
				int i=Random.Range (1, 8);
				int j = Random.Range (1, 5);
				last_chest = new Vector2Int (i, j);
				chests_opred.Add (new chest (i, j));
			}
		break;
		case "rSilver":break;
		case "rGold":break;
		case "rPlatina":break;
		}
	}
	public bool think_time(ref float time){
		if (time > 0) {
			time -= Time.fixedDeltaTime;
			return false;
		} else if(time<=0){
			return true;
		}
		return false;
	}
}