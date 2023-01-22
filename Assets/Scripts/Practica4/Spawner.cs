using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeToSpawn;
    public int numOrcs;
    public GameObject orc;
    
    private float timerOrc = 0;
    private int currentOrc;
    private List<GameObject> orcs;
    
    void Start()
    {
        currentOrc = 0;
        orcs = new List<GameObject>();
        for (int i = 0; i < numOrcs; i++)
        {
            GameObject newOrc = Instantiate(orc, transform.position, transform.rotation);
            newOrc.SetActive(false);
            orcs.Add(newOrc);
        }

        timerOrc = 0;
    }
    
    void Update()
    {
        timerOrc += Time.deltaTime;

        if ( timerOrc > timeToSpawn )
        {
            timerOrc = 0;
            CreateOrc();
        }
    }
    
    void CreateOrc()
    {
        if (currentOrc > orcs.Count - 1)
        {
            currentOrc = 0;
        }
        
        orcs[currentOrc].SetActive(true);
        orcs[currentOrc].transform.position = transform.position;
        orcs[currentOrc].transform.rotation = transform.rotation;

        currentOrc++;
    }
}
