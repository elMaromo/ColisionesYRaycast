using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcFinalBattle : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate( Vector3.forward * speed * Time.deltaTime );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blacksmith")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Soldier")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Blacksmith")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Soldier")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
