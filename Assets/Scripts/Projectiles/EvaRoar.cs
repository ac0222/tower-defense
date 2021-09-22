using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EvaRoar : MonoBehaviour
{
    private List<GameObject> effects;

    private CircleCollider2D aoe;

    private float roarDuration = 1;
    private float timeRemaining;

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

        // add fear effect
        GameObject fearPrefab = Resources.Load("Prefabs/Effects/FearEffect") as GameObject;
        fearPrefab.GetComponent<FearEffect>().FearDuration = 1;
        fearPrefab.GetComponent<FearEffect>().FearPoint = gameObject.transform.position;
        effects.Add(fearPrefab);   
    }

    void Start()
    {
        Roar();
        timeRemaining = roarDuration;
    }
    
    void Update()
    {
        transform.Rotate(Vector3.forward * Random.value * 20 * Time.deltaTime);
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        MinionController mc = collider.gameObject.GetComponent<MinionController>();
        if (mc != null) 
        {
            ApplyEffectsToMinion(mc);
        }
    }
    void Roar()
    {
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
