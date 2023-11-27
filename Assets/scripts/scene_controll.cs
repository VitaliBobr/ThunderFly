using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_controll : MonoBehaviour {
	static public void scene_load(string name){
		SceneManager.LoadScene (name);
	}
	static public void scene_load(int number){
		SceneManager.LoadScene (number);
	}
	static public void scene_restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
	static public void scene_next(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}
	static public void scene_back(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex-1);
	}
	static public void scene_menu(){
		SceneManager.LoadScene (0);
	}
}
