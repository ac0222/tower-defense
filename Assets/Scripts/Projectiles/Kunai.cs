using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : AbstractProjectile
{
    public override bool IsDeflectable {get; set;} = true;
    public float damage = 2.0f;
    private List<GameObject> effects;

    void Awake()
    {
       InitEffects();
    }

    void InitEffects()
    {
        effects = new List<GameObject>();
        // add basic damage effect
        GameObject instantDamagePrefab = Resources.Load("Prefabs/Effects/InstantDamageEffect") as GameObject;
        instantDamagePrefab.GetComponent<InstantDamageEffect>().Damage = damage;
        effects.Add(instantDamagePrefab);   
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
            ApplyEffectsToMinion(mc);
            Destroy(gameObject);
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
