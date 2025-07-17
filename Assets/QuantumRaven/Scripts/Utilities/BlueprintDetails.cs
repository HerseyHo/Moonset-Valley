using UnityEngine;
[System.Serializable]

public class BlueprintDetails
{
    //蓝图的名称
    public string BPname;

    //蓝图的描述
    public string BPdesc;

    //蓝图的类型
    public BPtypes BPtype;

    //蓝图需要的物品ID及数量
    public class BPitem
    {
        public int itemID { get; set; }
        public int itemNum { get; set; }
    }

    BPitem[] BPitems = new BPitem[1];  //该蓝图需要的物品对象数组
    

    //是否解锁
    public bool isUnlock;
}
