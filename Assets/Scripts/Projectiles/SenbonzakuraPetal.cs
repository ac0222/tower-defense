using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenbonzakuraPetal : AbstractProjectile
{
    public override bool IsDeflectable {get; set;} = false;
    public float Alpha {get; set;} = 0;
    public float SemiMajorAxis {get; set;}
    public float SemiMinorAxis {get; set;}
    public float Tilt {get; set;}
    public float Speed {get; set;}
    public Vector3 FocalPoint {get; set;}
    public float damage = 2.0f;
    private List<GameObject> effects;
    private float rotationSpeed;

    void Awake()
    {
        rotationSpeed = (Random.value * 720) + 180;
        transform.Rotate(Vector3.forward * Random.value * 360);
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
        float x = FocalPoint.x + (SemiMajorAxis * MCos(Alpha) * MCos(Tilt)) - ( SemiMinorAxis * MSin(Alpha) * MSin(Tilt));
        float y= FocalPoint.y + (SemiMajorAxis * MCos(Alpha) * MSin(Tilt)) + ( SemiMinorAxis * MSin(Alpha) * MCos(Tilt));
        transform.position = new Vector2(x, y);
        Alpha += (Speed * Time.deltaTime);
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
    }

    float MCos(float value)
    {
        return Mathf.Cos(Mathf.Deg2Rad * value);
    }

    float MSin(float value)
    {
        return Mathf.Sin(Mathf.Deg2Rad * value);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        MinionController mc = collider.gameObject.GetComponent<MinionController>();
        if (mc != null) 
        {
            ApplyEffectsToMinion(mc);
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
