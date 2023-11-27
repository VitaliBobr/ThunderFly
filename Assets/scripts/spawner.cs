using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
	[SerializeField]private GameObject entity;
	[SerializeField]private int interval_max;
	private float interval;
	private GameObject temp_object;

	void Start(){
		interval = interval_max;
	}
	void Update () {
		if (interval > 0) {
			interval-=Time.deltaTime;
		} else {
			temp_object=Instantiate (entity,transform.position,entity.transform.rotation);
			temp_object.name = entity.name;
			interval = interval_max;
		}
	}
}
