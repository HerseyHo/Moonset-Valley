using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

namespace MoonsetValley.Inventory
{
    public class BlueprintSlotUI : MonoBehaviour, IPointerClickHandler
    {
        [Header("组件获取")]

        [SerializeField] private Image BPicon;  //蓝图图标

        [SerializeField] public Image slotHightlight;   //选中高亮

        [SerializeField] private Button button;

        [Header("格子类型")]
        public BPtypes BPtype;  //蓝图分类

        public bool isSelected;  //是否选中

        public int slotIndex;

        //物品信息
        public BlueprintDetails bpDetails;

        private InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();

        private void Start()
        {
            isSelected = false;
            if (bpDetails.BPID == "")
            {
                // UpdateEmptySlot();
            }
        }

        /// <summary>
        /// 更新蓝图格子UI和信息
        /// </summary>
        /// <param name="item">蓝图</param>
        public void UpdateSlot(BlueprintDetails item)
        {
            bpDetails = item;
            BPicon.sprite = item.BPIcon;
            slotHightlight.enabled = true;
            button.interactable = true;
        }

        /// <summary>
        /// 将Slot更新为空
        /// </summary>
        public void UpdateEmptySlot()
        {
            if (isSelected)
            {
                isSelected = false;
            }

            slotHightlight.enabled = false;
            button.interactable = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            isSelected = !isSelected;  //是否被选中

            inventoryUI.UpdateSlotHightlight(slotIndex);
        }
    }
}