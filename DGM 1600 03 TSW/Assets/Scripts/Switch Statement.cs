using UnityEngine;
using System.Collections;

public class SwitchStatement : MonoBehaviour
{
		public int intelligence = 5;


	void Greet () 
	{
		switch (intelligence)
		{
			case 5:
				print ("Greetings good fellow! Are you looking for a quest?"); 
				break;
			case 4:
				print ("Hello and good day!");
				break;
			case 3:
				print ("Hiya!");
				break;
			case 2:
				print ("Grunk say hi!");
				break;
			case 1:
				print ("Ugg.");
				break;
			default:
				print ("ERROR, Intelligence not detected");
				break;
		}
	
	}
}
