using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EvaOne : ProjectileTurret
{
    public int clipSize = 50;
    public float roundsPerSecond = 5;
    protected int roundsLeftInClip;
    
    protected override void Start()
    {
        base.Start();
        roundsLeftInClip = clipSize;
    }

    protected override void FixedUpdate()
    {
        
        if (timeUntilNextShot < 0 && roundsLeftInClip > 0)
        {
            GameObject target = AcquireTarget();
            if (target == null) {
                return;
            }
            // shoot
            ShootAtTarget(target, projectilePrefab, throwingForce); 
            timeUntilNextShot = 1.0f / roundsPerSecond;
            roundsLeftInClip--;
        }
        if (roundsLeftInClip <= 0)
        {
            Reload();
        }
    }

    protected void Reload()
    {
        timeUntilNextShot = reloadTime;
        roundsLeftInClip = clipSize;
    }
    
}
