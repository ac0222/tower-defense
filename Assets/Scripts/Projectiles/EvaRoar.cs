using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EvaRoar : MonoBehaviour
{
    private CircleCollider2D aoe;

    void Awake()
    {
        aoe = gameObject.GetComponent<CircleCollider2D>();
    }

    void Start()
    {
        Roar();
    }
    
    void Roar()
    {
        Debug.Log("roaring!!");
        Collider2D[] collidersInAoe = Physics2D.OverlapCircleAll(
            this.transform.position, 
            aoe.radius, 
            LayerMask.GetMask("Minion"));
        
        List<GameObject> minionsInAoe = collidersInAoe == null 
            ? new List<GameObject>() 
            : collidersInAoe.Select(cl => cl.gameObject).ToList();
        
        if (minionsInAoe == null)
        {
            return;
        }
        Debug.Log(minionsInAoe.Count);

        // apply roar effect
        foreach(GameObject minion in minionsInAoe)
        {
            MinionController mcInAoe = minion.GetComponent<MinionController>();
            if (mcInAoe != null)
            {
                mcInAoe.speed = 1;
            }
        }
        Destroy(gameObject);
    }
}
