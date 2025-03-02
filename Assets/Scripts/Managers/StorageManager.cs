using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    public static StorageManager Instance;

    private Dictionary<PlantType, int> storedPlants = new Dictionary<PlantType, int>();

    public void AddItem(PlantType plantType)
    {
        if (!storedPlants.ContainsKey(plantType))
            storedPlants.Add(plantType, 1);

        storedPlants[plantType]++;
    }

    public void RemoveItem(PlantType plantType)
    {
        if (!storedPlants.ContainsKey(plantType)) return;

        storedPlants[plantType] = Mathf.Max(0, storedPlants[plantType]--);
    }
}
