using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcLichFinalBattle : MonoBehaviour
{
    public float timeToCreateOrcs, minDist, maxDist;
    public Transform posTarget;
    public GameObject orc;
    public int numOrcs;

    private List<GameObject> listOrcks = new List<GameObject>();

    void Awake()
    {
        for(int i = 0; i < numOrcs; i++ )
        {
            GameObject newOrc = Instantiate(orc, NextPosOrc(), transform.rotation );
            newOrc.transform.LookAt(posTarget);
            newOrc.SetActive(false);
            listOrcks.Add(newOrc);
        }
    }

    void Start()
    {
        Invoke("CreateOrcs", timeToCreateOrcs);
    }

    void CreateOrcs()
    {
        for(int i = 0; i < numOrcs; i++ )
        {
            listOrcks[i].SetActive(true);
        }
        Destroy(gameObject);
    }

    Vector3 NextPosOrc()
    {
        Vector3 newPos = new Vector3();
        newPos.x = Random.value - Random.value;
        newPos.z = Random.value - Random.value;
        newPos.Normalize();
        float randomicedLenght = minDist + ( maxDist - minDist ) * Random.value;
        newPos = posTarget.position + (newPos * randomicedLenght);

        return newPos;
    }
}
