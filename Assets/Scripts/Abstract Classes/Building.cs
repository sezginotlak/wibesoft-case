using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public bool isPlacable;

    private void OnEnable()
    {
        isPlacable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ground"))
        {
            Debug.Log("Not Placable");
            isPlacable = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Ground") && isPlacable)
        {
            Debug.Log("Not Placable");
            isPlacable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ground"))
        {
            Debug.Log("Placable");
            isPlacable = true;
        }
    }
}
