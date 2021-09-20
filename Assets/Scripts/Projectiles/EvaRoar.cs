using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EvaRoar : MonoBehaviour
{
    private List<GameObject> effects;

    private CircleCollider2D aoe;

    void Awake()
    {
        aoe = gameObject.GetComponent<CircleCollider2D>();
        InitEffects();
    }

    void InitEffects()
    {
        effects = new List<GameObject>();
        // add slow effect
        GameObject slowPrefab = Resources.Load("Prefabs/Effects/SlowEffect") as GameObject;
        slowPrefab.GetComponent<SlowEffect>().SlowDuration = 1;
        slowPrefab.GetComponent<SlowEffect>().SlowPercentage = 0.5f;
        effects.Add(slowPrefab);   
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

        // apply roar effect
        foreach(GameObject minion in minionsInAoe)
        {
            MinionController mcInAoe = minion.GetComponent<MinionController>();
            if (mcInAoe != null)
            {
                ApplyEffectsToMinion(mcInAoe);
            }
        }
        Destroy(gameObject);
    }

    void ApplyEffectsToMinion(MinionController mc)
    {
        foreach(GameObject effect in effects)
        {
            GameObject effectOnMinion = Instantiate(effect, mc.transform.position, Quaternion.identity);
            effectOnMinion.transform.SetParent(mc.gameObject.transform);
            IEffect ec = effectOnMinion.GetComponent<IEffect>();
            ec.TargetMinion = mc;
            ec.CopyEffect(effect.GetComponent<IEffect>());
            ec.Invoke();
        }
    }
}
