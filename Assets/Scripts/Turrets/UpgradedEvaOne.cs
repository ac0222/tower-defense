using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradedEvaOne : EvaOne
{
    public GameObject roarPrefab;
    public float roarCooldown = 10;
    private float timeUntilNextRoar;

    void Start()
    {
        timeUntilNextRoar = 0;
        timeUntilNextShot = 0;
        rangeCollider = GetComponent<CircleCollider2D>();
        targetsInRange = new Queue<GameObject>();
        roundsLeftInClip = clipSize;
    }

    void Update()
    {
        timeUntilNextShot -= Time.deltaTime;
        timeUntilNextRoar -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (timeUntilNextShot < 0 && roundsLeftInClip > 0)
        {
            GameObject target = AcquireTarget();
            if (target != null) {
                // shoot
                ShootAtTarget(target, projectilePrefab, throwingForce); 
                timeUntilNextShot = 1.0f / roundsPerSecond;
                roundsLeftInClip--;            
            }
        }

        if (roundsLeftInClip <= 0)
        {
            Reload();
        }

        if (timeUntilNextRoar < 0)
        {
            GameObject target = AcquireTarget();
            if (target != null)
            {
                Roar();
                timeUntilNextRoar = roarCooldown;
            }
        }
    }

    void Roar()
    {
        Instantiate(roarPrefab, this.transform.position, Quaternion.identity);
    }
    
}
