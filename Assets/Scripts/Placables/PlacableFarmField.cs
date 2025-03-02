using UnityEngine;
using UnityEngine.EventSystems;

public class PlacableFarmField : Placable
{
    public override Vector3 GetWorldPosition(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        if (plane.Raycast(ray, out float distance))
        {
            return SnapToGrid(ray.GetPoint(distance));
        }
        return Vector3.zero;
    }

    private Vector3 SnapToGrid(Vector3 worldPosition)
    {
        float x = Mathf.Round(worldPosition.x / 15) * 15;
        float y = worldPosition.y;
        float z = Mathf.Round(worldPosition.z / 15) * 15;
        return new Vector3(x, y, z);
    }
}
