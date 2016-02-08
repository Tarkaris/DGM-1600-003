using UnityEngine;
using System.Collections;

public class scopeaccessmodifiers : MonoBehaviour 
{
	public int alpha = 5;

	private int beta = 0;
	private int gamma = 5;

	private AnotherClass myOtherClass;

	// Comments before we start
	void Start () 
	{
		alpha = 29;

		myOtherClass = new AnotherClass ();
		myOtherClass.FruitMachine (alpha, myOtherClass.apples);
	}

	void Example (int pens, int crayons)
	{
		int answer;
		answer = pens * crayons * alpha;
		Debug.Log (answer);
	}
	
	// Comments as things occur
	void Update () 
	{
		Debug.Log ("Alpha is set to: " + alpha);
	}
}
