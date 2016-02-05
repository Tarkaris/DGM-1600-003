using UnityEngine;
using System.Collections;

public class ForLoop : MonoBehaviour 
{

	int numItems = 4;

	void Start () 
	{
		for(int i = 0; i < numItems; i++)
		{
			Debug.Log ("Creating item number: " + i);
		}
	}
}
