using UnityEngine;

[System.Serializable]
public class CropDetails
{
    public string seedItemID;

    [Header("不同阶段需要的天数")]
    public int[] growthDays;

    public int TotalGrowthDays
    {
        get
        {
            int amount = 0;
            foreach (var days in growthDays)
            {
                amount += days;
            }

            return amount;
        }
    }

    [Header("不同生长阶段物品的prefab")]
    public GameObject[] growthPrefabs;

    [Header("不同阶段的图片")]
    public Sprite[] growthSprites;

    [Space]
    [Header("收割工具")]
    public string[] harvestToolItemID;

    [Header("每种工具使用次数")]
    public int[] requireActionCount;

    [Header("转换新物品ID")]
    public string transformItemID;

    [Space]
    [Header("收割果实信息")]
    public string[] producedItemID;

    public int[] producedMinAmount;

    public int[] producedMaxAmount;

    public Vector2 spawnRadius;

    [Header("再次生长时间")]
    public int daysToRegrow;

    public int regrowTimes;

    [Header("Options")]
    public bool generateAtPlayerPosition;

    public bool hasAnimation;

    public bool hasParticalEffect;
    //TODO:特效、音效等
}
