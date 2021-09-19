using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EvaThree : ProjectileTurret
{
    public int clipSize = 50;
    public float roundsPerSecond = 5;
    private int roundsLeftInClip;
    
    void Start()
    {
        timeUntilNextShot = 0;
        rangeCollider = GetComponent<CircleCollider2D>();
        targetsInRange = new Queue<GameObject>();
        roundsLeftInClip = clipSize;
    }

    void FixedUpdate()
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

    void Reload()
    {
        timeUntilNextShot = reloadTime;
        roundsLeftInClip = clipSize;
    }
    
}
