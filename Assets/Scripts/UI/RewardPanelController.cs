using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;

public class RewardPanelController : MonoBehaviour
{
    public Button closeButton;

    public static RewardPanelController Instance {get; private set;}
    void Awake()
    {
        gameObject.SetActive(false);
        closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        Instance = this;
    }
}
