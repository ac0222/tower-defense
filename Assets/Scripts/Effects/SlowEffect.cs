using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffect : MonoBehaviour, IEffect
{
    public MinionController TargetMinion {get; set;}
    public float SlowPercentage {get; set;}
    public float SlowDuration {get; set;}
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
            TargetMinion.speed *= (1 - SlowPercentage);
            timeRemaining = SlowDuration;
            invoked = true;
        }
    }

    public void CopyEffect(IEffect otherEffect)
    {
        SlowEffect castedEffect = (SlowEffect) otherEffect;
        SlowDuration = castedEffect.SlowDuration;
        SlowPercentage = castedEffect.SlowPercentage;
    }

    void OnDestroy()
    {
        TargetMinion.speed = TargetMinion.initialSpeed;
    }


}
