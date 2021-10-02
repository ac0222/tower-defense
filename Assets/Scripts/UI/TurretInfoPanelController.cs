using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;

public class TurretInfoPanelController : MonoBehaviour
{
    public Button closeButton;
    public Button tearDownButton;
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
        tearDownButton.onClick.AddListener(() => TearDownTurret());
    }

    public void FillInfo(GameObject turret, TurretMetadata turretMetadata)
    {
        selectedTurret = turret;
        selectedMetadata = turretMetadata;
        turretNameText.text = turretMetadata.TurretName;
        turretDescriptionText.text = turretMetadata.TurretDescription;
        tearDownButton.GetComponentInChildren<Text>().text = $"Tear Down";
        turretImage.sprite = Resources.Load<Sprite>(turretMetadata.TurretButtonImageName);
    }

    void Update()
    {
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

    void TearDownTurret()
    {
        BasicTurret turretController = selectedTurret.GetComponent<BasicTurret>();
        if (turretController.Status != Constants.ACTIVE || PlayerController.Instance.NumberOfAvailableBuilders() <= 0)
        {
            Debug.Log("turret busy or not enough builders, can't start tear down");
        }
        else
        {
            turretController.TearDown();
            gameObject.SetActive(false);
        }
    }
}
