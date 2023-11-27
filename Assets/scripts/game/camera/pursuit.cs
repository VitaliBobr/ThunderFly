using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pursuit : MonoBehaviour {
	public Transform target;
	void Update () {
		transform.SetPositionAndRotation(new Vector3(target.transform.position.x,transform.position.y,-1),Quaternion.Euler(new Vector3(0,0,0))); 
		}
}
