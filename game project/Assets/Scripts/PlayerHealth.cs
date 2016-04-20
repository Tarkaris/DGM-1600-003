using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float fullHealth;
    public GameObject deathfx;
    public AudioClip PlayerHurt;

    float currentHealth;

    DragomanControllerScript controlMovement;

    AudioSource playerAS;

    //HUD variables
    public Slider healthSlider;
    public Image damageScreen;

    bool damaged = false;
    Color damagedColor = new Color(0f, 0f, 0f, 0.5f);
    float smoothColor = 5f;

	// Use this for initialization
	void Start ()
    {
        currentHealth = fullHealth;

        controlMovement = GetComponent<DragomanControllerScript>();

        //HUD Initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        //Sound initialization
        playerAS = GetComponent<AudioSource>();

	}

    // Update is called once per frame. Damage is taken into account, player is warned, and script rests until damage occurs again.
    void Update()
    {

        if (damaged)
        {
            damageScreen.color = damagedColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
        }
        damaged = false;
    }

    public void addDamage(float damage)
    {
        if(damage <= 0) return;
        currentHealth -= damage;

        //Sound on injury code
        playerAS.clip = PlayerHurt;
        playerAS.Play();
        


        healthSlider.value = currentHealth;
        damaged = true;
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void makeDead()
    {
        Instantiate(deathfx, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
