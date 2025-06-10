using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections.Generic;
using System;


public class ItemEditor : EditorWindow
{
    private ItemDataList_SO dataBase;
    private List<ItemDetails> itemList = new List<ItemDetails>();
    private VisualTreeAsset itemRowTemplate;

    //获得VisualElement
    private ListView itemListView;

    [MenuItem("QuantuanRaven/ItemEditor")]
    public static void ShowExample()
    {
        ItemEditor wnd = GetWindow<ItemEditor>();
        wnd.titleContent = new GUIContent("ItemEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/UI Builder/ItemEditor.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        //拿到模板数据
        itemRowTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/UI Builder/ItemRowTemplate.uxml");

        //变量赋值
        itemListView = root.Q<VisualElement>("ItemList").Q<ListView>("ListView");

        //加载数据
        LoadDataBase();

        //生成ListView
        GenerateListView();
    }
    //在创建面板之前拿到数据
    private void LoadDataBase()
    {
        var dataArray = AssetDatabase.FindAssets("ItemDataList_SO"); 

        if(dataArray.Length > 1)
        {
            var path = AssetDatabase.GUIDToAssetPath(dataArray[0]);
            dataBase = AssetDatabase.LoadAssetAtPath(path, typeof(ItemDataList_SO)) as ItemDataList_SO;
        }

        itemList = dataBase.itemDetailsList;

        //如果不标记则无法保存数据
        EditorUtility.SetDirty(dataBase);
        //Debug.Log(itemList[0].itemID);
    }

    private void GenerateListView()
    {
        Func<VisualElement> makeItem = () => itemRowTemplate.CloneTree();

        Action<VisualElement, int> bindItem = (e, i) =>
        {
            if (i < itemList.Count)
            {
                if (itemList[i].itemIcon != null)
                    e.Q<VisualElement>("Icon").style.backgroundImage = itemList[i].itemIcon.texture;
                e.Q<Label>("Name").text = itemList[i] == null ? "NO ITEM" : itemList[i].itemName;
                e.Q<Label>("ID").text = itemList[i] == null ? "NO ITEM" : itemList[i].itemID;
            }
        };

        itemListView.fixedItemHeight = 80;
        itemListView.itemsSource = itemList;
        itemListView.makeItem = makeItem;
        itemListView.bindItem = bindItem;
    }
}