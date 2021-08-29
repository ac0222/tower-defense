using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionPanelController : MonoBehaviour
{
    public Button buildTurretButton;
    public GameObject turretPrefab;
    bool isInBuildMode;
    // Start is called before the first frame update
    void Start()
    {
        isInBuildMode = false;
        buildTurretButton.onClick.AddListener(() => BuildButtonClicked());
    }

    // Update is called once per frame
    void Update()
    {
        if (isInBuildMode && Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            if (PlayerController.Money >= TurretController.cost)
            {
                BuildTurretAtPosition(worldPosition);
                PlayerController.ChangeMoney(-1 * TurretController.cost);
                isInBuildMode = false;
            }
        }
    }

    void BuildButtonClicked()
    {
        isInBuildMode = true;
    }

    void BuildTurretAtPosition(Vector3 position)
    {
        Instantiate(turretPrefab, position, Quaternion.identity);
    }
}
