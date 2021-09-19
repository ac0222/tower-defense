using System.Collections;
using System.Collections.Generic;

public class TurretMetadata
{
    public string TurretName {get; set;}
    public float TurretCost {get; set;}
    public string TurretPrefabName {get; set;}
    public string TurretDescription {get; set;}
    public string TurretCursorTextureName {get; set;}

    public TurretMetadata CreateCopy()
    {
         TurretMetadata tmdCopy = new TurretMetadata {
            TurretName = TurretName,
            TurretCost = TurretCost,
            TurretDescription = TurretDescription,
            TurretPrefabName = TurretPrefabName,
            TurretCursorTextureName = TurretCursorTextureName
        };
        return tmdCopy;
    }

    public static List<TurretMetadata> turretMetadataList = new List<TurretMetadata> {
        new TurretMetadata {
            TurretName = "Default Turret",
            TurretCost = 100,
            TurretPrefabName = "Prefabs/Turret",
            TurretDescription = "This is the default scrub turret",
            TurretCursorTextureName = "",
        },
        new TurretMetadata {
            TurretName = "Shinobi Lookout",
            TurretCost = 50,
            TurretPrefabName = "Prefabs/ShinobiLookout",
            TurretDescription = "Genin chucking kunais",
            TurretCursorTextureName = ""
        },
        new TurretMetadata {
            TurretName = "Upgraded Shinobi Lookout",
            TurretCost = 200,
            TurretPrefabName = "Prefabs/UpgradedShinobiLookout",
            TurretDescription = "One genin chucking kunas, one chunin chucking fireballs",
            TurretCursorTextureName = ""
        },
    };
}
