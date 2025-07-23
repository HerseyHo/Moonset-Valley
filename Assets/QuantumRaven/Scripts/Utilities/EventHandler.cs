using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class EventHandler
{
    /// <summary>
    /// 渲染背包中的物品列表
    /// </summary>
    public static event Action<InventoryLocation, List<InventoryItem>> UpdateInventoryUI;

    public static void CallUpdateInventoryUI(InventoryLocation location, List<InventoryItem> list)
    {
        UpdateInventoryUI?.Invoke(location, list);
    }


    /// <summary>
    /// 更新蓝图UI
    /// </summary>
    public static event Action<BPlist_SO> UpdateBlueprintUI;
    public static void CallUpdateBlueprintUI(BPlist_SO bplist)
    {
        UpdateBlueprintUI?.Invoke(bplist);
    }

    /// <summary>
    /// 更新时间——分针
    /// </summary>
    public static event Action<int, int> GameMinuteEvent;
    public static void CallGameMinuteEvent(int minute, int hour)
    {
        GameMinuteEvent?.Invoke(minute, hour);
    }

    /// <summary>
    /// 更新时间——时针
    /// </summary>
    public static event Action<int, int, int, int> GameDateEvent;
    public static void CallGameDateEvent(int hour, int day, int month, int year)
    {
        GameDateEvent?.Invoke(hour, day, month, year);
    }

    public static event Action<string, Vector3> InstantiateItemInScene;

    public static void CallInstantiateItemInScene(string ID, Vector3 pos)
    {
        InstantiateItemInScene?.Invoke(ID, pos);
    }
}
