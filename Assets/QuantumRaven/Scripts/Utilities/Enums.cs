//物品类型
public enum ItemType
{
    Seed, Commodity, Furniture, Enviroment, Recover, HoeTool, ChopTool, BreakTool, ReapTool, WaterTool, CollectTool
}

//背包类型
public enum SlotType
{
    Bag, Box, Shop, ActionBar
}

public enum InventoryLocation
{
    Player = 0, Box = 1
}

//蓝图的类型
public enum BPtypes
{
    BasicSurvival, CommonTools, CookingAndUtensils, HuntTools, BuildingItems, MedicineAndProtection, AdvancedSupplies
}
public enum PartType
{
    None, Carry, Heo, Break
}

public enum PartName
{
    Body, Arm, Tool
}

public enum GridType
{
    Diggable, DropItem, PlaceFurniture, NPCObstacle
}

public enum ParticleEffectType
{
    LeavesFalling01, LeavesFalling02
}