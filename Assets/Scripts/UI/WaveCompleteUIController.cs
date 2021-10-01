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
        Wave waveInfo = gameObject.GetComponent<MinionSpawner>().waveInfo;
        GameController.Instance.WaveCompleteActions(waveInfo);
    }
}
