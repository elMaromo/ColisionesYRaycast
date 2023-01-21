using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwSoldiersOnClick : MonoBehaviour
{
    public int numberOfSoldiers;
    public GameObject soldier;
    public float minDistance;
    public float maxDistance;

    void OnMouseDown()
    {
        for(int i = 0; i<numberOfSoldiers; i++ )
        {
            GameObject newSoldier = Instantiate(soldier, NextPosSoldier(), transform.rotation);
            newSoldier.transform.LookAt(transform);
            newSoldier.transform.Rotate(Vector3.up, 180);
        }
    }

    Vector3 NextPosSoldier()
    {
        Vector3 newPos = new Vector3();
        newPos.x = Random.value - Random.value;
        newPos.z = Random.value - Random.value;
        newPos.Normalize();

        Vector3 minPart = newPos * minDistance;
        Vector3 randomPart = newPos * ((maxDistance - minDistance) * Random.value );

        newPos = minPart + randomPart;
        newPos = transform.position + newPos;
        
        return newPos;
    }
}
