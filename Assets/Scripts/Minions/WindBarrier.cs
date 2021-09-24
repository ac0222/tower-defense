using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBarrier : MonoBehaviour
{
    public float windForce = 100;
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Kunai kunai = collider.gameObject.GetComponent<Kunai>();
        if (kunai != null) 
        {
            Repel(kunai.gameObject);
        }
    }

    void Repel(GameObject objectToRepel)
    {
        Vector2 awayFromCenter = (objectToRepel.transform.position - this.transform.position).normalized;
        objectToRepel.GetComponent<Rigidbody2D>().AddForce(awayFromCenter * windForce);
    }
}
