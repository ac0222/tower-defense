using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;

public class TurretUIController : MonoBehaviour
{
    public string turretName;
    private TurretMetadata turretMetadata;
    // Start is called before the first frame update
    void Start()
    {
        turretMetadata = TurretMetadata.turretMetadataList
            .Where(tmd => tmd.TurretName == turretName)
            .FirstOrDefault();
    }

    void OnMouseDown()
    {
        TurretInfoPanelController turretInfoController = TurretInfoPanelController.Instance;
        turretInfoController.gameObject.SetActive(true);
        turretInfoController.FillInfo(gameObject, turretMetadata);
    }
}
