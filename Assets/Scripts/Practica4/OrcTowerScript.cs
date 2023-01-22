using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcTowerScript : MonoBehaviour
{
    public float health, speed;
    private float currentHealth;

    void Start()
    {
        currentHealth = health;
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Guide")
        {
            transform.rotation = other.transform.rotation;
        }

        if (other.gameObject.tag == "Blacksmith")
        {
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage( float damage )
    {
        currentHealth -= damage;

        if( currentHealth <= 0 )
        {
            currentHealth = health;
            gameObject.SetActive(false);
        }
    }
}
