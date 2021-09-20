using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{   
    public MinionController TargetMinion {get; set;}
    
    public void Invoke();

    public void CopyEffect(IEffect otherEffect);
}
