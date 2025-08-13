using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MoonsetValley.Inventory
{
    [RequireComponent(typeof(SlotUI))]
    public class ShowItemTooltip : MonoBehaviour, IPointerClickHandler
    {
        private SlotUI slotUI;

        private InventoryUI inventoryUI => GetComponentInParent<InventoryUI>();


        private void Awake()
        {
            slotUI = GetComponent<SlotUI>();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if(slotUI.itemDetails != null)
            {
                inventoryUI.itemTooltip.gameObject.SetActive(true);
                inventoryUI.itemTooltip.SetupTooltip(slotUI.itemDetails, slotUI.slotType);
            }
            else
            {
                inventoryUI.itemTooltip.gameObject.SetActive(false);
            }
        }
    }
}

