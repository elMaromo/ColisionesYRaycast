using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed, lifeSpawn;

    void Update()
    {
        transform.Translate( Vector3.forward * speed * Time.deltaTime );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        CancelInvoke(nameof(Deactivate));
        Invoke(nameof(Deactivate), lifeSpawn);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
