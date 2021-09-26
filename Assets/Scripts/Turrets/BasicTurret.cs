using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BasicTurret : MonoBehaviour
{
    public float TimeUntilBuilt {get; protected set;}
    public bool IsBuilt {get; protected set;} = false;
    public string TurretName;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        TurretMetadata tmd = TurretMetadata.turretMetadataList
            .FirstOrDefault(tmd => tmd.TurretName == TurretName);
        TimeUntilBuilt = tmd == null ? 50 : tmd.BuildTime;
    }

    protected virtual void FixedUpdate()
    {
        if (!IsBuilt)
        {
            TimeUntilBuilt -= Time.deltaTime;
        }
        if (TimeUntilBuilt <= 0)
        {
            IsBuilt = true;
        }
    }
}
