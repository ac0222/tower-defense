using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ConstructionPanelController : MonoBehaviour
{
    // error display
    float errorMessageTimer = 0;
    float timeToShowErrorMessage = 3.0f;
    public Text errorMessage;

    // build mode
    private GameObject turretPrefab;
    private Texture2D buildModeCursorTexture;
    private float buildCost;
    private bool isInBuildMode;
    public GameObject construcTurretButtonPrefab;

    // button grid
    GameObject buttonGrid;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonGrid = gameObject.GetComponentInChildren<GridLayoutGroup>().gameObject;
        FillButtonGrid();
    }

    // Update is called once per frame
    void Update()
    {
        ListenForConstructTurretClick();
        UpdateErrorMessage();
    }

    void FillButtonGrid()
    {
        foreach(TurretMetadata tmd in TurretMetadata.turretMetadataList)
        {
             GameObject buttonObject = Instantiate(construcTurretButtonPrefab, Vector3.zero, Quaternion.identity);
            
            TurretMetadata tmdCopy = tmd.CreateCopy();

            Button myButton = buttonObject.GetComponent<Button>();
            myButton.onClick.AddListener(() => {
                SetTurrentBuildModeData(tmdCopy);
                TryEnterBuildMode();
            });
            
            Text buttonText = buttonObject.GetComponentInChildren<Text>();
            buttonText.text = $"${tmdCopy.TurretCost}";

            Image buttonImage = buttonObject.GetComponentsInChildren<Image>()
                .Where(img => img.gameObject.GetInstanceID() != buttonObject.GetInstanceID())
                .First();
            buttonImage.sprite = Resources.Load<Sprite>(tmdCopy.TurretButtonImageName);
            
            buttonObject.transform.SetParent(buttonGrid.transform);
            buttonObject.transform.localScale = Vector3.one;
        }
    }

    void ListenForConstructTurretClick()
    {
        if (isInBuildMode && Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            if (PlayerController.Money >= buildCost)
            {
                BuildTurretAtPosition(worldPosition);
                PlayerController.ChangeMoney(-1 * buildCost);
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

    void SetTurrentBuildModeData(TurretMetadata turretMetadata)
    {
        buildCost = turretMetadata.TurretCost;
        turretPrefab = Resources.Load<GameObject>(turretMetadata.TurretPrefabName);
        buildModeCursorTexture = turretPrefab.GetComponent<SpriteRenderer>().sprite.texture;
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
        return PlayerController.Money >= buildCost;
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
