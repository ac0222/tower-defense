using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BasicTurret : MonoBehaviour
{
    public float TimeUntilBuilt {get; protected set;}
    public string Status {get; protected set;} = string.Empty;
    public string TurretName;
    TurretMetadata turretMetadata;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        turretMetadata = TurretMetadata.turretMetadataList
            .FirstOrDefault(tmd => tmd.TurretName == TurretName);
        TimeUntilBuilt = turretMetadata == null ? 50 : turretMetadata.BuildTime;
        Status = Constants.BEING_BUILT;
    }

    protected virtual void FixedUpdate()
    {
        if (Status == Constants.BEING_BUILT)
        {
            TimeUntilBuilt -= Time.deltaTime;
        }
        if (TimeUntilBuilt <= 0)
        {
            Status = Constants.ACTIVE;
        }
    }

    void OnDestroy()
    {
        GameController.Instance.turrets.Remove(gameObject);
    }
}
