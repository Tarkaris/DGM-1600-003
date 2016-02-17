using UnityEngine;
using System.Collections;

public class Array : MonoBehaviour 
{
	public GameObject[] weapons;

	void Start () 
	{
		weapons = GameObject.FindGameObjectsWithTag("Weapon");

		for(int i = 0; i < weapons.Length; i++)
		{
			Debug.Log("Weapon Number "+i+" is named "+weapons[i].name);
		}
	}
}