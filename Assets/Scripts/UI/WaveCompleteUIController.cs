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
        RewardPanelController rpcInstance = RewardPanelController.Instance;
        if (rpcInstance != null)
        {
            RewardPanelController.Instance.gameObject.SetActive(true);
            RewardPanelController.Instance.GenerateAndShowRewards();
        }
    }
}
