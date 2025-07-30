using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using TMPro;

namespace MoonsetValley.Inventory
{
    public class BlueprintManager : MonoBehaviour
    {
        [Header("蓝图数据")]
        [SerializeField] private BPlist_SO BPlist;
        public ItemDataList_SO itemDataList_SO;

        [SerializeField] private GameObject BPitemPrefab; //蓝图预制体
        [SerializeField] private GameObject MaterialPrefab; //蓝图所需材料预制体
        [SerializeField] private Transform MaterialHub; //渲染蓝图所需材料的容器

        [Header("蓝图分类")]
        [SerializeField] private Transform BasicSurvival;      //基础生存类
        [SerializeField] private Transform CommonTools;    //常用工具
        [SerializeField] private Transform CookingAndUtensils;     //烹饪与器皿
        [SerializeField] private Transform MedicineAndProtection;      //医疗与防护
        [SerializeField] private Transform HuntTools;      //陷进与狩猎工具
        [SerializeField] private Transform BuildingItems;      //建筑类
        [SerializeField] private Transform AdvancedSupplies;       //高级/特殊物品

        [Header("蓝图详情页")]
        [SerializeField] private GameObject BlueprintDetailsPage;
        [SerializeField] private TextMeshProUGUI BPname;
        [SerializeField] private TextMeshProUGUI BPdesc;

        private BlueprintDetails currentBP; //当前点击的BP


        private void Start()
        {
            // 生成预制体
            //GenerateBPItem();
            EventHandler.CallUpdateBlueprintUI(BPlist);
            BlueprintDetailsPage.SetActive(false);
        }


        public void ShowBlueprintDetails(String id)
        {
            for (int i= 0; i < BPlist.bpList.Count; i++)
            {
                if (BPlist.bpList[i].BPID == id)
                {
                    BlueprintDetailsPage.SetActive(true);
                    currentBP = BPlist.bpList[i];
                    BPname.text = BPlist.bpList[i].BPname;
                    BPdesc.text = BPlist.bpList[i].BPdesc;
                    foreach (var item in BPlist.bpList[i].itemList)
                    {
                        //渲染蓝图所需的材料
                    }
                }
            }
        }
        
        
        public void rendererMaterials()
        {

        }

        //根据物品ID查找物品信息
        public ItemDetails GetItemDetails(string ID)
        {
            return itemDataList_SO.itemDetailsList.Find(i => i.itemID == ID);
        }

        public void GenerateBPItem(BlueprintDetails BPitem)
        {
            GameObject newItem = BPitemPrefab;
            //newItem.name = BPitem.BPID;     //重新命名
            Transform bpIcon = FindDeepChild(newItem.transform, "BP Icon");
            Image iconImage = bpIcon.GetComponent<Image>();
            iconImage.sprite = BPitem.BPIcon;
            switch (BPitem.BPtype)
            {
                case BPtypes.BasicSurvival:
                    GameObject newItem_D = Instantiate(newItem, BasicSurvival);
                    newItem_D.name = BPitem.BPID;     //重新命名
                    break;
                case BPtypes.CommonTools:
                    GameObject newItem_T = Instantiate(newItem, CommonTools);
                    newItem_T.name = BPitem.BPID;     //重新命名
                    break;
                case BPtypes.CookingAndUtensils:
                    GameObject newItem_C = Instantiate(newItem, CookingAndUtensils);
                    newItem_C.name = BPitem.BPID;     //重新命名
                    break;
                case BPtypes.HuntTools:
                    GameObject newItem_H = Instantiate(newItem, HuntTools);
                    newItem_H.name = BPitem.BPID;     //重新命名
                    break;
                case BPtypes.BuildingItems:
                    GameObject newItem_B = Instantiate(newItem, BuildingItems);
                    newItem_B.name = BPitem.BPID;     //重新命名
                    break;
                case BPtypes.MedicineAndProtection:
                    GameObject newItem_M = Instantiate(newItem, MedicineAndProtection);
                    newItem_M.name = BPitem.BPID;     //重新命名
                    break;
                case BPtypes.AdvancedSupplies:
                    GameObject newItem_S = Instantiate(newItem, AdvancedSupplies);
                    newItem_S.name = BPitem.BPID;     //重新命名
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

                    //Debug.Log($"物品: {item.BPname}, 数量: {item.BPtype}");
                }
            }
        }
    }
}


