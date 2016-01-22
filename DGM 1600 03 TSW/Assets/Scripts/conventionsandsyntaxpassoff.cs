using UnityEngine;
using System.Collections;

public class conventionsandsyntaxpassoff : MonoBehaviour
{
	void Start ()
	{
//		This is a single line comment.
		
//		This is a multiple line comment or block 
//		of code that needs to be commented out.
	
	}

	void Update()
	{

		Debug.Log (transform.position.y);

		if (transform.position.y <= 10f) 
		{
			Debug.Log ("I'm going to splatter!");
		}
	}
}