using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

namespace MoonsetValley.Inventory
{
    public class BlueprintManager : MonoBehaviour
    {
        [Header("蓝图数据")]
        [SerializeField] private BPlist_SO BPlist;

        [SerializeField] private GameObject BPitemPrefab; //蓝图预制体

        [Header("蓝图分类")]
        [SerializeField] private Transform BasicSurvival;      //基础生存类
        [SerializeField] private Transform CommonTools;    //常用工具
        [SerializeField] private Transform CookingAndUtensils;     //烹饪与器皿
        [SerializeField] private Transform MedicineAndProtection;      //医疗与防护
        [SerializeField] private Transform HuntTools;      //陷进与狩猎工具
        [SerializeField] private Transform BuildingItems;      //建筑类
        [SerializeField] private Transform AdvancedSupplies;       //高级/特殊物品


        private void Start()
        {
            // 生成预制体
            //GenerateBPItem();
            EventHandler.CallUpdateBlueprintUI(BPlist);
        }

        public void GenerateBPItem(BlueprintDetails BPitem)
        {
            GameObject newItem = BPitemPrefab;
            newItem.name = BPitem.BPID;     //重新命名
            Transform bpIcon = FindDeepChild(newItem.transform, "BP Icon");
            Image iconImage = bpIcon.GetComponent<Image>();
            iconImage.sprite = BPitem.BPIcon;
            switch (BPitem.BPtype)
            {
                case BPtypes.BasicSurvival:
                    GameObject newItem_D = Instantiate(newItem, BasicSurvival);
                    break;
                case BPtypes.CommonTools:
                    GameObject newItem_T = Instantiate(newItem, CommonTools);
                    break;
                case BPtypes.CookingAndUtensils:
                    GameObject newItem_C = Instantiate(newItem, CookingAndUtensils);
                    break;
                case BPtypes.HuntTools:
                    GameObject newItem_H = Instantiate(newItem, HuntTools);
                    break;
                case BPtypes.BuildingItems:
                    GameObject newItem_B = Instantiate(newItem, BuildingItems);
                    break;
                case BPtypes.MedicineAndProtection:
                    GameObject newItem_M = Instantiate(newItem, MedicineAndProtection);
                    break;
                case BPtypes.AdvancedSupplies:
                    GameObject newItem_S = Instantiate(newItem, AdvancedSupplies);
                    break;
                default:
                    break;
            }
        }

        // 深度查找子对象（递归方法）
        private Transform FindDeepChild(Transform parent, string childName)
        {
            // 先尝试直接查找
            Transform result = parent.Find(childName);
            if (result != null) return result;

            // 递归查找所有子对象
            foreach (Transform child in parent)
            {
                result = FindDeepChild(child, childName);
                if (result != null) return result;
            }

            return null;
        }

        public void OnEnable()
        {
            EventHandler.UpdateBlueprintUI += OnUpdateBlueprintUI;
        }

        public void OnDisable()
        {
            EventHandler.UpdateBlueprintUI -= OnUpdateBlueprintUI;
        }

        private void OnUpdateBlueprintUI(BPlist_SO list)
        {
            if (list != null)
            {
                foreach (BlueprintDetails item in list.bpList)
                {
                    GenerateBPItem(item);

                    Debug.Log($"物品: {item.BPname}, 数量: {item.BPtype}");
                }
            }
        }
    }
}


