using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBarrier : MonoBehaviour
{
    public float windForce = 100;
    public float windRotation = 100;
    public float rotationSpeed = 20;
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        AbstractProjectile projectile = collider.gameObject.GetComponent<AbstractProjectile>();
        if (projectile != null && projectile.IsDeflectable) 
        {
            Repel(projectile.gameObject);
        }
    }

    void Repel(GameObject objectToRepel)
    {
        Vector2 awayFromCenter = (objectToRepel.transform.position - this.transform.position).normalized;
        Rigidbody2D rigidBody = objectToRepel.GetComponent<Rigidbody2D>();
        objectToRepel.GetComponent<Rigidbody2D>().AddForce(awayFromCenter * windForce);
        objectToRepel.GetComponent<Rigidbody2D>().AddTorque(windRotation);
    }
}
