using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="new flyer",menuName="Flyer Data",order=51)]
public class flyers : ScriptableObject {
	[SerializeField]
	private short max_lvl_speed;
	[SerializeField]
	private short max_lvl_degree;
	[SerializeField]
	private short max_lvl_fuel;
	[SerializeField]
	private short max_lvl_seat;
	[SerializeField]
	private short select_lvl_speed;
	[SerializeField]
	private short select_lvl_degree;
	[SerializeField]
	private short select_lvl_fuel;
	[SerializeField]
	private short select_lvl_seat;
	[SerializeField]
	private short max_unlocklvl_speed;
	[SerializeField]
	private short max_unlocklvl_degree;
	[SerializeField]
	private short max_unlocklvl_fuel;
	[SerializeField]
	private short max_unlocklvl_seat;
	[SerializeField]
	private Sprite view;
	[SerializeField]
	private float kpd_bonus_speed;
	[SerializeField]
	private float kpd_bonus_degree;
	[SerializeField]
	private float kpd_bonus_fuel;
	[SerializeField]
	private float cost_fix;
}
