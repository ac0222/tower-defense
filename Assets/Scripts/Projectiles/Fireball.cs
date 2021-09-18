using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float bulletDamage = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 30)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        MinionController mc = collider.gameObject.GetComponent<MinionController>();
        if (mc != null) 
        {
            mc.ChangeHealth(-1 * bulletDamage);
        }
    }
}
