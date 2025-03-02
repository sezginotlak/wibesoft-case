using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Vector3 topRightBorder;

    [SerializeField]
    Vector3 bottomLeftBorder;

    private float moveSpeed = 7.5f;
    private bool isOverUI;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            return;

        if (!Input.GetMouseButton(0)) return;

        Vector3 deltaMove = (-Input.mousePositionDelta * moveSpeed * Time.deltaTime);
        Vector3 moveAmount = new Vector3(deltaMove.x, 0f, deltaMove.y);
        transform.position += moveAmount;

        if (Input.GetMouseButtonUp(0))
            isOverUI = false;
    }
}
