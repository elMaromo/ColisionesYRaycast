using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithEpilogue : MonoBehaviour
{
    public float minTime, maxTime;
    private float nextTime, timer;
    public GameObject soldier;

    void Start()
    {
        resetTimer();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > nextTime)
        {
            SpanwNewSoldier();
            resetTimer();
        }
    }

    void SpanwNewSoldier()
    {
        GameObject newSoldier = Instantiate(soldier, transform.position, transform.rotation);
        newSoldier.transform.Rotate(Vector3.up, 360 * Random.value);
    }

    void resetTimer()
    {
        nextTime = minTime + (maxTime - minTime) * Random.value;
        timer = 0;
    }
}
