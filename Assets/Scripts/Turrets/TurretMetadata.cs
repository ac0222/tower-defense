using System.Collections;
using System.Collections.Generic;

public class TurretMetadata
{
    public int BuildCost {get; set;}
    public string TurretName {get; set;}
    public float BuildTime {get; set;}
    public float TearDownTime {get; set;}
    public float UpgradeCost {get; set;}
    public string TurretPrefabName {get; set;}
    public string UpgradePrefabName {get; set;}
    public string TurretDescription {get; set;}
    public string TurretCursorTextureName {get; set;}
    public string TurretButtonImageName {get; set;}
    public bool IsBuildable {get; set;}
    public bool IsUpgradeable {get; set;}

    public TurretMetadata CreateCopy()
    {
         TurretMetadata tmdCopy = new TurretMetadata {
            BuildCost = BuildCost,
            TurretName = TurretName,
            BuildTime = BuildTime,
            TearDownTime = TearDownTime,
            UpgradeCost = UpgradeCost,
            TurretDescription = TurretDescription,
            TurretPrefabName = TurretPrefabName,
            UpgradePrefabName = UpgradePrefabName,
            TurretCursorTextureName = TurretCursorTextureName,
            TurretButtonImageName = TurretButtonImageName,
            IsBuildable = IsBuildable,
            IsUpgradeable = IsUpgradeable
        };
        return tmdCopy;
    }

    public static List<TurretMetadata> turretMetadataList = new List<TurretMetadata> {
        new TurretMetadata {
            TurretName = "Shinobi Lookout",
            BuildCost = 0,
            BuildTime = 0,
            TearDownTime = 0,
            UpgradeCost = 88,
            TurretPrefabName = "Prefabs/Turrets/ShinobiLookout",
            UpgradePrefabName = "Prefabs/Turrets/UpgradedShinobiLookout",
            TurretDescription = "Genin chucking kunais",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/shinobi_lookout",
            IsBuildable = true,
            IsUpgradeable = true
        },
        new TurretMetadata {
            TurretName = "Ichigo",
            BuildCost = 0,
            BuildTime = 0,
            TearDownTime = 0,
            UpgradeCost = 0,
            TurretPrefabName = "Prefabs/Turrets/Ichigo",
            TurretDescription = "Bleach MC",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/ichigo",
            IsBuildable = true,
            IsUpgradeable = true
        },
        new TurretMetadata {
            TurretName = "Renji",
            BuildCost = 0,
            BuildTime = 0,
            TearDownTime = 0,
            UpgradeCost = 0,
            TurretPrefabName = "Prefabs/Turrets/Renji",
            TurretDescription = "Bleach male supporting character",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/renji",
            IsBuildable = true,
            IsUpgradeable = true
        },
        new TurretMetadata {
            TurretName = "Rukia",
            BuildCost = 0,
            BuildTime = 0,
            TearDownTime = 0,
            UpgradeCost = 0,
            TurretPrefabName = "Prefabs/Turrets/Rukia",
            TurretDescription = "Bleach female supporting character",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/rukia",
            IsBuildable = true,
            IsUpgradeable = true
        },
        new TurretMetadata {
            TurretName = "Upgraded Shinobi Lookout",
            BuildCost = 0,
            BuildTime = 0,
            TearDownTime = 0,
            TurretPrefabName = "Prefabs/Turrets/UpgradedShinobiLookout",
            TurretDescription = "Chunin that chucks kunais and fireballs",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/upgraded_shinobi_lookout",
            IsBuildable = false,
            IsUpgradeable = false
        },
        new TurretMetadata {
            TurretName = "Eva01",
            BuildCost = 0,
            BuildTime = 0,
            TearDownTime = 0,
            UpgradeCost = 100,
            TurretPrefabName = "Prefabs/Turrets/EvaOne",
            UpgradePrefabName = "Prefabs/Turrets/UpgradedEvaOne",
            TurretDescription = "Shinji's robot",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/eva01",
            IsBuildable = true,
            IsUpgradeable = true
        },
        new TurretMetadata {
            TurretName = "Berserk Eva01",
            BuildCost = 0,
            BuildTime = 0,
            TearDownTime = 0,
            TurretPrefabName = "Prefabs/Turrets/UpgradedEvaOne",
            TurretDescription = "Angry robot",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/berserk_eva01",
            IsBuildable = false,
            IsUpgradeable = false
        },
        new TurretMetadata {
            TurretName = "Byakuya",
            BuildCost = 0,
            BuildTime = 0,
            TearDownTime = 0,
            UpgradeCost = 150,
            TurretPrefabName = "Prefabs/Turrets/Byakuya",
            UpgradePrefabName = "Prefabs/Turrets/UpgradedByakuya",
            TurretDescription = "5th Squad Captain Kuchiki Byakuya",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/byakuya",
            IsBuildable = true,
            IsUpgradeable = true
        },
        new TurretMetadata {
            TurretName = "Bankai Byakuya",
            BuildCost = 0,
            BuildTime = 0,
            TearDownTime = 0,
            TurretPrefabName = "Prefabs/Turrets/UpgradedByakuya",
            TurretDescription = "ban-KAI!",
            TurretCursorTextureName = "",
            TurretButtonImageName = "Art/Turrets/byakuya_bankai",
            IsBuildable = false,
            IsUpgradeable = false
        }
    };
}
