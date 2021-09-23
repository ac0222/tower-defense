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

    public static TurretInfoPanelController Instance {get; private set;}
    void Awake()
    {
        gameObject.SetActive(false);
        closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        Instance = this;
    }
}
