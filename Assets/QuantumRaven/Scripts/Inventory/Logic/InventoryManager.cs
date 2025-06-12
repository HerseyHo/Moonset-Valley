using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonsetValley.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        [Header("��Ʒ����")]
        public ItemDataList_SO itemDataList_SO;

        [Header("��������")]
        public InventoryBag_SO playerBag;

        /// <summary>
        /// ͨ��ID������Ʒ��Ϣ
        /// </summary>
        /// <param name="ID">itemID</param>
        /// <returns></returns>
        public ItemDetails GetItemDetails(string ID)
        {
            return itemDataList_SO.itemDetailsList.Find(i => i.itemID == ID);
        }

        /// <summary>
        /// �����Ʒ��Player������
        /// </summary>
        /// <param name="item"></param>
        /// <param name="toDestory">�Ƿ�Ҫ������Ʒ</param>
        public void AddItem(Item item, bool toDestory)
        {
            //�Ƿ��Ѿ��и���Ʒ
            var index = GetItemIndexInBag(item.itemID);

            //�����Ƿ��п�λ
            if (!CheckBagCapacity())
                return;

            Debug.Log(GetItemDetails(item.itemID).itemID + "Name:" + GetItemDetails(item.itemID).itemName);
            if (toDestory)
            {
                Destroy(item.gameObject);
            }
        }
        /// <summary>
        /// ��鱳���Ƿ��п�λ
        /// </summary>
        /// <returns></returns>
        private bool CheckBagCapacity()
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                Debug.Log(playerBag.itemList[i].itemID);
                if (playerBag.itemList[i].itemID == "")
                    return true;
            }
            return false;
        }

        /// <summary>
        /// ͨ����ƷID�ҵ�����������Ʒλ��
        /// </summary>
        /// <param name="ID">��ƷID</param>
        /// <returns>-1��û�������Ʒ���򷵻����</returns>
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
        /// ��ָ���������λ�������Ʒ
        /// </summary>
        /// <param name="ID">��ƷID</param>
        /// <param name="index">���</param>
        /// <param name="amount">����</param>
        private void AddItemAtIndex(string ID, int index, int amount)
        {
            if (index == -1)   //����û�������Ʒ ͬʱ�����п�λ
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
            else   //�����������Ʒ
            {
                int currentAmount = playerBag.itemList[index].itemAmount + amount;
                var item = new InventoryItem { itemID= ID, itemAmount = currentAmount };

                playerBag.itemList[index] = item;
            }
        }
    }
}

