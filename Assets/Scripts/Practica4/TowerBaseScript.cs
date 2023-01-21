using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseScript : MonoBehaviour
{
    public GameObject cannon;
    GameObject myCannon;

    void Awake()
    {
        myCannon = Instantiate(cannon, transform.position, transform.rotation );
        myCannon.SetActive(false);
    }

    void OnMouseDown()
    {
        myCannon.SetActive(true);
    }
}
