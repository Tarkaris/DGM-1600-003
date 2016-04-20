using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour
{

    public float aliveTime;

	// Used to tell a called thing to dissappear, time alive is set in unity
	void Awake ()
    {
        Destroy(gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
