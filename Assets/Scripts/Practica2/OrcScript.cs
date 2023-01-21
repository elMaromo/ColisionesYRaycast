using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcScript : MonoBehaviour
{
    float speed;
    bool walking = false;


    void Update()
    {
        if (walking)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }

    public void init( float newSpeed )
    {
        
        walking = true;
        speed = newSpeed;
    }
}
