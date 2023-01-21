using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask layerLaberint, layerBlackSmith, layerRocks;
    public float speed;
    public float rayDistance;

    bool rocks, obstacle, goal;

    void start()
    {
        obstacle = false;
        goal = false;
        rocks = false;
    }

    void Update()
    {
        scan();
        Move();
    }

    void Move()
    {
        if (obstacle)
        {
            transform.Rotate(Vector3.up, 90);
        }

        if (!goal)
        {
            if (rocks)
            {
                transform.Translate(Vector3.forward * speed / 2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }

    void scan()
    {
        obstacle = false;
        goal = false;
        rocks = false;

        Ray rayFordward = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        Ray rayUp = new Ray(transform.position, transform.TransformDirection(Vector3.up));

        if (Physics.Raycast(rayFordward, out hit, rayDistance, layerLaberint))
        {
            obstacle = true;
        }

        if (Physics.Raycast(rayFordward, out hit, rayDistance, layerBlackSmith))
        {
            goal = true;
        }

        if (Physics.Raycast(rayUp, out hit, rayDistance, layerRocks))
        {
            rocks = true;
        }
    }
}
