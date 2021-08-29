using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionPanelController : MonoBehaviour
{
    float errorMessageTimer = 0;
    float timeToShowErrorMessage = 3.0f;
    public Text errorMessage;
    public Sprite buildModeCursor;
    public Button buildTurretButton;
    public GameObject turretPrefab;
    bool isInBuildMode;
    // Start is called before the first frame update
    void Start()
    {
        isInBuildMode = false;
        buildTurretButton.onClick.AddListener(() => TryEnterBuildMode());
        buildTurretButton.GetComponentInChildren<Text>().text = $"Build Turret\n Cost = {TurretController.cost}";
    }

    // Update is called once per frame
    void Update()
    {
        ListenForConstructTurretClick();
        UpdateErrorMessage();
    }

    void ListenForConstructTurretClick()
    {
        if (isInBuildMode && Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            if (PlayerController.Money >= TurretController.cost)
            {
                BuildTurretAtPosition(worldPosition);
                PlayerController.ChangeMoney(-1 * TurretController.cost);
                ExitBuildMode();
            }
        }
    }

    void UpdateErrorMessage()
    {
        if (CanEnterBuildMode())
        {
            errorMessage.enabled = false;
        }
        if (errorMessage.enabled)
        {
            errorMessageTimer -= Time.deltaTime;
        }
        if (errorMessageTimer < 0)
        {
            errorMessage.enabled = false;
        }
    }

    void TryEnterBuildMode()
    {
        if (CanEnterBuildMode())
        {
            errorMessage.enabled = false;
            isInBuildMode = true;
            Cursor.SetCursor(buildModeCursor.texture, Vector2.one*0.5f, CursorMode.Auto);
        }
        else
        {
            errorMessage.enabled = true;
            errorMessageTimer = timeToShowErrorMessage;
        }

    }

    bool CanEnterBuildMode()
    {
        return PlayerController.Money >= TurretController.cost;
    }

    void ExitBuildMode()
    {
        isInBuildMode = false;
        Cursor.SetCursor(null, Vector2.one, CursorMode.Auto);
    }

    void BuildTurretAtPosition(Vector3 position)
    {
        Instantiate(turretPrefab, position, Quaternion.identity);
    }
}
