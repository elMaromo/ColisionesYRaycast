using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrckSpawner : MonoBehaviour
{
    public Transform playerPos;
    public GameObject orc;
    public float distanceToPlayer, timeToCreate;
    public int numOrcs;
    public float speedOrc;

    private float timer;
    private int currentOrc;
    private List<GameObject> orcs;
    private List<OrcScript> orcsInit;

    void Start()
    {
        currentOrc = 0;
        orcs = new List<GameObject>();
        orcsInit = new List<OrcScript>();
        for (int i = 0; i < numOrcs; i++)
        {
            GameObject newOrc = Instantiate(orc, NextPosOrc(), transform.rotation);
            orcsInit.Add(newOrc.GetComponent<OrcScript>());
            newOrc.SetActive(false);
            orcs.Add(newOrc);
        }

        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToCreate && playerPos != null)
        {
            timer = 0;
            CreateOrc();
        }
    }

    void CreateOrc()
    {
        if (currentOrc > orcs.Count - 1)
        {
            currentOrc = 0;
        }

        timer = 0;
        orcs[currentOrc].SetActive(true);
        orcsInit[currentOrc].init( speedOrc );
        orcs[currentOrc].transform.position = NextPosOrc();
        orcs[currentOrc].transform.LookAt(playerPos.position);

        currentOrc++;
    }

    Vector3 NextPosOrc()
    {
        Vector3 newPos = new Vector3();
        newPos.x = Random.value - Random.value;
        newPos.z = Random.value - Random.value;
        newPos.Normalize();
        newPos = playerPos.position + (newPos * distanceToPlayer);

        return newPos;
    }
}
