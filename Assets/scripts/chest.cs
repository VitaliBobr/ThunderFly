using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chest : ScriptableObject {
	public int choose_case;
	public int choose_part;
	public chest(int a, int b){
		choose_case = a;
		choose_part = b;
	}
}
