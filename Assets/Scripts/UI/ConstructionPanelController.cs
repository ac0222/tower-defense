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
    Texture2D buildModeCursorTexture;

    void Awake()
    {
        buildModeCursorTexture = buildModeCursor.texture;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        isInBuildMode = false;
        buildTurretButton.onClick.AddListener(() => TryEnterBuildMode());
        buildTurretButton.GetComponentInChildren<Text>().text = $"Build Turret\n Cost = {TurretCosts.PROJECTILE_TURRET_COST}";
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
            if (PlayerController.Money >= TurretCosts.PROJECTILE_TURRET_COST)
            {
                BuildTurretAtPosition(worldPosition);
                PlayerController.ChangeMoney(-1 * TurretCosts.PROJECTILE_TURRET_COST);
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
            Vector2 cursorHotspot = new Vector2(buildModeCursorTexture.width / 2, buildModeCursorTexture.height / 2);
            Cursor.SetCursor(buildModeCursorTexture, cursorHotspot, CursorMode.Auto);
        }
        else
        {
            errorMessage.enabled = true;
            errorMessageTimer = timeToShowErrorMessage;
        }

    }

    bool CanEnterBuildMode()
    {
        return PlayerController.Money >= TurretCosts.PROJECTILE_TURRET_COST;
    }

    void ExitBuildMode()
    {
        isInBuildMode = false;
        Cursor.SetCursor(null, Vector2.one, CursorMode.Auto);
    }

    void BuildTurretAtPosition(Vector3 position)
    {
        GameObject newTurret = Instantiate(turretPrefab, position, Quaternion.identity);
        GameController.Instance.towers.Add(newTurret);
    }
}
