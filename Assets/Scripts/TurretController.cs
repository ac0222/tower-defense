using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    CircleCollider2D rangeCollider;
    Queue<GameObject> targetsInRange;
    // Start is called before the first frame update
    void Start()
    {
        rangeCollider = GetComponent<CircleCollider2D>();
        targetsInRange = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        targetsInRange.Enqueue(col.gameObject);
    }
}
