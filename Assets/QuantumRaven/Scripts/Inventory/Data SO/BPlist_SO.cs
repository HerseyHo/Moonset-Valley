using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BPlist_SO", menuName = "Inventory/BPlist_SO")]
public class BPlist_SO : ScriptableObject
{
    public List<BlueprintDetails> bpList;
}
