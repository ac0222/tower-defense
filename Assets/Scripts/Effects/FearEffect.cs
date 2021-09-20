using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearEffect : MonoBehaviour, IEffect
{
    public MinionController TargetMinion {get; set;}
    public Vector3 FearPoint {get; set;}
    public float FearDuration {get; set;}
    private bool invoked = false;
    private float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (invoked)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Invoke()
    {
        if (TargetMinion != null) 
        {
            TargetMinion.FearPoint = FearPoint;
            timeRemaining = FearDuration;
            invoked = true;
        }
    }

    public void CopyEffect(IEffect otherEffect)
    {
        FearEffect castedEffect = (FearEffect) otherEffect;
        FearDuration = castedEffect.FearDuration;
        FearPoint = castedEffect.FearPoint;
    }

    void OnDestroy()
    {
        TargetMinion.FearPoint = null;
    }


}
