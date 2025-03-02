using UnityEngine;

public interface IFarmable
{
    public bool IsOccupied { get; set; }
    public Plant Plant { get; set; }
}
