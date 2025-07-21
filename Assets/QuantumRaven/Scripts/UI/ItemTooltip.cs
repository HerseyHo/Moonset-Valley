using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;  //物品名称

    [SerializeField] private TextMeshProUGUI descriptionText;   //物品详情

    [SerializeField] private Image icon;    //物品图标

    public void SetupTooltip(ItemDetails itemDetails, SlotType slotType)
    {
        //判断只有在背包内的物品才显示物品详情

        nameText.text = itemDetails.itemName;

        descriptionText.text = itemDetails.itemDescription;

        icon.sprite = itemDetails.itemIcon;
        //if(slotType == SlotType.Bag)
        //{
        //    bottomPart.SetActive(true);
        //}
    }
}
