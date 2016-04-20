using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

    public float fireballSpeed;

    Rigidbody2D myRB;

	// Used when the object comes to life. Speed os set to be adjustable in unity. Impulse is for launched, sudden movement.
	void Awake ()
    {
        myRB = GetComponent<Rigidbody2D>();
        if(transform.localRotation. z>0)
            myRB.AddForce(new Vector2(-1, 0)*fireballSpeed, ForceMode2D.Impulse);
        else
            myRB.AddForce(new Vector2(1, 0) * fireballSpeed, ForceMode2D.Impulse);

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
