using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;

public class TurretInfoPanelController : MonoBehaviour
{
    public Button closeButton;
    public Button upgradeButton;
    public Text turretNameText;
    public Text errorMessage;
    public Text turretDescriptionText;
    public Image turretImage;
    private float timeToShowErrorMessage = 1.0f;

    private GameObject selectedTurret;
    private TurretMetadata selectedMetadata;
    private float errorMessageTimer = 0;

    public static TurretInfoPanelController Instance {get; private set;}
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        upgradeButton.onClick.AddListener(() => UpgradeTurret());
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

    void Update()
    {
        UpdateErrorMessage();
    }

    void UpdateErrorMessage()
    {
        if (errorMessage.enabled)
        {
            errorMessageTimer -= Time.deltaTime;
        }
        if (errorMessageTimer <= 0)
        {
            errorMessage.enabled = false;
        }
    }

    void UpgradeTurret()
    {
        if (PlayerController.Instance.Money >= selectedMetadata.UpgradeCost)
        {
            GameObject upgradedPrefab = Resources.Load<GameObject>(selectedMetadata.UpgradePrefabName);
            GameObject newTurret = Instantiate(upgradedPrefab, selectedTurret.transform.position, Quaternion.identity);
            string newTurretName = newTurret.GetComponent<TurretUIController>().turretName;
            TurretMetadata newMetadata = TurretMetadata.turretMetadataList
                .Where(tmd => tmd.TurretName == newTurretName)
                .FirstOrDefault();
            Destroy(selectedTurret);
            PlayerController.Instance.ChangeMoney(-1 * selectedMetadata.UpgradeCost);
            FillInfo(newTurret, newMetadata);
        }
        else
        {
            errorMessage.enabled = true;
            errorMessageTimer = timeToShowErrorMessage;
        }
    }
}
