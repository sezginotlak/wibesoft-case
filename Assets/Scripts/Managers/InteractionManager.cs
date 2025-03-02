using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                HandleInteraction(hit);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
                CanvasManager.Instance.CloseAnyCanvas();
        }
    }

    private void HandleInteraction(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out FarmField farmfield))
        {
            
            if (!farmfield.IsOccupied)
                CanvasManager.Instance.OpenSeedCanvas();
            else
            {
                if(farmfield.Plant.isReadyToHarvest)
                    CanvasManager.Instance.OpenHarvestCanvas();
            }
        }
    }
}
