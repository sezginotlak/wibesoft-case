using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CollectibleSO", menuName = "Scriptable Objects/CollectibleSO")]
public class CollectibleSO : ScriptableObject
{
    public List<CollectibleData> collectibleDataList;
}

[Serializable]
public struct CollectibleData
{
    public PlantType plantType;
    public Sprite sprite;
}
