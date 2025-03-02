using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    public PlantSO plantData;

    public PoolObjectType poolType;

    [SerializeField]
    protected List<GameObject> phaseList;

    protected int growPhaseCount;
    protected int currentPhaseIndex;
    protected float growTime;
    public bool isReadyToHarvest;

    protected void OnEnable()
    {
        CalculateGrowPhaseCount();
        OnSeed();
    }

    private void Update()
    {
        Grow();
    }

    protected void OnSeed()
    {
        growTime = plantData.growTime;

        currentPhaseIndex = 0;

        phaseList[0].SetActive(true);

        for (int i = 1; i < phaseList.Count; i++)
        {
            GameObject phase = phaseList[i];
            phase.SetActive(false);
        }
    }

    protected void Grow()
    {
        if (isReadyToHarvest) return;

        growTime -= Time.deltaTime;

        ChangeVisual(CalculatePhaseIndex());

        if (growTime > 0) return;

        isReadyToHarvest = true;
        ChangeVisual(growPhaseCount - 1);
    }

    public void Harvest()
    {
        ChangeVisual(phaseList.Count - 1); //shows collectible plant
    }

    public void CalculateGrowPhaseCount()
    {
        growPhaseCount = phaseList.Count - 1;
    }

    protected void ChangeVisual(int newPhaseIndex)
    {
        if (currentPhaseIndex == newPhaseIndex) return;

        phaseList[currentPhaseIndex].SetActive(false);
        phaseList[newPhaseIndex].SetActive(true);

        currentPhaseIndex = newPhaseIndex;
    }

    private int CalculatePhaseIndex()
    {
        int newPhaseIndex = Mathf.FloorToInt((1 - (growTime / plantData.growTime)) * (growPhaseCount - 1));
        return newPhaseIndex;
    }
}
