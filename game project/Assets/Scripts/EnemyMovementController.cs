using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour
{
    public float enemySpeed;

    Animator BarbarianAnimator;

    //facing. Bool canFlip lets a player play matador with the bull :D Fliptime is when the enemy flips around and looks. Flipchance is opportunities to flip
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    //Attacking. Chargetime is time it takes to aggro the enemy once in aggro range.
    public float chargeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D EnemyRB;

	// Use this for initialization
	void Start ()
    {
        BarbarianAnimator = GetComponent<Animator>();
        EnemyRB = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame. Chance to flip every 5 seconds
    void Update()
    {
        if (Time.time > nextFlipChance)
        {
        if (Random.Range(0, 10) >= 5) flipFacing();
        nextFlipChance = Time.time + flipTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }

        }
        else if (!facingRight && other.transform.position.x > transform.position.x)
        {

            flipFacing();
        }
        canFlip = false;
        charging = true;
        startChargeTime = Time.time + chargeTime;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (startChargeTime <= Time.time)
            {
                if (!facingRight) EnemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
                else EnemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
                BarbarianAnimator.SetBool("isCharging", charging);
            }
           
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canFlip = true;
            charging = false;
            EnemyRB.velocity = new Vector2(0f, 0f);
            BarbarianAnimator.SetBool("isCharging", charging);
        }
    }

    void flipFacing()
    {
        if (!canFlip) return;
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;
    }
}
