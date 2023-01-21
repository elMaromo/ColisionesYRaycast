using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, rotateSpeed;
    
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime );
        transform.Rotate(Vector3.up, rotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
}
