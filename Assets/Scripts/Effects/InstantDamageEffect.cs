using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDamageEffect : MonoBehaviour, IEffect
{
    public MinionController TargetMinion {get; set;}
    public float Damage {get; set;}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Invoke()
    {
        if (TargetMinion != null) 
        {
            TargetMinion.ChangeHealth(-1 * Damage);
            Destroy(gameObject);
        }
    }

    public void CopyEffect(IEffect otherEffect)
    {
        InstantDamageEffect castedEffect = (InstantDamageEffect) otherEffect;
        Damage = castedEffect.Damage;
    }


}
