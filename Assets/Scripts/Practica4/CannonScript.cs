using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    List<GameObject> targets = new List<GameObject>();
    public GameObject bullet;
    public float rateOfFire;
    float timer;

    void Update()
    {
        FilterDeadths();
        timer += Time.deltaTime;

        if (targets.Count > 0)
        {
            transform.LookAt(targets[targets.Count-1].transform);

            if( timer > rateOfFire)
            {
                timer = 0;
                Instantiate(bullet, transform.position, transform.rotation);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            targets.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            targets.Remove(other.gameObject);
        }
    }

    void FilterDeadths()
    {
        for( int i = 0; i < targets.Count; i++ )
        {
            if( targets[i] == null )
            {
                targets.RemoveAt(i);
            }
        }
    }
}
