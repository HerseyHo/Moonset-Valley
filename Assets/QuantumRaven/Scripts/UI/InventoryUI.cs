using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MoonsetValley.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("玩家背包UI")]
        [SerializeField] private GameObject bagUI;
        private bool bagOpened;

        [Header("控制菜单切换")]
        [SerializeField] private GameObject[] MenuTabItem;

        public string currentPage;

        [SerializeField] private SlotUI[] playerSlots;

        private void OnEnable()
        {
            EventHandler.UpdateInventoryUI += OnUpdateInventoryUI;
        }

        private void OnDisable()
        {
            EventHandler.UpdateInventoryUI -= OnUpdateInventoryUI;
        }


        private void Start()
        {
            //给每个格子一个序号
            for (int i = 0; i < playerSlots.Length; i++)
            {
                playerSlots[i].slotIndex = i;
            }
            bagOpened = bagUI.activeInHierarchy;

        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                OpenBagUI();
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {

            }
            if( Input.GetKeyDown(KeyCode.E))
            {

            }
        }

        private void OnUpdateInventoryUI(InventoryLocation location, List<InventoryItem> list)
        {
            switch (location)
            {
                case InventoryLocation.Player:
                    for (int i = 0; i < playerSlots.Length; i++)
                    {
                        if (list[i].itemAmount > 0)
                        {
                            var item = InventoryManager.Instance.GetItemDetails(list[i].itemID);
                            playerSlots[i].UpdateSlot(item, list[i].itemAmount);
                        }
                        else
                        {
                            playerSlots[i].UpdateEmptySlot();
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// 控制菜单打开关闭
        /// </summary>
        public void OpenBagUI()
        {
            bagOpened = !bagOpened;

            bagUI.SetActive(bagOpened);

            MenuSelect(currentPage);
        }

        public void MenuSelect(string key)
        {
            currentPage = key;
            switch (key)
            {
                case "Information":
                    MenuTabItem[0].SetActive(true);
                    MenuTabItem[1].SetActive(false);
                    MenuTabItem[2].SetActive(false);
                    MenuTabItem[3].SetActive(false);
                    MenuTabItem[4].SetActive(false);
                    break;
                case "Mission":
                    MenuTabItem[0].SetActive(false);
                    MenuTabItem[1].SetActive(true);
                    MenuTabItem[2].SetActive(false);
                    MenuTabItem[3].SetActive(false);
                    MenuTabItem[4].SetActive(false);
                    break;
                case "Inventory":
                    MenuTabItem[0].SetActive(false);
                    MenuTabItem[1].SetActive(false);
                    MenuTabItem[2].SetActive(true);
                    MenuTabItem[3].SetActive(false);
                    MenuTabItem[4].SetActive(false);
                    break;
                case "BluePrint":
                    MenuTabItem[0].SetActive(false);
                    MenuTabItem[1].SetActive(false);
                    MenuTabItem[2].SetActive(false);
                    MenuTabItem[3].SetActive(true);
                    MenuTabItem[4].SetActive(false);
                    break;
                case "Settings":
                    MenuTabItem[0].SetActive(false);
                    MenuTabItem[1].SetActive(false);
                    MenuTabItem[2].SetActive(false);
                    MenuTabItem[3].SetActive(false);
                    MenuTabItem[4].SetActive(true);
                    break;
                default:
                    //Console.WriteLine("...");
                    break;
            }
        }
    }
}

