using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class flyer : MonoBehaviour {
	float speed;
	vars varsCL;
	private Vector2 startCord;
	public PolygonCollider2D coll;
	public GameObject bullet_ggn;
	public GameObject garpun;
	public GameObject portal;
	public GameObject temp_portal;
	public float time_life_portal;
	float times=0;
	float times_spell_cast=0;
	float temp_z;
	void Start(){
		varsCL = GameObject.Find ("controll").GetComponent<vars> ();
		coll = gameObject.AddComponent<PolygonCollider2D> () as PolygonCollider2D;
		coll.points = varsCL.poligons_flyer [varsCL.current_flyer].points;
		gameObject.GetComponent<SpriteRenderer> ().sprite = varsCL.view [varsCL.current_flyer];
	}
	void garp_one_skill(){
		var i = new GameObject ();
		switch (varsCL.current_upgrade_one_spell [varsCL.current_flyer]) {
		case 0:
			i = Instantiate (garpun, new Vector2 (transform.position.x + 1, transform.position.y), garpun.transform.rotation);
			i.name = "garp";
			print (i.name);
			times_spell_cast = 20;
			break;
		case 1:
			i = Instantiate (garpun, new Vector2 (transform.position.x + 1, transform.position.y + 0.5f), garpun.transform.rotation);
			i.name = "garp";

			i = Instantiate (garpun, new Vector2 (transform.position.x + 1, transform.position.y - 0.5f), garpun.transform.rotation);
			i.name = "garp";
			times_spell_cast = 20;

			break;
		case 2:

			i = Instantiate (garpun, new Vector2 (transform.position.x + 1, transform.position.y + 1), garpun.transform.rotation);
			i.name = "garp";
			i = Instantiate (garpun, new Vector2 (transform.position.x + 1, transform.position.y - 1), garpun.transform.rotation);
			i.name = "garp";

			i = Instantiate (garpun, new Vector2 (transform.position.x + 1, transform.position.y - 0), garpun.transform.rotation);
			i.name = "garp";
			times_spell_cast = 20;
			break;
		case 3:

			i = Instantiate (garpun, new Vector2 (transform.position.x + 1, transform.position.y + 2), garpun.transform.rotation);
			i.name = "garp";
			i = Instantiate (garpun, new Vector2 (transform.position.x + 1, transform.position.y + 1), garpun.transform.rotation);
			i.name = "garp";
			i = Instantiate (garpun, new Vector2 (transform.position.x + 1, transform.position.y - 1), garpun.transform.rotation);
			i.name = "garp";

			i = Instantiate (garpun, new Vector2 (transform.position.x + 1, transform.position.y - 2), garpun.transform.rotation);
			i.name = "garp";
			times_spell_cast = 20;
			break;
		}
	}
	void Create_bullet(){
		var i = Instantiate (bullet_ggn, new Vector2(transform.position.x+1,transform.position.y),bullet_ggn.transform.rotation);
		i.name=bullet_ggn.name;
	}

	void Create_bullet(float offsetY){
		var i = Instantiate (bullet_ggn, new Vector2(transform.position.x+1,transform.position.y+offsetY),bullet_ggn.transform.rotation);
		i.name=bullet_ggn.name;
	}

	void ggn_one_skill(){
		var i = new GameObject ();
			switch (varsCL.current_upgrade_one_spell [varsCL.current_flyer]) {
		case 0:
			Create_bullet (0f);
			times_spell_cast = 10;
				break;
		case 1:
			Create_bullet (0.5f);
			Invoke ("Create_bullet", 0.5f);
			times_spell_cast = 10;
				break;
		case 2:
			Create_bullet (0.5f);
			Invoke ("Create_bullet", 0.5f);
			Create_bullet (-0.5f);
			times_spell_cast = 10;
			break;
		case 3:
			Create_bullet (0.5f);		
			Create_bullet (-0.5f);
			Invoke ("Create_bullet", 0.5f);
			Invoke ("Create_bullet", 1f);
			times_spell_cast = 10;
		
				break;
			}
	}
	public void SpellCast(){
		if (times_spell_cast == 0) {
			switch (varsCL.current_flyer) {
			case 2:
				ggn_one_skill ();
				break;
			
			case 4:
				garp_one_skill ();
				break;
			case 7:
				if (temp_portal == null) {
					temp_portal = Instantiate (portal, new Vector2 (transform.position.x + 1, transform.position.y), portal.transform.rotation);	
					switch (varsCL.current_upgrade_two_spell [7]) {
					case 0:
						temp_portal.GetComponent<ConstantForce2D> ().relativeForce = new Vector2 (0.0003f, 0f);
						break;
					case 1:
						temp_portal.GetComponent<ConstantForce2D> ().relativeForce = new Vector2 (0.0005f, 0f);
						break;
					case 2:
						temp_portal.GetComponent<ConstantForce2D> ().relativeForce = new Vector2 (0.0009f, 0f);
						break;
					}

					switch (varsCL.current_upgrade_one_spell [7]) {
					case 0:
						time_life_portal = 2;
						break;
					case 1:
						time_life_portal = 3;
						break;
					case 2:
						time_life_portal = 4;
						break;
					case 3:
						time_life_portal = 5;
						break;
					}
				} else {
					transform.position = temp_portal.transform.position;
					Destroy (temp_portal);
					times_spell_cast = 15;
				}
				break;
			}
		}
	}
	void FixedUpdate(){
		if (varsCL.current_flyer==7) {
			if (varsCL.think_time (ref time_life_portal)) {
				if (temp_portal != null) {
					transform.position = temp_portal.transform.position;
					Destroy (temp_portal);
					times_spell_cast = 20;
				}
			}
		}
		if (times_spell_cast > 0) {
			GameObject.Find("button_spell").GetComponent<Image>().fillAmount=Mathf.Lerp(1,0,times_spell_cast/10);
			times_spell_cast -= Time.fixedDeltaTime;
		} else if(times_spell_cast<0){
			times_spell_cast = 0;
		}
		if (varsCL.fuel [varsCL.current_flyer] < 0)
			varsCL.fuel [varsCL.current_flyer] = 0;
		if (GameObject.Find ("hp") != null) {
			GameObject.Find ("hp").GetComponent<Text> ().text = varsCL.hp_flyer [varsCL.current_flyer].ToString();
		}
		if (varsCL.fuel [varsCL.current_flyer] > 0) {
			varsCL.fuel [varsCL.current_flyer] -= Time.deltaTime;
		}
		if (transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z <= 270) {
			transform.rotation = Quaternion.Euler(0,0, temp_z);
		}
		temp_z=transform.rotation.eulerAngles.z;
		varsCL = GameObject.Find ("controll").GetComponent<vars> ();
		speed =varsCL.kpd_bonus_speed [varsCL.current_flyer] * varsCL.select_lvl_speed [varsCL.current_flyer] ;
		if (varsCL.current_flyer != 6) {
			if (transform.rotation.eulerAngles.z >= 30 && transform.rotation.eulerAngles.z <= 90) {
				transform.Translate (new Vector2 (speed * 0.8f, 0) * Time.deltaTime);
				if (GameObject.Find ("display_speed") != null)
					GameObject.Find ("display_speed").GetComponent<Text> ().text = (speed * 180 * 1.5f).ToString ();
			} else if (transform.rotation.eulerAngles.z <= 30 && transform.rotation.eulerAngles.z >= -30) {
				transform.Translate (new Vector2 (speed, 0) * Time.deltaTime);
				if (GameObject.Find ("display_speed") != null)
					GameObject.Find ("display_speed").GetComponent<Text> ().text = (speed * 180).ToString ();
			} else if (transform.rotation.eulerAngles.z >= 275 && transform.rotation.eulerAngles.z <= 360) {
				transform.Translate (new Vector2 (speed * 2, 0) * Time.deltaTime);
				if (GameObject.Find ("display_speed") != null)
					GameObject.Find ("display_speed").GetComponent<Text> ().text = (speed * 180 * 2).ToString ();
			} else if (transform.rotation.eulerAngles.z >= 270 && transform.rotation.eulerAngles.z <= 275) {
				transform.Translate (new Vector2 (speed * 5, 0) * Time.deltaTime);
				if (GameObject.Find ("display_speed") != null)
					GameObject.Find ("display_speed").GetComponent<Text> ().text = (speed * 180 * 5).ToString ();
			}
		} else {
			transform.Translate (new Vector2 (speed, 0) * Time.deltaTime);
			if (GameObject.Find ("display_speed") != null)
				GameObject.Find ("display_speed").GetComponent<Text> ().text = (speed * 180).ToString ();
		}
		if (varsCL.fuel [varsCL.current_flyer] <= 0) {
			times +=Time.deltaTime/150;
			GetComponent<Rigidbody2D> ().gravityScale =Mathf.Lerp(0f,2f,times/2);
		} else {
			GetComponent<Rigidbody2D> ().gravityScale = 0.0001f;
		}
		if (Input.GetMouseButton (0) ) {
			transform.Rotate (0, 0, varsCL.kpd_bonus_degree [varsCL.current_flyer] * varsCL.select_lvl_degree [varsCL.current_flyer] + 1);
		} else {
			transform.Rotate (0, 0, -(varsCL.kpd_bonus_degree [varsCL.current_flyer] * varsCL.select_lvl_degree [varsCL.current_flyer] + 1));
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			scene_controll.scene_back();
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			scene_controll.scene_next();
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		switch (col.tag) {
		case "chest":
			int choose_flyer = col.GetComponent<chest_object> ().choose_case;
			int choose_part = col.GetComponent<chest_object> ().choose_part;
			varsCL.add_chest (choose_flyer, choose_part);
			varsCL.alert_in_technolog++;
			varsCL.chestisclosed [SceneManager.GetActiveScene ().buildIndex]--;
			Destroy (col.gameObject);
			break;
		case "bird":
			Destroy (col.gameObject);
			break;
		case "destroyer":
			switch (col.gameObject.name) {
			case "end_vertical_down":
				if(varsCL.current_flyer==3){
					scene_controll.scene_menu ();
				}else varsCL.hp_flyer [varsCL.current_flyer] -= col.GetComponent<destroyer> ().damage;
				break;
			case "bird":
				if (varsCL.current_flyer!=0) {
					varsCL.hp_flyer [varsCL.current_flyer] -= col.GetComponent<destroyer> ().damage;
					Destroy (col.gameObject);
				}
				break;
			}
			if (varsCL.hp_flyer [varsCL.current_flyer] < 1) {
				scene_controll.scene_menu ();
			}
		break;
		case "finish":
			varsCL.money += varsCL.maps_cost [varsCL.current_maps] * varsCL.select_lvl_seat[varsCL.current_flyer];
			scene_controll.scene_load (0);
		break;
		case "coin":
			varsCL.money += 700;
			Destroy (col.gameObject);
		break;
		case "cristal":
			varsCL.cristal += 1;
			Destroy (col.gameObject);
		break;
		case "gas":
			varsCL.fuel[varsCL.GetComponent<vars> ().current_flyer] = varsCL.fuel_max[varsCL.GetComponent<vars> ().current_flyer];
			Destroy (col.gameObject);
		break;
		case "hp":
			varsCL.hp_flyer [varsCL.GetComponent<vars> ().current_flyer] = 100;
			Destroy (col.gameObject);
		break;
		}
	}
}