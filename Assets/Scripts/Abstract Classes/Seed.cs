using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Seed : MonoBehaviour, IDraggable
{
    [SerializeField]
    protected PlantType plantType;

    [SerializeField]
    protected LayerMask layerMask;

    protected Transform parent;
    protected GridLayoutGroup layoutGroup;

    protected int index;
    private bool hasPassedUI;

    private void Awake()
    {
        parent = transform.parent;
        index = transform.GetSiblingIndex();
        layoutGroup = parent.GetComponent<GridLayoutGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        FarmField farmField = GetFarmField();

        if (farmField == null || farmField.IsOccupied) return;

        if (!EventSystem.current.IsPointerOverGameObject() && !hasPassedUI)
        {
            hasPassedUI = true;
            transform.parent = CanvasManager.Instance.canvas;
            CanvasManager.Instance.CloseSeedCanvas();
        }

        PlantSeed(farmField);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //to rearrange the layout group
        layoutGroup.enabled = false;
        layoutGroup.enabled = true;
        transform.parent = parent;
        transform.SetSiblingIndex(index);
    }

    private void PlantSeed(FarmField farmField)
    {
        PoolObjectType poolObjectType = (PoolObjectType)System.Enum.Parse(typeof(PoolObjectType), plantType.ToString());
        Plant plant = ObjectPoolManager.Instance.GetObject(poolObjectType).GetComponent<Plant>();
        plant.isReadyToHarvest = false;
        plant.transform.parent = farmField.transform;
        plant.transform.localPosition = Vector3.zero;
        plant.transform.localScale = Vector3.one;
        farmField.Plant = plant;
        farmField.IsOccupied = true;
    }

    public FarmField GetFarmField()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            hit.transform.TryGetComponent(out FarmField farmable);
            return farmable;
        }

        return null;
    } 
}
