using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonsetValley.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        [Header("物品数据")]
        public ItemDataList_SO itemDataList_SO;

        [Header("背包数据")]
        public InventoryBag_SO playerBag;

        /// <summary>
        /// 通过ID返回物品信息
        /// </summary>
        /// <param name="ID">itemID</param>
        /// <returns></returns>
        public ItemDetails GetItemDetails(string ID)
        {
            return itemDataList_SO.itemDetailsList.Find(i => i.itemID == ID);
        }

        /// <summary>
        /// 添加物品到Player背包里
        /// </summary>
        /// <param name="item"></param>
        /// <param name="toDestory">是否要销毁物品</param>
        public void AddItem(Item item, bool toDestory)
        {
            //是否已经有该物品
            var index = GetItemIndexInBag(item.itemID);

            AddItemAtIndex(item.itemID, index, 1);

            Debug.Log(GetItemDetails(item.itemID).itemID + "Name:" + GetItemDetails(item.itemID).itemName);
            if (toDestory)
            {
                Destroy(item.gameObject);
            }
        }
        /// <summary>
        /// 检查背包是否有空位
        /// </summary>
        /// <returns></returns>
        private bool CheckBagCapacity()
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == "")
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 通过物品ID找到背包已有物品位置
        /// </summary>
        /// <param name="ID">物品ID</param>
        /// <returns>-1则没有这个物品否则返回序号</returns>
        private int GetItemIndexInBag(string ID)
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == ID)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 在指定背包序号位置添加物品
        /// </summary>
        /// <param name="ID">物品ID</param>
        /// <param name="index">序号</param>
        /// <param name="amount">数量</param>
        private void AddItemAtIndex(string ID, int index, int amount)
        {
            if (index == -1 && CheckBagCapacity())   //背包没有这个物品 同时背包有空位
            {
                var item = new InventoryItem { itemID = ID, itemAmount = amount };
                for (int i = 0; i < playerBag.itemList.Count; i++)
                {
                    if (playerBag.itemList[i].itemID == "" )
                    {
                        playerBag.itemList[i] = item;
                        break;
                    }
                }
            }
            else   //背包有这个物品
            {
                int currentAmount = playerBag.itemList[index].itemAmount + amount;
                var item = new InventoryItem { itemID= ID, itemAmount = currentAmount };

                playerBag.itemList[index] = item;
            }
        }
    }
}

