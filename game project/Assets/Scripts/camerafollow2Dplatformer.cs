using UnityEngine;
using System.Collections;

public class camerafollow2Dplatformer : MonoBehaviour
{
    //1.What the camera follows and 2.how quickly and gently the camera follows/ dampening effect. 
    //3= offset adjusts where the player is in the game window. "lowY" is the lowest the camera goes. A lowX would work for the end of a stage I assume.

    public Transform target; 
    public float smoothing;

    Vector3 offset;

    float lowY;
	// Use this for initialization
	void Start ()
    {
        offset = transform.position - target.position;

        lowY = transform.position.y;
	}
	
	// Update is called once per frame. "Lerp" allows for smooth movement. As the camera gets closer to being where it should, it slows down. The last line prevents the camera from following a "falling to their doom" player
	void FixedUpdate ()
    {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
	}
}
