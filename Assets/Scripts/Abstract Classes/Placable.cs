using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Placable : MonoBehaviour, IDraggable
{
    [SerializeField]
    protected PlacableType placableType;

    protected bool hasPassedUI;
    protected GameObject spawnedPlacable;

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

        if (!EventSystem.current.IsPointerOverGameObject() && !hasPassedUI)
        {
            hasPassedUI = true;

            PoolObjectType poolObjectType = (PoolObjectType)System.Enum.Parse(typeof(PoolObjectType), placableType.ToString());
            spawnedPlacable = ObjectPoolManager.Instance.GetObject(poolObjectType);
            spawnedPlacable.transform.position = GetWorldPosition(Input.mousePosition);
            CanvasManager.Instance.ClosePlacableCanvas();
        }

        if (hasPassedUI && spawnedPlacable != null)
        {
            spawnedPlacable.transform.position = GetWorldPosition(Input.mousePosition);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //to rearrange the layout group
        GridLayoutGroup layoutGroup = transform.parent.GetComponent<GridLayoutGroup>();
        layoutGroup.enabled = false;
        layoutGroup.enabled = true;

        if (!hasPassedUI) return;

        if (spawnedPlacable.TryGetComponent(out Building building))
        {
            if (!building.isPlacable)
            {
                PoolObjectType poolObjectType = (PoolObjectType)System.Enum.Parse(typeof(PoolObjectType), placableType.ToString());
                ObjectPoolManager.Instance.ReturnObject(spawnedPlacable, poolObjectType);
            }
        }
        else if (spawnedPlacable.TryGetComponent(out FarmField farmField))
        {
            if (!farmField.isPlacable)
            {
                PoolObjectType poolObjectType = (PoolObjectType)System.Enum.Parse(typeof(PoolObjectType), placableType.ToString());
                ObjectPoolManager.Instance.ReturnObject(spawnedPlacable, poolObjectType);
            }
        }

        hasPassedUI = false;
        spawnedPlacable = null;
    }

    public virtual Vector3 GetWorldPosition(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }
        return Vector3.zero;
    }
}
