using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBuild : MonoBehaviour
{

    public float minTimeBuild, maxTimeBuild, creationRadious;
    private float timerBuild, nextTimeBuild;
    public GameObject blackSmtih;

    void Start()
    {
        resetTimerBuild();
    }

    // Update is called once per frame
    void Update()
    {
        build();
    }

    void build()
    {
        timerBuild += Time.deltaTime;
        if (timerBuild > nextTimeBuild)
        {
            if (SpanwNewBlacSmith())
            {
                Destroy(gameObject);
            }
            resetTimerBuild();
        }
    }
    
    void resetTimerBuild()
    {
        nextTimeBuild = minTimeBuild + (maxTimeBuild - minTimeBuild) * Random.value;
        timerBuild = 0;
    }

    bool SpanwNewBlacSmith()
    {
        bool blackSmtihCreated = CanCreateBlackSmith();

        if (blackSmtihCreated)
        {
            Instantiate(blackSmtih, transform.position, transform.rotation);
        }

        return blackSmtihCreated;
    }

    bool CanCreateBlackSmith()
    {
        bool canCreate = true;
        int numSoldiers = 0;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, creationRadious);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "Soldier")
            {
                numSoldiers++;
            }

            if (hitColliders[i].gameObject.tag == "Blacksmith")
            {
                canCreate = false;
            }
        }

        if (numSoldiers > 1)
        {
            canCreate = false;
        }

        return canCreate;
    }
}
