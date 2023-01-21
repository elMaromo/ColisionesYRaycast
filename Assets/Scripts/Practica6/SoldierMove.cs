using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMove : MonoBehaviour
{
    public float speed, minTimeRotate, maxTimeRotate;
    private float timerRotate, nextTimeRotate;

    void Start()
    {
        resetTimerRotate();
    }

    void Update()
    {
        rotateSoldier();
        move();
    }

    void move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void rotateSoldier()
    {
        timerRotate += Time.deltaTime;
        if (timerRotate > nextTimeRotate)
        {
            transform.Rotate(Vector3.up, 360*Random.value);
            resetTimerRotate();
        }
    }

    void resetTimerRotate()
    {
        nextTimeRotate = minTimeRotate + (maxTimeRotate - minTimeRotate) * Random.value;
        timerRotate = 0;
    }
}
