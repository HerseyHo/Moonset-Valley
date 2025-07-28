using UnityEngine;
[System.Serializable]

public class BlueprintDetails
{
    //蓝图的名称
    public string BPname;

    //蓝图的名称
    public string BPID;

    //蓝图图标
    public Sprite BPIcon;

    //蓝图的描述
    public string BPdesc;

    //蓝图的类型
    public BPtypes BPtype;

    //蓝图需要的物品ID及数量
    public bpItem[] itemList = {};


    //是否解锁
    public bool isUnlock;
}

[System.Serializable]
public struct bpItem
{
    public string itemID;

    public int itemNum;
}
