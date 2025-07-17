using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MoonsetValley.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [Header("拖拽图片")]
        public Image dragItem;

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
            if (Input.GetKeyDown(KeyCode.Q))
            {

            }
            if (Input.GetKeyDown(KeyCode.E))
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
        /// 控制菜单打开关闭，Button调用事件
        /// </summary>
        public void OpenBagUI()
        {
            bagOpened = !bagOpened;

            bagUI.SetActive(bagOpened);

            MenuSelect(currentPage);
        }

        /// <summary>
        /// 更新Slot高亮显示
        /// </summary>
        /// <param name="index">序号</param>
        public void UpdateSlotHightlight(int index)
        {
            Vector3 newScale = new Vector3(1.3f, 1.3f, 1.0f); // X, Y, Z轴的缩放值
            Vector3 oldScale = new Vector3(1.0f, 1.0f, 1.0f); // X, Y, Z轴的缩放值
            if (index > 8)//背包内的物品
            {
                for (var i = 9; i < playerSlots.Length; i++)
                {
                    if (playerSlots[i].isSelected && playerSlots[i].slotIndex == index)
                    {
                        playerSlots[i].slotHightlight.gameObject.SetActive(true);  //高亮
                    }
                    else
                    {
                        playerSlots[i].isSelected = false;
                        playerSlots[i].slotHightlight.gameObject.SetActive(false);  //取消高亮
                    }
                }
            }
            else //玩家身上的物品
            {
                for (var i = 0; i < 9; i++)
                {
                    if (playerSlots[i].isSelected && playerSlots[i].slotIndex == index)
                    {
                        playerSlots[i].slotHightlight.gameObject.transform.localScale = newScale;  //高亮
                    }
                    else
                    {
                        playerSlots[i].isSelected = false;
                        playerSlots[i].slotHightlight.gameObject.transform.localScale = oldScale;  //取消高亮
                    }
                }
            }
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

