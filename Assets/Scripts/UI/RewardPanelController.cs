using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;

public class RewardPanelController : MonoBehaviour
{
    public GameObject rewardButtonPrefab;
    public Button closeButton;
    public GameObject buttonGrid;
    public int numRewards = 2;

    public static RewardPanelController Instance {get; private set;}
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        closeButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

    public void GenerateAndShowRewards()
    {
        ClearButtonGrid();
        // get 3 random turrets
        List<TurretMetadata> rewards = TurretMetadata.turretMetadataList
            .OrderBy(x => Random.value)
            .Take(numRewards)
            .ToList();
        foreach(TurretMetadata tmd in rewards)
        {
            GameObject buttonObject = Instantiate(rewardButtonPrefab, Vector3.zero, Quaternion.identity);
            
            TurretMetadata tmdCopy = tmd.CreateCopy();

            Button myButton = buttonObject.GetComponent<Button>();
            myButton.onClick.AddListener(() => {
                ClaimReward(tmdCopy);
                ConstructionPanelController.Instance.FillButtonGrid();
                gameObject.SetActive(false);
            });
            
            Text buttonText = buttonObject.GetComponentInChildren<Text>();
            buttonText.text = $"{tmd.TurretName}";

            Image buttonImage = buttonObject.GetComponentsInChildren<Image>()
                .Where(img => img.gameObject.GetInstanceID() != buttonObject.GetInstanceID())
                .First();
            buttonImage.sprite = Resources.Load<Sprite>(tmdCopy.TurretButtonImageName);
            
            buttonObject.transform.SetParent(buttonGrid.transform);
            buttonObject.transform.localScale = Vector3.one;
        }
    }

    void ClaimReward(TurretMetadata tmd)
    {
        PlayerController.Instance.PlayerInventory.AddTurret(tmd.TurretName, 1);
    }

    void ClearButtonGrid()
    {
        foreach(Transform t in buttonGrid.transform)
        {
            Destroy(t.gameObject);
        }
    }
}
