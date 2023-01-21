using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeOrcs : MonoBehaviour
{
    public float minDistance, maxdistance;
    public GameObject orc;
    public int numOrcsPool;
    int currentOrcs;
    List<GameObject> poolOrcs;
    float maxRandomDistance;
    bool canInvoke;

    void Start()
    {
        currentOrcs = 0;
        poolOrcs = new List<GameObject>();

        for( int i = 0; i < numOrcsPool; i++ )
        {
            GameObject newOrc = Instantiate(orc, transform.position, transform.rotation);
            newOrc.SetActive(false);
            poolOrcs.Add(newOrc);
        }

        maxRandomDistance = maxdistance - minDistance;
        canInvoke = false;
    }

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) && canInvoke == true && currentOrcs < numOrcsPool )
        {
            invokeOrck();
        }
    }

    void invokeOrck()
    {
        Debug.Log(currentOrcs);
        Debug.Log(poolOrcs.Count);

        float distanceOrc = minDistance + maxRandomDistance * Random.value;
        Vector3 posOrc = transform.position + (distanceOrc * transform.forward);
        posOrc.y = 0;
        poolOrcs[currentOrcs].SetActive(true);
        poolOrcs[currentOrcs].transform.position = posOrc;
        poolOrcs[currentOrcs].transform.LookAt(gameObject.transform);
        currentOrcs++;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Summon Area")
        {
            canInvoke = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Summon Area")
        {
            canInvoke = false;
        }
    }

}
