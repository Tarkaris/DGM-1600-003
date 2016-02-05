using UnityEngine;
using System.Collections;

public class WhileLoop : MonoBehaviour 

{
	int LevelsMade = 4;
	
	void Start () 
	{
		while(LevelsMade > 0)
		{
			Debug.Log ("Levels under construction.");
			LevelsMade--;
		}
	}
}
