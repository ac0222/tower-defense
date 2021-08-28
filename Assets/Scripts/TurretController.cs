using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    CircleCollider2D rangeCollider;
    Queue<GameObject> targetsInRange;
    public GameObject ammoPrefab;
    public float reloadTime = 0.2f;
    float timeUntilNexShot;
    // Start is called before the first frame update
    void Start()
    {
        timeUntilNexShot = 0;
        rangeCollider = GetComponent<CircleCollider2D>();
        targetsInRange = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNexShot -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        List<GameObject> minionsInRange = Physics2D.OverlapCircleAll(
            rangeCollider.transform.position, 
            rangeCollider.radius, 
            LayerMask.GetMask("Minion"))
            .Select(cl => cl.gameObject)
            .ToList();
        if (timeUntilNexShot < 0 && minionsInRange.Count > 0)
        {
            // acquire target - it will be the minion that has the least distance to travel to the exit
            GameObject target = minionsInRange
                .Aggregate((minItem, nextItem) => 
                    minItem.GetComponent<MinionController>().DistanceToExit() < nextItem.GetComponent<MinionController>().DistanceToExit() 
                    ? minItem : nextItem);
            Debug.Log(target.name);


            // shoot at target
            Vector2 directionOfTarget = (target.transform.position - this.transform.position).normalized;
            GameObject bullet = Instantiate(ammoPrefab, this.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().AddForce(directionOfTarget * 500);

            // reload
            timeUntilNexShot = reloadTime; 
        }

    }
}
