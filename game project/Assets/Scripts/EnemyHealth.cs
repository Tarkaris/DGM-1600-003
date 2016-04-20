using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
    {

    public float enemyMaxHealth;

    public GameObject enemyDeathFX;

    float currentHealth;

	// Use this for initialization
	void Start ()
    {
        currentHealth = enemyMaxHealth;
       
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void addDamage(float damage) // -= is "minus equals" or the amount of health left after an attack hits while <= is less or equal to
    {
        currentHealth -= damage;

        if (currentHealth <= 0) makeDead();
    }

    void makeDead() //death animations would go in here if there were any. Damage is handled in the "FireballHit" script
    {
        Destroy(gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
    }
}
