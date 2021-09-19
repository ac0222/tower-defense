using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradedShinobiLookout : ProjectileTurret
{
    public GameObject fireballPrefab;

    public float fireballReloadTime;

    public float fireballThrowingForce;

    private float timeUntilNextFireball = 0;


    void Update()
    {
        timeUntilNextShot -= Time.deltaTime;
        timeUntilNextFireball -= Time.deltaTime;
    }
    
    void FixedUpdate()
    {
        if (timeUntilNextShot < 0)
        {
            GameObject target = AcquireTarget();
            if (target == null) {
                return;
            }
            // shoot
            ShootAtTarget(target, projectilePrefab, throwingForce);
            // reload
            timeUntilNextShot = reloadTime; 
        }

        if (timeUntilNextFireball < 0)
        {
            GameObject target = AcquireTarget();
            if (target == null) {
                return;
            }
            // shoot
            ShootAtTarget(target, fireballPrefab, fireballThrowingForce);
            // reload
            timeUntilNextFireball = fireballReloadTime; 
        }
    }
}
