using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TurretInfoPanelController : MonoBehaviour
{
    public Button closeButton;
    public Button upgradeButton;
    public Text turretNameText;
    public Text turretDescriptionText;
    public Image turretImage;

    private GameObject selectedTurret;
    private TurretMetadata selectedMetadata;

    public static TurretInfoPanelController Instance {get; private set;}
    void Awake()
    {
        gameObject.SetActive(false);
        closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        Instance = this;
    }

    public void FillInfo(GameObject turret, TurretMetadata turretMetadata)
    {
        selectedTurret = turret;
        selectedMetadata = turretMetadata;
        turretNameText.text = turretMetadata.TurretName;
        turretDescriptionText.text = turretMetadata.TurretDescription;
        if (turretMetadata.IsUpgradeable)
        {
            upgradeButton.gameObject.SetActive(true);
            upgradeButton.GetComponentInChildren<Text>().text = $"Upgrade: ${turretMetadata.UpgradeCost}";
        }
        else
        {
            upgradeButton.gameObject.SetActive(false);
        }
        turretImage.sprite = Resources.Load<Sprite>(turretMetadata.TurretButtonImageName);
    }
}
