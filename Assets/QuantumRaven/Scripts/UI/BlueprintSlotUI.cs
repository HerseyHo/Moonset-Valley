using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Diagnostics;

namespace MoonsetValley.Inventory
{
    public class BlueprintSlotUI : MonoBehaviour, IPointerClickHandler
    {
        [Header("组件获取")]

        [SerializeField] private Image BPicon;  //蓝图图标

        [SerializeField] public Image slotHightlight;   //选中高亮

        [SerializeField] private Button button;

        //物品信息
        public BlueprintDetails bpDetails;

        private BlueprintManager blueprintUI => GetComponentInParent<BlueprintManager>();

        private void Start()
        {
            
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            blueprintUI.ShowBlueprintDetails(gameObject.name);
            //UnityEngine.Debug.Log("当前对象名称: " + gameObject.name);
        }
    }
}