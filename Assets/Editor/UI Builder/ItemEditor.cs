using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections.Generic;
using System;
using System.Linq;


public class ItemEditor : EditorWindow
{
    private ItemDataList_SO dataBase;
    private List<ItemDetails> itemList = new List<ItemDetails>();
    private VisualTreeAsset itemRowTemplate;

    //�Ҳ࿨Ƭ����Ϣ
    private ScrollView itemDetailsSection;
    //��ǰѡ�е���Ʒ����Ϣ
    private ItemDetails activeItem;

    //����Ĭ�ϵ�icon
    private Sprite defaultIcon;

    private VisualElement iconPreview;

    //���VisualElement
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

        //�õ�ģ������
        itemRowTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/UI Builder/ItemRowTemplate.uxml");

        //��Ĭ�ϵ�IconͼƬ
        defaultIcon = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/QuantumRaven/Art/icon.jpg");

        //������ֵ
        itemListView = root.Q<VisualElement>("ItemList").Q<ListView>("ListView");
        itemDetailsSection = root.Q<ScrollView>("ItemDetails");
        iconPreview = itemDetailsSection.Q<VisualElement>("Icon");

        //��������
        LoadDataBase();

        //����ListView
        GenerateListView();
    }
    //�ڴ������֮ǰ�õ�����
    private void LoadDataBase()
    {
        var dataArray = AssetDatabase.FindAssets("ItemDataList_SO"); 

        if(dataArray.Length > 1)
        {
            var path = AssetDatabase.GUIDToAssetPath(dataArray[0]);
            dataBase = AssetDatabase.LoadAssetAtPath(path, typeof(ItemDataList_SO)) as ItemDataList_SO;
        }

        itemList = dataBase.itemDetailsList;

        //�����������޷���������
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

        itemListView.onSelectionChange += OnListSelectionChange;

        //�Ҳ���Ϣ��岻�ɼ�
        itemDetailsSection.visible = false;
    }

    private void OnListSelectionChange(IEnumerable<object> selectedItem)
    {
        activeItem = (ItemDetails)selectedItem.First();
        GetItemDetails();
        itemDetailsSection.visible = true;
    }

    private void GetItemDetails()
    {
        itemDetailsSection.MarkDirtyRepaint();

        //��ƷID
        itemDetailsSection.Q<TextField>("ItemID").value = activeItem.itemID;
        itemDetailsSection.Q<TextField>("ItemID").RegisterValueChangedCallback(evt =>
        {
            activeItem.itemID = evt.newValue;
            itemListView.Rebuild();
        });

        //��Ʒ����
        itemDetailsSection.Q<TextField>("ItemName").value = activeItem.itemName;
        itemDetailsSection.Q<TextField>("ItemName").RegisterValueChangedCallback(evt =>
        {
            activeItem.itemName = evt.newValue;
            itemListView.Rebuild();
        });

        //��Ʒlogo
        iconPreview.style.backgroundImage = activeItem.itemIcon == null ? defaultIcon.texture : activeItem.itemIcon.texture;
        itemDetailsSection.Q<ObjectField>("ItemIcon").value = activeItem.itemIcon;
        itemDetailsSection.Q<ObjectField>("ItemIcon").RegisterValueChangedCallback(evt =>
        {
            Sprite newIcon = evt.newValue as Sprite;
            activeItem.itemIcon = newIcon;
            iconPreview.style.backgroundImage = newIcon == null? defaultIcon.texture : newIcon.texture;
            itemListView.Rebuild();
        });

        //��Ʒ�ڵ�ͼ����ʾ��logo>ItemOnWorldSprite
        itemDetailsSection.Q<ObjectField>("ItemOnWorldSprite").value = activeItem.itemOnWorldSprite;
        itemDetailsSection.Q<ObjectField>("ItemOnWorldSprite").RegisterValueChangedCallback(evt =>
        {
            Sprite newIcon = evt.newValue as Sprite;
            activeItem.itemOnWorldSprite = newIcon;
            itemListView.Rebuild();
        });

        //��Ʒ����
        //itemDetailsSection.Q<DropdownField>("ItemType").value = activeItem.itemType;
        itemDetailsSection.Q<DropdownField>("ItemType").RegisterValueChangedCallback(evt =>
        {
            //activeItem.itemType = evt.newValue;
            itemListView.Rebuild();
        });

        //��Ʒ����
        itemDetailsSection.Q<TextField>("ItemDescription").value = activeItem.itemDescription;
        itemDetailsSection.Q<TextField>("ItemDescription").RegisterValueChangedCallback(evt =>
        {
            activeItem.itemDescription = evt.newValue;
            itemListView.Rebuild();
        });

        //��Ʒ��ʹ�÷�Χ
        itemDetailsSection.Q<IntegerField>("ItemUseRadius").value = activeItem.itemUseRadius;
        itemDetailsSection.Q<IntegerField>("ItemUseRadius").RegisterValueChangedCallback(evt =>
        {
            activeItem.itemUseRadius = evt.newValue;
            itemListView.Rebuild();
        });

        //�Ƿ��ʰȡ
        itemDetailsSection.Q<Toggle>("CanPickUp").value = activeItem.canPickedup;
        itemDetailsSection.Q<Toggle>("CanPickUp").RegisterValueChangedCallback(evt =>
        {
            activeItem.canPickedup = evt.newValue;
            itemListView.Rebuild();
        });

        //�Ƿ�ɶ���
        itemDetailsSection.Q<Toggle>("CanDropped").value = activeItem.canDropped;
        itemDetailsSection.Q<Toggle>("CanDropped").RegisterValueChangedCallback(evt =>
        {
            activeItem.canDropped = evt.newValue;
            itemListView.Rebuild();
        });

        //�Ƿ�ɾ���
        itemDetailsSection.Q<Toggle>("CanCarried").value = activeItem.canCarried;
        itemDetailsSection.Q<Toggle>("CanCarried").RegisterValueChangedCallback(evt =>
        {
            activeItem.canCarried = evt.newValue;
            itemListView.Rebuild();
        });

        //����
        itemDetailsSection.Q<IntegerField>("ItemPrice").value = activeItem.itemPrice;
        itemDetailsSection.Q<IntegerField>("ItemPrice").RegisterValueChangedCallback(evt =>
        {
            activeItem.itemPrice = evt.newValue;
            itemListView.Rebuild();
        });

        //��Ʒ��������
        itemDetailsSection.Q<Slider>("SellPercentage").value = activeItem.sellPercentage;
        itemDetailsSection.Q<Slider>("SellPercentage").RegisterValueChangedCallback(evt =>
        {
            activeItem.sellPercentage = evt.newValue;
            itemListView.Rebuild();
        });

        //�Ƿ��лָ�Ч��
        itemDetailsSection.Q<Toggle>("CanRecover").value = activeItem.canRecover;
        itemDetailsSection.Q<Toggle>("CanRecover").RegisterValueChangedCallback(evt =>
        {
            activeItem.canRecover = evt.newValue;
            itemListView.Rebuild();
        });

        //�ָ�����ֵ
        itemDetailsSection.Q<SliderInt>("HealthPoint").value = activeItem.healthPoint;
        itemDetailsSection.Q<SliderInt>("HealthPoint").RegisterValueChangedCallback(evt =>
        {
            activeItem.healthPoint = evt.newValue;
            itemListView.Rebuild();
        });

        //�ָ�����ֵ
        itemDetailsSection.Q<SliderInt>("HungerPoint").value = activeItem.hungerPoint;
        itemDetailsSection.Q<SliderInt>("HungerPoint").RegisterValueChangedCallback(evt =>
        {
            activeItem.hungerPoint = evt.newValue;
            itemListView.Rebuild();
        });
        
        //�ָ��ڿ�ֵ
        itemDetailsSection.Q<SliderInt>("ThirstPoint").value = activeItem.thirstPoint;
        itemDetailsSection.Q<SliderInt>("ThirstPoint").RegisterValueChangedCallback(evt =>
        {
            activeItem.thirstPoint = evt.newValue;
            itemListView.Rebuild();
        });

        //����ʱ��
        itemDetailsSection.Q<IntegerField>("FreshTime").value = activeItem.freshTime;
        itemDetailsSection.Q<IntegerField>("FreshTime").RegisterValueChangedCallback(evt =>
        {
            activeItem.freshTime = evt.newValue;
            itemListView.Rebuild();
        });

        //�Ƿ��и���Ч��
        itemDetailsSection.Q<Toggle>("SpecialPoint").value = activeItem.specialPoint;
        itemDetailsSection.Q<Toggle>("SpecialPoint").RegisterValueChangedCallback(evt =>
        {
            activeItem.specialPoint = evt.newValue;
            itemListView.Rebuild();
        });
    }
}