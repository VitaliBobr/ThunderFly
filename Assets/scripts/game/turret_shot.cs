using UnityEngine;
using System.Collections;

public class turret_shot : MonoBehaviour {
	public Transform target;
	public GameObject laser;
	public float maxTimeShot;
	private float timeShot;
	public float rotationSpeed = 1F;
	public float deadZone = 0.1F;
	private float rotateDirection = 0;
	void shot(){
		Instantiate (laser, transform.position, transform.rotation);
	}
	void Start(){
		target = GameObject.FindWithTag ("Player").transform;
		timeShot = 0;
	}
	void LateUpdate () {
		if (timeShot > 0) {
			timeShot -= Time.deltaTime;
		}
		if(transform.InverseTransformPoint(target.position).x > deadZone/2)rotateDirection = -1F;
		else if (transform.InverseTransformPoint(target.position).x < -deadZone/2)rotateDirection = 1F;
		else {
			if (transform.InverseTransformPoint (target.position).y < 0)
				rotateDirection = 1F;
			else {
				rotateDirection = 0;
				if (timeShot <= 0) {
					shot ();
					timeShot = maxTimeShot;
				}
			}
		}

		transform.rotation *= Quaternion.Euler(0,0,rotationSpeed * rotateDirection);
	}
}
