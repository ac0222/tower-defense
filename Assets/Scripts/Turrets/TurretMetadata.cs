using System.Collections;
using System.Collections.Generic;

public class TurretMetadata
{
    public string TurretName {get; set;}
    public float TurretCost {get; set;}
    public string TurretPrefabName {get; set;}
    public string TurretDescription {get; set;}
    public string TurretCursorTextureName {get; set;}
    public string TurretButtonImageName {get; set;}

    public TurretMetadata CreateCopy()
    {
         TurretMetadata tmdCopy = new TurretMetadata {
            TurretName = TurretName,
            TurretCost = TurretCost,
            TurretDescription = TurretDescription,
            TurretPrefabName = TurretPrefabName,
            TurretCursorTextureName = TurretCursorTextureName,
            TurretButtonImageName = TurretButtonImageName
        };
        return tmdCopy;
    }

    public static List<TurretMetadata> turretMetadataList = new List<TurretMetadata> {
        new TurretMetadata {
            TurretName = "Shinobi Lookout",
            TurretCost = 50,
            TurretPrefabName = "Prefabs/Turrets/ShinobiLookout",
            TurretDescription = "Genin chucking kunais",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/shinobi_lookout"
        },
        new TurretMetadata {
            TurretName = "Upgraded Shinobi Lookout",
            TurretCost = 200,
            TurretPrefabName = "Prefabs/Turrets/UpgradedShinobiLookout",
            TurretDescription = "One genin chucking kunas, one chunin chucking fireballs",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/upgraded_shinobi_lookout"
        },
        new TurretMetadata {
            TurretName = "Eva01",
            TurretCost = 150,
            TurretPrefabName = "Prefabs/Turrets/EvaOne",
            TurretDescription = "Shinji's robot",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/eva01"
        },
        new TurretMetadata {
            TurretName = "Berserk Eva01",
            TurretCost = 200,
            TurretPrefabName = "Prefabs/Turrets/UpgradedEvaOne",
            TurretDescription = "Shinji's robot, in berserk mode",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/berserk_eva01"
        },
        new TurretMetadata {
            TurretName = "Byakuya",
            TurretCost = 150,
            TurretPrefabName = "Prefabs/Turrets/Byakuya",
            TurretDescription = "5th Squad Captain Kuchiki Byakuya",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/byakuya"
        },
        new TurretMetadata {
            TurretName = "Bankai Byakuya",
            TurretCost = 250,
            TurretPrefabName = "Prefabs/Turrets/UpgradedByakuya",
            TurretDescription = "ban-KAI!",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/byakuya_bankai"
        }
    };
}
