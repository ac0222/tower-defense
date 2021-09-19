using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Fireball : MonoBehaviour
{
    public float damage = 2.0f;

    private CircleCollider2D aoe;

    void Awake()
    {
        aoe = gameObject.GetComponent<CircleCollider2D>();

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
            Collider2D[] collidersInAoe = Physics2D.OverlapCircleAll(
                mc.transform.position, 
                aoe.radius, 
                LayerMask.GetMask("Minion"));
            
            List<GameObject> minionsInAoe = collidersInAoe == null 
                ? new List<GameObject>() 
                : collidersInAoe.Select(cl => cl.gameObject).ToList();
            
            if (minionsInAoe == null)
            {
                return;
            }
            // do aoe damage
            foreach(GameObject minion in minionsInAoe)
            {
                MinionController mcInAoe = minion.GetComponent<MinionController>();
                if (mcInAoe != null)
                {
                    mcInAoe.ChangeHealth(-1 * damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
