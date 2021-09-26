using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ProjectileTurret : BasicTurret
{
    // projectile prefabs
    public GameObject projectilePrefab;

    // prefab settings
    public float reloadTime = 0.5f;
    public float throwingForce = 1000;
    public int clipSize = 1;
    public float roundsPerSecond = 1;
    protected int roundsLeftInClip;

    // instance variables
    protected CircleCollider2D rangeCollider;
    protected Queue<GameObject> targetsInRange;
    protected float timeUntilNextShot;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        timeUntilNextShot = 0;
        roundsLeftInClip = clipSize;
        rangeCollider = GetComponent<CircleCollider2D>();
        targetsInRange = new Queue<GameObject>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        timeUntilNextShot -= Time.deltaTime;
        if (IsBuilt && timeUntilNextShot < 0 && roundsLeftInClip > 0)
        {
            GameObject target = AcquireTarget();
            if (target == null) {
                return;
            }
            // shoot
            ShootAtTarget(target, projectilePrefab, throwingForce);
            // prepare next shot
            timeUntilNextShot = 1.0f / roundsPerSecond;
            roundsLeftInClip--;
        }
        if (roundsLeftInClip <= 0)
        {
            Reload();
        }
    }

    protected GameObject AcquireTarget()
    {
        List<GameObject> minionsInRange = Physics2D.OverlapCircleAll(
            rangeCollider.transform.position, 
            rangeCollider.radius, 
            LayerMask.GetMask("Minion"))
            .Select(cl => cl.gameObject)
            // some minions can become untargetable by going 'invis'
            .Where(g => g.GetComponent<MinionController>().IsTargetable)
            .ToList();
        
        if (minionsInRange.Count == 0)
        {
            return null;
        }
         // target will be the minion that has the least distance to travel to the exit
        GameObject target = minionsInRange
            .Aggregate((minItem, nextItem) => 
                minItem.GetComponent<MinionController>().DistanceToExit() < nextItem.GetComponent<MinionController>().DistanceToExit() 
                ? minItem : nextItem);
        return target;
    }

    protected void ShootAtTarget(GameObject target, GameObject projectilePrefab, float throwingForce)
    {
        Vector2 directionOfTarget = (target.transform.position - this.transform.position).normalized;
        // rotate towards target
        float angle = Mathf.Atan2(directionOfTarget.y , directionOfTarget.x) * Mathf.Rad2Deg + 90;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // shoot at target
        GameObject projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        projectile.GetComponent<Rigidbody2D>().AddForce(directionOfTarget * throwingForce);
    }

    protected void Reload()
    {
        timeUntilNextShot = reloadTime;
        roundsLeftInClip = clipSize;
    }
}
