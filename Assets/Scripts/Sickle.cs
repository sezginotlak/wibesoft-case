using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sickle : MonoBehaviour, IDraggable
{
    [SerializeField]
    protected LayerMask layerMask;

    protected Transform parent;
    protected GridLayoutGroup layoutGroup;

    protected int index;
    protected FarmField currentFarmField;
    private bool hasPassedUI;

    private void Awake()
    {
        parent = transform.parent;
        index = transform.GetSiblingIndex();
        layoutGroup = parent.GetComponent<GridLayoutGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        currentFarmField = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        FarmField farmField = GetFarmField();

        if (currentFarmField == farmField) return;

        if (farmField == null || !farmField.IsOccupied) return;

        currentFarmField = farmField;

        if (!EventSystem.current.IsPointerOverGameObject() && !hasPassedUI)
        {
            hasPassedUI = true;
            transform.parent = CanvasManager.Instance.canvas;
            CanvasManager.Instance.CloseHarvestCanvas();
        }

        if (farmField.Plant.isReadyToHarvest)
        {
            farmField.Plant.Harvest();
            //farmField.Plant.isReadyToHarvest = false;
            CanvasManager.Instance.HandleCollectAnimation(farmField.Plant);
            farmField.Plant = null;
            farmField.IsOccupied = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //to rearrange the layout group
        layoutGroup.enabled = false;
        layoutGroup.enabled = true;
        transform.parent = parent;
        transform.SetSiblingIndex(index);
    }

    public FarmField GetFarmField()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            hit.transform.TryGetComponent(out FarmField farmable);
            return farmable;
        }

        return null;
    }
}
