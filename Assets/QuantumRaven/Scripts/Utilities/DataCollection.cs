
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
}