using DG.Tweening;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Transform canvas;

    [SerializeField]
    Transform placableCanvas;

    [SerializeField]
    Transform startPoint, endPoint;

    [SerializeField]
    Transform collectibleEndPoint;

    [SerializeField]
    GameObject seedCanvas;

    [SerializeField]
    GameObject harvestCanvas;

    [SerializeField]
    Button placableButton;

    [SerializeField]
    GameObject collectibleImagePrefab;

    [SerializeField]
    CollectibleSO collectibleData;

    public static CanvasManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        placableButton.onClick.AddListener(OnPlacableButtonClick);
    }

    private void OpenPlacableCanvas()
    {
        placableCanvas.DOMoveX(endPoint.position.x, 1f);
    }

    public void ClosePlacableCanvas()
    {
        placableCanvas.DOMoveX(startPoint.position.x, 1f).OnComplete(() => placableButton.gameObject.SetActive(true));
    }

    public void OpenSeedCanvas()
    {
        seedCanvas.SetActive(true);
    }

    public void CloseSeedCanvas()
    {
        seedCanvas.SetActive(false);
    }

    public void OpenHarvestCanvas()
    {
        harvestCanvas.SetActive(true);
    }

    public void CloseHarvestCanvas()
    {
        harvestCanvas.SetActive(false);
    }

    public void CloseAnyCanvas()
    {
        ClosePlacableCanvas();
        CloseSeedCanvas();
        CloseHarvestCanvas();
    }

    public void HandleCollectAnimation(Plant plant)
    {
        CollectibleData data = collectibleData.collectibleDataList.Where(x => x.plantType == plant.plantData.PlantType).First();
        Image collectibleImage = Instantiate(collectibleImagePrefab, canvas).GetComponent<Image>();
        collectibleImage.sprite = data.sprite;
        collectibleImage.transform.DOMove(collectibleEndPoint.position, 1.5f).OnComplete(() =>
        {
            ObjectPoolManager.Instance.ReturnObject(plant.gameObject, plant.poolType);
            Destroy(collectibleImage.gameObject);
            StorageManager.Instance.AddItem(plant.plantData.PlantType);
        });
    }

    private void OnPlacableButtonClick()
    {
        OpenPlacableCanvas();
        placableButton.gameObject.SetActive(false);
    }
}
