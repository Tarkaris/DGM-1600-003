using UnityEngine;
using System.Collections;

public class FireballHit : MonoBehaviour
{
    public float weaponDamage;

    ProjectileController myPC;

    public GameObject FireballExplosion;

    // Use this for initialization
    void Awake()
    {
        myPC = GetComponentInParent<ProjectileController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //This is what happens when the projectile collider hits another 2D collider, both explosion wise and damage wise
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(FireballExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "enemy")
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Instantiate(FireballExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "enemy")
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }

    }
    
    }

