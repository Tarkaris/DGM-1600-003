using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour
    {

    public float restartTime;
    bool restartNow = false;
    float resetTime;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(restartNow && resetTime <= Time.time)
        {
            //Application
        }
	}
}
