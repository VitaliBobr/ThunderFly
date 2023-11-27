using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garp_line : MonoBehaviour {
	public	float times=10;
	public float times2=5;
	private GameObject player;
	void Update(){
		player = GameObject.Find ("player");
		if (times > 0) {
			times -= Time.deltaTime;
		} else if (times < 0) {
			times = 0;
		} else if (times == 0) {
			Destroy (GetComponent<ConstantForce2D> ());
			GetComponent<Rigidbody2D> ().MovePosition(new Vector2 (Mathf.Lerp (player.transform.position.x, transform.position.x, times2 / 5), Mathf.Lerp (player.transform.position.y, transform.position.y, times2 / 5)));
			//transform.position = new Vector2 (Mathf.Lerp (player.transform.position.x, transform.position.x, times2 / 5), Mathf.Lerp (player.transform.position.y, transform.position.y, times2 / 5));
			if(times2 > 0 ){times2 -= Time.deltaTime;}
			else{Destroy (gameObject);}
		}
			//GetComponent<ConstantForce2D> ().force=new Vector2 (GetComponent<ConstantForce2D> ().force.x > 0 ? GetComponent<ConstantForce2D> ().force.x*-1 : GetComponent<ConstantForce2D> ().force.x , GetComponent<ConstantForce2D> ().force.y);
		GetComponentInChildren<LineRenderer> ().SetPosition (1, transform.position);
		GetComponentInChildren<LineRenderer> ().SetPosition (0, GameObject.Find("player").transform.position);
	}
	void OnTriggerEnter2D(Collider2D col){
		print ("Kyky");
		if (col.tag == "coin")col.gameObject.AddComponent<FixedJoint2D> ().connectedBody=gameObject.GetComponent<Rigidbody2D>();
	}
}
