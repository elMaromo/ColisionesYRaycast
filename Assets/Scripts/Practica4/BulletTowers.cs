using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTowers : MonoBehaviour
{
    public float speed, lifeSpawn, damage;

    void Start()
    {
        Destroy(gameObject, lifeSpawn );
    }

    void Update()
    {
        transform.Translate( Vector3.forward * speed * Time.deltaTime );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<OrcTowerScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
