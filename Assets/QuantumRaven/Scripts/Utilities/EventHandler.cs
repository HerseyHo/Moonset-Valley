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

    public static event Action<int> GameDayEvent;
    public static void CallGameDayEvent(int day)
    {
        GameDayEvent?.Invoke(day);
    }

    /// <summary>
    /// 更新时间——时针
    /// </summary>
    public static event Action<int, int, int, int> GameDateEvent;
    public static void CallGameDateEvent(int hour, int day, int month, int year)
    {
        GameDateEvent?.Invoke(hour, day, month, year);
    }

    //生成物品
    public static event Action<string, Vector3> InstantiateItemInScene;
    public static void CallInstantiateItemInScene(string ID, Vector3 pos)
    {
        InstantiateItemInScene?.Invoke(ID, pos);
    }

    //扔出物品
    public static event Action<string, Vector3, ItemType> DropItemEvent;
    public static void CallDropItemEvent(string ID, Vector3 pos, ItemType itemType)
    {
        DropItemEvent?.Invoke(ID, pos, itemType);
    }

    public static event Action<string, Vector3> TransitionEvent;
    public static void CallTransitionEvent(string sceneName, Vector3 pos)
    {
        TransitionEvent?.Invoke(sceneName, pos);
    }


    //加载场景之前要呼叫的事件
    public static event Action BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }


    //加载场景之后要呼叫的事件
    public static event Action AfterSceneLoadedEvent;
    public static void CallAfterSceneLoadedEvent()
    {
        AfterSceneLoadedEvent?.Invoke();
    }

    public static event Action<Vector3> MoveToPosition;
    public static void CallMoveToPosition(Vector3 targetPosition)
    {
        MoveToPosition?.Invoke(targetPosition);
    }

    public static event Action<ItemDetails, bool> ItemSelectedEvent;
    public static void CallItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
    {
        ItemSelectedEvent?.Invoke(itemDetails, isSelected);
    }

    public static event Action<Vector3, ItemDetails> MouseClickedEvent;
    public static void CallMouseClickedEvent(Vector3 pos, ItemDetails itemDetails)
    {
        MouseClickedEvent?.Invoke(pos, itemDetails);
    }

    public static event Action<Vector3, ItemDetails> ExecuteActionAfterAnimation;
    public static void CallExecuteActionAfterAnimation(Vector3 pos, ItemDetails itemDetails)
    {
        ExecuteActionAfterAnimation?.Invoke(pos, itemDetails);
    }

    public static event Action<string, TileDetails> PlantSeedEvent;
    public static void CallPlantSeedEvent(string ID, TileDetails tile)
    {
        PlantSeedEvent?.Invoke(ID, tile);
    }

    public static event Action<string> HarvestAtPlayerPosition;
    public static void CallHarvestAtPlayerPosition(string ID)
    {
        HarvestAtPlayerPosition?.Invoke(ID);
    }

    public static event Action RefreshCurrentMap;
    public static void CallRefreshCurrentMap()
    {
        RefreshCurrentMap?.Invoke();
    }

    public static event Action<ParticleEffectType, Vector3> ParticleEffectEvent;
    public static void CallParticleEffectEvent(ParticleEffectType effectType, Vector3 pos)
    {
        ParticleEffectEvent?.Invoke(effectType, pos);
    }

    public static event Action GenerateCropEvent;
    public static void CallGenerateCropEvent()
    {
        GenerateCropEvent?.Invoke();
    }
}
