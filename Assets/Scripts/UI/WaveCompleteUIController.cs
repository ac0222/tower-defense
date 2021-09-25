using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;

public class WaveCompleteUIController : MonoBehaviour
{
    void OnDestroy()
    {
        RewardPanelController.Instance.gameObject.SetActive(true);
    }
}
