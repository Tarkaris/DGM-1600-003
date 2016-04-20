using UnityEngine;
using System.Collections;

public class enemyDamage : MonoBehaviour
{
    // "damage rate" is how often you can take damage, "next damage" is when it occurs.
    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;

	// Use this for initialization.
	void Start ()
    {
        nextDamage = 0f;
	}
	
	// Update is called once per frame.
	void Update ()
    {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        // this "if" code prevents enemies from hurting each other. Push back shoves the player out of an enemy collider.
        if(other.tag=="Player" && nextDamage < Time.time)
        {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
