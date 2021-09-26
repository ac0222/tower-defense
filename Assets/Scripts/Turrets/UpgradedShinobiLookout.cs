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

    protected override void Start()
    {
        base.Start();
    }
    
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        timeUntilNextFireball -= Time.deltaTime;
        if (IsBuilt && timeUntilNextFireball < 0)
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
