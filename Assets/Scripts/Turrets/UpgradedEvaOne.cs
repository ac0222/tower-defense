using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradedEvaOne : EvaOne
{
    public GameObject roarPrefab;
    public float roarCooldown = 10;
    private float timeUntilNextRoar;

    protected override void Start()
    {
        base.Start();
        timeUntilNextRoar = 0;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        timeUntilNextRoar -= Time.deltaTime;
        if (Status == Constants.ACTIVE && timeUntilNextRoar < 0)
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
