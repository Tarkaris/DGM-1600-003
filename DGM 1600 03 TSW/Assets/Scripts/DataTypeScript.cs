using UnityEngine;
using System.Collections;

public class DataTypeScript : MonoBehaviour 
{
	
	void Start () 
	{
		// Value type variable
		Vector3 pos = transform.position;
		pos = new Vector3(0, 2, 0);

		//Reference type variable
		Transform tran = transform;
		transform.position = new Vector3(0, 2, 0);
	}
}	