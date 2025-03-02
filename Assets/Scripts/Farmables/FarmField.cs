using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class FarmField : MonoBehaviour, IFarmable
{
    [SerializeField]
    Plant currentPlant;

    [SerializeField]
    PoolObjectType poolObjectType;
    
    public bool isPlacable;

    public bool IsOccupied { get; set; }
    public Plant Plant { get => currentPlant; set => currentPlant = value; }

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
