using UnityEngine;
using System.Collections;

public class DragomanControllerScript : MonoBehaviour 
{
    //movement stuff
	public float maxSpeed = 1.5f;

    //jumping stuff
    bool grounded = false;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float jumpForce = 150f; //force could be called Height
    public AudioClip PlayerJump;

    AudioSource playerAS;

    Rigidbody2D myRB;
    Animator anim;
    bool facingRight;


    //To shoot stuff, item 3 below is fire rate or how often the player can fire, 4th is the fire delay

    public Transform dragonMouth;
    public GameObject fireball;
    float fireRate = 1.2f;
    float nextFire = 0f;

	// Use this for initialization
	void Start () 
	{
        myRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        facingRight = true;

        //Sound initialization
        playerAS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            //Sound on injury code
            playerAS.clip = PlayerJump;
            playerAS.Play();


        }

        //Player shooting code
        //if(Input.GetKeyDown(KeyCode.Space))
        if (Input.GetAxisRaw("Fire1") > 0) fireFlame();
    }

    // Update is called once per frame see around
    void FixedUpdate () 
	{
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        } else if (move < 0 && facingRight)
        {
            flip();
        }


        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
       anim.SetBool("Ground", grounded);

        anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

	}

  
	void flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
  
    } 

    //shootin code
    void fireFlame()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Rigidbody2D fireballInstance;
                fireballInstance = Instantiate(fireball, dragonMouth.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            }
            // Else if code is basically the same as if code here. z axis is just rotated 180.
            else if (!facingRight)
            {
                Rigidbody2D fireballInstance;
                fireballInstance = Instantiate(fireball, dragonMouth.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
            }
        }
    }
}
