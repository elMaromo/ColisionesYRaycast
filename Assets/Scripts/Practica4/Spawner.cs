using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject orc;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if ( timer > timeToSpawn )
        {
            timer = 0;
            Instantiate( orc, transform.position, transform.rotation );
        }
    }
}
