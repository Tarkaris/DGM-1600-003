using UnityEngine;
using System.Collections;

public class Ifstatements : MonoBehaviour 
{
	float hotcocoTemperature = 85.0f;
	float hotLimitTemperature = 70.0f;
	float coldlimitTemperature = 40.0f;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
			TemperatureTest ();
		
		hotcocoTemperature -= Time.deltaTime * 5f;
	}

	void TemperatureTest()
	{
		if (hotcocoTemperature > hotLimitTemperature) 
		
		{
			print ("Coco is too hot.");
		} 

		else if (hotcocoTemperature < coldlimitTemperature) 
		
		{
			print ("Coco is too cold.");
		} 

		else 
		
		{
			print ("Coco is just right.");
		}
	}
}
