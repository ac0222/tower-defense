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
            TurretPrefabName = "Prefabs/Turrets/Turret",
            TurretDescription = "This is the default scrub turret",
            TurretCursorTextureName = "",
        },
        new TurretMetadata {
            TurretName = "Shinobi Lookout",
            TurretCost = 50,
            TurretPrefabName = "Prefabs/Turrets/ShinobiLookout",
            TurretDescription = "Genin chucking kunais",
            TurretCursorTextureName = ""
        },
        new TurretMetadata {
            TurretName = "Upgraded Shinobi Lookout",
            TurretCost = 200,
            TurretPrefabName = "Prefabs/Turrets/UpgradedShinobiLookout",
            TurretDescription = "One genin chucking kunas, one chunin chucking fireballs",
            TurretCursorTextureName = ""
        },
        new TurretMetadata {
            TurretName = "Eva01",
            TurretCost = 150,
            TurretPrefabName = "Prefabs/Turrets/EvaOne",
            TurretDescription = "Shinji's robot",
            TurretCursorTextureName = ""
        },
        new TurretMetadata {
            TurretName = "Berserk Eva01",
            TurretCost = 200,
            TurretPrefabName = "Prefabs/Turrets/UpgradedEvaOne",
            TurretDescription = "Shinji's robot, in berserk mode",
            TurretCursorTextureName = ""
        },
        new TurretMetadata {
            TurretName = "Byakuya",
            TurretCost = 150,
            TurretPrefabName = "Prefabs/Turrets/Byakuya",
            TurretDescription = "5th Squad Captain Kuchiki Byakuya",
            TurretCursorTextureName = ""
        },
        new TurretMetadata {
            TurretName = "Bankai Byakuya",
            TurretCost = 250,
            TurretPrefabName = "Prefabs/Turrets/UpgradedByakuya",
            TurretDescription = "ban-KAI!",
            TurretCursorTextureName = ""
        }
    };
}
