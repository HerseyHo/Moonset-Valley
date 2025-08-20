
using System;
using UnityEngine;
[System.Serializable]
public class ItemDetails
{
    //物品的id,不同字母开头的代表不同的分类；
    public string itemID;

    //物品的名称
    public string itemName;

    //物品类型——枚举
    public ItemType itemType;

    //物品Icon
    public Sprite itemIcon;

    //物品在世界地图上的Icon
    public Sprite itemOnWorldSprite;

    //物品介绍
    public string itemDescription;

    //每单元格可叠加最大数量
    public int stackableCount;

    //物品的适用范围半径
    public int itemUseRadius;

    //是否可拾取
    public bool canPickedup;

    //是否可扔在地上
    public bool canDropped;

    //是否可以举起
    public bool canCarried;

    //物品价值
    public int itemPrice;

    //物品卖出时的折率
    [Range(0, 1)]
    public float sellPercentage;

    //有无恢复效果
    public bool canRecover;
    public int healthPoint; //生命值
    public int hungerPoint; //饥饿值
    public int thirstPoint; //口渴值
    //腐烂时间
    public int freshTime;

    //特殊效果
    public bool specialPoint;

}

[System.Serializable]
public struct InventoryItem
{
    public string itemID;

    public int itemAmount;

}


[System.Serializable]
public class SerializableVector3
{
    public float x, y, z;

    public SerializableVector3(Vector3 pos)
    {
        this.x = pos.x;
        this.y = pos.y;
        this.z = pos.z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }

    public Vector2Int ToVector2Int()
    {
        return new Vector2Int((int)x, (int)y);
    }
}

[System.Serializable]
public class SceneItem
{
    public string itemID;
    public SerializableVector3 position;
}

[System.Serializable]
public class AnimatorType
{
    public PartType partType;

    public PartName partName;

    public AnimatorOverrideController overrideController;
}

[System.Serializable]
public class TileProperty
{
    public Vector2Int tileCoordinate;

    public GridType gridType;

    public bool boolTypeValue;
}

[System.Serializable]
public class TileDetails
{
    public int gridX, gridY;

    public bool canDig;

    public bool canDropItem;

    public bool canPlaceFurniture;

    public bool isNPCObstacle;

    public int daysSinceDug = -1;

    public int daysSinceWatered = -1;

    public string seedItemID = "";

    public int growthDays = -1;

    public int daysSinceLastHarvest = -1;
}
