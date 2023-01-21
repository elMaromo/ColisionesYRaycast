using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public float timeToShoot;
    public Transform bulletStart;
    public GameObject bullet;

    public int numBullets;
    float timer;
    int currentBullet;

    private List<GameObject> bullets;

    void Start()
    {
        currentBullet = 0;
        bullets = new List<GameObject>();
        for(int i = 0; i<numBullets; i++ )
        {
            GameObject newBullet = Instantiate( bullet, bulletStart.position, bulletStart.rotation );
            newBullet.SetActive(false);
            bullets.Add(newBullet);
        }

        timer = timeToShoot;
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        timer += Time.deltaTime;
        if( Input.GetMouseButton(0) && timer > timeToShoot)
        {
            if(currentBullet > bullets.Count - 1)
            {
                currentBullet = 0;
            }
            
            timer = 0;
            bullets[currentBullet].SetActive(true);
            bullets[currentBullet].transform.position = bulletStart.position;
            bullets[currentBullet].transform.rotation = bulletStart.rotation;

            currentBullet++;
        }
    }
}
