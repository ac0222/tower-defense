using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildCountdownPanel : MonoBehaviour
{
    private BasicTurret turretController;
    private Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        turretController = GetComponentInParent<BasicTurret>();
        countdownText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (turretController.TimeUntilBuilt > 0)
        {
            countdownText.text = $"{(int)turretController.TimeUntilBuilt}";
        }
        else if (turretController.TimeUntilTornDown > 0)
        {
            countdownText.text = $"{(int)turretController.TimeUntilTornDown}";
        }
        else
        {
            countdownText.text = "";
        }
    }


}
