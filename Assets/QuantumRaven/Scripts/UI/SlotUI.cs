using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

namespace MoonsetValley.Inventory
{
    public class SlotUI : MonoBehaviour, IPointerClickHandler
    {
        [Header("组件获取")]

        [SerializeField] private Image slotImage;

        [SerializeField] private TextMeshProUGUI amountText;

        [SerializeField] public Image slotHightlight;

        [SerializeField] private Button button;

        [Header("格子类型")]
        public SlotType slotType;

        public bool isSelected;

        public int slotIndex;

        //物品信息
        public ItemDetails itemDetails;

        public int itemAmount;

        private InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();

        private void Start()
        {
            isSelected = false;
            if (itemDetails.itemID == "")
            {
                UpdateEmptySlot();
            }
        }

        /// <summary>
        /// 更新格子UI和信息
        /// </summary>
        /// <param name="item">物品信息</param>
        /// <param name="amount">物品数量</param>
        public void UpdateSlot(ItemDetails item, int amount)
        {
            itemDetails = item;
            slotImage.sprite = item.itemIcon;
            itemAmount = amount;
            amountText.text = amount.ToString();
            slotImage.enabled = true;
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

            slotImage.enabled = false;
            amountText.text = string.Empty;
            button.interactable = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (itemAmount == 0) return;
            isSelected = !isSelected;  //是否被选中

            inventoryUI.UpdateSlotHightlight(slotIndex);
        }
    }

}
