using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ConstructionPanelController : MonoBehaviour
{
    public static ConstructionPanelController Instance {get; private set;}
    // error display
    float errorMessageTimer = 0;
    float timeToShowErrorMessage = 3.0f;
    public Text errorMessage;

    // build mode
    private string turretName;
    private GameObject turretPrefab;
    private Texture2D buildModeCursorTexture;
    private int numberInInventory;
    private bool isInBuildMode;
    public GameObject construcTurretButtonPrefab;

    // button grid
    GameObject buttonGrid;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        buttonGrid = gameObject.GetComponentInChildren<GridLayoutGroup>().gameObject;
        FillButtonGrid();
    }

    // Update is called once per frame
    void Update()
    {
        ListenForConstructTurretClick();
        UpdateErrorMessage();
    }

    public void FillButtonGrid()
    {
        ClearButtonGrid();
        foreach(TurretMetadata tmd in TurretMetadata.turretMetadataList)
        {
            int numTurrets = PlayerController.Instance.PlayerInventory.NumberOfTurrets(tmd.TurretName);
            if (numTurrets > 0)
            {
                GameObject buttonObject = Instantiate(construcTurretButtonPrefab, Vector3.zero, Quaternion.identity);
                
                TurretMetadata tmdCopy = tmd.CreateCopy();

                Button myButton = buttonObject.GetComponent<Button>();
                myButton.onClick.AddListener(() => {
                    SetTurrentBuildModeData(tmdCopy);
                    TryEnterBuildMode();
                });
                
                Text buttonText = buttonObject.GetComponentInChildren<Text>();
                buttonText.text = $"{numTurrets}";

                Image buttonImage = buttonObject.GetComponentsInChildren<Image>()
                    .Where(img => img.gameObject.GetInstanceID() != buttonObject.GetInstanceID())
                    .First();
                buttonImage.sprite = Resources.Load<Sprite>(tmdCopy.TurretButtonImageName);
                
                buttonObject.transform.SetParent(buttonGrid.transform);
                buttonObject.transform.localScale = Vector3.one;
            }
           
        }
    }

    void ClearButtonGrid()
    {
        foreach(Transform t in buttonGrid.transform)
        {
            Destroy(t.gameObject);
        }
    }

    void ListenForConstructTurretClick()
    {
        if (isInBuildMode && Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = 0;
            if (numberInInventory > 0)
            {
                BuildTurretAtPosition(worldPosition);
                PlayerController.Instance.PlayerInventory.AddTurret(turretName, -1);
                FillButtonGrid();
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
        turretName = turretMetadata.TurretName;
        numberInInventory = PlayerController.Instance.PlayerInventory.NumberOfTurrets(turretName);
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
        return numberInInventory > 0 && (PlayerController.Instance.NumberOfAvailableBuilders() > 0);
    }

    void ExitBuildMode()
    {
        isInBuildMode = false;
        Cursor.SetCursor(null, Vector2.one, CursorMode.Auto);
    }

    void BuildTurretAtPosition(Vector3 position)
    {
        GameObject newTurret = Instantiate(turretPrefab, position, Quaternion.identity);
        GameController.Instance.turrets.Add(newTurret);
    }
}
